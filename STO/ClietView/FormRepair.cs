using BuisnessLogic.BindingModels;
using BuisnessLogic.BuisnessLogicInterfaces;
using BuisnessLogic.Enums;
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
    public partial class FormRepair : Form
    {
        private readonly IRepairLogic _logic;
        public FormRepair(IRepairLogic repairLogic)
        {
            _logic = repairLogic;
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new RepairBindingModel
                {
                    Sum = Convert.ToInt32(textBoxName.Text),
                    ClientId = Convert.ToInt32(textBoxClientId.Text),
                    Name = textBoxName.Text,
                    DateStart = DateTime.Now,
                    Status = (RepairStatus)Convert.ToInt32(textBoxStatus.Text)

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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);
            try
            {
                _logic.Delete(new RepairBindingModel { Id = id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new RepairBindingModel
                {
                    Id = Convert.ToInt32(textBoxId.Text),
                    Sum = Convert.ToInt32(textBoxName.Text),
                    ClientId = Convert.ToInt32(textBoxClientId.Text),
                    Name = textBoxName.Text,
                    DateStart = DateTime.Now,
                    Status = (RepairStatus)Convert.ToInt32(textBoxStatus.Text)
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
    }
}
