using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Departments.Controllers;
using Departments.Models;

namespace Departments
{
    public partial class Form1 : Form
    {
        DepartmentController departmentController;
        EmployeeController employeeController;
        List<Employee> empList;
        public Form1()
        {
            InitializeComponent();
            departmentController = new DepartmentController();
            employeeController = new EmployeeController();
            FillMainDepNodes();
            dataGridView1.ContextMenuStrip = contextMenuStripEmployee;
        }

        void FillMainDepNodes()
        {
            treeViewDeps.Nodes.Clear();
            var deps = departmentController.GetDepartments(null);
            foreach (var dep in deps)
            {
                TreeNode node = new TreeNode()
                {
                    Text = dep.Name,
                    Name = dep.Name,
                    Tag = dep
                };
                node.Nodes.Add(new TreeNode());//Add emptyTreeNode
                node.ContextMenuStrip = contextMenuDepartment;
                treeViewDeps.Nodes.Add(node);
            }
        }

        void FillNodes(TreeNode main_node, Guid guid)
        {
            var deps = departmentController.GetDepartments(guid);
            foreach (var dep in deps)
            {
                TreeNode node = new TreeNode()
                {
                    Text = dep.Name,
                    Name = dep.Name,
                    Tag = dep
                };
                node.Nodes.Add(new TreeNode());//Add emptyTreeNode
                node.ContextMenuStrip = contextMenuDepartment;
                main_node.Nodes.Add(node);
            }
        }

        private void treeViewDeps_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            FillNodes(e.Node, ((Department)e.Node.Tag).ID);
            UpdateDataGrid(((Department)e.Node.Tag).ID);
        }

        private void treeViewDeps_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            UpdateDataGrid(((Department)e.Node.Tag).ID);
        }

        private void UpdateDataGrid(Guid depId)
        {
            empList = employeeController.GetEmployee(depId);
            dataGridView1.DataSource = empList;
            dataGridView1.Refresh();
        }

        private void buttonUpdateGrid_Click(object sender, EventArgs e)
        {
            if (treeViewDeps.SelectedNode != null)
                UpdateDataGrid(((Department)treeViewDeps.SelectedNode.Tag).ID);
        }

        private void buttonAddDep_Click(object sender, EventArgs e)
        {
            Data.department = null;
            Data.departmentsList = departmentController.GetDepartments();
            DepartmentForm depForm = new DepartmentForm();
            if (depForm.ShowDialog() == DialogResult.OK)
            {
                departmentController.Create(Data.department);
            }
            Data.department = null;
            FillMainDepNodes();
        }

        private void EditToolStripDepMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeViewDeps.SelectedNode;
            if (node == null)
                return;
            Data.department = (Department)treeViewDeps.SelectedNode.Tag;
            Data.departmentsList = departmentController.GetDepartmentsWC(Data.department.ID);
            DepartmentForm depForm = new DepartmentForm();
            if (depForm.ShowDialog() == DialogResult.OK)
            {
                if (Data.department.ID == Guid.Empty)
                    departmentController.Create(Data.department);
                else if (Data.department.Name != null)
                    departmentController.Update(Data.department);
                else
                    DeleteDepartment(Data.department.ID);
            }
            Data.department = null;
            FillMainDepNodes();
        }

        private void DeleteToolStripDepMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewDeps.SelectedNode != null)
                DeleteDepartment(((Department)treeViewDeps.SelectedNode.Tag).ID);
        }

        private void DeleteDepartment(Guid depId)
        {
            int res = departmentController.Delete(depId);
            if (res == -99)
            {
                MessageBox.Show("Нельзя удалить, так как в департаменте есть работники или подразделения");
            }
            FillMainDepNodes();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var emp = (Employee)dataGridView1.CurrentRow.DataBoundItem;
            Data.employee = emp;
            Data.departmentsList = departmentController.GetDepartments();
            EmployeeForm empForm = new EmployeeForm();
            if (empForm.ShowDialog() == DialogResult.OK)
            {
                if (Data.employee.FirstName != null)
                    employeeController.Update(Data.employee);
                else
                    employeeController.Delete(Data.employee.ID);
            }
            UpdateDataGrid(emp.DepartmentID);
            Data.employee = null;
        }

        private void DeleteToolStripEmpMenuItem_Click(object sender, EventArgs e)
        {
            var emp = (Employee)dataGridView1.CurrentRow.DataBoundItem;
            employeeController.Delete(emp.ID);
            UpdateDataGrid(emp.DepartmentID);
        }

        private void buttonAddEmp_Click(object sender, EventArgs e)
        {
            Data.employee = null;
            Data.departmentsList = departmentController.GetDepartments();
            EmployeeForm empForm = new EmployeeForm();
            if (empForm.ShowDialog() == DialogResult.OK)
            {
                employeeController.Create(Data.employee);
                UpdateDataGrid(Data.employee.DepartmentID);
            }
            Data.employee = null;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            SortOrder so = SortOrder.None;
            if (grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                so = SortOrder.Descending;
            }
            else
            {
                so = SortOrder.Ascending;
            }
            //set SortGlyphDirection after databinding otherwise will always be none 
            Sort(grid.Columns[e.ColumnIndex].Name, so);
            grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = so;
        }
        private void Sort(string column, SortOrder sortOrder)
        {
            switch (column)
            {
                case "FirstName":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView1.DataSource = empList.OrderBy(x => x.FirstName).ToList();
                        }
                        else
                        {
                            dataGridView1.DataSource = empList.OrderByDescending(x => x.FirstName).ToList();
                        }
                        break;
                    }
                case "SurName":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView1.DataSource = empList.OrderBy(x => x.SurName).ToList();
                        }
                        else
                        {
                            dataGridView1.DataSource = empList.OrderByDescending(x => x.SurName).ToList();
                        }
                        break;
                    }
                case "Patronymic":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView1.DataSource = empList.OrderBy(x => x.Patronymic).ToList();
                        }
                        else
                        {
                            dataGridView1.DataSource = empList.OrderByDescending(x => x.Patronymic).ToList();
                        }
                        break;
                    }
                case "DateOfBirth":
                    {
                        if (sortOrder == SortOrder.Ascending)
                        {
                            dataGridView1.DataSource = empList.OrderBy(x => x.DateOfBirth).ToList();
                        }
                        else
                        {
                            dataGridView1.DataSource = empList.OrderByDescending(x => x.DateOfBirth).ToList();
                        }
                        break;
                    }
            }

        }
    }
}
