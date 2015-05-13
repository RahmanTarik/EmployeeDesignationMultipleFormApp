using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.Model;

namespace EmployeeInformationApp.UI
{
    public partial class SearchAndResultUi : Form
    {
        public SearchAndResultUi()
        {
            InitializeComponent();
        }
        EmployeeManager manager = new EmployeeManager();
        List<Employee> employees = new List<Employee>(); 
        private void SearchAndResultUi_Load(object sender, EventArgs e)
        {
            employees.Clear();
            employees = manager.GetAllEmployees();
            LoadSearchData(employees);
        }

        private void LoadSearchData(List<Employee> employees )
        {
            employeeListView.Items.Clear();
            int count = 0;
            foreach (var employee in employees)
            {
                count++;
                ListViewItem item = new ListViewItem(count.ToString());
                item.SubItems.Add(employee.Name);
                item.SubItems.Add(employee.Email);
                item.Tag = employee;
                employeeListView.Items.Add(item);
            }
        }

        List<Employee> employeeList = new List<Employee>();
        private void searchButton_Click(object sender, EventArgs e)
        {
            string name = searchNameTextBox.Text;
            employeeList.Clear();
            employeeList = manager.GetEmployeeByName(name);
            LoadSearchData(employeeList);

        }

        private void employeeListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    searchResultContextMenuStrip.Show(listView, e.Location);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListView.SelectedItems.Count > 0)
            {
                //ListViewItem firstSelectedListViewItem = employeeListView.SelectedItems[0];
                //int employeeId = int.Parse(firstSelectedListViewItem.Text);
                ListViewItem firstSelectedListViewItem = employeeListView.SelectedItems[0];
                Employee selectedEmployee = (Employee)firstSelectedListViewItem.Tag;
                int employeeId = selectedEmployee.Id;
                Employee aEmployee = manager.GetEmployeeById(employeeId);
                EmployeeInformationUi ui = new EmployeeInformationUi(aEmployee);
                ui.Show();
                this.Hide();
                
            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete Selected Item ?", "Delete Item ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (employeeListView.SelectedItems.Count > 0)
                {
                    //ListViewItem firstSelectedListViewItem = employeeListView.SelectedItems[0];
                    //int employeeId = int.Parse(firstSelectedListViewItem.Text);
                    ListViewItem firstSelectedListViewItem = employeeListView.SelectedItems[0];
                    Employee selectedEmployee = (Employee)firstSelectedListViewItem.Tag;
                    int employeeId = selectedEmployee.Id;
                    MessageBox.Show(manager.Delete(employeeId));
                    employees.Clear();
                    employees = manager.GetAllEmployees();
                    LoadSearchData(employees);
                }

                
            }
            else if (dr == DialogResult.No)
            {
               
            }
        }
    }
}
