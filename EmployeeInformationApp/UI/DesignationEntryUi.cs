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
    public partial class DesignationEntryUi : Form
    {
        DesignationManager manager = new DesignationManager();
        public DesignationEntryUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Designation designation = new Designation();
            designation.Code = codeTextBox.Text;
            designation.Title = titleTextBox.Text;
            if (designation.Code !=String.Empty & designation.Title !=String.Empty)
            {
                MessageBox.Show(manager.Insert(designation));
                ClearTextFields();
                EmployeeInformationUi emUi = new EmployeeInformationUi();
                emUi.Show();
                this.Hide();
            }
            else
            {
                if (designation.Code ==String.Empty && designation.Title ==String.Empty)
                {
                    MessageBox.Show("Please Enter Details");
                }
                else if (designation.Code ==String.Empty)
                {
                    MessageBox.Show("Please Enter Code");
                }
                else if (designation.Title == String.Empty)
                {
                    MessageBox.Show("Please Enter Title");
                }
                
            }
            
            
        }

        private void ClearTextFields()
        {
            codeTextBox.Clear();
            titleTextBox.Clear();
        }
    }
}
