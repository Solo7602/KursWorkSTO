using BuisnessLogic.BindingModels;
using BuisnessLogic.BuisnessLogic;
using BuisnessLogic.Enums;
using BuisnessLogic.ViewModels;
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
    public partial class FormRepair : Form
    {
        public int Id { set { id = value; } }
        private PaymentLogic paymentLogic;
        private readonly RepairLogic _logic;
        private readonly WorkLogic workLogic;
        private int? id;
        private Dictionary<int, string> repairWorks;
        public FormRepair(RepairLogic logic, WorkLogic workLogic, PaymentLogic paymentLogic)
        {
            this.paymentLogic = paymentLogic;
            this.workLogic= workLogic;
            InitializeComponent();
            _logic = logic;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RepairViewModel view = _logic.Read(new RepairBindingModel
                    {Id =id.Value})?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        repairWorks = view.repairWorks;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                repairWorks = new Dictionary<int, string>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (repairWorks != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in repairWorks)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormRepairWorks>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (repairWorks.ContainsKey(form.Id))
                {
                    repairWorks[form.Id] = form.WorkName;
                }
                else
                {
                    repairWorks.Add(form.Id, form.WorkName);
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormRepairWorks>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    repairWorks[form.Id] = form.WorkName;
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        repairWorks.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text=="")
            {
                MessageBox.Show("Название не может быть пустым", "Ошибка", MessageBoxButtons.OK,

               MessageBoxIcon.Error);
                return;
            }
            if (repairWorks == null || repairWorks.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                var listWork = workLogic.Read(null);
                decimal sumCurrent = listWork
                    .Where(r => repairWorks.ContainsKey(r.Id)).Sum(r => r.WorkPrice);
                if (id.HasValue)
                {

                     decimal sumLast = _logic.Read(new RepairBindingModel()
                    {
                        Id = id.Value
                    })[0].Sum;
                    var lastPay = paymentLogic.Read(new PaymentBindingModel() { RepairId = (int)id }).Last();
                    sumCurrent-=(sumLast-lastPay.Sum);
                    paymentLogic.CreateOrUpdate(new PaymentBindingModel()
                    {
                        Id = lastPay.Id,
                        Remain = sumCurrent
                    });
                }

                _logic.CreateOrUpdate(new RepairBindingModel
                {
                    Id = id,
                    DateStart = DateTime.Now,
                    Sum=sumCurrent,
                    ClientId=Program.client.Id,
                    repairWorks=repairWorks,
                    Name = textBoxName.Text,
                    Status=RepairStatus.Adopted
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
