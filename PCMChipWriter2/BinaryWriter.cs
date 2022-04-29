using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace PCMChipWriter2
{
    internal class BinaryWriter
    {
        public enum State_e
        {
            Idol = 0,
            Start,
            SendPreamble,
            SendSize,
            SendBlock,
            SendFooter,
            Stop,
        }
        public enum Error
        {
            NoError,
            illegalData,
            illegalResponse,
            TimeOut,
            NoData,
            PortError,
            StateNotIdol,
        }
        private SerialPort serialPort;
        private Timer timeoutTimer;
        public int TimeOutMs { get; set; } = 3000;

        public State_e State {
            get;
            private set;
        }
        private int blockLen;
        private Byte[] blockBuffer;

        public delegate void _EndCallBackFunction(Error result);
        public event _EndCallBackFunction EndCallBackFunction;
        public delegate void _LogUpdate(string text);
        public event _LogUpdate LogUpdate;
        public delegate void _ProgressUpdate(double progress);
        public event _ProgressUpdate ProgressUpdate;
        private MemoryStream binary;
        public BinaryWriter(SerialPortSettings protocol, int blockLen)
        {
            this.blockLen = blockLen;
            serialPort = new SerialPort();
            protocol.Apply(serialPort);
            serialPort.DataReceived += DataReceived;
            timeoutTimer = new Timer(TimeOut, null, Timeout.Infinite, Timeout.Infinite);
            blockBuffer = new Byte[blockLen];
            State = State_e.Idol;
        }
        public void WriteStart(string portName, MemoryStream binary)
        {
            if (State !=  State_e.Idol)
            {
                LogUpdate("[ERROR]Writer state error.\r\n");
                WriteEnd(Error.StateNotIdol);
                return;
            }
            serialPort.PortName = portName;
            if (binary.Length == 0)
            {
                LogUpdate("[ERROR]Binary is empty.\r\n");
                WriteEnd(Error.NoData);
                return;
            }
            this.binary = binary;
            binary.Position = 0;
            State = State_e.SendPreamble;
            timeoutTimer.Change(TimeOutMs, Timeout.Infinite);
            ProgressUpdate(0);
            Write();
        }
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            char ackChar;
            int charint;
            if ((charint = serialPort.ReadChar()) == -1)
            {
                return;
            }
            serialPort.DiscardInBuffer();
            ackChar = (char)charint;
            switch (ackChar)
            {
                case 'K':
                    LogUpdate($"OK\r\n");
                    Write();
                    break;
                case 'E':
                    LogUpdate("[ERROR]Error recieved.\r\n");
                    WriteStop(Error.illegalData);
                    break;
                default:
                    LogUpdate($"[ERROR]Unknown ACK.(0x{(int)ackChar:X}:\"{ackChar}\")\r\n");
                    WriteStop(Error.illegalResponse);
                    break;
            }
        }
        private void Write()
        {
            int writelen;
            timeoutTimer.Change(TimeOutMs, Timeout.Infinite);
            switch (State)
            {
                case State_e.SendPreamble:
                    this.LogUpdate("Write start.\r\n");
                    try
                    {
                        serialPort.Open();
                    }
                    catch (Exception)
                    {
                        LogUpdate("[ERROR]PortOpen failed.\r\n");
                        WriteStop(Error.PortError);
                        break;
                    }
                    this.LogUpdate("Open port.\r\n");
                    LogUpdate("Send preamble...");
                    serialPort.Write("FLASH");
                    State = State_e.SendSize;
                    break;
                case State_e.SendSize:
                    Int32 size = (Int32)binary.Length;
                    LogUpdate($"Size0x{size:X}...");
                    byte[] sizeByte = BitConverter.GetBytes(size);
                    serialPort.Write(sizeByte,0,4);
                    State = State_e.SendBlock;
                    break;
                case State_e.SendBlock:
                    LogUpdate($"0x{binary.Position:X}/0x{binary.Length:X}...");
                    writelen = binary.Read(blockBuffer, 0, blockLen);
                    serialPort.Write(blockBuffer, 0, writelen);
                    ProgressUpdate((double)binary.Position / binary.Length);
                    if (binary.Length == binary.Position)
                    {
                        State = State_e.Stop;
                    }
                    break;
                case State_e.Stop:
                    WriteStop(Error.NoError);
                    break;
                case 0:
                    throw new Exception();
            }
        }
        private void TimeOut(object sender)
        {
            LogUpdate("[ERROR]Timed out.\r\n");
            WriteStop(Error.TimeOut);
        }
        private void WriteStop(Error res)
        {
            State = State_e.Idol;
            serialPort.Close();
            timeoutTimer.Change(Timeout.Infinite, Timeout.Infinite);
            WriteEnd(res);
        }
        private void WriteEnd(Error res)
        {
            //Windowsフォームのスレッドから直でEndCallBackFunctionするとInvokeRequiredがfalseなのにWindowsフォームが変更できない?
            new Thread(new ThreadStart(() =>
            {
                EndCallBackFunction(res);
            })).Start();
        }
        public class SerialportName
        {
            public string Name { get; set; }
            public string EasyName { get; set; }
            public SerialportName(string name, string easyName)
            {
                Name = name;
                EasyName = easyName;
            }
        }
        public static List<SerialportName> GetSerialPortList()
        {
            var serialPorts = new List<SerialportName>();
            string[] portNames = SerialPort.GetPortNames();
            foreach (string name in portNames)
            {
                serialPorts.Add(new SerialportName(name, ""));
            }
            ManagementClass pnPEntities = new ManagementClass("Win32_PnPEntity");
            foreach (ManagementObject entity in pnPEntities.GetInstances())
            {
                var caption = entity.GetPropertyValue("Caption");
                if (caption == null)
                {
                    continue;
                }
                string captionString = caption.ToString();
                Match portNum = Regex.Match(captionString, "COM[0-9]+");
                if (portNum.Success)
                {
                    foreach(SerialportName pn in serialPorts)
                    {
                        if(pn.Name == portNum.Value)
                        {
                            pn.EasyName = captionString;
                        }
                    }
                }
            }
            return serialPorts;
        }
    }
}
