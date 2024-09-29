using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Operation
{
    public partial class StudentRegistration : Form
    {
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connStr))
            {               

                using (SqlCommand sqlComm = new SqlCommand("INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)", connection))
                {
                    if (sqlComm.Connection.State == ConnectionState.Closed)
                        sqlComm.Connection.Open();

                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;

                    sqlComm.Parameters.AddWithValue("@FirstName", firstName);
                    sqlComm.Parameters.AddWithValue("@LastName", lastName);
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("Transition Added Sucessfully");
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;

                }
            }
        }
    }
}
