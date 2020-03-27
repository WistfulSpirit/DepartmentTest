using Departments.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Departments
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            buttonDelete.Visible = (Data.employee != null);
            buttonDelete.Enabled = (Data.employee != null);
            buttonAddUpdate.Text = (Data.employee == null) ? "Добавить" : "Обновить";

            var departList = Data.departmentsList;
            var depList = new BindingList<Department>(departList.OrderBy(x => x.ID).ToList());
            comboBoxDepartment.ValueMember = "ID";
            comboBoxDepartment.DisplayMember = "Name";
            comboBoxDepartment.DataSource = depList;// depList.OrderBy(x => x.ID).ToList(); 
            if (Data.employee != null)
            {
                textBoxName.Text = Data.employee.FirstName;
                textBoxSurName.Text = Data.employee.SurName;
                textBoxPatronymic.Text = Data.employee.Patronymic;
                dateTimePicker1.Value = Data.employee.DateOfBirth;
                textBoxPosition.Text = Data.employee.Position;
                textBoxDocSeries.Text = Data.employee.DocSeries;
                textBoxDocNumber.Text = Data.employee.DocNumber;
                //comboBoxParentDepartment.DataSource = depList;// depList.OrderBy(x => x.ID).ToList(); 
                var dep = depList.Where(x => x.ID == Data.employee.DepartmentID).ElementAt(0);
                comboBoxDepartment.SelectedIndex = comboBoxDepartment.FindString(dep.Name);
            }
            //comboBoxParentDepartment.DataSource = depList;// depList.OrderBy(x => x.ID).ToList(); 
            comboBoxDepartment.Update();
            //buttonAddUpdate.DialogResult = DialogResult.OK;
            //buttonDelete.DialogResult = DialogResult.OK;
        }

        private void buttonAddUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;
            int id = Data.employee?.ID ?? 0;
            Data.employee = new Employee()
            {
                ID = id,
                FirstName = textBoxName.Text,
                SurName = textBoxSurName.Text,
                Patronymic = textBoxPatronymic.Text,
                DateOfBirth = dateTimePicker1.Value,
                Position = textBoxPosition.Text,
                DocSeries = textBoxDocSeries.Text,
                DocNumber = textBoxDocNumber.Text,
                DepartmentID = ((Department)comboBoxDepartment.SelectedItem).ID
            };
            this.DialogResult = DialogResult.OK;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = Data.employee.ID;
            Data.employee = new Employee()
            {
                ID = id,
                FirstName = null
            };
            this.DialogResult = DialogResult.OK;
        }

        private bool ValidateForm()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (String.IsNullOrWhiteSpace(textBoxName.Text) || textBoxName.Text.Length > 50)
            {
                errorProvider1.SetError(textBoxName, "Поле не должно быть пустым или превышать 50 символов");
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(textBoxSurName.Text) || textBoxSurName.Text.Length > 50)
            {
                errorProvider1.SetError(textBoxSurName, "Поле не должно быть пустым или превышать 50 символов");
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(textBoxDocSeries.Text) || textBoxDocSeries.Text.Length > 4)
            {
                errorProvider1.SetError(textBoxDocSeries, "Поле не должно быть пустым или превышать 4 символов");
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(textBoxDocNumber.Text) || textBoxDocNumber.Text.Length > 6)
            {
                errorProvider1.SetError(textBoxDocNumber, "Поле не должно быть пустым или превышать 6 символов");
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(textBoxPosition.Text) || textBoxPosition.Text.Length > 50)
            {
                errorProvider1.SetError(textBoxPosition, "Поле не должно быть пустым или превышать 50 символов");
                valid = false;
            }

            return valid;
        }
    }
}

