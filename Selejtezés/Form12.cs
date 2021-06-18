using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Selejtezés
{
    public partial class Form12 : Form
    {
     private int fsz;
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Dolgozok várj egy kicsit!!  ";
        }
        private void Form12_Shown(object sender, EventArgs e)
        {
            do
            {
                this.Close();
            }
            while (Directory.GetFiles(@"\\scala1\inputxml\", "SE*.xml", SearchOption.TopDirectoryOnly).Count() > 0);
        }
    }
}
