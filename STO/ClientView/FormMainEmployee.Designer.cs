namespace EmployeeView
{
    partial class FormMainEmployee
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
            this.buttonEmp = new System.Windows.Forms.Button();
            this.buttonWork = new System.Windows.Forms.Button();
            this.buttonStaff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEmp
            // 
            this.buttonEmp.Location = new System.Drawing.Point(12, 6);
            this.buttonEmp.Name = "buttonEmp";
            this.buttonEmp.Size = new System.Drawing.Size(123, 48);
            this.buttonEmp.TabIndex = 0;
            this.buttonEmp.Text = "Сотудник";
            this.buttonEmp.UseVisualStyleBackColor = true;
            this.buttonEmp.Click += new System.EventHandler(this.buttonEmp_Click);
            // 
            // buttonWork
            // 
            this.buttonWork.Location = new System.Drawing.Point(169, 6);
            this.buttonWork.Name = "buttonWork";
            this.buttonWork.Size = new System.Drawing.Size(113, 48);
            this.buttonWork.TabIndex = 1;
            this.buttonWork.Text = "Работа";
            this.buttonWork.UseVisualStyleBackColor = true;
            this.buttonWork.Click += new System.EventHandler(this.buttonWork_Click);
            // 
            // buttonStaff
            // 
            this.buttonStaff.Location = new System.Drawing.Point(324, 6);
            this.buttonStaff.Name = "buttonStaff";
            this.buttonStaff.Size = new System.Drawing.Size(106, 48);
            this.buttonStaff.TabIndex = 2;
            this.buttonStaff.Text = "Должность";
            this.buttonStaff.UseVisualStyleBackColor = true;
            this.buttonStaff.Click += new System.EventHandler(this.buttonStaff_Click);
            // 
            // FormMainEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 73);
            this.Controls.Add(this.buttonStaff);
            this.Controls.Add(this.buttonWork);
            this.Controls.Add(this.buttonEmp);
            this.Name = "FormMainEmployee";
            this.Text = "FormMainEmployee";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEmp;
        private System.Windows.Forms.Button buttonWork;
        private System.Windows.Forms.Button buttonStaff;
    }
}