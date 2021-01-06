namespace _3PS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btkKilometri = new System.Windows.Forms.Button();
            this.BtnPDF = new System.Windows.Forms.Button();
            this.BtnWK = new System.Windows.Forms.Button();
            this.BtnPK = new System.Windows.Forms.Button();
            this.BtnGraf = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btngraf2 = new System.Windows.Forms.Button();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // btkKilometri
            // 
            this.btkKilometri.Location = new System.Drawing.Point(12, 537);
            this.btkKilometri.Name = "btkKilometri";
            this.btkKilometri.Size = new System.Drawing.Size(126, 23);
            this.btkKilometri.TabIndex = 0;
            this.btkKilometri.Text = "Word ";
            this.btkKilometri.UseVisualStyleBackColor = true;
            this.btkKilometri.Click += new System.EventHandler(this.btkKilometri_Click);
            // 
            // BtnPDF
            // 
            this.BtnPDF.Location = new System.Drawing.Point(157, 537);
            this.BtnPDF.Name = "BtnPDF";
            this.BtnPDF.Size = new System.Drawing.Size(101, 23);
            this.BtnPDF.TabIndex = 1;
            this.BtnPDF.Text = "PDF ";
            this.BtnPDF.UseVisualStyleBackColor = true;
            this.BtnPDF.Click += new System.EventHandler(this.BtnPDF_Click);
            // 
            // BtnWK
            // 
            this.BtnWK.Location = new System.Drawing.Point(298, 537);
            this.BtnWK.Name = "BtnWK";
            this.BtnWK.Size = new System.Drawing.Size(90, 23);
            this.BtnWK.TabIndex = 2;
            this.BtnWK.Text = "Word vse";
            this.BtnWK.UseVisualStyleBackColor = true;
            this.BtnWK.Click += new System.EventHandler(this.BtnWK_Click);
            // 
            // BtnPK
            // 
            this.BtnPK.Location = new System.Drawing.Point(405, 537);
            this.BtnPK.Name = "BtnPK";
            this.BtnPK.Size = new System.Drawing.Size(95, 23);
            this.BtnPK.TabIndex = 3;
            this.BtnPK.Text = "PDF vse";
            this.BtnPK.UseVisualStyleBackColor = true;
            this.BtnPK.Click += new System.EventHandler(this.BtnPK_Click);
            // 
            // BtnGraf
            // 
            this.BtnGraf.Location = new System.Drawing.Point(12, 74);
            this.BtnGraf.Name = "BtnGraf";
            this.BtnGraf.Size = new System.Drawing.Size(75, 23);
            this.BtnGraf.TabIndex = 4;
            this.BtnGraf.Text = "Graf";
            this.BtnGraf.UseVisualStyleBackColor = true;
            this.BtnGraf.Click += new System.EventHandler(this.BtnGraf_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(118, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Kilometri";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(478, 214);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(664, 12);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Kilometri";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(478, 214);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            // 
            // btngraf2
            // 
            this.btngraf2.Location = new System.Drawing.Point(1158, 74);
            this.btngraf2.Name = "btngraf2";
            this.btngraf2.Size = new System.Drawing.Size(75, 23);
            this.btngraf2.TabIndex = 7;
            this.btngraf2.Text = "Graf 2";
            this.btngraf2.UseVisualStyleBackColor = true;
            this.btngraf2.Click += new System.EventHandler(this.btngraf2_Click);
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(664, 274);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Kilometri";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(478, 258);
            this.chart3.TabIndex = 8;
            this.chart3.Text = "chart3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1158, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Graf 3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 572);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.btngraf2);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.BtnGraf);
            this.Controls.Add(this.BtnPK);
            this.Controls.Add(this.BtnWK);
            this.Controls.Add(this.BtnPDF);
            this.Controls.Add(this.btkKilometri);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btkKilometri;
        private System.Windows.Forms.Button BtnPDF;
        private System.Windows.Forms.Button BtnWK;
        private System.Windows.Forms.Button BtnPK;
        private System.Windows.Forms.Button BtnGraf;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button btngraf2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button button1;
    }
}

