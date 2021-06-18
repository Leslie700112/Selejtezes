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

namespace Selejtezés
{
    public partial class Form6 : Form
    {
        public string pecset;
        private decimal menny;
        DataGridViewPrinter MyDataGridViewPrinter;
        public Form6()
        {
            InitializeComponent();
            dataGridView2.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView2_EditingControlShowing);
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.VF_SC010300_Stockfile_Hulladek' table. You can move, or remove it, as needed.
            this.vF_SC010300_Stockfile_HulladekTableAdapter.Fill(this.dataSet1.VF_SC010300_Stockfile_Hulladek);
            dataGridView2.Dock = DockStyle.Fill;

        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView2.CurrentCell.ColumnIndex == 4) //Desired Column
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point 
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }


        }   
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
            SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
            connection.Open();
            SqlCommand mySqlCommand = connection.CreateCommand();

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (dataGridView2.Rows[i].Cells["Column1"].Value== "" || dataGridView2.Rows[i].Cells["Column1"].Value == null)
                {
                    menny = 0;
                }
                else
                    menny = Convert.ToDecimal(dataGridView2.Rows[i].Cells["Column1"].Value.ToString().Trim());
                if (menny > 0)
                {
                    mySqlCommand.CommandText = "insert into Hulladek (Cikkszam,Menny,Dolgozo,Hulladek_datum,Port)values (@StockCode,@Menny,@pecset,@pontosido,'SELEJT')";
                    mySqlCommand.Parameters.Clear();
                    mySqlCommand.Parameters.Add("@StockCode", SqlDbType.NVarChar);
                    mySqlCommand.Parameters["@StockCode"].Value = dataGridView2.Rows[i].Cells["StockCode"].Value.ToString();
                    mySqlCommand.Parameters.Add("@pontosido", SqlDbType.DateTime);
                    mySqlCommand.Parameters["@pontosido"].Value = DateTime.Now;
                    mySqlCommand.Parameters.Add("@pecset", SqlDbType.NVarChar);
                    mySqlCommand.Parameters["@pecset"].Value = pecset;
                    mySqlCommand.Parameters.Add("@Menny", SqlDbType.Decimal);
                    mySqlCommand.Parameters["@Menny"].Value = Convert.ToDecimal(dataGridView2.Rows[i].Cells["Column1"].Value.ToString().Trim());
                    mySqlCommand.ExecuteNonQuery();

                    string datu = DateTime.Now.ToString("yyyy-MM-dd");
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<?xml version='1.0' encoding='UTF-8' ?>" +
                   "<msg:Msg xsi:schemaLocation='http://Epicor.com/Message/2.0 http://scshost/schemas/epicor/ScalaMessage.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:msg='http://Epicor.com/Message/2.0'>" +
                    "<msg:Hdr>" +
                       "<msg:Sender>" +
                         "<msg:Name>Hull</msg:Name>" +
                        //  "<msg:Subname></msg:Subname>"+
                       "</msg:Sender>" +
                     "</msg:Hdr>" +
                    "<msg:Body>" +
                     "<msg:Req msg-type='Stock Transaction' action='Process' >" +
                       "<msg:Dta>" +
                        "<dta:StockTransaction xsi:schemaLocation='http://www.scala.net/StockTransaction/1.1 http://scshost/schemas/Scala/1.1/StockTransaction.xsd' xmlns:dta='http://www.scala.net/StockTransaction/1.1'>" +
                       "<dta:Issue>" +
                         "<dta:TransDate>" + datu + "</dta:TransDate>" +
                         "<dta:Qty>" + Convert.ToDecimal(dataGridView2.Rows[i].Cells["Column1"].Value.ToString().Replace(',', '.')) * -1 + "</dta:Qty>" +
                         "<dta:StockCode>" + dataGridView2.Rows[i].Cells["StockCode"].Value.ToString() + "</dta:StockCode>" +
                         "<dta:WhCode>SE</dta:WhCode>" +
                         "<dta:BinCode>HULLSE</dta:BinCode>" +
                         "<dta:AccCode>86</dta:AccCode>" +
                     "</dta:Issue>" +
                    "</dta:StockTransaction>" +
                   "</msg:Dta>" +
                   "</msg:Req>" +
                   "</msg:Body>" +
                   "</msg:Msg>");
                    // Save the document to a file.
                    string f_nev = "SEHull" + dataGridView2.Rows[i].Cells["StockCode"].Value.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                //    doc.Save(f_nev);
                    doc.Save(@"\\10.0.0.11\inputxml\" + f_nev);

                }
            }
            mySqlCommand.CommandText = "update Selejt set Status='3' where Status='2'";
            mySqlCommand.ExecuteNonQuery();

            connection.Close();
            Nyomisz();
            Form12 form12 = new Form12();
            form12.ShowDialog();
            dataSet1.VF_SC010300_Stockfile_Hulladek.Clear();
            this.vF_SC010300_Stockfile_HulladekTableAdapter.Fill(this.dataSet1.VF_SC010300_Stockfile_Hulladek);
        }

        private void Nyomisz()
        {
            this.dataGridView2.Columns["Hull_Suly"].Visible = false;
            //dataGridView2.Visible = false;
            for (int j = 0; j < dataGridView2.RowCount; j++)
            {
                if (dataGridView2.Rows[j].Cells["Column1"].Value == "" || dataGridView2.Rows[j].Cells["Column1"].Value == null ||
                    Convert.ToDecimal(dataGridView2.Rows[j].Cells["Column1"].Value) == 0)
                {
                    dataGridView2.Rows[j].Cells["Column1"].Value = "";
                }
            }
            //         menny = 0;
            //   this.dataGridView2.Rows[i].Visible = false;

            //     else
            //        menny = Convert.ToDecimal(dataGridView2.Rows[j].Cells["Column1"].Value.ToString());
            //     if (menny == 0)
            //     {
            //         dataGridView2.Rows.Remove(dataGridView2.Rows[j]);
            //     this.dataGridView2.Rows[i].Visible = false;
            // else
            //   this.dataGridView2.Rows[i].Visible = true;
            //        dataGridView2.Rows[j].Cells["Column1"].Value = menny.ToString();
            //   }
            // }
            SetupThePrinting();
            PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
            MyPrintPreviewDialog.Document = MyPrintDocument;
            MyPrintPreviewDialog.ShowDialog();
           
        }
        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            this.MyPrintDocument.DefaultPageSettings.Landscape = false;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(10, 10, 80, 10);

            MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView2, MyPrintDocument, true, true, "Hulladék Átadás Raktárnak", new Font("Verdana", 16, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image newImage = Image.FromFile("Logo_FT.jpg");
            Point ulCorner = new Point(20, 20);
            string mystring = Convert.ToString(DateTime.Now);
            System.Drawing.Graphics g = e.Graphics;
            g.DrawString("Kaposvár," + mystring.Substring(0, 17), new System.Drawing.Font("Verdana", 10F), new SolidBrush(Color.Black), new Point(580, 25));
            e.Graphics.DrawImage(newImage, ulCorner);

            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;

            g.DrawString("Átadó", new System.Drawing.Font("Verdana", 12F), new SolidBrush(Color.Black), new Point(120, 1085));
            g.DrawString("Engedélyező", new System.Drawing.Font("Verdana", 12F), new SolidBrush(Color.Black), new Point(360, 1095));
            g.DrawString("Átvevő", new System.Drawing.Font("Verdana", 12F), new SolidBrush(Color.Black), new Point(640, 1085));
        }
 


    }
}
