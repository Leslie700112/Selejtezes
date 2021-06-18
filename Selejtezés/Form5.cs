using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Drawing.Printing;
using System.Threading;


namespace Selejtezés
{
    public partial class Form5 : Form
    {
        public string pecset, konyvkod,valtozik="N";
         private decimal menny,SeMenny;
       
        public Form5()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
           
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
           
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           // TODO: This line of code loads data into the 'dataSet1.Selejt_Cikk_Csoport' table. You can move, or remove it, as needed.
            this.selejt_Cikk_CsoportTableAdapter.Fill(this.dataSet1.Selejt_Cikk_Csoport);
          
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Visible = true;
         }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string wkeres = " ";

            string seekValue = this.textBox1.Text;
            if (seekValue != wkeres)
            {
                if (!string.IsNullOrEmpty(seekValue))
                {
                    selejtCikkCsoportBindingSource.Filter = "Kereso like '%" + seekValue + "%'";
                }
                else
                {
                    try
                    {
                        selejtCikkCsoportBindingSource.Filter = "";
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                wkeres = seekValue;
            }
        }  
       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           dataGridView1.EndEdit();
           dataGridView1.Visible = false;
            SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
            connection.Open();
            SqlCommand mySqlCommand = connection.CreateCommand();
       
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Atad"].Value)) 
                {
                    mySqlCommand.CommandText = " update Selejt set Status='2',AtadasIdo=@pontosido,Atado=@pecset where Sorszam=@StockCode";
                    mySqlCommand.Parameters.Clear();
                    mySqlCommand.Parameters.Add("@StockCode", SqlDbType.NVarChar);
                    mySqlCommand.Parameters["@StockCode"].Value = dataGridView1.Rows[i].Cells["Sorszam"].Value.ToString();
                    mySqlCommand.Parameters.Add("@pontosido", SqlDbType.DateTime);
                    mySqlCommand.Parameters["@pontosido"].Value =DateTime.Now;
                    mySqlCommand.Parameters.Add("@pecset", SqlDbType.NVarChar);
                    mySqlCommand.Parameters["@pecset"].Value = pecset;
                    mySqlCommand.ExecuteNonQuery();
                                 
                    if (dataGridView1.Rows[i].Cells["Cikkszam"].Value.ToString().Substring(0, 2) == "02")
                    {
                      konyvkod="55";
                    }
                    if (dataGridView1.Rows[i].Cells["Cikkszam"].Value.ToString().Substring(0, 2) == "03")
                    {
                       konyvkod="60";
                    }
                    if (dataGridView1.Rows[i].Cells["Cikkszam"].Value.ToString().Substring(0, 2) == "00")
                    {
                         konyvkod="50";
                    }
                    if (dataGridView1.Rows[i].Cells["Column2"].Value == "" || dataGridView1.Rows[i].Cells["Column2"].Value == "0" || dataGridView1.Rows[i].Cells["Column2"].Value ==null)
                        SeMenny = +Convert.ToDecimal(dataGridView1.Rows[i].Cells["Mennyi"].Value.ToString().Replace(',', '.')); //+Convert.ToDecimal(textBox11.Text.Replace(',', '.'))*-1+
                    else
                        SeMenny = +Convert.ToDecimal(dataGridView1.Rows[i].Cells["column2"].Value.ToString().Replace(',', '.'));
                  
                    string datum = DateTime.Now.ToString("yyyy-MM-dd");
                     XmlDocument doc = new XmlDocument();
                     doc.LoadXml("<?xml version='1.0' ?>"+
                     "<msg:Msg xsi:schemaLocation='http://Epicor.com/Message/2.0 http://scshost/schemas/epicor/ScalaMessage.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:msg='http://Epicor.com/Message/2.0'>"+
                     "<msg:Hdr>"+
                     "<msg:Sender>"+
                     "<msg:Name>Hull</msg:Name>"+
                   // "<msg:Subname></msg:Subname>"+
                     "</msg:Sender>"+
                     "</msg:Hdr>"+
                     "<msg:Body>"+
                     "<msg:Req msg-type='Stock Transaction' action='Process' >"+
                     "<msg:Dta>"+
                     "<dta:StockTransaction xsi:schemaLocation='http://www.scala.net/StockTransaction/1.1 http://scshost/schemas/Scala/1.1/StockTransaction.xsd' xmlns:dta='http://www.scala.net/StockTransaction/1.1'>"+
                     "<dta:Issue>"+
                     "<dta:TransDate>"+datum+"</dta:TransDate>"+
                     "<dta:Qty>"+SeMenny+"</dta:Qty>"+
                     "<dta:StockCode>"+dataGridView1.Rows[i].Cells["Cikkszam"].Value.ToString()+"</dta:StockCode>"+
                     "<dta:WhCode>SE</dta:WhCode>"+
                     "<dta:BinCode>STDSE</dta:BinCode>"+
                     "<dta:AccCode>"+konyvkod+"</dta:AccCode>"+
                     "</dta:Issue>"+
                     "</dta:StockTransaction>"+
                     "</msg:Dta>"+
                     "</msg:Req>"+
                     "</msg:Body>"+
                     "</msg:Msg>");
                     // Save the document to a file.
                     string f_nev = "AR" +dataGridView1.Rows[i].Cells["Cikkszam"].Value.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                     //  doc.Save(f_nev);
                    doc.Save(@"\\10.0.0.11\inputxml\" + f_nev);
                    //   Thread.Sleep(1000); 
                }
            }
            connection.Close();
            Form12 form12 = new Form12();
            form12.ShowDialog();
            //   Thread.Sleep(5000); 
            dataSet1.Selejt_Cikk_Csoport.Clear();
           this.selejt_Cikk_CsoportTableAdapter.Fill(this.dataSet1.Selejt_Cikk_Csoport);
           dataGridView1.Visible = true;
        }
    
         private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 6) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
        }
        
      private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["MertEgys"].Value.ToString() == "db")
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
            valtozik = "I";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            if (dataGridView1.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    try
                    {
                        if (!Convert.ToBoolean(dataGridView1.Rows[cell.RowIndex].Cells["Atad"].Value))
                            dataGridView1.Rows[cell.RowIndex].Cells["Atad"].Value = true;
                        else
                            dataGridView1.Rows[cell.RowIndex].Cells["Atad"].Value = false;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Column2"].Value =="" || dataGridView1.CurrentRow.Cells["Column2"].Value == null)
                dataGridView1.CurrentRow.Cells["Column2"].Value = null;
           if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Column2"].Value) == 0)
               dataGridView1.CurrentRow.Cells["Column2"].Value = null;

            if (dataGridView1.CurrentRow.Cells["Column2"].Value != "" && dataGridView1.CurrentRow.Cells["Column2"].Value != null && dataGridView1.CurrentRow.Cells["Column2"].Value != "0")
            {
                if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Mennyi"].Value) < Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Column2"].Value.ToString().Replace(',', '.')))
                {
                    dataGridView1.CurrentRow.Cells["Column2"].Value = null;
                    dataGridView1.CurrentRow.Cells["Atad"].Value = "N";
                }
                else
                    dataGridView1.CurrentRow.Cells["Atad"].Value = "I";
            }
            else
           {
              if (dataGridView1.CurrentRow.Cells["Atad"].Value == "I" && valtozik == "I")
                    dataGridView1.CurrentRow.Cells["Atad"].Value = "N";
            }
            valtozik = "N";
        }
    
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Rows[e.RowIndex].Cells["Atad"].Value == "I")
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
            else
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dataSet1.Selejt_Cikk_Csoport.Clear();
            this.selejt_Cikk_CsoportTableAdapter.Fill(this.dataSet1.Selejt_Cikk_Csoport);
        }

    
       


    }
}
