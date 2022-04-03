using ClientView;
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

namespace EmployeeView
{
    public partial class FormMainEmployee : Form
    {
        public FormMainEmployee()
        {
            InitializeComponent();
        }

        private void buttonEmp_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEmployee>();
            form.ShowDialog();
        }

        private void buttonWork_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWork>();
            form.ShowDialog();
        }

        private void buttonStaff_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormStaff>();
            form.ShowDialog();
        }
    }
}
