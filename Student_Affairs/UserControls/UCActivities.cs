using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
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

namespace Student_Affairs.UserControls
{
    public partial class UCActivities : DevExpress.XtraEditors.XtraUserControl
    {

        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        public UCActivities()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {

                txtActivityName.Enabled = true;
                txtActivityName.Text = "";
                txtActivityKind.Enabled = true;
                txtActivityKind.Text = "";
                txtActivityDate.Enabled = true;
                txtActivityDate.Text = "";

                btnSave1.Enabled = true;
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

                if (txtActivityName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم النشاط", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtActivityKind.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل نوع النشاط", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtActivityDate.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ النشاط", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            
             
                SqlParameter[] prm = new SqlParameter[5];

                prm[0] = new SqlParameter("@ActivityName", txtActivityName.Text);
                prm[1] = new SqlParameter("@TypeOfActivity", txtActivityKind.Text);
                prm[2] = new SqlParameter("@ActivityDate", Convert.ToDateTime(txtActivityDate.Text));
                prm[3] = new SqlParameter("@id", null);
                prm[4] = new SqlParameter("@IsEdit", false);

                string query = $"ActivitiesEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");
                btnEdit1.Enabled = true;

                dt = _dbHelp.Return_DT("ActivitiesSelect", null, true);
                gridControl1.DataSource = dt;

                BtnNew.Enabled = true;
                btnSave1.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtActivityName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم النشاط", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtActivityKind.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل نوع النشاط", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtActivityDate.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ النشاط", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }



                SqlParameter[] prm = new SqlParameter[5];

                prm[0] = new SqlParameter("@ActivityName", txtActivityName.Text);
                prm[1] = new SqlParameter("@TypeOfActivity", txtActivityKind.Text);
                prm[2] = new SqlParameter("@ActivityDate", Convert.ToDateTime(txtActivityDate.Text));
                prm[3] = new SqlParameter("@id", gridView1.GetFocusedRowCellValue(ID).ToString());
                prm[4] = new SqlParameter("@IsEdit", true);

                string query = $"ActivitiesEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");
                btnEdit1.Enabled = true;

                dt = _dbHelp.Return_DT("ActivitiesSelect", null, true);
                gridControl1.DataSource = dt;

                BtnNew.Enabled = true;
                btnSave1.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void UCActivities_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("ActivitiesSelect", null, true);
                gridControl1.DataSource = dt;

               


                DataTable dtcob = new DataTable();
                dtcob = _dbHelp.Return_DT("ActivitiesSelect", null, true);


                COBActivity.DataSource = dtcob;

                //foreach (DataRow row in dtcob.Rows)
                //{
                //    // Add each item from the result to the combo box
                //    COBActivity.Items.Add(row["ActivityName"].ToString());

                //}

                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@id_ActivityStudent", COBActivity.SelectedValue);
                string query = $"ActivityStudentChack";

                dt = _dbHelp.Return_DT(query, prm, true);
                gridControl3.DataSource = dt;




                dt = _dbHelp.Return_DT("ActivityStudentSelect", null, true);
                gridControl2.DataSource = dt;
                gridView2.ExpandAllGroups();



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {

                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@id", gridView1.GetFocusedRowCellValue(ID).ToString());
                string query = $"ActivitiesSelectById";
                dt = _dbHelp.Return_DT(query, prm, true);

                if (dt.Rows.Count > 0)
                {
                    txtActivityName.Text = dt.Rows[0]["ActivityName"].ToString();
                    txtActivityKind.Text = dt.Rows[0]["TypeOfActivity"].ToString();
                 //   txtActivityDate.Text = dt.Rows[0]["ActivityDate"].ToString();
                    


                    txtActivityDate.EditValue = Convert.ToDateTime(dt.Rows[0]["ActivityDate"]);

                    txtActivityDate.Properties.Mask.MaskType = MaskType.DateTime;
                    txtActivityDate.Properties.Mask.EditMask = "dd/MM/yyyy";
                }
                BtnNew.Enabled = true;
                btnDelete1.Enabled = true;
                btnSave1.Enabled = false;
                btnEdit1.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            
                   try
                    {

                if (gridView1.GetSelectedRows().Count() >= 1)
                {
                    dynamic mboxResult = XtraMessageBox.Show("هل انت متاكد من حذف المعلومات ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (mboxResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {

                        string UserID = gridView1.GetFocusedRowCellValue(ID).ToString();
                        SqlParameter[] prm = new SqlParameter[1];  // Create a SQL parameter array

                        int selectedRowCount = gridView1.SelectedRowsCount;

                        if (selectedRowCount > 1)  // If more than one row is selected
                        {
                            int[] selectedRowHandles = gridView1.GetSelectedRows();

                            // Loop through the selected rows
                            foreach (int rowHandle in selectedRowHandles)
                            {
                                if (rowHandle >= 0)  // Make sure the row is valid
                                {
                                    // Get the ID value of the selected row (assuming the column name is "ID")
                                    int id = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "ID"));

                                    // Set the parameter for the stored procedure
                                    prm[0] = new SqlParameter("@id", id);

                                    // Execute the stored procedure to delete the row by ID
                                    string squery = "ActivitiesDelete";
                                    _dbHelp.ExcuteData(squery, prm, true);
                                }
                            }
                        }
                        else
                        {
                            prm[0] = new SqlParameter("@id", UserID);
                            string squery = "ActivitiesDelete";
                            _dbHelp.ExcuteData(squery, prm, true);
                        }

                        XtraMessageBox.Show("تمت عملية الحذف بنجاح");

                        dt = _dbHelp.Return_DT("ActivitiesSelect", null, true);
                        gridControl1.DataSource = dt;

             
                    }

                }
                else
                {
                  
                    return;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void COBActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtActivityID.Text = COBActivity.SelectedValue.ToString();
            splashScreenManager1.ShowWaitForm();
            
           
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@id_ActivityStudent", COBActivity.SelectedValue.ToString());
            string query = $"ActivityStudentChack";

            dt = _dbHelp.Return_DT(query, prm, true);
           
            gridControl3.DataSource = dt;
            splashScreenManager1.CloseWaitForm();

        }
        public DataTable GetCheckedRowsAsDataTable(GridView gridView, string checkColumnName)
        {
            // Create a DataTable to hold the checked rows
            DataTable dtCheckedRows = new DataTable();

            // Check if the DataSource is a DataView or DataTable and get the source DataTable accordingly
            DataTable sourceDataTable;

            if (gridView.DataSource is DataView dataView)
            {
                // Convert the DataView to DataTable
                sourceDataTable = dataView.ToTable();
            }
            else if (gridView.DataSource is DataTable dataTable)
            {
                sourceDataTable = dataTable;
            }
            else
            {
                throw new InvalidCastException("Unsupported data source type. Please bind the grid to a DataTable or DataView.");
            }

            // Clone the structure of the source DataTable
            dtCheckedRows = sourceDataTable.Clone();

            // Loop through the rows in the GridView
            for (int i = 0; i < gridView.RowCount; i++)
            {
                // Check if the row is valid
                if (gridView.IsDataRow(i))
                {
                    // Get the current row
                    DataRow row = gridView.GetDataRow(i);

                    // Check if the checkbox column has a checked value (assuming boolean type)
                    if (row[checkColumnName] != DBNull.Value && Convert.ToBoolean(row[checkColumnName]))
                    {
                        // Import the row if it's checked
                        dtCheckedRows.ImportRow(row);
                    }
                }
            }

            return dtCheckedRows;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetCheckedRowsAsDataTable(gridView3 , "chackActivityStudent");


                int[] array = dt.AsEnumerable()
                             .Select(row => row.Field<int>("id"))
                             .ToArray();

                string TR = string.Empty;

                foreach (int item in array)
                {
                    TR += item.ToString() + ',';
                }

                SqlParameter[] prm = new SqlParameter[2];

                prm[0] = new SqlParameter("@Ids", TR);
                prm[1] = new SqlParameter("@id_ActivityStudent", COBActivity.SelectedValue.ToString());
                string query = $"addtableActivityStudent";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية اضافة الانشطة بنجاح");


                SqlParameter[] prm2 = new SqlParameter[1];
                prm2[0] = new SqlParameter("@id_ActivityStudent", COBActivity.SelectedValue.ToString());
                string query2 = $"ActivityStudentChack";

                dt = _dbHelp.Return_DT(query2, prm2, true);
                gridControl3.DataSource = dt;

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            try
            {

                dt = _dbHelp.Return_DT("ActivityStudentSelect", null, true);
                gridControl2.DataSource = dt;
                gridView2.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
