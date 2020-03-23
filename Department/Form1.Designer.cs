namespace Departments
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonUpdateGrid = new System.Windows.Forms.Button();
            this.treeViewDeps = new System.Windows.Forms.TreeView();
            this.labelDepart = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.buttonAddEmp = new System.Windows.Forms.Button();
            this.buttonAddDep = new System.Windows.Forms.Button();
            this.contextMenuDepartment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditToolStripDepMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripDepMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEmployee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditToolStripEmpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripEmpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuDepartment.SuspendLayout();
            this.contextMenuStripEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(276, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(512, 390);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // buttonUpdateGrid
            // 
            this.buttonUpdateGrid.Location = new System.Drawing.Point(713, 12);
            this.buttonUpdateGrid.Name = "buttonUpdateGrid";
            this.buttonUpdateGrid.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateGrid.TabIndex = 1;
            this.buttonUpdateGrid.Text = "Обновить";
            this.buttonUpdateGrid.UseVisualStyleBackColor = true;
            this.buttonUpdateGrid.Click += new System.EventHandler(this.buttonUpdateGrid_Click);
            // 
            // treeViewDeps
            // 
            this.treeViewDeps.Location = new System.Drawing.Point(12, 48);
            this.treeViewDeps.Name = "treeViewDeps";
            this.treeViewDeps.Size = new System.Drawing.Size(249, 390);
            this.treeViewDeps.TabIndex = 2;
            this.treeViewDeps.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDeps_BeforeExpand);
            this.treeViewDeps.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDeps_BeforeSelect);
            // 
            // labelDepart
            // 
            this.labelDepart.AutoSize = true;
            this.labelDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelDepart.Location = new System.Drawing.Point(13, 12);
            this.labelDepart.Name = "labelDepart";
            this.labelDepart.Size = new System.Drawing.Size(124, 20);
            this.labelDepart.TabIndex = 3;
            this.labelDepart.Text = "Департаменты";
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelEmployee.Location = new System.Drawing.Point(272, 12);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(100, 20);
            this.labelEmployee.TabIndex = 3;
            this.labelEmployee.Text = "Сотрудники";
            // 
            // buttonAddEmp
            // 
            this.buttonAddEmp.Location = new System.Drawing.Point(656, 448);
            this.buttonAddEmp.Name = "buttonAddEmp";
            this.buttonAddEmp.Size = new System.Drawing.Size(132, 23);
            this.buttonAddEmp.TabIndex = 1;
            this.buttonAddEmp.Text = "Добавить сотрудника";
            this.buttonAddEmp.UseVisualStyleBackColor = true;
            this.buttonAddEmp.Click += new System.EventHandler(this.buttonAddEmp_Click);
            // 
            // buttonAddDep
            // 
            this.buttonAddDep.Location = new System.Drawing.Point(12, 448);
            this.buttonAddDep.Name = "buttonAddDep";
            this.buttonAddDep.Size = new System.Drawing.Size(101, 23);
            this.buttonAddDep.TabIndex = 1;
            this.buttonAddDep.Text = "Добавить отдел";
            this.buttonAddDep.UseVisualStyleBackColor = true;
            this.buttonAddDep.Click += new System.EventHandler(this.buttonAddDep_Click);
            // 
            // contextMenuDepartment
            // 
            this.contextMenuDepartment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripDepMenuItem,
            this.DeleteToolStripDepMenuItem});
            this.contextMenuDepartment.Name = "contextMenuStrip1";
            this.contextMenuDepartment.Size = new System.Drawing.Size(129, 48);
            // 
            // EditToolStripDepMenuItem
            // 
            this.EditToolStripDepMenuItem.Name = "EditToolStripDepMenuItem";
            this.EditToolStripDepMenuItem.Size = new System.Drawing.Size(128, 22);
            this.EditToolStripDepMenuItem.Text = "Изменить";
            this.EditToolStripDepMenuItem.Click += new System.EventHandler(this.EditToolStripDepMenuItem_Click);
            // 
            // DeleteToolStripDepMenuItem
            // 
            this.DeleteToolStripDepMenuItem.Name = "DeleteToolStripDepMenuItem";
            this.DeleteToolStripDepMenuItem.Size = new System.Drawing.Size(128, 22);
            this.DeleteToolStripDepMenuItem.Text = "Удалить";
            this.DeleteToolStripDepMenuItem.Click += new System.EventHandler(this.DeleteToolStripDepMenuItem_Click);
            // 
            // contextMenuStripEmployee
            // 
            this.contextMenuStripEmployee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripEmpMenuItem,
            this.DeleteToolStripEmpMenuItem});
            this.contextMenuStripEmployee.Name = "contextMenuStripEmployee";
            this.contextMenuStripEmployee.Size = new System.Drawing.Size(129, 48);
            // 
            // EditToolStripEmpMenuItem
            // 
            this.EditToolStripEmpMenuItem.Name = "EditToolStripEmpMenuItem";
            this.EditToolStripEmpMenuItem.Size = new System.Drawing.Size(128, 22);
            this.EditToolStripEmpMenuItem.Text = "Изменить";
            this.EditToolStripEmpMenuItem.Click += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // DeleteToolStripEmpMenuItem
            // 
            this.DeleteToolStripEmpMenuItem.Name = "DeleteToolStripEmpMenuItem";
            this.DeleteToolStripEmpMenuItem.Size = new System.Drawing.Size(128, 22);
            this.DeleteToolStripEmpMenuItem.Text = "Удалить";
            this.DeleteToolStripEmpMenuItem.Click += new System.EventHandler(this.DeleteToolStripEmpMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.labelDepart);
            this.Controls.Add(this.treeViewDeps);
            this.Controls.Add(this.buttonAddDep);
            this.Controls.Add(this.buttonAddEmp);
            this.Controls.Add(this.buttonUpdateGrid);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuDepartment.ResumeLayout(false);
            this.contextMenuStripEmployee.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonUpdateGrid;
        private System.Windows.Forms.TreeView treeViewDeps;
        private System.Windows.Forms.Label labelDepart;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Button buttonAddEmp;
        private System.Windows.Forms.Button buttonAddDep;
        private System.Windows.Forms.ContextMenuStrip contextMenuDepartment;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripDepMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripDepMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEmployee;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripEmpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripEmpMenuItem;
    }
}

