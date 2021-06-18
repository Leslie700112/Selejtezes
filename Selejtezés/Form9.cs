using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Selejtezés
{
    public partial class Form9 : Form
    {
        public Int32 sorszam;
        private string selkat,selfaj;
        private double besz, ell, gyart, homok,mennyi;
        SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
         
        public Form9()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox1_MouseClick);
            this.textBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox1_MouseClick);
            this.textBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox1_MouseClick);
            this.textBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(textBox1_MouseClick);
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            
            
            this.selejtTableAdapter.Fill(this.dataSet1.Selejt, "9");
            selejtBindingSource.Filter = "Sorszam=" + sorszam ;
            label1.Text = dataGridView1.Rows[0].Cells["Cikkszam"].Value.ToString() +"  ¤  "+ dataGridView1.Rows[0].Cells["Description1"].Value.ToString()+
                 "  "+dataGridView1.Rows[0].Cells["Description2"].Value.ToString() +"  ¤  "+ dataGridView1.Rows[0].Cells["InternRem1"].Value.ToString();
            label3.Text = dataGridView1.Rows[0].Cells["Menny"].Value.ToString();
            label4.Text = dataGridView1.Rows[0].Cells["Meegys"].Value.ToString();
            selkat = dataGridView1.Rows[0].Cells["SelejtFajta"].Value.ToString();
            label10.Text = dataGridView1.Rows[0].Cells["Menny"].Value.ToString();
           if (dataGridView1.Rows[0].Cells["Description1"].Value.ToString().Substring(0,5)=="Quarz")
               textBox4.Visible=true;

            switch (selkat)
            {
                case "1":
                    textBox1.Text = dataGridView1.Rows[0].Cells["Menny"].Value.ToString();
                    break;
                case "3":
                    textBox2.Text = dataGridView1.Rows[0].Cells["Menny"].Value.ToString();
                    break;
                case "4":
                    textBox3.Text = dataGridView1.Rows[0].Cells["Menny"].Value.ToString();
                    break;
                case "5":
                    textBox4.Text = dataGridView1.Rows[0].Cells["Menny"].Value.ToString();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
          if (dataGridView1.Rows[0].Cells["Meegys"].Value.ToString().Trim() == "db")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                // only allow one decimal point 
                if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1 || (sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
          if ((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab )
            {
                Szamol();
                SendKeys.Send("{Tab}");
            }
        }
      
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Szamol();
        }
    
        private void Szamol()
        {
            if (String.IsNullOrEmpty(textBox1.Text))
                besz = 0;
            else
                besz = Convert.ToDouble(textBox1.Text);

            if (String.IsNullOrEmpty(textBox2.Text))
                ell = 0;
            else
                ell = Convert.ToDouble(textBox2.Text);

            if (String.IsNullOrEmpty(textBox3.Text))
                gyart = 0;
            else
                gyart = Convert.ToDouble(textBox3.Text);

            if (String.IsNullOrEmpty(textBox4.Text))
                homok = 0;
            else
                homok = Convert.ToDouble(textBox4.Text);

            label10.Text = (besz + ell + gyart + homok).ToString();
            return;
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            Szamol();
            if (Convert.ToDouble(label10.Text) <= 0)
                textBox1.Select();
            else
            {
                if (Convert.ToDouble(label3.Text) == Convert.ToDouble(label10.Text))
                    TorolBeir();
                else
                {
                    DialogResult dr = MessageBox.Show("A módosított mennyiség eltér a megadott mennyiségtől !!\r\n\r\nTovább ?",
                          "Mennyiség", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            TorolBeir();
                            break;
                        case DialogResult.No:
                            textBox1.Select();
                            break;
                    }
                }
            }
        }

        private void TorolBeir()
        {
          connection.Open();
          for (int i = 0; i < 4; i++)
            {
                if (besz > 0)
                {
                    mennyi = besz;
                    besz = 0;
                    selfaj = "1";
                    Beiro();
                }
                if (ell > 0)
                {
                    mennyi = ell;
                    ell = 0;
                    selfaj = "3";
                    Beiro();
                }
                if (gyart > 0)
                {
                    mennyi = gyart;
                    gyart = 0;
                    selfaj = "4";
                    Beiro();
                }
                if (homok > 0)
                {
                    mennyi = homok;
                    homok = 0;
                    selfaj = "5";
                    Beiro();
                }
           }
          string sqlCmdDel = "delete from Selejt where Sorszam=@Sorsz";
          SqlCommand mySqlCommand = new SqlCommand(sqlCmdDel, connection);
          mySqlCommand.Parameters.Add("@Sorsz", SqlDbType.Int);
          mySqlCommand.Parameters["@Sorsz"].Value = sorszam;
          mySqlCommand.ExecuteNonQuery(); 
          connection.Close();
          this.Close();
        }

        private void Beiro()
        {
            string sqlCmd = "INSERT INTO Selejt (MRendeles,Cikkszam,Menny,PortDolg,PortSelejtDatum,Port,Status,SelejtFajta) VALUES (@MRendeles, @StockCode,@Menny,@Dolgozo, @portsedatum,@Port,'9',@Selfaj)";
            SqlCommand mySqlCommand = new SqlCommand(sqlCmd, connection);
            mySqlCommand.Parameters.Add("@MRendeles", SqlDbType.Char);
            mySqlCommand.Parameters["@MRendeles"].Value = dataGridView1.Rows[0].Cells["MRendeles"].Value.ToString().Trim();
            mySqlCommand.Parameters.Add("@StockCode", SqlDbType.NVarChar);
            mySqlCommand.Parameters["@StockCode"].Value = dataGridView1.Rows[0].Cells["Cikkszam"].Value.ToString().Trim();
            mySqlCommand.Parameters.Add("@Menny", SqlDbType.Decimal);
            mySqlCommand.Parameters["@Menny"].Value = Convert.ToDecimal(mennyi.ToString().Replace(',', '.'));
            mySqlCommand.Parameters.Add("@Dolgozo", SqlDbType.NVarChar);
            mySqlCommand.Parameters["@Dolgozo"].Value = dataGridView1.Rows[0].Cells["PortDolg"].Value.ToString().Trim();
            mySqlCommand.Parameters.Add("@Port", SqlDbType.NChar);
            mySqlCommand.Parameters["@Port"].Value = dataGridView1.Rows[0].Cells["Port"].Value.ToString().Trim();
            mySqlCommand.Parameters.Add("@SelFaj", SqlDbType.NChar);
            mySqlCommand.Parameters["@SelFaj"].Value = selfaj.Trim();
            mySqlCommand.Parameters.Add("@portsedatum", SqlDbType.DateTime);
            mySqlCommand.Parameters["@portsedatum"].Value = Convert.ToDateTime(dataGridView1.Rows[0].Cells["PortSelejtDatum"].Value.ToString().Trim());
            mySqlCommand.ExecuteNonQuery();
        }


    
    
    }
}
