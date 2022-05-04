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
    public partial class VersionForm : Form
    {
        public VersionForm()
        {
            InitializeComponent();
        }

        private void Version_Load(object sender, EventArgs e)
        {
            MaximumSize = Size;
            MinimumSize = Size;
            labelAppName.Text = Application.ProductName;
            labelVersion.Text = "Version : " + Application.ProductVersion;
        }
    }
}
