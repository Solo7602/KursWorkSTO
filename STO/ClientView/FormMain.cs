using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button_Empolyee_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEmployee>();
            form.ShowDialog();
        }

        private void button_Work_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWork>();
            form.ShowDialog();
        }

        private void button_Staff_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormStaff>();
            form.ShowDialog();
        }
    }
}
