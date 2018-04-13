namespace Library_Management_System
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
            this.btn_mem_reg = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_mem_reg
            // 
            this.btn_mem_reg.Location = new System.Drawing.Point(250, 61);
            this.btn_mem_reg.Name = "btn_mem_reg";
            this.btn_mem_reg.Size = new System.Drawing.Size(259, 65);
            this.btn_mem_reg.TabIndex = 0;
            this.btn_mem_reg.Text = "Register Member";
            this.btn_mem_reg.UseVisualStyleBackColor = true;
            this.btn_mem_reg.Click += new System.EventHandler(this.btn_mem_reg_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(250, 161);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(259, 52);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_mem_reg);
            this.Name = "Form1";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_mem_reg;
        private System.Windows.Forms.Button btn_search;
    }
}

