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

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPayment>();
            form.ShowDialog();
        }

        private void buttonRepair_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormRepair>();
            form.ShowDialog();
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClients>();
            form.ShowDialog();
        }
    }
}
