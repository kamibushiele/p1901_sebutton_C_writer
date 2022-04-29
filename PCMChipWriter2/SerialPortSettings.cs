using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMChipWriter2
{
    internal class SerialPortSettings
    {
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public SerialPortSettings(int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            BaudRate = baudRate;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
        }
        public void Apply(SerialPort serialPort)
        {
            serialPort.BaudRate = BaudRate;
            serialPort.Parity = Parity;
            serialPort.DataBits = DataBits;
            serialPort.StopBits = StopBits;
        }
    }
}
