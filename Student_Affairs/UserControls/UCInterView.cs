using DevExpress.DashboardWin.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using sql_builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Affairs
{
    public partial class UCInterView : DevExpress.XtraEditors.XtraUserControl
    {

        public DataTable Dt2 { get; private set; }

        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        public UCInterView()
        {
            InitializeComponent();

           // Dt2 = dt;
        }

        private void panelControl1_Click(object sender, EventArgs e)
        {
            //DataTable newdt = new DataTable();
            //gridControl1.DataSource = newdt;
            //for (int i = 0; i < 3; i++)
            //{
            //    gridView1.AddNewRow();

            //}
            //gridView1.FocusedRowHandle = 0;
        }

        private void UCInterView_Load(object sender, EventArgs e)
        {

            try
            {

             
                dt = _dbHelp.Return_DT("SelectInterView", null, true);
                gridControl1.DataSource = dt;

              

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm = new SqlParameter[7];

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    // Interview_date (Ensure it's a valid date)
                    var interviewDate = gridView1.GetRowCellValue(i, "Interview_date").ToString();
                    if (DateTime.TryParse(interviewDate, out DateTime parsedInterviewDate))
                    {
                        prm[0] = new SqlParameter("@Interview_date", parsedInterviewDate);
                    }
                    else
                    {
                        prm[0] = new SqlParameter("@Interview_date", DBNull.Value); // Handle invalid date (set to NULL)
                    }

                    // Test_date: skip if empty or invalid date
                    var testDate = gridView1.GetRowCellValue(i, "Test_date").ToString();
                    if (string.IsNullOrEmpty(testDate) || !DateTime.TryParse(testDate, out DateTime parsedTestDate))
                    {
                        prm[1] = new SqlParameter("@Test_date", DBNull.Value); // Handle empty or invalid date
                    }
                    else
                    {
                        prm[1] = new SqlParameter("@Test_date", parsedTestDate);
                    }

                    // Interview_degree (no conversion needed, just string)
                    prm[2] = new SqlParameter("@Interview_degree", gridView1.GetRowCellValue(i, "Interview_degree").ToString());

                    // Test_grade: skip if empty or invalid grade
                    var testGrade = gridView1.GetRowCellValue(i, "Test_grade").ToString();
                    if (string.IsNullOrEmpty(testGrade))
                    {
                        prm[3] = new SqlParameter("@Test_grade", DBNull.Value); // Handle empty value
                    }
                    else
                    {
                        prm[3] = new SqlParameter("@Test_grade", testGrade);
                    }

                    // accepted (no conversion needed, just string)
                    prm[4] = new SqlParameter("@accepted", gridView1.GetRowCellValue(i, "accepted").ToString());

                    // Nodes (no conversion needed, just string)
                    prm[5] = new SqlParameter("@Nodes", gridView1.GetRowCellValue(i, "Nodes").ToString());

                    // id_Student (no conversion needed, just string)
                    prm[6] = new SqlParameter("@id_Student", gridView1.GetRowCellValue(i, "id").ToString());

                    // Execute query
                    string query = $"EditInterView";
                    dt = _dbHelp.Return_DT(query, prm, true);
                }

                XtraMessageBox.Show("تمت عملية حفظ المقابلات بنجاح");
                btnSave1.Enabled = true;

                string userInput = Student_Affairs.Properties.Settings.Default.username;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("يجب ملىء الحقول بالكامل");
                XtraMessageBox.Show(ex.ToString());
            }


        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //// Get the value of the 'accepted' column for the current row
            //string acceptedValue = gridView1.GetRowCellValue(e.RowHandle, "accepted")?.ToString();

            //// If the value is 'مقبول', make the row read-only and disallow editing
            //if (acceptedValue == "مقبول")
            //{
            //    // Set the repository item to read-only
            //    e.RepositoryItem.ReadOnly = true; // This makes the cell non-editable
            //}
            //// If the value is 'غير مقبول', allow editing
            //else if (acceptedValue == "غير مقبول")
            //{
            //    // Set the repository item to editable
            //    e.RepositoryItem.ReadOnly = false; // This makes the cell editable
            //}

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string acceptedValue = gridView1.GetRowCellValue(e.RowHandle, "accepted").ToString();

            if (acceptedValue == "مقبول")
            {
                e.Appearance.BackColor = Color.White; // Optional: Change the background color for visual indication
            }
            else if (acceptedValue == "غير مقبول")
            {
                e.Appearance.BackColor = Color.OrangeRed; // Optional: Change the background color for visual indication
            }
        }
    }
}
