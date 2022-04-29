using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCMChipWriter2
{
    public partial class ItemEditForm : Form
    {
        MainForm.ItemEditParam item;
        public ItemEditForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            item.sound.Weight = (byte)numWeight.Value;
            Close();
        }

        private void ItemEdit_Load(object sender, EventArgs e)
        {
            item = ((MainForm)Owner).EditingItem;
            numWeight.Value = item.sound.Weight;
            Text = item.sound.Name;
        }
    }
}
