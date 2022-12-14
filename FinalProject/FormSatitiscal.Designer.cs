namespace FinalProject
{
    partial class FormSatitiscal
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
            this.dgrvBest = new System.Windows.Forms.DataGridView();
            this.dgrvStatis = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStatis = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.rbtnImport = new System.Windows.Forms.RadioButton();
            this.rbtnExport = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.lblExport = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvBest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvStatis)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrvBest
            // 
            this.dgrvBest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvBest.Location = new System.Drawing.Point(24, 97);
            this.dgrvBest.Name = "dgrvBest";
            this.dgrvBest.Size = new System.Drawing.Size(430, 198);
            this.dgrvBest.TabIndex = 0;
            // 
            // dgrvStatis
            // 
            this.dgrvStatis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvStatis.Location = new System.Drawing.Point(385, 436);
            this.dgrvStatis.Name = "dgrvStatis";
            this.dgrvStatis.Size = new System.Drawing.Size(719, 198);
            this.dgrvStatis.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(123, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Best Selling Products";
            // 
            // btnStatis
            // 
            this.btnStatis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStatis.Location = new System.Drawing.Point(766, 295);
            this.btnStatis.Name = "btnStatis";
            this.btnStatis.Size = new System.Drawing.Size(122, 52);
            this.btnStatis.TabIndex = 4;
            this.btnStatis.Text = "Statistical";
            this.btnStatis.UseVisualStyleBackColor = false;
            this.btnStatis.Click += new System.EventHandler(this.btnStatis_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(13, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rbtnImport
            // 
            this.rbtnImport.AutoSize = true;
            this.rbtnImport.Location = new System.Drawing.Point(24, 404);
            this.rbtnImport.Name = "rbtnImport";
            this.rbtnImport.Size = new System.Drawing.Size(54, 17);
            this.rbtnImport.TabIndex = 7;
            this.rbtnImport.TabStop = true;
            this.rbtnImport.Text = "Import";
            this.rbtnImport.UseVisualStyleBackColor = true;
            this.rbtnImport.CheckedChanged += new System.EventHandler(this.rbtnImport_CheckedChanged);
            // 
            // rbtnExport
            // 
            this.rbtnExport.AutoSize = true;
            this.rbtnExport.Location = new System.Drawing.Point(24, 456);
            this.rbtnExport.Name = "rbtnExport";
            this.rbtnExport.Size = new System.Drawing.Size(55, 17);
            this.rbtnExport.TabIndex = 8;
            this.rbtnExport.TabStop = true;
            this.rbtnExport.Text = "Export";
            this.rbtnExport.UseVisualStyleBackColor = true;
            this.rbtnExport.CheckedChanged += new System.EventHandler(this.rbtnExport_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Import";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Export";
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(799, 137);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(16, 13);
            this.lblImport.TabIndex = 11;
            this.lblImport.Text = "...";
            // 
            // lblExport
            // 
            this.lblExport.AutoSize = true;
            this.lblExport.Location = new System.Drawing.Point(799, 188);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(16, 13);
            this.lblExport.TabIndex = 12;
            this.lblExport.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(644, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Profit";
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Location = new System.Drawing.Point(799, 237);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(16, 13);
            this.lblProfit.TabIndex = 14;
            this.lblProfit.Text = "...";
            // 
            // FormSatitiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 646);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblExport);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtnExport);
            this.Controls.Add(this.rbtnImport);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnStatis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgrvStatis);
            this.Controls.Add(this.dgrvBest);
            this.Name = "FormSatitiscal";
            this.Text = "FormSatitiscal";
            this.Load += new System.EventHandler(this.FormSatitiscal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvBest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvStatis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvBest;
        private System.Windows.Forms.DataGridView dgrvStatis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStatis;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton rbtnImport;
        private System.Windows.Forms.RadioButton rbtnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProfit;
    }
}