using DevExpress.XtraEditors;
using sql_builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Affairs.UserControls
{
    public partial class US_STD_Status : DevExpress.XtraEditors.XtraUserControl
    {
        public US_STD_Status()
        {
            InitializeComponent();
        }

        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        private void US_STD_Status_Load(object sender, EventArgs e)
        {

            try
            {


                dt = _dbHelp.Return_DT("V_student_status", null, true);
                gridControl1.DataSource = dt;



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}
