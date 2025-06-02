using DevExpress.DataAccess.Native.Data;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
using DataTable = System.Data.DataTable;

namespace Student_Affairs.UserControls
{
    public partial class UCMaterialStudent : DevExpress.XtraEditors.XtraUserControl
    {


        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        public UCMaterialStudent()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dt = _dbHelp.Return_DT("MaterialNamesSelect", null, true);
            gridControl1.DataSource = dt;
        }

        private void UCMaterialStudent_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("MaterialNamesSelect", null, true);
                gridControl1.DataSource = dt;
                gridView1.ExpandAllGroups();

                DataTable dtcob = new DataTable();
                dtcob = _dbHelp.Return_DT("StagesSelect", null, true);


                CobStage.Properties.Items.Clear();

                foreach (DataRow row in dtcob.Rows)
                {
                    // Add each item from the result to the combo box
                    CobStage.Properties.Items.Add(row["name"].ToString());

                }








                //gridView2.OptionsSelection.MultiSelect = true;
                //gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


                dt = _dbHelp.Return_DT("MaterialsStudentSelect", null, true);
                gridControl2.DataSource = dt;
                gridView2.ExpandAllGroups();
                gridView2.ValidatingEditor += gridView2_ValidatingEditor;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                CobStage.Enabled = true;
                CobStage.Text = "";

                txtMatName.Enabled = true;
                txtMatName.Text = "";

                txtNumberofhours.Enabled = true;
                txtNumberofhours.Text = "";

                txtProfName.Enabled = true;
                txtProfName.Text = "";

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

                if (txtMatName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم المادة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNumberofhours.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل عدد ساعات المادة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtProfName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الاستاذ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (CobStage.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل المرحلة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


                SqlParameter[] prm = new SqlParameter[5];

                prm[0] = new SqlParameter("@NumberOfHours", txtNumberofhours.Text);
                prm[1] = new SqlParameter("@Stage", CobStage.Text);
                prm[2] = new SqlParameter("@MaterialName", txtMatName.Text);
                prm[3] = new SqlParameter("@ProfessorName", txtProfName.Text);
                prm[4] = new SqlParameter("@IsEdit", false);

                string query = $"MaterialNamesEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");
                btnEdit1.Enabled = true;
               
                dt = _dbHelp.Return_DT("MaterialNamesSelect", null, true);
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
                string query = $"MaterialNameSelectById";
                dt = _dbHelp.Return_DT(query, prm, true);

                if (dt.Rows.Count > 0)
                {
                    txtMatName.Text = dt.Rows[0]["MaterialName"].ToString();
                    txtNumberofhours.Text = dt.Rows[0]["NumberOfHours"].ToString();
                    txtProfName.Text = dt.Rows[0]["ProfessorName"].ToString();
                    CobStage.Text = dt.Rows[0]["Stage"].ToString();
                    
                }
                BtnNew.Enabled=true;    
                btnEdit1.Enabled=true;
                btnSave1.Enabled = false;
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

                if (txtMatName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم المادة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNumberofhours.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل عدد ساعات المادة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtProfName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الاستاذ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (CobStage.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل المرحلة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


                SqlParameter[] prm = new SqlParameter[6];

                prm[0] = new SqlParameter("@NumberOfHours", txtNumberofhours.Text);
                prm[1] = new SqlParameter("@Stage", CobStage.Text);
                prm[2] = new SqlParameter("@MaterialName", txtMatName.Text);
                prm[3] = new SqlParameter("@ProfessorName", txtProfName.Text);
                prm[4] = new SqlParameter("@IsEdit", true);
                prm[5] = new SqlParameter("@id" , gridView1.GetFocusedRowCellValue(ID).ToString());
                string query = $"MaterialNamesEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية التعديل بنجاح");
                btnEdit1.Enabled = true;
                
                dt = _dbHelp.Return_DT("MaterialNamesSelect", null, true);
                gridControl1.DataSource = dt;

                BtnNew.Enabled = true;
                btnSave1.Enabled = false;
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
               // SqlParameter[] prm = new SqlParameter[4];

                // Iterate over all rows in the grid view
                for (int i2 = 0; i2 < gridView2.DataRowCount; ++i2)
                {
                    List<SqlParameter> prm = new List<SqlParameter>();

                    // Check each required field individually and add to the SQL parameters if not empty or null
                    object degreeValue = gridView2.GetRowCellValue(i2, "Degree");
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(degreeValue)))
                    {
                        prm.Add(new SqlParameter("@Degree", degreeValue == null ? (object)DBNull.Value : Convert.ToInt32(degreeValue)));
                    }

                    object evaluationValue = gridView2.GetRowCellValue(i2, "Evaluation");
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(evaluationValue)))
                    {
                        prm.Add(new SqlParameter("@Evaluation", evaluationValue == null ? (object)DBNull.Value : Convert.ToInt32(evaluationValue)));
                    }

                    object notesValue = gridView2.GetRowCellValue(i2, "Notes");
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(notesValue)))
                    {
                        prm.Add(new SqlParameter("@Notes", string.IsNullOrWhiteSpace(Convert.ToString(notesValue)) ? (object)DBNull.Value : notesValue.ToString()));
                    }

                    object idValue = gridView2.GetRowCellValue(i2, "id");
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(idValue)))
                    {
                        prm.Add(new SqlParameter("@id", idValue == null ? (object)DBNull.Value : idValue.ToString()));
                    }

                    // Only execute the query if there are parameters to process (i.e., some non-empty fields)
                    if (prm.Count > 0)
                    {
                        // Convert the list to an array for the SQL helper
                        string query = "MaterialsStudentEdit";
                        dt = _dbHelp.Return_DT(query, prm.ToArray(), true);
                    }
                }

                // Show success message
                XtraMessageBox.Show("تمت عملية حفظ الدرجات بنجاح");

                // Reload the data to reflect the updated values
                dt = _dbHelp.Return_DT("MaterialsStudentSelect", null, true);
                gridControl2.DataSource = dt;

                // Enable the save button
                btnSave1.Enabled = true;
            }
            catch (Exception ex)
            {
                // Show error messages
                XtraMessageBox.Show("يجب ملىء الحقول بالكامل");
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            // Check if the edited column is the target column
            if (view.FocusedColumn.FieldName == "Degree") // Replace with your column name
            {
                if (int.TryParse(e.Value as string, out int value))
                {
                    if (value < 1 || value > 100)
                    {
                        e.Valid = false;
                        e.ErrorText = "يجب ان تكون الدرجة من 1 الى 100";
                    }
                }
                else
                {
                    e.Valid = false;
                    e.ErrorText = "يجب ان تكون الدرجة من 1 الى 100";
                }
            }


            if (view.FocusedColumn.FieldName == "Evaluation") // Replace with your column name
            {
                if (int.TryParse(e.Value as string, out int value))
                {
                    if (value < 1 || value > 100)
                    {
                        e.Valid = false;
                        e.ErrorText = "يجب ان تكون الدرجة من 1 الى 100";
                    }
                }
                else
                {
                    e.Valid = false;
                    e.ErrorText = "يجب ان تكون الدرجة من 1 الى 100";
                }
            }

        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;

            // Get the value from the "Degree" column
            object cellValue = view.GetRowCellValue(e.RowHandle, "Degree");

            // Ensure the value is not null and can be parsed to an integer
            if (cellValue != null && int.TryParse(cellValue.ToString(), out int acceptedValue))
            {
                if (acceptedValue >= 50)
                {
                    e.Appearance.BackColor = Color.White; // Change color for acceptedValue > 10
                }
                else if (acceptedValue <= 50)
                {
                    e.Appearance.BackColor = Color.OrangeRed; // Change color for acceptedValue <= 10
                }
            }
        }

        private void ch2_CheckedChanged(object sender, EventArgs e)
        {
            if (ch2.Checked == true) 
                {
                dt = _dbHelp.Return_DT("MaterialsStudentSelect_F", null, true);
                gridControl2.DataSource = dt;
                gridView2.ExpandAllGroups();
                gridView2.ValidatingEditor += gridView2_ValidatingEditor;
            }
            else
            {
                dt = _dbHelp.Return_DT("MaterialsStudentSelect", null, true);
                gridControl2.DataSource = dt;
                gridView2.ExpandAllGroups();
                gridView2.ValidatingEditor += gridView2_ValidatingEditor;
            }
 
        }
    }
}
