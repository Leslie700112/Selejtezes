using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;

namespace Selejtezés
{
    public partial class Form4 : Form
    {
        public string pecset;
        private string v_cikk, Mertegys, mitcsi;
        private double keszlet;

        public Form4()
        {
            InitializeComponent();
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            this.dataGridView1.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox3_KeyPress);
            comboBox1.KeyPress += new KeyPressEventHandler(comboBox1_KeyPress);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.VF_SC360300_StockBinNo' table. You can move, or remove it, as needed.
            this.vF_SC360300_StockBinNoTableAdapter.Fill(this.dataSet1.VF_SC360300_StockBinNo);
            // TODO: This line of code loads data into the 'dataSet1.VF_SY240300_Cells' table. You can move, or remove it, as needed.
            this.vF_SY240300_CellsTableAdapter.Fill(this.dataSet1.VF_SY240300_Cells);
            mitcsi = "SE";
            // TODO: This line of code loads data into the 'dataSet1.VF_SC010300_Stock_Scrap' table. You can move, or remove it, as needed.
            this.vF_SC010300_Stock_ScrapTableAdapter.Fill(this.dataSet1.VF_SC010300_Stock_Scrap, mitcsi);
            label8.Text = "";
            label4.Text = "";
            label5.Text = "";
            textBox1.Select();
           // comboBox1.SelectedIndex = 30;
            dataSet1.EnforceConstraints = false;
            comboBox1.SelectedValue = "STD01";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string wkeres = " ";

            string seekValue = this.textBox1.Text;
            if (seekValue != wkeres)
            {
                if (!string.IsNullOrEmpty(seekValue))
                {
                    vFSC010300StockScrapBindingSource.Filter = "Kereso like '%" + seekValue + "%'";
                }
                else
                {
                    try
                    {
                        vFSC010300StockScrapBindingSource.Filter = "";
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                wkeres = seekValue;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            alapinformaciok();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                alapinformaciok();
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Rows[e.RowIndex].Cells["StockCode"].Value.ToString() == textBox2.Text)
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            else
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        private void alapinformaciok()
        {
            label4.Text = "";
            label5.Text = "";
            v_cikk = dataGridView1.CurrentRow.Cells["StockCode"].Value.ToString();
            textBox2.Text = v_cikk;
            label4.Text = dataGridView1.CurrentRow.Cells["Description1"].Value.ToString() + " ¤ " + dataGridView1.CurrentRow.Cells["Description2"].Value.ToString()
                + " ¤ " + dataGridView1.CurrentRow.Cells["InternRem1"].Value.ToString();
            Mertegys = dataGridView1.CurrentRow.Cells["UnitStock"].Value.ToString().Trim();
            label5.Text = Mertegys;
            keszlet = Convert.ToDouble(dataGridView1.CurrentRow.Cells["StockBalance"].Value);
            textBox3.Text = dataGridView1.CurrentRow.Cells["StockBalance"].Value.ToString();
            textBox3.Select();
            

        }
        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void textBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            label8.Text = "";
            if (((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab) && textBox2.Text != "")
            {
                int StockFound = vFSC010300StockScrapBindingSource.Find("StockCode", textBox2.Text.Trim());
                if (StockFound < 0)
                {
                    label8.Text = "NINCS ILYEN CIKKSZÁM VAGY A SELEJT RAKTÁRBAN NINCS KÉSZLET !";
                    textBox2.Clear();
                }
                else
                {
                    v_cikk = dataGridView1.CurrentRow.Cells["StockCode"].Value.ToString();
                    dataGridView1.CurrentCell = dataGridView1.Rows[StockFound].Cells["StockCode"];
                    label4.Text = dataGridView1.CurrentRow.Cells["Description1"].Value.ToString() + " ¤ " + dataGridView1.CurrentRow.Cells["Description2"].Value.ToString()
                        + " ¤ " + dataGridView1.CurrentRow.Cells["InternRem1"].Value.ToString();
                    Mertegys = dataGridView1.CurrentRow.Cells["UnitStock"].Value.ToString().Trim();
                    label5.Text = Mertegys;
                    keszlet = Convert.ToDouble(dataGridView1.CurrentRow.Cells["StockBalance"].Value);
                    textBox3.Text = dataGridView1.CurrentRow.Cells["StockBalance"].Value.ToString();
                    textBox3.Select();
                }
            }
        }

        private void textBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            label8.Text = "";
            if (Mertegys == "db")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
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
            if ((int)e.KeyChar == (int)Keys.Enter && textBox3.Text != "")
            {
                if (textBox3.Text == "0")
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox1.Select();
                }
                else
                {
                    if (Convert.ToDouble(textBox3.Text) > keszlet)
                    {
                        label8.Text = "A TERMELÉSBEN NINCS ELÉG KÉSZLET !";
                        textBox3.Clear();
                        textBox3.Select();

                    }
                    else
                        comboBox1.Select();
                  
                }
            }

        }

        private void Selejtez()
        {
            SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
            connection.Open();
            SqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandText = " update Selejt set VisszMenny=Menny where Cikkszam=@Sorszam ";
            mySqlCommand.Parameters.Clear();
            mySqlCommand.Parameters.Add("@Sorszam", SqlDbType.NVarChar);
            mySqlCommand.Parameters["@Sorszam"].Value = textBox2.Text.Trim();
            mySqlCommand.ExecuteNonQuery();
            connection.Close();
            
            string datum = DateTime.Now.ToString("yyyy-MM-dd");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<msg:Msg xsi:schemaLocation='http://Epicor.com/Message/2.0 http://scshost/schemas/epicor/ScalaMessage.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:msg='http://Epicor.com/Message/2.0'>" +
     "<msg:Hdr>" +
     "<msg:Sender>" +
     "<msg:Name>03</msg:Name>" +
     "<msg:Subname>{0}</msg:Subname>" +
     "</msg:Sender>" +
     "</msg:Hdr>" +
     "<msg:Body>" +
     "<msg:Req msg-type='Stock Transaction' action='Process'>" +
     "<msg:Dta>" +
     "<dta:StockTransaction xsi:schemaLocation='http://www.scala.net/StockTransaction/1.1 http://scshost/schemas/Scala/1.1/StockTransaction.xsd' xmlns:msg='http://Epicor.com/InternalMessage/1.1' xmlns:dta='http://www.scala.net/StockTransaction/1.1'>" +
     "<dta:Movement>" +
     "<dta:TransDate>" + datum + "</dta:TransDate>" +
     "<dta:Qty>" +keszlet + "</dta:Qty>" +
     "<dta:StockCode>" + textBox2.Text.Trim() + "</dta:StockCode>" +
     "<dta:WhCodeFrom>SE</dta:WhCodeFrom>" +
     "<dta:BinCodeFrom>STDSE</dta:BinCodeFrom>" +
     "<dta:WhCodeTo>01</dta:WhCodeTo>" +
     "<dta:BinCodeTo>" +comboBox1.Text.Trim().ToUpper()+"</dta:BinCodeTo>" +
      "<dta:Ref>SE_VI</dta:Ref>" +
                //"<dta:OrdNum>" + MRend.Trim() + "</dta:OrdNum>" +
     "<dta:Note>TM</dta:Note>" +
        "</dta:Movement>" +
        "</dta:StockTransaction>" +
        "</msg:Dta>" +
        "</msg:Req>" +
     "</msg:Body>" +
     "</msg:Msg>");
            // Save the document to a file.
            string f_nev = "SEv" + textBox2.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
          // doc.Save(f_nev);
            doc.Save(@"\\10.0.0.11\inputxml\" + f_nev);
            Thread.Sleep(2000);
            Form12 form12 = new Form12();
            form12.ShowDialog();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label4.Text = "";
            dataSet1.VF_SC010300_Stock_Scrap.Clear();
            this.vF_SC010300_Stock_ScrapTableAdapter.Fill(this.dataSet1.VF_SC010300_Stock_Scrap, mitcsi);
            textBox2.Select();
        }

        private void comboBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            label8.Text = "";
            if (comboBox1.Text == "")
                comboBox1.Select();
            else
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    int PolcFound =vFSC360300StockBinNoBindingSource.Find("BinNumber", comboBox1.Text.ToUpper().Trim());
                    if (PolcFound < 0)
                    {
                        label8.Text = "NINCS ILYEN POLCHELY !";
                     //   comboBox1.SelectedIndex = 0;
                        dataSet1.EnforceConstraints = false;
                        comboBox1.SelectedValue = "STD01";
                    }
                    else
                     //  SendKeys.Send("{TAB}");
                       Selejtez();
                }
            }
        }


    }
}
