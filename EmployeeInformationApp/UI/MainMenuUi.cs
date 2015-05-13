using System.Windows.Forms;

namespace EmployeeInformationApp.UI
{
    public partial class MainMenuUi : Form
    {
        public MainMenuUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            EmployeeInformationUi employeeInformationUi = new EmployeeInformationUi();
            employeeInformationUi.Show();
        }

        private void findEditButton_Click(object sender, System.EventArgs e)
        {
            SearchAndResultUi searchAndResultUi = new SearchAndResultUi();
            searchAndResultUi.Show();
        }
    }
}
