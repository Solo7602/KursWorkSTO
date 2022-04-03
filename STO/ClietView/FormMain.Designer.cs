namespace ClientView
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPayment = new System.Windows.Forms.Button();
            this.buttonClients = new System.Windows.Forms.Button();
            this.buttonRepair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPayment
            // 
            this.buttonPayment.Location = new System.Drawing.Point(92, 42);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(121, 42);
            this.buttonPayment.TabIndex = 0;
            this.buttonPayment.Text = "Оплата";
            this.buttonPayment.UseVisualStyleBackColor = true;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // buttonClients
            // 
            this.buttonClients.Location = new System.Drawing.Point(468, 42);
            this.buttonClients.Name = "buttonClients";
            this.buttonClients.Size = new System.Drawing.Size(121, 42);
            this.buttonClients.TabIndex = 1;
            this.buttonClients.Text = "Клиенты";
            this.buttonClients.UseVisualStyleBackColor = true;
            this.buttonClients.Click += new System.EventHandler(this.buttonClients_Click);
            // 
            // buttonRepair
            // 
            this.buttonRepair.Location = new System.Drawing.Point(285, 42);
            this.buttonRepair.Name = "buttonRepair";
            this.buttonRepair.Size = new System.Drawing.Size(121, 42);
            this.buttonRepair.TabIndex = 2;
            this.buttonRepair.Text = "Ремонты";
            this.buttonRepair.UseVisualStyleBackColor = true;
            this.buttonRepair.Click += new System.EventHandler(this.buttonRepair_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRepair);
            this.Controls.Add(this.buttonClients);
            this.Controls.Add(this.buttonPayment);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.Button buttonClients;
        private System.Windows.Forms.Button buttonRepair;
    }
}
