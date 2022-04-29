using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio.Wave;

namespace PCMChipWriter2
{
    internal class SoundBinary_1 : SoundBinary
    {
        private static int FIX_BLOCK_HEADER_TEXT = 3;
        private static int FIX_BLOCK_HEADER_SOUNDS_NUM = 1;
        private static int FIX_BLOCK_INFO_SOUND_SIZE = 2;
        private static int FIX_BLOCK_INFO_SOUND_WEIGHT = 1;
        public SoundBinary_1(int maxSoundsNumber, int maxSoundSize, int maxBinSize, WaveFormat soundFormat) : 
            base(maxSoundsNumber, maxSoundSize, maxBinSize, soundFormat)
        {
        }

        public override void Generate()
        {
            Error = SoundBinaryError.NoError;
            int soundNum = Sounds.Count;
            if (soundNum < 0 || soundNum > MaxSoundsNumber)
            {
                soundNum = MaxSoundsNumber;
                Error |= SoundBinaryError.MaxSondsNumError;
            }
            Binary.SetLength(0);
            if (soundNum == 0)
            {
                Error |= SoundBinaryError.NoError;
                return;
            }
            Binary.Write(Encoding.UTF8.GetBytes("PCM"), 0, 3);
            Binary.WriteByte((byte)soundNum);
            foreach(PCMSound sound in Sounds)
            {
                int soundSize = sound.SoundSize;
                if(soundSize > MaxSoundSize)
                {
                    soundSize = MaxSoundSize;
                    Error |= SoundBinaryError.MaxSoundSizeError;
                }
                Binary.WriteByte((byte)(soundSize & 0xff));
                Binary.WriteByte((byte)((soundSize >> 8) & 0xff));
                Binary.WriteByte(sound.Weight);
            }
            foreach (PCMSound sound in Sounds)
            {
                Binary.Write(sound.ByteSound, 0,sound.SoundSize);
            }
            if (BinSize > MaxBinSize)
            {
                Error |= SoundBinaryError.MaxBinSizeError;
            }
        }
        public override double MaxSoundTime()
        {//最大の場合(soundは1つのみ)
            return (double)
                (
                    MaxBinSize - (
                        FIX_BLOCK_HEADER_TEXT 
                        + FIX_BLOCK_HEADER_SOUNDS_NUM 
                        + FIX_BLOCK_INFO_SOUND_SIZE 
                        + FIX_BLOCK_INFO_SOUND_WEIGHT
                    )
                )/(
                    SoundFormat.BlockAlign * SoundFormat.SampleRate * SoundFormat.Channels
                );
        }
        public override double MaxSingleSoundTime()
        {
            return (double)(MaxSoundSize) / (SoundFormat.BlockAlign * SoundFormat.SampleRate * SoundFormat.Channels);
        }
    }
}
