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
    public partial class FormEmployee : Form
        
    {
        private readonly IEmployeeLogic _logic;
        public FormEmployee(IEmployeeLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new EmployeeBindingModel
                {
                    EmployeeName = textBox1.Text,
                    EmployeeSurname = textBox2.Text,
                    EmployeeMiddlename = textBox3.Text,
                    EmployeePhoneNumber = textBox4.Text,
                    EmployeePrize = Convert.ToInt32(textBox5.Text)
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

        private void buttonDeli_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox6.Text);
            try
            {
                _logic.Delete(new EmployeeBindingModel { Id = id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
