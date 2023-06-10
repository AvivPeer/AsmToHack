
namespace WindowsFormsApp2
{
    partial class AsmHackCmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsmHackCmp));
            this.Compare = new System.Windows.Forms.Button();
            this.File1 = new System.Windows.Forms.RichTextBox();
            this.File2 = new System.Windows.Forms.RichTextBox();
            this.Load = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.res = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Compare
            // 
            this.Compare.Location = new System.Drawing.Point(300, 409);
            this.Compare.Name = "Compare";
            this.Compare.Size = new System.Drawing.Size(75, 23);
            this.Compare.TabIndex = 0;
            this.Compare.Text = "Compare";
            this.Compare.UseVisualStyleBackColor = true;
            this.Compare.Click += new System.EventHandler(this.button1_Click);
            // 
            // File1
            // 
            this.File1.Location = new System.Drawing.Point(35, 151);
            this.File1.Name = "File1";
            this.File1.Size = new System.Drawing.Size(184, 405);
            this.File1.TabIndex = 1;
            this.File1.Text = "";
            // 
            // File2
            // 
            this.File2.Location = new System.Drawing.Point(481, 151);
            this.File2.Name = "File2";
            this.File2.Size = new System.Drawing.Size(184, 408);
            this.File2.TabIndex = 2;
            this.File2.Text = "";
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(35, 113);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(75, 23);
            this.Load.TabIndex = 7;
            this.Load.Text = "Load File";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(484, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Load File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(565, 113);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Result";
            // 
            // res
            // 
            this.res.Location = new System.Drawing.Point(285, 453);
            this.res.Multiline = true;
            this.res.Name = "res";
            this.res.ReadOnly = true;
            this.res.Size = new System.Drawing.Size(155, 20);
            this.res.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = global::WindowsFormsApp2.Properties.Resources.coollogo_com_245302810;
            this.label2.Location = new System.Drawing.Point(52, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(613, 69);
            this.label2.TabIndex = 12;
            // 
            // AsmHackCmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(717, 572);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.res);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.File2);
            this.Controls.Add(this.File1);
            this.Controls.Add(this.Compare);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AsmHackCmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asm/Hack Compare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Compare;
        private System.Windows.Forms.RichTextBox File1;
        private System.Windows.Forms.RichTextBox File2;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox res;
        private System.Windows.Forms.Label label2;
    }
}