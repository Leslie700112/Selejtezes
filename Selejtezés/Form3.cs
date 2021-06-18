using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Selejtezés
{
    public partial class Form3 : Form
    {
        private static string jog,jelsz,pecset;
        public static string Jog
        {
            get
            {
                return jog;
            }
        }
        public static string Pecset
        {
            get
            {
                return pecset;
            }
        }
        public Form3()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataSet1.EnforceConstraints = false;
            this.jogokTableAdapter.Fill(this.dataSet1.Jogok);
            textBox1.Select();

        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab)
            {
                string felhaszn = textBox1.Text.Trim();
                int itemFound = jogokBindingSource.Find("Jogosult", felhaszn);
                if (itemFound < 0)
                {
                    MessageBox.Show("NINCS ILYEN FELSZNÁLÓ !");
                    textBox1.Clear();
                    textBox1.Select();
                }
                else
                {
                    DataTable joguDataTable = dataSet1.Tables["Jogok"];
                    joguDataTable.PrimaryKey = new DataColumn[] { joguDataTable.Columns["Jogosult"] };
                    DataRow jogi = joguDataTable.Rows.Find(felhaszn);
                    foreach (DataColumn myDataColumn in joguDataTable.Columns)
                    {
                        jog = jogi["Jog"].ToString().Trim();
                        jelsz = jogi["Jelszo"].ToString().Trim();
                        pecset = jogi["Pecset"].ToString().Trim();
                    }
                    textBox2.Select();
                }
            }
        }
       
        private void textBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab)
            {
               if (textBox2.Text.Trim() == jelsz.Trim())
                    this.Close();
                else
                {
                    MessageBox.Show("NEM MEGFELELŐ JELSZÓ !");
                    textBox2.Clear();
                    textBox2.Select();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    
    
    }
}
