using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMChipWriter2
{
    internal class ChipDataGenWriter
    {
        public SoundBinary SoundBinary
        {
            get;
            private set;
        }
        public BinaryWriter Writer
        {
            get;
            private set;
        }
        public ChipDataGenWriter(
            int binSoundsMaxNum,    //音声の最大個数
            int binSoundMaxSize,    //音声単体の最大サイズ
            int binBinMaxSize,      //バイナリ全体の最大サイズ
            WaveFormat soundFormat,    //バイナリ内の音声フォーマット
            SerialPortSettings serialPortProtocol, //通信に使うSerial portのフォーマット
            int writerBlockSize    //ackまでの一度に送るバイト数
            )
        {
            SoundBinary = new SoundBinary_1(binSoundsMaxNum, binSoundMaxSize, binBinMaxSize, soundFormat);
            Writer = new BinaryWriter(serialPortProtocol, writerBlockSize);
        }
        public void WriteStart(string portName)
        {
            if(SoundBinary.Error == SoundBinary.SoundBinaryError.NoError)
            {
                Writer.WriteStart(portName, SoundBinary.Binary);
            }
        }
    }
}
