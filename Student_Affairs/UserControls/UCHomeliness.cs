using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using sql_builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Affairs.UserControls
{
    public partial class UCHomeliness : DevExpress.XtraEditors.XtraUserControl
    {
        public UCHomeliness()
        {
            InitializeComponent();
        }
        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        public String STDID;
        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                 
                    txtSTDName.Text = "";
                    txtDep.Enabled = true;
                    txtDep.Text = "";
                    txtDep.Enabled = true;
                    txtDep.Text = "";

                    txtEvaluation.Enabled = true;
                    txtEvaluation.Text = "";
                    txtDateHome.Enabled = true;
                    txtDateHome.Text = "";


                    btnSave1.Enabled = true;
                    txtNotes.Enabled = true;
                    txtNotes.Text = "";

                  //  btnAddFile.Enabled = true;
                    BtnstdShow.Enabled = true;
             //  btnFileOpen.Enabled = true;
                    //DateDirect.Text = "";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void UCHomeliness_Load(object sender, EventArgs e)
        {
            dt = _dbHelp.Return_DT("ResearchSelectSTDName_ID", null, true);
            gridControl2.DataSource = dt;

            dt = _dbHelp.Return_DT("HomelinessSelect", null, true);
            gridControl1.DataSource = dt;

            DataTable dtcob = new DataTable();
            dtcob = _dbHelp.Return_DT("selectDepartments", null, true);


            txtDep.Properties.Items.Clear();

            foreach (DataRow row in dtcob.Rows)
            {
                // Add each item from the result to the combo box
                txtDep.Properties.Items.Add(row["DepName"].ToString());

            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

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

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDep.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل القسم", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSTDName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
              
                if (txtEvaluation.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التقييم النهائي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNotes.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل الملاحظات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                
                if (txtDateHome.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ المعايشة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


                SqlParameter[] prm = new SqlParameter[7];

                prm[0] = new SqlParameter("@id_Student", Convert.ToInt32(STDID));
                prm[1] = new SqlParameter("@id", null);
                prm[2] = new SqlParameter("@date", txtDateHome.Text);
          
                prm[3] = new SqlParameter("@IsEdit", false);
                prm[4] = new SqlParameter("@Evaluation", txtEvaluation.Text);
                prm[5] = new SqlParameter("@id_Department", txtDep.Text );
                prm[6] = new SqlParameter("@Notes", txtNotes.Text);
                string query = $"HomelinessEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                dt = _dbHelp.Return_DT("HomelinessSelect", null, true);
                gridControl1.DataSource = dt;



                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");
                btnEdit1.Enabled = true;



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
                if (txtDep.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل القسم", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSTDName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (txtEvaluation.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التقييم النهائي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNotes.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل الملاحظات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (txtDateHome.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ المعايشة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


                SqlParameter[] prm = new SqlParameter[7];

                prm[0] = new SqlParameter("@id_Student", Convert.ToInt32(STDID));
                prm[1] = new SqlParameter("@id", gridView1.GetFocusedRowCellValue(idd).ToString());
                prm[2] = new SqlParameter("@date", txtDateHome.Text);

                prm[3] = new SqlParameter("@IsEdit", true);
                prm[4] = new SqlParameter("@Evaluation", txtEvaluation.Text);
                prm[5] = new SqlParameter("@id_Department", txtDep.Text);
                prm[6] = new SqlParameter("@Notes", txtNotes.Text);
                string query = $"HomelinessEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                dt = _dbHelp.Return_DT("HomelinessSelect", null, true);
                gridControl1.DataSource = dt;



                XtraMessageBox.Show("تمت عملية الـــتعديل بنجــاح");
                btnEdit1.Enabled = true;



                BtnNew.Enabled = true;
                btnSave1.Enabled = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void BtnstdShow_Click(object sender, EventArgs e)
        {
            try
            {
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

                        string UserID = gridView1.GetFocusedRowCellValue(idd).ToString();
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
                                    string squery = "HomelinessDelete";
                                    _dbHelp.ExcuteData(squery, prm, true);
                                }
                            }
                        }
                        else
                        {
                            prm[0] = new SqlParameter("@id", UserID);
                            string squery = "HomelinessDelete";
                            _dbHelp.ExcuteData(squery, prm, true);
                        }

                        XtraMessageBox.Show("تمت عملية الحذف بنجاح");

                        dt = _dbHelp.Return_DT("HomelinessSelect", null, true);
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {

                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@id", gridView1.GetFocusedRowCellValue(idd).ToString());
                string query = $"HomelinessSelectById";
                dt = _dbHelp.Return_DT(query, prm, true);

                if (dt.Rows.Count > 0)
                {
                    txtSTDName.Text = dt.Rows[0]["FullName"].ToString();
                    
                    txtDep.Text = dt.Rows[0]["Department"].ToString();
                    txtDateHome.EditValue = Convert.ToDateTime(dt.Rows[0]["hdate"]);

                    txtDateHome.Properties.Mask.MaskType = MaskType.DateTime;
                    txtDateHome.Properties.Mask.EditMask = "dd/MM/yyyy";

                    txtEvaluation.Text = dt.Rows[0]["Evaluation"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                   
                    STDID = dt.Rows[0]["id_Student"].ToString();
               
                }
                BtnNew.Enabled = true;
                btnDelete1.Enabled = true;
                btnEdit1.Enabled = true;
                btnSave1.Enabled = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}
