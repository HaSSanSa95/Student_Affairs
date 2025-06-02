using DevExpress.XtraEditors;
using sql_builder;
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

namespace Student_Affairs
{
    public partial class UCAcademicStage : DevExpress.XtraEditors.XtraUserControl
    {

        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        public UCAcademicStage()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void UCAcademicStage_Load(object sender, EventArgs e)
        {
            dt = _dbHelp.Return_DT("SelectAcademicStages", null, true);
            gridControl1.DataSource = dt;
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm = new SqlParameter[3];

                for (int i2 = 0; i2 < gridView1.DataRowCount; ++i2)
                {
                    if (string.IsNullOrWhiteSpace(Convert.ToString(gridView1.GetRowCellValue(i2, "StageStartDate"))))
                    {


                        continue;


                    }
                    else
                    {

                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            prm[0] = new SqlParameter("@id", gridView1.GetRowCellValue(i, "id").ToString());

                            

                            if (gridView1.GetRowCellValue(i, "StageStartDate").ToString()== "")
                            {
                                prm[1] = new SqlParameter("@StageStartDate",null);
                            }
                            else
                            {
                                 prm[1] = new SqlParameter("@StageStartDate",Convert.ToDateTime( gridView1.GetRowCellValue(i, "StageStartDate").ToString()));
                            }
                           
                            prm[2] = new SqlParameter("@Notes", gridView1.GetRowCellValue(i, "Notes").ToString());
                       

                            string query = $"AcademicStagesEdit";
                            dt = _dbHelp.Return_DT(query, prm, true);
                        }
                    }
                }

                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");


                btnSave1.Enabled = true;

                string userInput = Student_Affairs.Properties.Settings.Default.username;






            }
            catch (Exception ex)
            {
         
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}
