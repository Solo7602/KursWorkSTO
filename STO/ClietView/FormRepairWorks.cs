using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnessLogic.ViewModels;
using BuisnessLogic.BuisnessLogic;

namespace ClientView
{
    public partial class FormRepairWorks : Form
    {
        public int Id
        {
            get { return Convert.ToInt32(comboBoxWork.SelectedValue); }
            set { comboBoxWork.SelectedValue = value; }
        }
        public string WorkName { get { return comboBoxWork.Text; } }
        public FormRepairWorks(WorkLogic logic)
        {
            InitializeComponent();
            List<WorkViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxWork.DisplayMember = "WorkName";
                comboBoxWork.ValueMember = "Id";
                comboBoxWork.DataSource = list;
                comboBoxWork.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxWork.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
