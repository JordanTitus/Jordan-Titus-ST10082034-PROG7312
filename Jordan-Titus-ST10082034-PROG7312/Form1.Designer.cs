namespace Jordan_Titus_ST10082034_PROG7312
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
            this.lblMenuHeading = new System.Windows.Forms.Label();
            this.btnFindCallNumbers = new System.Windows.Forms.Button();
            this.btnIdentifyAreas = new System.Windows.Forms.Button();
            this.btnReplaceBooks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMenuHeading
            // 
            this.lblMenuHeading.AutoSize = true;
            this.lblMenuHeading.Font = new System.Drawing.Font("Goudy Stout", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuHeading.Location = new System.Drawing.Point(201, 61);
            this.lblMenuHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuHeading.Name = "lblMenuHeading";
            this.lblMenuHeading.Size = new System.Drawing.Size(389, 55);
            this.lblMenuHeading.TabIndex = 7;
            this.lblMenuHeading.Text = "Welcome";
            // 
            // btnFindCallNumbers
            // 
            this.btnFindCallNumbers.Enabled = false;
            this.btnFindCallNumbers.Location = new System.Drawing.Point(349, 326);
            this.btnFindCallNumbers.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindCallNumbers.Name = "btnFindCallNumbers";
            this.btnFindCallNumbers.Size = new System.Drawing.Size(100, 54);
            this.btnFindCallNumbers.TabIndex = 6;
            this.btnFindCallNumbers.Text = "Find Call Numbers";
            this.btnFindCallNumbers.UseVisualStyleBackColor = true;
            // 
            // btnIdentifyAreas
            // 
            this.btnIdentifyAreas.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnIdentifyAreas.Location = new System.Drawing.Point(349, 234);
            this.btnIdentifyAreas.Margin = new System.Windows.Forms.Padding(4);
            this.btnIdentifyAreas.Name = "btnIdentifyAreas";
            this.btnIdentifyAreas.Size = new System.Drawing.Size(100, 54);
            this.btnIdentifyAreas.TabIndex = 5;
            this.btnIdentifyAreas.Text = "Identify Area";
            this.btnIdentifyAreas.UseVisualStyleBackColor = false;
            this.btnIdentifyAreas.Click += new System.EventHandler(this.btnIdentifyAreas_Click);
            // 
            // btnReplaceBooks
            // 
            this.btnReplaceBooks.BackColor = System.Drawing.SystemColors.Control;
            this.btnReplaceBooks.Enabled = false;
            this.btnReplaceBooks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReplaceBooks.Location = new System.Drawing.Point(349, 146);
            this.btnReplaceBooks.Margin = new System.Windows.Forms.Padding(4);
            this.btnReplaceBooks.Name = "btnReplaceBooks";
            this.btnReplaceBooks.Size = new System.Drawing.Size(100, 54);
            this.btnReplaceBooks.TabIndex = 4;
            this.btnReplaceBooks.Text = "Replace Books";
            this.btnReplaceBooks.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Jordan_Titus_ST10082034_PROG7312.Properties.Resources._360_F_625256025_ohJcE1pPJwzbRY0oUl1LvJSfWiKb1CMR;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMenuHeading);
            this.Controls.Add(this.btnFindCallNumbers);
            this.Controls.Add(this.btnIdentifyAreas);
            this.Controls.Add(this.btnReplaceBooks);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenuHeading;
        private System.Windows.Forms.Button btnFindCallNumbers;
        private System.Windows.Forms.Button btnIdentifyAreas;
        private System.Windows.Forms.Button btnReplaceBooks;
    }
}

