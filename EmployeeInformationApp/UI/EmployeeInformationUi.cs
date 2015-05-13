using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.Model;

namespace EmployeeInformationApp.UI
{
    public partial class EmployeeInformationUi : Form
    {
        EmployeeManager employeeManager = new EmployeeManager();
        DesignationManager manager = new DesignationManager();
        List<Designation> designations = new List<Designation>();
        private bool isUpdateMode = false;
        private Employee newEmployee = null;
        public EmployeeInformationUi()
        {
            InitializeComponent();

        }
        public EmployeeInformationUi(Employee aEmployee)
        {
            InitializeComponent();
            newEmployee = aEmployee;

        }


        private void addMoreButton_Click(object sender, EventArgs e)
        {
            DesignationEntryUi designationEntryUi = new DesignationEntryUi();
            designationEntryUi.Show();
            this.Hide();
        }

        private void EmployeeInformationUi_Load(object sender, EventArgs e)
        {
            if (newEmployee != null)
            {
                isUpdateMode = true;
                saveButton.Text = "Update";
                nameTextBox.Text = newEmployee.Name;
                emailTextBox.Text = newEmployee.Email;
                addressTextBox.Text = newEmployee.Address;
            }
            designations.Clear();
            designations = manager.GetAllDesignations();
            LoadDesignationComboBox(designations);

        }

        private void LoadDesignationComboBox(List<Designation> designationssList)
        {
            designationComboBox.Items.Clear();
            designationComboBox.DisplayMember = "Title";
            designationComboBox.ValueMember = "Code";
            designationComboBox.DataSource = null;
            designationComboBox.DataSource = designationssList;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            Employee aEmployee = new Employee();
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            aEmployee.DesignationId = int.Parse(designationComboBox.SelectedValue.ToString());
            if (isUpdateMode)
            {
                aEmployee.Id = newEmployee.Id;
                MessageBox.Show(employeeManager.Update(aEmployee));
                saveButton.Text = "Save";
                ClearTextField();
                this.Hide();
                SearchAndResultUi Ui = new SearchAndResultUi();
                Ui.Show();
            }
            else
            {

                if (nameTextBox.Text != String.Empty && emailTextBox.Text != String.Empty &&
                    addressTextBox.Text != String.Empty)
                {
                    if (emailTextBox.Text.Contains("@") && emailTextBox.Text.Contains(".com"))
                    {
                        MessageBox.Show(employeeManager.Save(aEmployee));
                        ClearTextField();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter valid email");
                    }

                }
                else
                {
                    if (nameTextBox.Text == String.Empty && emailTextBox.Text == String.Empty &&
                        addressTextBox.Text == String.Empty)
                    {
                        MessageBox.Show("Please Enter Details");
                    }
                    else if (nameTextBox.Text == String.Empty)
                    {
                        MessageBox.Show("Enter Your Name");
                    }
                    else if (emailTextBox.Text == String.Empty)
                    {
                        MessageBox.Show("Enter Your Email");
                    }
                    else if (addressTextBox.Text == String.Empty)
                    {
                        MessageBox.Show("Enter Your Address");
                    }

                }
            }
        }

        private void ClearTextField()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            addressTextBox.Clear();

        }

    }
}
