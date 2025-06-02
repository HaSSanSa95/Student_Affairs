using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
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
    public partial class UCVicationAndAbsences : DevExpress.XtraEditors.XtraUserControl
    {

        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();

        public String STDID, MatID;
        public UCVicationAndAbsences()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
              
                txtMatName.Text = "";
                CobVicationType.Enabled = true;
                CobVicationType.Text = "";
               
                txtSTDName.Text = "";
                VGV.DataSource = null;
                txtNumberofhours.Enabled = true;
                txtNumberofhours.Text = "";
                txtNotes.Enabled = true;
                txtNotes.Text = "";

                txtVicDate.Enabled = true;
                txtVicDate.Text = "";

                btnSave1.Enabled = true;    
                //txtSchoolState.Enabled = true;
                //txtSchoolState.Text = "";

                //DateDirect.Enabled = true;
                //DateDirect.Text = "";
            } 
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("VacationsAndAbsencesSelectSTDName_ID", null, true);
                gridControl2.DataSource = dt;

                dt = _dbHelp.Return_DT("MaterialNamesSelect", null, true);
                gridControl3.DataSource = dt;

                dt = _dbHelp.Return_DT("VacationsAndAbsencesSelect", null, true);
                gridControl1.DataSource = dt;


                dt = _dbHelp.Return_DT("VacationsAndAbsencesSelect", null, true);
                gridControl1.DataSource = dt;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {

               txtSTDName.Text = gridView2.GetFocusedRowCellValue("STDFullName").ToString();
                STDID = gridView2.GetFocusedRowCellValue("id_Student").ToString();    
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dockPanel2.Visible == false)
                {
                    dockPanel2.Visible = true;
                    
                }
             
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void GCSTD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dockPanel2.Visible == true)
                {
                    dockPanel2.Visible = false;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void BtnMatSearch_Click(object sender, EventArgs e)
        {
            try { 
            
                if (dockPanel1.Visible == false)
                {
                    dockPanel1.Visible = true;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dockPanel1.Visible == true)
                {
                    dockPanel1.Visible = false;

                }
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

                if (CobVicationType.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل نوع الاجازة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtMatName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم المادة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSTDName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNumberofhours.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل عدد الساعات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNotes.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل الملاحظات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtVicDate.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ الاجازة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                SqlParameter[] prm = new SqlParameter[8];

                prm[0] = new SqlParameter("@id_Student", Convert.ToInt32(STDID));
                prm[1] = new SqlParameter("@id_MaterialNames", Convert.ToInt32(MatID));
                prm[2] = new SqlParameter("@date", Convert.ToDateTime(txtVicDate.Text));
                prm[3] = new SqlParameter("@id", null);
                prm[4] = new SqlParameter("@IsEdit", false);
                prm[5] = new SqlParameter("@Type", CobVicationType.Text);
                prm[6] = new SqlParameter("@NumberOfHours", (txtNumberofhours.Text));
                prm[7] = new SqlParameter("@Notes", txtNotes.Text);
                string query = $"VacationsAndAbsencesEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");
                btnEdit1.Enabled = true;

                dt = _dbHelp.Return_DT("VacationsAndAbsencesSelect", null, true);
                gridControl1.DataSource = dt;

                BtnNew.Enabled = true;
                btnSave1.Enabled = true;
           
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
                string query = $"VacationsAndAbsencesSelectById";
                dt = _dbHelp.Return_DT(query, prm, true);

                if (dt.Rows.Count > 0)
                {
                    CobVicationType.Text = dt.Rows[0]["victype"].ToString();
                    txtSTDName.Text = dt.Rows[0]["FullName"].ToString();
                    txtMatName.Text = dt.Rows[0]["MaterialName"].ToString();
                    STDID = dt.Rows[0]["id_Student"].ToString();
                    MatID = dt.Rows[0]["id_MaterialNames"].ToString(); ;
                    //txtVicDate.Properties.Mask.MaskType = MaskType.DateTime;
                    //txtVicDate.Properties.Mask.EditMask = "dd-MM-yyyy";
                    txtVicDate.EditValue = Convert.ToDateTime(dt.Rows[0]["date"]).ToString("dd/MM/yyyy");
                    txtNumberofhours.Text = dt.Rows[0]["NumberOfHours"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();

                }
                BtnNew.Enabled = true;
                btnDelete1.Enabled = true;
                btnSave1.Enabled = false;
                btnEdit1.Enabled = true;

                SqlParameter[] prm2 = new SqlParameter[2];

                prm2[0] = new SqlParameter("@id_student", dt.Rows[0]["id_Student"].ToString());
                prm2[1] = new SqlParameter("@id_Material", dt.Rows[0]["id_MaterialNames"].ToString());

                dt = _dbHelp.Return_DT("VacationsAndAbsencesViewInfo", prm2, true);
                //LsumHV.Text = dt.Rows[0]["sumHV"].ToString();
                //LsumHA.Text = dt.Rows[0]["sumHA"].ToString();
                //LresidualHA.Text = dt.Rows[0]["residualHA"].ToString();
                //LresidualHV.Text = dt.Rows[0]["residualHV"].ToString();
                //LStatusHA.Text = dt.Rows[0]["residualHA"].ToString();
                //LStatusHV.Text = dt.Rows[0]["residualHV"].ToString();

                VGV.DataSource = dt;







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

                if (CobVicationType.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل نوع الاجازة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtMatName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم المادة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSTDName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNumberofhours.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل عدد الساعات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNotes.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل الملاحظات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtVicDate.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ الاجازة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            

                SqlParameter[] prm = new SqlParameter[8];

                prm[0] = new SqlParameter("@id_Student", Convert.ToInt32(STDID));
                prm[1] = new SqlParameter("@id_MaterialNames", Convert.ToInt32(MatID));
                prm[2] = new SqlParameter("@date", Convert.ToDateTime(txtVicDate.Text));
                prm[3] = new SqlParameter("@id", null);
                prm[4] = new SqlParameter("@IsEdit", false);
                prm[5] = new SqlParameter("@Type", CobVicationType.Text);
                prm[6] = new SqlParameter("@NumberOfHours", (txtNumberofhours.Text));
                prm[7] = new SqlParameter("@Notes", txtNotes.Text);
                string query = $"VacationsAndAbsencesEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");
                btnEdit1.Enabled = true;

                dt = _dbHelp.Return_DT("VacationsAndAbsencesSelect", null, true);
                gridControl1.DataSource = dt;

                BtnNew.Enabled = true;
                btnSave1.Enabled = true;

          
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
                                    int id = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "id"));

                                    // Set the parameter for the stored procedure
                                    prm[0] = new SqlParameter("@id", id);

                                    // Execute the stored procedure to delete the row by ID
                                    string squery = "VacationsAndAbsencesDelete";
                                    _dbHelp.ExcuteData(squery, prm, true);
                                }
                            }
                        }
                        else
                        {
                            prm[0] = new SqlParameter("@id", UserID);
                            string squery = "VacationsAndAbsencesDelete";
                            _dbHelp.ExcuteData(squery, prm, true);
                        }

                        XtraMessageBox.Show("تمت عملية الحذف بنجاح");

                        dt = _dbHelp.Return_DT("VacationsAndAbsencesSelect", null, true);
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

        private void UCVicationAndAbsences_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("VacationsAndAbsencesSelectSTDName_ID", null, true);
                gridControl2.DataSource = dt;

                dt = _dbHelp.Return_DT("MaterialNamesSelect", null, true);
                gridControl3.DataSource = dt;

                dt = _dbHelp.Return_DT("VacationsAndAbsencesSelect", null, true);
                gridControl1.DataSource = dt;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void VGV_CustomDrawRowValueCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e)
        {

            if (VGV.DataSource == null)
            {
                return;
            }

            // Retrieve vacation and absence details
            string id = gridView1.GetFocusedRowCellValue(ID).ToString();
            DataTable dt = GetVacationAbsenceById(id);

            if (dt.Rows.Count > 0)
            {
                PopulateFields(dt);
                BtnNew.Enabled = true;
                btnDelete1.Enabled = true;

                // Retrieve additional information
                DataTable infoDt = GetVacationAbsenceInfo(dt);
                string acceptedValue = e.CellValue.ToString();

                // Update cell color based on status
                Color cellColor = GetCellColorFromDataTable(infoDt, acceptedValue);
                e.Appearance.BackColor = cellColor;
            }

        }
        private DataTable GetVacationAbsenceById(string id)
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@id", id);
            string query = "VacationsAndAbsencesSelectById";
            return _dbHelp.Return_DT(query, prm, true);
        }

        private void PopulateFields(DataTable dt)
        {
            CobVicationType.Text = dt.Rows[0]["victype"].ToString();
            txtSTDName.Text = dt.Rows[0]["FullName"].ToString();
            txtMatName.Text = dt.Rows[0]["MaterialName"].ToString();
            txtVicDate.EditValue = Convert.ToDateTime(dt.Rows[0]["date"]).ToString("dd/MM/yyyy");
            txtNumberofhours.Text = dt.Rows[0]["NumberOfHours"].ToString();
            txtNotes.Text = dt.Rows[0]["Notes"].ToString();
        }

        private DataTable GetVacationAbsenceInfo(DataTable dt)
        {
            SqlParameter[] prm2 = new SqlParameter[2];
            prm2[0] = new SqlParameter("@id_student", dt.Rows[0]["id_Student"].ToString());
            prm2[1] = new SqlParameter("@id_Material", dt.Rows[0]["id_MaterialNames"].ToString());
            return _dbHelp.Return_DT("VacationsAndAbsencesViewInfo", prm2, true);
        }

        private Color GetCellColorFromDataTable(DataTable dataTable, string acceptedValue)
        {
            Color cellColor = GetColorFromDataTable(dataTable, "StatusHV", acceptedValue, "ColorHV");

            if (cellColor.IsEmpty) // Check for empty color from StatusHV
            {
                cellColor = GetColorFromDataTable(dataTable, "StatusHA", acceptedValue, "ColorHA");
            }

            return cellColor.IsEmpty ? Color.Transparent : cellColor; // Default to transparent if no color found
        }

        private Color GetColorFromDataTable(DataTable dataTable, string statusColumn, string acceptedValue, string colorColumn)
        {
            DataRow[] matchingRows = dataTable.Select($"{statusColumn} = '{acceptedValue}'");
            if (matchingRows.Length > 0)
            {
                string colorHex = matchingRows[0][colorColumn].ToString();
                return ColorTranslator.FromHtml(colorHex); // Convert hex to Color
            }
            return Color.Empty; // Return empty if no match found
        }
        private void gridView3_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {

                txtMatName.Text = gridView3.GetFocusedRowCellValue("MaterialName").ToString();
                MatID = gridView3.GetFocusedRowCellValue("id").ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}
