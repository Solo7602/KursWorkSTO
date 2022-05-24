using BuisnessLogic.BindingModels;
using BuisnessLogic.BuisnessLogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientView
{
    public partial class FormStaff : Form
    {
        private readonly IStaffLogic _logic;
        public FormStaff(IStaffLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new StaffBindingModel
                {
                    StaffName = textBox1.Text,
                    StaffPrice = Convert.ToInt32(textBox2.Text),
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox3.Text);
            try
            {
                _logic.Delete(new StaffBindingModel { Id = id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
