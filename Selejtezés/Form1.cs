using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Selejtezés
{
    public partial class Form1 : Form
    {
        public string pecset;
        private string jog;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            // TODO: This line of code loads data into the 'dataSet1.Jogok' table. You can move, or remove it, as needed.
            this.jogokTableAdapter.Fill(this.dataSet1.Jogok);
            dataSet1.EnforceConstraints =false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
            Jogosult();
            Kezdo();
        }
        
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closeMdis()
        {
            foreach (Form c in this.MdiChildren)
                c.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           if (jog == "S" || jog == "A")
            {
                toolStripLabel1.Visible = false;
                Frissítés.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Visible = false;
                closeMdis();
                Form2 childForm = new Form2();
                childForm.pecset = pecset;
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
                MessageBox.Show("ACCESZ DINÁJDID !");
        }
        private void Jogosult()
        {
            System.Security.Principal.WindowsIdentity currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
            string felhaszn = Environment.UserName;
            int itemFound = jogokBindingSource.Find("Jogosult", felhaszn);
            if (itemFound < 0)
            {
                Form3 Beablak = new Form3();
                Beablak.ShowDialog();
                jog = Form3.Jog;
                pecset = Form3.Pecset;
            }
            else
            {
                    jog = dataSet1.Tables["Jogok"].Rows[itemFound]["Jog"].ToString().Trim();
                    pecset = dataSet1.Tables["Jogok"].Rows[itemFound]["Pecset"].ToString().Trim();
                }
      
              //  DataTable joguDataTable = dataSet1.Tables["Jogok"];
               // joguDataTable.PrimaryKey = new DataColumn[] { joguDataTable.Columns["Jogosult"] };
              //  DataRow jogi = joguDataTable.Rows.Find(felhaszn);
              //  foreach (DataColumn myDataColumn in joguDataTable.Columns)
              //  {
              //      jog = jogi["Jog"].ToString().Trim();
              //      pecset = jogi["Pecset"].ToString().Trim();
              //  }
           // }
        }

        private void Selejt_Click(object sender, EventArgs e)
        {
            Kezdo();
        }
        private void Kezdo()
        {
            dataGridView1.Visible = true;
            // TODO: This line of code loads data into the 'dataSet1.Selejt' table. You can move, or remove it, as needed.
            this.selejtTableAdapter.Fill(this.dataSet1.Selejt,"0");
            toolStripLabel1.Visible = true;
            Frissítés.Visible = true;
            textBox1.Visible = true;
            textBox1.Clear();
            textBox1.Select();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          if (jog == "S" || jog == "A")
            {
                toolStripLabel1.Visible = false;
                Frissítés.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Visible = false;
                closeMdis();
                Form4 childForm = new Form4();
                childForm.pecset = pecset;
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
                MessageBox.Show("ACCESZ DINÁJDID !");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              string wkeres = " ";

            string seekValue = this.textBox1.Text;
            if (seekValue != wkeres)
            {
                if (!string.IsNullOrEmpty(seekValue))
                {
                 selejtBindingSource.Filter = "Kereso like '%" + seekValue + "%'";
                }
                else
                {
                    try
                    {
                    selejtBindingSource.Filter = "";
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                wkeres = seekValue;
            }
        }

        private void Frissítés_Click(object sender, EventArgs e)
        {
            dataSet1.Selejt.Clear();
            this.selejtTableAdapter.Fill(this.dataSet1.Selejt,"0");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (jog == "S" || jog == "A")
            {
                toolStripLabel1.Visible = false;
                Frissítés.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Visible = false;
                closeMdis();
                Form5 childForm = new Form5();
                childForm.pecset = pecset;
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
                MessageBox.Show("ACCESZ DINÁJDID !");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (jog == "S" || jog == "A")
            {
                toolStripLabel1.Visible = false;
                Frissítés.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Visible = false;
                closeMdis();
                Form6 childForm = new Form6();
                childForm.pecset = pecset;
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
                MessageBox.Show("ACCESZ DINÁJDID !");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (jog == "S" || jog == "A")
            {
                toolStripLabel1.Visible = false;
                Frissítés.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Visible = false;
                closeMdis();
                Form7 childForm = new Form7();
                childForm.pecset = pecset;
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
                MessageBox.Show("ACCESZ DINÁJDID !");
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (jog == "S" || jog == "A")
            {
                toolStripLabel1.Visible = false;
                Frissítés.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Visible = false;
                closeMdis();
                Form8 childForm = new Form8();
                childForm.pecset = pecset;
                childForm.MdiParent = this;
                childForm.Show();
            }
            else
                MessageBox.Show("ACCESZ DINÁJDID !");
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (jog == "S" || jog == "A")
            {
                toolStripLabel1.Visible = false;
                Frissítés.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Visible = false;
                closeMdis();
                Form10 childForm = new Form10();
                childForm.pecset = pecset;
                childForm.MdiParent = this;
                childForm.Show();
             }
            else
                MessageBox.Show("ACCESZ DINÁJDID !");
        }
       
       
    
    
    }
}
