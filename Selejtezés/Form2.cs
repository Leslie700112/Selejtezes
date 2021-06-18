using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Threading;

namespace Selejtezés
{
    public partial class Form2 : Form
    {
        public string pecset,er_muszak;
        private string v_cikk, Mertegys,mitcsi;
        private double keszlet,ossz = 0;
        private DateTime berogz;

        public Form2()
        {
            InitializeComponent();
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            this.dataGridView1.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);
            this.dataGridView2.KeyDown += new KeyEventHandler(dataGridView2_KeyDown);
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView2.CellEndEdit += new DataGridViewCellEventHandler(dataGridView2_CellEndEdit);
            dataGridView2.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView2_EditingControlShowing);
            dataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView2_CellFormatting);
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox3_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox4_KeyPress);
            comboBox1.KeyPress += new KeyPressEventHandler(comboBox1_KeyPress);
            dateTimePicker1.KeyPress += new KeyPressEventHandler(dateTimePicker1_KeyyPress);
            comboBox2.KeyPress += new KeyPressEventHandler(comboBox2_KeyPress);
            comboBox3.KeyPress += new KeyPressEventHandler(comboBox3_KeyPress);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           // TODO: This line of code loads data into the 'dataSet1.SelejtKod' table. You can move, or remove it, as needed.
            this.selejtKodTableAdapter.Fill(this.dataSet1.SelejtKod);
            // TODO: This line of code loads data into the 'dataSet1.VF_SY240300_Cells' table. You can move, or remove it, as needed.
            mitcsi = "01";
            this.vF_SY240300_CellsTableAdapter.Fill(this.dataSet1.VF_SY240300_Cells);
            // TODO: This line of code loads data into the 'dataSet1.VF_SC010300_Stock_Scrap' table. You can move, or remove it, as needed.
            this.vF_SC010300_Stock_ScrapTableAdapter.Fill(this.dataSet1.VF_SC010300_Stock_Scrap,mitcsi);
            label8.Text = "";
            label4.Text = "";
            label5.Text = "";
            label12.Text = "";
            textBox1.Select();
            dateTimePicker1.Value = DateTime.Today;
        
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

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                dataGridView2.EndEdit();
                e.Handled = true;
                if (Convert.ToDouble(textBox3.Text.Trim()) != ossz)
                {
                    MessageBox.Show("Az össz mennyiség nem egyenlő a selejtezendő mennyiségel !!");
                    dataGridView2.Select();
                }
                else
                button1.Select();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                   if (this.dataGridView1.Rows[e.RowIndex].Cells["StockCode"].Value.ToString() == textBox2.Text)
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                   else
                       this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
                 
         }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.Columns[2].HeaderCell.Style.BackColor = Color.LightGreen;
        }

        private void alapinformaciok()
        {
            label4.Text = "";
            label5.Text = "";
            v_cikk = dataGridView1.CurrentRow.Cells["StockCode"].Value.ToString();
           textBox2.Text = v_cikk;
            label4.Text = dataGridView1.CurrentRow.Cells["Description1"].Value.ToString() + " ¤ " + dataGridView1.CurrentRow.Cells["Description2"].Value.ToString()
                + " ¤ " + dataGridView1.CurrentRow.Cells["InternRem1"].Value.ToString();
            Mertegys=dataGridView1.CurrentRow.Cells["UnitStock"].Value.ToString().Trim();
            label5.Text = Mertegys;
            keszlet =Convert.ToDouble(dataGridView1.CurrentRow.Cells["StockBalance"].Value);
            comboBox1.Select();
            
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
                    label8.Text = "NINCS ILYEN CIKKSZÁM VAGY A TERMELÉSBEN NINCS KÉSZLET !";
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
                    comboBox1.Select(); 
                }
            }
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
                    int PortFound =vFSY240300CellsBindingSource.Find("TextDescription",comboBox1.Text.ToUpper().Trim());
                    if (PortFound < 0)
                    {
                        label8.Text = "NINCS ILYEN MUNKAHELY !";
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                     SendKeys.Send("{TAB}");
                }
            }
        }
        
        private void textBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
   {
       label8.Text = "";
            if (Mertegys == "db" )
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
            if (((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab) && textBox3.Text != "")
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
                      dateTimePicker1.Value = DateTime.Today;
                      dateTimePicker1.Select();
                }
                }
          
            }

        private void dateTimePicker1_KeyyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab)
            {
                TimeSpan time = DateTime.Now.TimeOfDay;

                if (time >= new TimeSpan(6, 00, 00) && time <= new TimeSpan(13, 59, 59))
                {
                    comboBox2.SelectedIndex = 0;
                    er_muszak = comboBox2.Text.Trim();
                }
                if (time >= new TimeSpan(14, 00, 00) && time <= new TimeSpan(21, 59, 59))
                {
                    comboBox2.SelectedIndex = 1;
                    er_muszak = comboBox2.Text.Trim();
                }
                if (time >= new TimeSpan(22, 00, 00) && time <= new TimeSpan(23, 59, 59))
                {
                    comboBox2.SelectedIndex = 2;
                    er_muszak = comboBox2.Text.Trim();
                }
                if (time >= new TimeSpan(0, 00, 00) && time <= new TimeSpan(5, 59, 59))
                {
                    comboBox2.SelectedIndex = 2;
                    er_muszak = comboBox2.Text.Trim();
                }
            }
                  comboBox2.Select();
    
        }

        private void comboBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab)
            {
                if (er_muszak == comboBox2.Text.Trim())
                {
                   berogz=Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()+DateTime.Now.TimeOfDay);
                }
                else
                {
                 switch (comboBox2.Text.Trim())
                    {
                        case "1":
                           berogz = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString() + " 06:55:00");
                            break;
                        case "2":
                            berogz = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString() + " 14:55:00");
                            break;
                        case "3":
                            berogz = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString() + " 22:55:00");
                            break;
                    }
                 }
                comboBox3.Select();
            }
        }
   
        private void comboBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            label8.Text = "";
            if ((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab)
            {
                if (comboBox3.SelectedValue.ToString() == "5")
                {
                    if (textBox2.Text.Trim() == "0399001" || textBox2.Text.Trim() == "0399140" || textBox2.Text.Trim() == "0399227" || textBox2.Text.Trim() == "0399238" || textBox2.Text.Trim() == "0399273")
                    {
                        textBox4.Select();
                    }
                    else
                    {
                        label8.Text = "EZ A SELEJT FAJTA CSAK HOMOKHOZ VÁLASZHATÓ !";
                        comboBox3.Select();
                    }

                }
                else
                    textBox4.Select();
            }
        }  
 
     private void textBox4_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                label12.Text = label5.Text;
              textBox5.Text =ossz.ToString();
                this.vF_SC330300_StockBatchTableAdapter.Fill(this.dataSet2.VF_SC330300_StockBatch, textBox2.Text.Trim());
                dataGridView2.Select();
                dataGridView2.CurrentCell = dataGridView2.Rows[0].Cells[2];
            
            }
        }
        
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ossz = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                ossz += Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            }
               textBox5.Text =ossz.ToString();

               if (Convert.ToDouble(textBox3.Text.Trim()) < ossz || Convert.ToDouble(dataGridView2.CurrentRow.Cells[1].Value) < Convert.ToDouble(dataGridView2.CurrentRow.Cells[2].Value))
            {
                MessageBox.Show("Az össz mennyiség nem lehet nagyobb a selejtezendő mennyiségnél !!");
                dataGridView2.CurrentRow.Cells[2].Value = "0";
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView2.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (label5.Text.Trim() == "db")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                // only allow one decimal point 
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           dataGridView2.EndEdit();
           if (Convert.ToDouble(textBox3.Text.Trim()) != ossz)
            {
                MessageBox.Show("Az össz mennyiség nem egyenlő a selejtezendő mennyiségel !!");
                dataGridView2.Select();
            }
            else
                Selejtez();
        }
  
        private void Selejtez()
        {
            SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
            connection.Open();
            SqlCommand mySqlCommand = connection.CreateCommand();
                    mySqlCommand.CommandText = "INSERT INTO Selejt (Cikkszam,Menny,Dolgozo,Sel_datum,Port,Megjegyz,Status,SelejtFajta) VALUES (@StockCode,@Menny,@Dolgozo, @Berogz,@Port,@Megjegyz,'0',@SelFaj)";
                    mySqlCommand.Parameters.Add("@SelFaj", SqlDbType.Char);
                    mySqlCommand.Parameters["@SElFaj"].Value = comboBox3.SelectedValue;
                    mySqlCommand.Parameters.Add("@StockCode", SqlDbType.NVarChar);
                    mySqlCommand.Parameters["@StockCode"].Value = textBox2.Text.Trim();
                    mySqlCommand.Parameters.Add("@Menny", SqlDbType.Decimal);
                    mySqlCommand.Parameters["@Menny"].Value = Convert.ToDecimal(textBox3.Text.Replace(',', '.'));
                    mySqlCommand.Parameters.Add("@Dolgozo", SqlDbType.NVarChar);
                    mySqlCommand.Parameters["@Dolgozo"].Value = pecset;
                    mySqlCommand.Parameters.Add("@Port", SqlDbType.NChar);
                    mySqlCommand.Parameters["@Port"].Value = comboBox1.Text.ToUpper();
                    mySqlCommand.Parameters.Add("@Megjegyz", SqlDbType.NChar);
                    mySqlCommand.Parameters["@Megjegyz"].Value = textBox4.Text.Trim();
                    mySqlCommand.Parameters.Add("@Berogz", SqlDbType.DateTime);
                    mySqlCommand.Parameters["@Berogz"].Value = berogz;
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        if (Convert.ToDouble(this.dataGridView2.Rows[i].Cells[2].Value) != 0)
                        {
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
                          "<dta:Qty>" + dataGridView2.Rows[i].Cells[2].Value.ToString().Trim() + "</dta:Qty>" +
                          "<dta:StockCode>" + textBox2.Text.Trim() + "</dta:StockCode>" +
                          "<dta:WhCodeFrom>01</dta:WhCodeFrom>" +
                          "<dta:BinCodeFrom>" + dataGridView2.Rows[i].Cells[0].Value.ToString().Trim()+ "</dta:BinCodeFrom>" +
                          "<dta:WhCodeTo>SE</dta:WhCodeTo>" +
                          "<dta:BinCodeTo>STDSE</dta:BinCodeTo>" +
                          "<dta:Ref>SELEJT</dta:Ref>" +
                         //"<dta:OrdNum>" + MRend.Trim() + "</dta:OrdNum>" +
                          "<dta:Note>TM</dta:Note>" +
                          "</dta:Movement>" +
                          "</dta:StockTransaction>" +
                          "</msg:Dta>" +
                          "</msg:Req>" +
                          "</msg:Body>" +
                          "</msg:Msg>");
                           // Save the document to a file.
                          string f_nev = "SE" + textBox2.Text.Trim() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                           //  doc.Save(f_nev);
                          doc.Save(@"\\10.0.0.11\inputxml\" + f_nev);
                        }
                    }
            Form12 form12 = new Form12();
            form12.ShowDialog();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 0;
            label4.Text = "";
            textBox5.Text = "0";
            label12.Text = "";          
            dataSet1.VF_SC010300_Stock_Scrap.Clear();
            dataSet2.VF_SC330300_StockBatch.Clear();
          //  Thread.Sleep(2000);
            this.vF_SC010300_Stock_ScrapTableAdapter.Fill(this.dataSet1.VF_SC010300_Stock_Scrap, mitcsi);
            textBox1.Select();
        }



    }
}
