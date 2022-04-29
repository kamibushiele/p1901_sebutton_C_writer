using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using NAudio.Wave;

namespace PCMChipWriter2
{
    public partial class MainForm : Form
    {
        private List<BinaryWriter.SerialportName> portList;
        private ChipDataGenWriter chipWriter;
        private const string MODEL_NAME = "KE-SB01";
        private const int BIN_SONDS_MAX_NUM = 8;
        private const int BIN_SOND_MAX_SIZE = 0xffff;
        private const int BIN_MAX_SIZE = 0x7fff + 1;
        private const int WRITER_BLOCK_SIZE = 64;
        private const int WRITER_BAUD_RATE = 57600;
        private const Parity WRITER_PARITY = Parity.None;
        private const int WRITER_BITS = 8;
        private const StopBits WRITER_STOP_BITS = StopBits.One;
        private const int SOUND_SAMPLE_RATE = 8000;
        private const int SOUND_BIT_DEPTH = 8;
        private const int SOUND_CHANNEL = 1;

        public class ItemEditParam
        {
            public PCMSound sound;
        }
        public ItemEditParam EditingItem { get; private set; }
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
            EditingItem = new ItemEditParam();
            chipWriter = new ChipDataGenWriter(
                BIN_SONDS_MAX_NUM,
                BIN_SOND_MAX_SIZE,
                BIN_MAX_SIZE,
                new WaveFormat(SOUND_SAMPLE_RATE, SOUND_BIT_DEPTH, SOUND_CHANNEL),
                new SerialPortSettings(WRITER_BAUD_RATE, WRITER_PARITY, WRITER_BITS, WRITER_STOP_BITS),
                WRITER_BLOCK_SIZE
                );
            labelMaxTime.Text = $"{chipWriter.SoundBinary.MaxSoundTime():F2} s";
            labelMaxSingleTime.Text = $"{chipWriter.SoundBinary.MaxSingleSoundTime():F2} s";
            labelModelName.Text = MODEL_NAME;
            labelBitPerSample.Text = $"{SOUND_BIT_DEPTH} bit";
            labelSamapleRate.Text = $"{SOUND_SAMPLE_RATE} Hz";
            labelChannel.Text = $"{SOUND_CHANNEL} ch";

            chipWriter.Writer.LogUpdate += LogUpdate;
            chipWriter.Writer.ProgressUpdate += ProgressUpdate;
            chipWriter.Writer.EndCallBackFunction += EndCallBackFunction;
            BinUsageUpdate();
            ProgressUpdate(0);
            ReloadPorts();
        }
        private void BinUsageUpdate()
        {
            int binMax = chipWriter.SoundBinary.MaxBinSize;
            int binNow = chipWriter.SoundBinary.BinSize;
            int sndsMax = chipWriter.SoundBinary.MaxSoundsNumber;
            int sndsNow = chipWriter.SoundBinary.Sounds.Count;
            double paercent = binNow * 100.0 / binMax;
            eepromUsageText.Text = $"{binNow}/{binMax} ({paercent:F1}%)";
            labelSondsNum.Text = $"{sndsNow}/{sndsMax} sound(s).";
            if ((chipWriter.SoundBinary.Error&SoundBinary.SoundBinaryError.MaxBinSizeError)!=0)
            {
                paercent = 100;
            }
            if (chipWriter.SoundBinary.Error != SoundBinary.SoundBinaryError.NoError)
            {
                eepromUsage.ForeColor = Color.Red;
            }
            else
            {
                eepromUsage.ForeColor = Color.Green;
            }
            eepromUsage.Value = (int)Math.Round(paercent);
            FlashButtonUpadate();
        }
        private void FlashButtonUpadate()
        {
            if (
                chipWriter.SoundBinary.Error == SoundBinary.SoundBinaryError.NoError 
                && chipWriter.SoundBinary.Binary.Length > 0
                && listPorts.SelectedIndex >= 0)
            {
                buttonFlash.Enabled = true;
            }
            else
            {
                buttonFlash.Enabled = false;
            }
        }

        private void buttonFlash_Click(object sender, EventArgs e)
        {
            if (listPorts.SelectedIndex < 0)
            {
                //LogUpdate("Select SerialPort to flash.\r\n");
                return;
            }

            string portname = portList[listPorts.SelectedIndex].Name;
            chipWriter.WriteStart(portname);
            buttonFlash.Enabled= false;

        }
        private void ReloadPorts()
        {
            portList = BinaryWriter.GetSerialPortList();
            listPorts.Items.Clear();
            foreach (var i in portList)
            {
                listPorts.Items.Add(i.EasyName);
            }
            FlashButtonUpadate();
        }

        private void LogUpdate(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogUpdate), text);
                return;
            }
            textBoxLog.Text += text;

            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.Focus();
            textBoxLog.ScrollToCaret();
        }
        private void ProgressUpdate(double progress)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<double>(ProgressUpdate), progress);
                return;
            }
            progressBarFlash.Value = (int)Math.Round(progress*100);
            labelProgressFlash.Text = $"{(int)Math.Round(progress * 100)}%";
        }
        private void EndCallBackFunction(BinaryWriter.Error  result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<BinaryWriter.Error>(EndCallBackFunction), result);
                return;
            }
            if(result != BinaryWriter.Error.NoError)
            {
                LogUpdate("Flash Failed.\r\n");
            }
            else
            {
                LogUpdate("Flash Success.\r\n");
            }
            FlashButtonUpadate();
        }
        private void buttonReload_Click(object sender, EventArgs e)
        {
            ReloadPorts();
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = "";
        }

        private void audioFileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void UpdateAudioFileList()
        {
            audioFileList.Items.Clear();
            foreach (PCMSound snd in chipWriter.SoundBinary.Sounds)
            {
                string[] item = { snd.Name, $"{snd.SoundSize}", $"{snd.Weight}", snd.FilePath };
                audioFileList.Items.Add(new ListViewItem(item));
            }
        }
        private void AddSoundFile(string[] filePath)
        {
            foreach (string file in filePath)
            {
                chipWriter.SoundBinary.AddSound(file);
            }
            chipWriter.SoundBinary.Generate();
            BinUsageUpdate();
            UpdateAudioFileList();
        }
        private void audioFileList_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AddSoundFile(files);
        }

        private void audioFile_Edit()
        {
            if (audioFileList.SelectedItems.Count == 0)
            {
                return;
            }
            string path = audioFileList.SelectedItems[0].SubItems[3].Text;
            foreach (PCMSound snd in chipWriter.SoundBinary.Sounds)
            {
                if (snd.FilePath == path)
                {
                    EditingItem.sound = snd;
                    var form = new ItemEditForm();
                    Enabled = false;
                    form.ShowDialog(this);
                    chipWriter.SoundBinary.Generate();
                    BinUsageUpdate();
                    UpdateAudioFileList();
                    Enabled = true;
                    break;
                }
            }
        }
        private void audioFile_Delete()
        {
            if (audioFileList.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem item in audioFileList.SelectedItems)
            {
                string path = item.SubItems[3].Text;
                chipWriter.SoundBinary.RemoveSound(path);
                chipWriter.SoundBinary.Generate();
            }
            BinUsageUpdate();
            UpdateAudioFileList();
        }
        private void audioFileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            audioFile_Edit();
        }

        private void audioFileList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                audioFile_Delete();
            }
#if DEBUG
            if (e.KeyCode == Keys.S&& e.Control ) {
                if(saveFileDialogDump.ShowDialog() == DialogResult.OK)
                {
                    using (var filestream = new FileStream(saveFileDialogDump.FileName,FileMode.Create,FileAccess.Write))
                    {
                        var ms = chipWriter.SoundBinary.Binary;
                        var b = new Byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(b, 0, b.Length);
                        filestream.Write(b, 0, b.Length);
                    }
                }
            }
#endif
        }

        private void deleteSoundFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audioFile_Delete();
        }

        private void editSdoundFileEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            audioFile_Edit();
        }


        private void soundFileMenu_Opening(object sender, CancelEventArgs e)
        {
            foreach(ToolStripItem item in soundFileMenu.Items)
            {
                if((string)item.Tag == "del" || (string)item.Tag == "edit")
                {
                    item.Enabled = (audioFileList.SelectedItems.Count != 0);
                }
                    
            }
        }

        private void addSoundFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialogSounds.ShowDialog()== DialogResult.OK)
            {
                if(openFileDialogSounds.FileNames.Length != 0)
                {
                    AddSoundFile(openFileDialogSounds.FileNames);
                }
            }
            
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var versionDialog = new Version();
            versionDialog.ShowDialog();
        }

        private void listPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlashButtonUpadate();
        }
    }
}
