using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace PCMChipWriter2
{
    public class PCMSound
    {
        private static byte DEFAULT_WEIGHT = 1;
        public string Name
        {
            get;
            private set;
        }
        public byte Weight
        {
            get;
            set;
        }
        public byte[] ByteSound
        {
            private set;
            get;
        }

        public Int32 SoundSize
        {
            private set;
            get;
        }
        public string FilePath
        {
            private set;
            get;
        }
        public PCMSound(String filePath, WaveFormat format)
        {
            using (var rd = new AudioFileReader(filePath))
            using (var rs = new MediaFoundationResampler(rd, format))
            {
                double sampleRatio = (double)format.SampleRate / rd.WaveFormat.SampleRate;
                double bitRatio = (double)format.BitsPerSample / rd.WaveFormat.BitsPerSample;
                double chRatio = (double)format.Channels / rd.WaveFormat.Channels;
                SoundSize = (Int32)Math.Round(rd.Length * sampleRatio * bitRatio * chRatio);//MediaFoundationResamplerは長さを取得できない
                ByteSound = new byte[SoundSize];
                SoundSize = rs.Read(ByteSound, 0, SoundSize);
                Weight = DEFAULT_WEIGHT;
            }
            Name = Path.GetFileName(filePath);
            FilePath = filePath;
        }
    }
}
