using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using System.IO;
using System.IO.Ports;
using NAudio.Wave;

namespace PCMChipWriter2
{
    public abstract class SoundBinary
    {
        public MemoryStream Binary { get; protected set; }
        public List<PCMSound> Sounds { get; protected set; }
        public int MaxSoundsNumber { get; protected set; }//音声の最大個数
        public int MaxSoundSize { get; protected set; }//音声単体の最大サイズ
        public int MaxBinSize { get; protected set; }//バイナリ全体の最大サイズ
        public WaveFormat SoundFormat { get; protected set; }
        public int BinSize
        {
            get
            {
                return (int)Binary.Length;
            }
        }
        public SoundBinaryError Error { get; protected set; }
        public enum SoundBinaryError
        {
            NoError = 0,
            MaxSondsNumError = 1<<0,
            MaxSoundSizeError = 1<<1,
            MaxBinSizeError = 1<<2,
        }
        public SoundBinary(
            int maxSoundsNumber,
            int maxSoundSize,
            int maxBinSize,
            WaveFormat soundFormat
            )
        {
            Sounds = new List<PCMSound>();
            Binary = new MemoryStream();
            MaxSoundsNumber = maxSoundsNumber;
            MaxSoundSize = maxSoundSize;
            MaxBinSize = maxBinSize;
            SoundFormat = soundFormat;
            Error = SoundBinaryError.NoError;
        }
        public abstract double MaxSoundTime();
        public abstract double MaxSingleSoundTime();

        public abstract void Generate(); // Binaryを更新
        public void AddSound(string path)
        {
            foreach(PCMSound snd in Sounds)
            {
                if(snd.FilePath == path)//同じファイルがあったら
                {
                    return;
                }
                
            }
            Sounds.Add(new PCMSound(path, SoundFormat));
        }
        public void RemoveSound(string path)
        {
            for(int i= Sounds.Count-1; i >= 0; i--)//foreachだとエラー, forのデクリメントだと取りこぼしなし
            {
                if(Sounds[i].FilePath == path)
                {
                    Sounds.RemoveAt(i);
                }
            }
        }
        public void ClearSound()
        {
            Sounds.Clear();
        }
    }
}
