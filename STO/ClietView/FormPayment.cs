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
    public partial class FormPayment : Form
    {
        private readonly IPaymentLogic _logic;
        public FormPayment(IPaymentLogic paymentLogic)
        {
            _logic = paymentLogic;
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new PaymentBindingModel
                {
                    Sum = Convert.ToInt32(textBoxSum.Text),
                    Remain = Convert.ToInt32(textBoxRemain.Text),
                    RepairId = Convert.ToInt32(textBoxId.Text)
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
                _logic.Delete(new PaymentBindingModel { Id = id });
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
                _logic.CreateOrUpdate(new PaymentBindingModel
                {
                    Id = Convert.ToInt32(textBoxId.Text),
                    Sum = Convert.ToInt32(textBoxSum.Text),
                    Remain = Convert.ToInt32(textBoxRemain.Text),
                    RepairId = Convert.ToInt32(textBoxId.Text)
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
