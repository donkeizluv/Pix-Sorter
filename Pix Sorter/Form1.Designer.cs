namespace Pix_Sorter
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
            this.textBoxImgPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDoit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.buttonBrowseExcel = new System.Windows.Forms.Label();
            this.textBoxExcelPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseImg = new System.Windows.Forms.Button();
            this.buttonBrowseOutput = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxImgPath
            // 
            this.textBoxImgPath.Location = new System.Drawing.Point(71, 12);
            this.textBoxImgPath.Name = "textBoxImgPath";
            this.textBoxImgPath.Size = new System.Drawing.Size(185, 22);
            this.textBoxImgPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image:";
            // 
            // buttonDoit
            // 
            this.buttonDoit.Location = new System.Drawing.Point(130, 141);
            this.buttonDoit.Name = "buttonDoit";
            this.buttonDoit.Size = new System.Drawing.Size(75, 23);
            this.buttonDoit.TabIndex = 2;
            this.buttonDoit.Text = "Do it!";
            this.buttonDoit.UseVisualStyleBackColor = true;
            this.buttonDoit.Click += new System.EventHandler(this.buttonDoit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output:";
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Location = new System.Drawing.Point(71, 40);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(185, 22);
            this.textBoxOutputPath.TabIndex = 3;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(150, 107);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(28, 17);
            this.labelProgress.TabIndex = 5;
            this.labelProgress.Text = "0/0";
            // 
            // buttonBrowseExcel
            // 
            this.buttonBrowseExcel.AutoSize = true;
            this.buttonBrowseExcel.Location = new System.Drawing.Point(20, 71);
            this.buttonBrowseExcel.Name = "buttonBrowseExcel";
            this.buttonBrowseExcel.Size = new System.Drawing.Size(45, 17);
            this.buttonBrowseExcel.TabIndex = 7;
            this.buttonBrowseExcel.Text = "Excel:";
            // 
            // textBoxExcelPath
            // 
            this.textBoxExcelPath.Location = new System.Drawing.Point(71, 68);
            this.textBoxExcelPath.Name = "textBoxExcelPath";
            this.textBoxExcelPath.Size = new System.Drawing.Size(185, 22);
            this.textBoxExcelPath.TabIndex = 6;
            // 
            // buttonBrowseImg
            // 
            this.buttonBrowseImg.Location = new System.Drawing.Point(262, 11);
            this.buttonBrowseImg.Name = "buttonBrowseImg";
            this.buttonBrowseImg.Size = new System.Drawing.Size(29, 23);
            this.buttonBrowseImg.TabIndex = 8;
            this.buttonBrowseImg.Text = "...";
            this.buttonBrowseImg.UseVisualStyleBackColor = true;
            this.buttonBrowseImg.Click += new System.EventHandler(this.buttonBrowseImg_Click);
            // 
            // buttonBrowseOutput
            // 
            this.buttonBrowseOutput.Location = new System.Drawing.Point(262, 39);
            this.buttonBrowseOutput.Name = "buttonBrowseOutput";
            this.buttonBrowseOutput.Size = new System.Drawing.Size(29, 23);
            this.buttonBrowseOutput.TabIndex = 9;
            this.buttonBrowseOutput.Text = "...";
            this.buttonBrowseOutput.UseVisualStyleBackColor = true;
            this.buttonBrowseOutput.Click += new System.EventHandler(this.buttonBrowseOutput_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(262, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 176);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonBrowseOutput);
            this.Controls.Add(this.buttonBrowseImg);
            this.Controls.Add(this.buttonBrowseExcel);
            this.Controls.Add(this.textBoxExcelPath);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxOutputPath);
            this.Controls.Add(this.buttonDoit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxImgPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Pix Sorter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxImgPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDoit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOutputPath;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label buttonBrowseExcel;
        private System.Windows.Forms.TextBox textBoxExcelPath;
        private System.Windows.Forms.Button buttonBrowseImg;
        private System.Windows.Forms.Button buttonBrowseOutput;
        private System.Windows.Forms.Button button3;
    }
}

