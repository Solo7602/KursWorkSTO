namespace ClientView
{
    partial class FormMain
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
            this.button_Empolyee = new System.Windows.Forms.Button();
            this.button_Work = new System.Windows.Forms.Button();
            this.button_Staff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Empolyee
            // 
            this.button_Empolyee.Location = new System.Drawing.Point(12, 12);
            this.button_Empolyee.Name = "button_Empolyee";
            this.button_Empolyee.Size = new System.Drawing.Size(116, 43);
            this.button_Empolyee.TabIndex = 0;
            this.button_Empolyee.Text = "Сотрудники";
            this.button_Empolyee.UseVisualStyleBackColor = true;
            this.button_Empolyee.Click += new System.EventHandler(this.button_Empolyee_Click);
            // 
            // button_Work
            // 
            this.button_Work.Location = new System.Drawing.Point(134, 12);
            this.button_Work.Name = "button_Work";
            this.button_Work.Size = new System.Drawing.Size(116, 43);
            this.button_Work.TabIndex = 1;
            this.button_Work.Text = "Работы";
            this.button_Work.UseVisualStyleBackColor = true;
            this.button_Work.Click += new System.EventHandler(this.button_Work_Click);
            // 
            // button_Staff
            // 
            this.button_Staff.Location = new System.Drawing.Point(256, 12);
            this.button_Staff.Name = "button_Staff";
            this.button_Staff.Size = new System.Drawing.Size(116, 43);
            this.button_Staff.TabIndex = 2;
            this.button_Staff.Text = "Должности";
            this.button_Staff.UseVisualStyleBackColor = true;
            this.button_Staff.Click += new System.EventHandler(this.button_Staff_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 75);
            this.Controls.Add(this.button_Staff);
            this.Controls.Add(this.button_Work);
            this.Controls.Add(this.button_Empolyee);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Empolyee;
        private System.Windows.Forms.Button button_Work;
        private System.Windows.Forms.Button button_Staff;
    }
}