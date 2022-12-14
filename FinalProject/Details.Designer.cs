namespace FinalProject
{
    partial class Details
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
            this.dgrvViewDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvViewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrvViewDetails
            // 
            this.dgrvViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvViewDetails.Location = new System.Drawing.Point(48, 47);
            this.dgrvViewDetails.Name = "dgrvViewDetails";
            this.dgrvViewDetails.Size = new System.Drawing.Size(684, 319);
            this.dgrvViewDetails.TabIndex = 0;
            this.dgrvViewDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvViewDetails_CellContentClick);
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgrvViewDetails);
            this.Name = "Details";
            this.Text = "Details";
            ((System.ComponentModel.ISupportInitialize)(this.dgrvViewDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvViewDetails;
    }
}