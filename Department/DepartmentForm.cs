using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Departments.Models;

namespace Departments
{
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();

            buttonDelete.Visible = (Data.department != null);
            buttonDelete.Enabled = (Data.department != null);
            ButtonAddUpdate.Text = (Data.department == null) ? "Добавить" : "Обновить";

            var departList = Data.departmentsList;
            departList.Add(new Department() { ID = Guid.Empty, Name = "Без родительского департамента" });
            var depList = new BindingList<Department>(departList.OrderBy(x => x.ID).ToList());

            comboBoxParentDepartment.ValueMember = "ID";
            comboBoxParentDepartment.DisplayMember = "Name";
            comboBoxParentDepartment.DataSource = depList;// depList.OrderBy(x => x.ID).ToList(); 
            if (Data.department != null)
            {
                int c = depList.Where(x => x.ID == Data.department.ID).Count();
                if (c > 0)
                    depList.Remove(depList.Where(x => x.ID == Data.department.ID).First());
                textBoxName.Text = Data.department.Name;
                textBoxCode.Text = Data.department.Code;
                //comboBoxParentDepartment.DataSource = depList;// depList.OrderBy(x => x.ID).ToList(); 
                var dep = depList.Where(x => x.ID == (Data.department.ParentDepartmentID ?? Guid.Empty)).ElementAt(0);
                comboBoxParentDepartment.SelectedIndex = comboBoxParentDepartment.FindString(dep.Name);
            }

            //comboBoxParentDepartment.DataSource = depList;// depList.OrderBy(x => x.ID).ToList(); 
            comboBoxParentDepartment.Update();
        }


        private void ButtonAddUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;
            Guid? depID;
            if (((Department)comboBoxParentDepartment.SelectedItem).ID == Guid.Empty)
                depID = null;
            else
                depID = ((Department)comboBoxParentDepartment.SelectedItem).ID;
            Data.department = new Department()
            {
                ID = Data.department?.ID ?? Guid.NewGuid(),
                Name = textBoxName.Text,
                Code = textBoxCode.Text,
                ParentDepartmentID = depID
            };
            this.DialogResult = DialogResult.OK;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Data.department = new Department()
            {
                ID = Data.department.ID,
                Name = null,
                Code = null

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
            if (String.IsNullOrWhiteSpace(textBoxCode.Text) || textBoxCode.Text.Length > 10)
            {
                errorProvider1.SetError(textBoxCode, "Поле не должно быть пустым или превышать 10 символов");
                valid = false;
            }
            
            return valid;
        }
        //NVARCHAR(50)
        //NVARCHAR(10)
    }
}
