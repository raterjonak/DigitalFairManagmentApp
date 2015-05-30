namespace DigitalFairApp
{
    partial class VisitorNumberUI
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
            this.visitorNumberListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // visitorNumberListView
            // 
            this.visitorNumberListView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.visitorNumberListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.visitorNumberListView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.visitorNumberListView.GridLines = true;
            this.visitorNumberListView.Location = new System.Drawing.Point(117, 59);
            this.visitorNumberListView.Name = "visitorNumberListView";
            this.visitorNumberListView.Size = new System.Drawing.Size(424, 201);
            this.visitorNumberListView.TabIndex = 8;
            this.visitorNumberListView.UseCompatibleStateImageBehavior = false;
            this.visitorNumberListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Zone";
            this.columnHeader1.Width = 257;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "NoOfVisitors";
            this.columnHeader2.Width = 162;
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.totalTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalTextBox.Location = new System.Drawing.Point(299, 296);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(221, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total";
            // 
            // VisitorNumberUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(658, 375);
            this.Controls.Add(this.visitorNumberListView);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.label1);
            this.Name = "VisitorNumberUI";
            this.Text = "VisitorNumberUI";
            this.Load += new System.EventHandler(this.VisitorNumberUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView visitorNumberListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Label label1;
    }
}