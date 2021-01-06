
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Font = Xceed.Document.NET.Font;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using GemBox.Document;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.Charts;
using Microsoft.Office.Interop.Word;
using Table = Xceed.Document.NET.Table;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using Syncfusion.Pdf.Parsing;
using DevExpress.XtraCharts;
using iTextSharp.text.pdf;
using PdfDocument = Syncfusion.Pdf.PdfDocument;
using PdfImage = Syncfusion.Pdf.Graphics.PdfImage;
using PdfPage = Syncfusion.Pdf.PdfPage;

namespace _3PS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public List<Sport> InfoWhole2()
        {
            List<Sport> ListFill = null;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\3PS\Parsing\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  Time, Distance, Speed FROM Dimen1";
            conn.Open();
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    ListFill = new List<Sport>();
                    while (rd.Read())
                    {
                        Sport a = new Sport();
                        a = new Sport();

                        a.Trajanje_aktivnosti = rd.GetString(0);
                        a.Stevilo_prevozenih_km = rd.GetString(1);
                        a.Povp_hitrost = rd.GetString(2);




                        ListFill.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
            return ListFill;
        }
        public List<Sport> InfoWhole()
        {
            List<Sport> ListFill = null;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\3PS\Parsing\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  Calories, Altitude, Cadence, Avg_Cadence FROM Dimen2";
            conn.Open();
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    ListFill = new List<Sport>();
                    while (rd.Read())
                    {
                        Sport a = new Sport();
                        a = new Sport();

                        a.Porabljene_kalorije = rd.GetString(0);
                        a.Skupen_vzpon = rd.GetString(1);
                        a.Max_kadenca = rd.GetString(2);
                        a.Povp_kadenca = rd.GetString(3);



                        ListFill.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
            return ListFill;
        }

        public List<Sport> Info()
        {
            List<Sport> ListFill = null;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\3PS\Parsing\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT  Total_time, Total_km, Total_calories FROM Fact";
            conn.Open();
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    ListFill = new List<Sport>();
                    while (rd.Read())
                    {
                        Sport a = new Sport();
                        a = new Sport();

                        a.Trajanje_aktivnosti = rd.GetString(0);
                        a.Stevilo_prevozenih_km = rd.GetString(1);
                        a.Porabljene_kalorije = rd.GetString(2);

                        ListFill.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            conn.Close();
            return ListFill;
        }


        private void btkKilometri_Click(object sender, EventArgs e)
        {

            List<Sport> sport = new List<Sport>();
            sport = Info();
            //Location Path
            string fileName = @"Info.docx";

            var doc = DocX.Create(fileName);
            //Formatting Title 
            Formatting titleFormat = new Formatting();
            //Specify font family 
            titleFormat.FontFamily = new Font("Batang");
            //Specify font size 
            titleFormat.Size = 18;
            titleFormat.Position = 40;
            titleFormat.FontColor = System.Drawing.Color.Orange;
            titleFormat.UnderlineColor = System.Drawing.Color.Gray;
            titleFormat.Italic = true;
            //Formatting Text Paragraph
            Formatting textParagraphFormat = new Formatting();
            //font family 
            textParagraphFormat.FontFamily = new Font("Century Gothic");
            //font size  
            textParagraphFormat.Size = 10;
            //Spaces between characters 
            textParagraphFormat.Spacing = 2;

            int count = sport.Count;
            //Create Table with 2 rows and 4 columns.
            Table t = doc.AddTable(count + 3, 4);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulList;
            //Fill cells by adding text.  
            t.Rows[0].Cells[0].Paragraphs.First().Append("Kolesar");
            t.Rows[0].Cells[1].Paragraphs.First().Append("Total distance");
            t.Rows[0].Cells[2].Paragraphs.First().Append("Total calories");
            t.Rows[0].Cells[3].Paragraphs.First().Append("Total time");

            int stevec = 1;
            foreach (var item in sport)
            {
                t.Rows[stevec].Cells[0].Paragraphs.First().Append(stevec.ToString());
                t.Rows[stevec].Cells[1].Paragraphs.First().Append(item.Stevilo_prevozenih_km);
                t.Rows[stevec].Cells[2].Paragraphs.First().Append(item.Porabljene_kalorije);
                t.Rows[stevec].Cells[3].Paragraphs.First().Append(item.Trajanje_aktivnosti);
                stevec++;
            }

            doc.InsertTable(t);
            doc.Save();
            Process.Start("WINWORD.EXE", fileName);
        }

        private void BtnPDF_Click(object sender, EventArgs e)
        {
            List<Sport> sport = new List<Sport>();
            sport = Info();
            //Create a new PDF document
            Syncfusion.Pdf.PdfDocument doc = new PdfDocument();
            //Add a page
            PdfPage page = doc.Pages.Add();
            // Create a PdfLightTable
            PdfLightTable pdfLightTable = new PdfLightTable();
            // Initialize DataTable to assign as DateSource to the light table
            System.Data.DataTable table = new System.Data.DataTable();
            //Include columns to the DataTable

            table.Columns.Add("Kolesar");
            table.Columns.Add("Total distance");
            table.Columns.Add("Total calories");
            table.Columns.Add("Total time");
            //Include rows to the DataTable
            int count = sport.Count;

            int stevec = 1;
            foreach (var item in sport)
            {
                table.Rows.Add(new string[] { stevec.ToString(), item.Stevilo_prevozenih_km, item.Porabljene_kalorije, item.Trajanje_aktivnosti });
                stevec++;
            }

            //Applying cell padding to table
            pdfLightTable.Style.CellPadding = 3;
            pdfLightTable.ApplyBuiltinStyle(PdfLightTableBuiltinStyle.GridTable3Accent3);
            //Assign data source
            pdfLightTable.DataSource = table;
            //Setting this property to true to show the header of table
            pdfLightTable.Style.ShowHeader = true;
            //Draw PdfLightTable
            pdfLightTable.Draw(page, new PointF(0, 0));
            //Save the document

            doc.Save("PdfTable.pdf");
            //Close the document
            doc.Close(true);
            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("PdfTable.pdf");
        }

        private void BtnWK_Click(object sender, EventArgs e)
        {
            List<Sport> sport = new List<Sport>();
            sport = InfoWhole();

            List<Sport> sport1 = new List<Sport>();
            sport = InfoWhole2();

            //Location Path
            string fileName = @"Info.docx";

            var doc = DocX.Create(fileName);
            //Formatting Title 
            Formatting titleFormat = new Formatting();
            //Specify font family 
            titleFormat.FontFamily = new Font("Batang");
            //Specify font size 
            titleFormat.Size = 18;
            titleFormat.Position = 40;
            titleFormat.FontColor = System.Drawing.Color.Orange;
            titleFormat.UnderlineColor = System.Drawing.Color.Gray;
            titleFormat.Italic = true;
            //Formatting Text Paragraph
            Formatting textParagraphFormat = new Formatting();
            //font family 
            textParagraphFormat.FontFamily = new Font("Century Gothic");
            //font size  
            textParagraphFormat.Size = 10;
            //Spaces between characters 
            textParagraphFormat.Spacing = 2;

            int count = sport.Count;
            //Create Table with 2 rows and 4 columns.
            Table t = doc.AddTable(count + 3, 3);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulList;
            //Fill cells by adding text.  

            t.Rows[0].Cells[0].Paragraphs.First().Append("Cas");
            t.Rows[0].Cells[1].Paragraphs.First().Append("Razdalja");
            t.Rows[0].Cells[2].Paragraphs.First().Append("Hitrost");



            int stevec = 1;
            foreach (var item in sport)
            {
                t.Rows[stevec].Cells[0].Paragraphs.First().Append(item.Trajanje_aktivnosti);
                t.Rows[stevec].Cells[1].Paragraphs.First().Append(item.Stevilo_prevozenih_km);
                t.Rows[stevec].Cells[2].Paragraphs.First().Append(item.Povp_hitrost);

                stevec++;
            }


            doc.InsertTable(t);
            doc.Save();
            Process.Start("WINWORD.EXE", fileName);
        }

        private void BtnPK_Click(object sender, EventArgs e)
        {
            List<Sport> sport = new List<Sport>();
            sport = InfoWhole();
            //Create a new PDF document
            PdfDocument doc = new PdfDocument();
            //Add a page
            PdfPage page = doc.Pages.Add();
            // Create a PdfLightTable
            PdfLightTable pdfLightTable = new PdfLightTable();
            // Initialize DataTable to assign as DateSource to the light table
            System.Data.DataTable table = new System.Data.DataTable();
            //Include columns to the DataTable

            table.Columns.Add("Kalorije");
            table.Columns.Add("Vzpon distance");
            table.Columns.Add("Kadenca");
            table.Columns.Add("Avg kadenca");
            //Include rows to the DataTable
            int count = sport.Count;

            int stevec = 1;
            foreach (var item in sport)
            {
                table.Rows.Add(new string[] { item.Porabljene_kalorije, item.Skupen_vzpon, item.Max_kadenca, item.Povp_kadenca });
                stevec++;
            }

            //Applying cell padding to table
            pdfLightTable.Style.CellPadding = 3;
            pdfLightTable.ApplyBuiltinStyle(PdfLightTableBuiltinStyle.GridTable3Accent3);
            //Assign data source
            pdfLightTable.DataSource = table;
            //Setting this property to true to show the header of table
            pdfLightTable.Style.ShowHeader = true;
            //Draw PdfLightTable
            pdfLightTable.Draw(page, new PointF(0, 0));
            //Save the document

            doc.Save("PdfTable.pdf");
            //Close the document
            doc.Close(true);
            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("PdfTable.pdf");
        }


        private void fillChart()
        {
            List<Sport> sport = new List<Sport>();
            sport = Info();

            int stevec = 1;
            foreach (var item in sport)
            {
                //AddXY value in chart1 in series named as Salary  
                chart1.Series["Kilometri"].Points.AddXY("Kolesar" + stevec.ToString(), item.Stevilo_prevozenih_km);
                stevec++;

            }
            //chart title  
            chart1.Titles.Add("Prevozeni kilometri");

        }

        private void fillChart2()
        {
            List<Sport> sport = new List<Sport>();
            sport = Info();

            int stevec = 1;
            foreach (var item in sport)
            {
                //AddXY value in chart1 in series named as Salary  
                chart2.Series["Kilometri"].Points.AddXY("Kolesar" + stevec.ToString(), item.Stevilo_prevozenih_km);
                stevec++;

            }
            //chart title  
            chart2.Titles.Add("Prevozeni kilometri");

        }

        private void fillChart3()
        {
            List<Sport> sport = new List<Sport>();
            sport = Info();

            int stevec = 1;
            foreach (var item in sport)
            {
                //AddXY value in chart1 in series named as Salary  
                chart3.Series["Kilometri"].Points.AddXY("Kolesar" + stevec.ToString(), item.Stevilo_prevozenih_km);
                stevec++;

            }
            //chart title  
            chart3.Titles.Add("Prevozeni kilometri");

        }
        private void BtnGraf_Click(object sender, EventArgs e)
        {

            string path = @"mychart.png";
            fillChart();

            string fileName = System.Windows.Forms.Application.StartupPath + "\\chartExport";

            string exportFileName = fileName + ".pdf";

            string file = fileName + ".gif";

            this.chart1.SaveImage("mychart.png", ChartImageFormat.Png);

            //Create a PDF document

            PdfDocument pdfDoc = new PdfDocument();

            //Add a page to the empty PDF document

            pdfDoc.Pages.Add();

            //Draw chart image in the first page

            pdfDoc.Pages[0].Graphics.DrawImage(PdfImage.FromFile(path), new PointF(10, 30));

            //Save the PDF Document to disk.

            pdfDoc.Save(exportFileName);

            // Launches the file.                         

            System.Diagnostics.Process.Start(exportFileName);



        }

        private void btngraf2_Click(object sender, EventArgs e)
        {
            string path = @"mychart2.png";
            fillChart2();

            string fileName = System.Windows.Forms.Application.StartupPath + "\\chartExport";

            string exportFileName = fileName + ".pdf";

            string file = fileName + ".gif";

            this.chart2.SaveImage("mychart2.png", ChartImageFormat.Png);

            //Create a PDF document

            PdfDocument pdfDoc = new PdfDocument();

            //Add a page to the empty PDF document

            pdfDoc.Pages.Add();

            //Draw chart image in the first page

            pdfDoc.Pages[0].Graphics.DrawImage(PdfImage.FromFile(path), new PointF(10, 30));

            //Save the PDF Document to disk.

            pdfDoc.Save(exportFileName);

            // Launches the file.                         

            System.Diagnostics.Process.Start(exportFileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"mychart.png";
            fillChart3();

            string fileName = System.Windows.Forms.Application.StartupPath + "\\chartExport";

            string exportFileName = fileName + ".pdf";

            string file = fileName + ".gif";

            this.chart3.SaveImage("mychart.png", ChartImageFormat.Png);

            //Create a PDF document

            PdfDocument pdfDoc = new PdfDocument();

            //Add a page to the empty PDF document

            pdfDoc.Pages.Add();

            //Draw chart image in the first page

            pdfDoc.Pages[0].Graphics.DrawImage(PdfImage.FromFile(path), new PointF(10, 30));

            //Save the PDF Document to disk.

            pdfDoc.Save(exportFileName);

            // Launches the file.                         

            System.Diagnostics.Process.Start(exportFileName);
        }
    }
}
