using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCommands
{
    public partial class frmAssignedShortcuts : Form
    {
        public frmAssignedShortcuts()
        {
            InitializeComponent();
        }

        private void frmAssignedShortcuts_Load(object sender, EventArgs e)
        {
            populateCbShortcuts();
        }

        private void populateCbShortcuts()
        {
            using (SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=wbpoc;Initial Catalog=DFCommands;Data Source=."))
            {
                try
                {
                    string query = "select ShortName, ShortcutId from tblShortcuts";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblShortcuts");
                    cbShortcut.DisplayMember = "ShortName";
                    cbShortcut.ValueMember = "ShortcutId";
                    cbShortcut.DataSource = ds.Tables["tblShortcuts"];
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!", ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frmMain = (Form1)StaticFormInstances.frmMainInstance;
            this.Hide();
            frmMain.Show();
        }
    }
}
