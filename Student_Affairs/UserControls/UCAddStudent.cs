using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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
using static DevExpress.XtraEditors.Mask.MaskSettings;
using System.Xml.Linq;
using sql_builder;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DashboardCommon;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.Utils.CommonDialogs;
using DevExpress.SpreadsheetSource;
using DevExpress.DataAccess.Excel;

namespace Student_Affairs
{
    public partial class UCAddStudent : DevExpress.XtraEditors.XtraUserControl
    {


        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        private Dashboard _dashboard;


        public UCAddStudent(Dashboard dashboard)
        {
            InitializeComponent();
            _dashboard = dashboard;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
         
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void BtnNew_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtStdName.Enabled = true;
                txtStdName.Text = "";
                txtBadge.Enabled = true;
                txtBadge.Text = "";
                txtDateBirth.Enabled = true;
                txtDateBirth.Text = "";
        
                txtPhoneNumber.Enabled = true;
                txtPhoneNumber.Text = "";
                txtEmail.Enabled = true;
                txtEmail.Text = "";

                txtAddress.Enabled = true;
                txtAddress.Text = "";

                txtSchoolState.Enabled = true;
                txtSchoolState.Text = "";

                DateDirect.Enabled = true;
                DateDirect.Text = "";


                CoBDepartment.Enabled = true;
                CoBDepartment.Text = "";
                ch1.Enabled = true;
                ch2.Enabled = true;

                ch1.Checked = false;
                ch2.Checked = false;
                txtServiceNumber.Enabled = true;
                txtServiceNumber.Text = "";

                txtSkills.Enabled = true;
                txtSkills.Text = "";

                txtSpeicaillist.Enabled = true;
                txtSpeicaillist.Text = "";

            

                TxtExperiance.Enabled = true;
                TxtExperiance.Text = "";

                TxtOldCourses.Enabled = true;
                TxtOldCourses.Text = "";

                TxtFiltrationMethod.Enabled = true;
                TxtFiltrationMethod.Text = "";


                DateApplication.Enabled = true;
                DateApplication.Text = "";



                PicVol.Image = null;
                btnSave1.Enabled = true;
                btnImportImage.Enabled = true;

                // dt = _dbHelp.Return_DT("SuperviserInfoTB_SELECT", null, true);
                // gridControl1.DataSource = dt;
                // dt.Clear();
                DataTable newdt = new DataTable();
                gridControl1.DataSource = newdt;
                for (int i = 0; i < 3; i++)
                {
                    gridView1.AddNewRow();

                }
                gridView1.FocusedRowHandle = 0;

                dt = _dbHelp.Return_DT("ViewStudentInfo", null, true);
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

                if (txtBadge.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل رقم الباج", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtStdName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtDateBirth.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ الميلاد", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSchoolState.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التحصيل الدراسي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


                if (txtEmail.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل البريد الالكتروني", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSpeicaillist.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل التخصص", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtAddress.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل العنوان", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtPhoneNumber.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل رقم الهاتف", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (DateDirect.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل تاريخ المباشرة في العتبة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (CoBDepartment.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل القسم", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (txtServiceNumber.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل سنوات الخدمة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (txtSkills.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل المهارات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (TxtExperiance.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل الخبرات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (TxtOldCourses.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل الدورات السابقة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (TxtFiltrationMethod.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل طريقة الترشيح", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (DateApplication.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل تاريخ التقديم", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }



                SqlParameter[] prm = new SqlParameter[19];

                prm[0] = new SqlParameter("@id", txtBadge.Text);
                prm[1] = new SqlParameter("@FullName", txtStdName.Text);
                prm[2] = new SqlParameter("@id_Educational_achievement", txtSchoolState.Text);
                prm[3] = new SqlParameter("@BirthDate",Convert.ToDateTime( txtDateBirth.Text));
                prm[4] = new SqlParameter("@IsEdit", false);
                prm[5] = new SqlParameter("@Email", txtEmail.Text);
                prm[6] = new SqlParameter("@Specialty", txtSpeicaillist.Text);
                prm[7] = new SqlParameter("@Address", txtAddress.Text);
                prm[8] = new SqlParameter("@Phone", Convert.ToInt64( txtPhoneNumber.Text));
             
                prm[9] = new SqlParameter("@Direct_date", Convert.ToDateTime(DateDirect.Text));
                prm[10] = new SqlParameter("@id_Department", CoBDepartment.Text);
                prm[11] = new SqlParameter("@YearsOfService", txtServiceNumber.Text);
         
                prm[12] = new SqlParameter("@Skills", txtSkills.Text);
                prm[13] = new SqlParameter("@Experiences", TxtExperiance.Text);
                prm[14] = new SqlParameter("@Previous_courses", TxtOldCourses.Text);
                prm[15] = new SqlParameter("@Nomination_method", TxtFiltrationMethod.Text);
                prm[16] = new SqlParameter("@Submission_date", Convert.ToDateTime(DateApplication.Text));

                if (PicVol.Image == null)
                {
                  
                    MessageBox.Show("يجب تحميل صورة للطالب اولاً");
                    return;
                }
              
                MemoryStream ms = new MemoryStream();
                PicVol.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);

                prm[17] = new SqlParameter("@Image", photo_aray);
                // prm[20].Value = arr;

                int checkrd = 0;
                if (ch1.Checked == true)
                {
                    checkrd = 1;
                }
                else
                {
                    checkrd = 0;
                }
                prm[18] = new SqlParameter("@Desire", checkrd);

                string query = $"AddEditStudentInfo";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");
                btnEdit1.Enabled = true;
                btnDelete1.Enabled = true;
                dt = _dbHelp.Return_DT("ViewStudentInfo", null, true);
                gridControl1.DataSource = dt;
             
                BtnNew.Enabled = true;
                btnSave1.Enabled = true;

                string userInput = Student_Affairs.Properties.Settings.Default.username;

                try
                {
                    //string UserID = System.Guid.NewGuid().ToString();
                    //SqlParameter[] prm2 = new SqlParameter[4];

                    //prm2[0] = new SqlParameter("@Guid", UserID);
                    //prm2[1] = new SqlParameter("@UserName", userInput);
                    //prm2[2] = new SqlParameter("@Operation", "عملية حفظ بيانات متطوع");
                    //prm2[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
                    //string squery = "TB_UsersOPInput_Insert";
                    //_dbHelp.ExcuteData(squery, prm2, true);
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

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtBadge.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل رقم الباج", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtStdName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtDateBirth.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ الميلاد", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSchoolState.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التحصيل الدراسي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
             

                if (txtEmail.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل البريد الالكتروني", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSpeicaillist.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل التخصص", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtAddress.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل العنوان", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtPhoneNumber.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل رقم الهاتف", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
           
                if (DateDirect.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل تاريخ المباشرة في العتبة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (CoBDepartment.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل القسم", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtServiceNumber.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل محل الولادة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                

                if (txtSkills.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل المهارات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (TxtExperiance.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل الخبرات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (TxtOldCourses.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل الدورات السابقة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (TxtFiltrationMethod.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل طريقة الترشيح", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (DateApplication.Text == "") { XtraMessageBox.Show(" الرجاء ملئ حقل تاريخ التقديم", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                SqlParameter[] prm = new SqlParameter[19];

                prm[0] = new SqlParameter("@id", txtBadge.Text);
                prm[1] = new SqlParameter("@FullName", txtStdName.Text);
                prm[2] = new SqlParameter("@id_Educational_achievement", txtSchoolState.Text);
                prm[3] = new SqlParameter("@BirthDate", Convert.ToDateTime(txtDateBirth.Text));
                prm[4] = new SqlParameter("@IsEdit", true);
                prm[5] = new SqlParameter("@Email", txtEmail.Text);
                prm[6] = new SqlParameter("@Specialty", txtSpeicaillist.Text);
                prm[7] = new SqlParameter("@Address", txtAddress.Text);
                prm[8] = new SqlParameter("@Phone", Convert.ToInt64(txtPhoneNumber.Text));

                prm[9] = new SqlParameter("@Direct_date", Convert.ToDateTime(DateDirect.Text));
                prm[10] = new SqlParameter("@id_Department", CoBDepartment.Text);
                prm[11] = new SqlParameter("@YearsOfService", txtServiceNumber.Text);

                prm[12] = new SqlParameter("@Skills", txtSkills.Text);
                prm[13] = new SqlParameter("@Experiences", TxtExperiance.Text);
                prm[14] = new SqlParameter("@Previous_courses", TxtOldCourses.Text);
                prm[15] = new SqlParameter("@Nomination_method", TxtFiltrationMethod.Text);
                prm[16] = new SqlParameter("@Submission_date", Convert.ToDateTime(DateApplication.Text));



                MemoryStream ms = new MemoryStream();
                PicVol.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);

                prm[17] = new SqlParameter("@Image", photo_aray);
                // prm[20].Value = arr;
                int checkrd = 0;
               
                if (ch1.Checked == true)
                {
                    checkrd = 1;
                }
                else
                {
                    checkrd = 0;
                }
                prm[18] = new SqlParameter("@Desire", checkrd);
                string query = $"AddEditStudentInfo";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية التعديل بنجاح");
                btnEdit1.Enabled = true;
                btnDelete1.Enabled = true;
                dt = _dbHelp.Return_DT("ViewStudentInfo", null, true);
                gridControl1.DataSource = dt;

                BtnNew.Enabled = true;
                btnSave1.Enabled = true;

                string userInput = Student_Affairs.Properties.Settings.Default.username;


                try
                {
                    //string UserID = System.Guid.NewGuid().ToString();
                    //SqlParameter[] prm2 = new SqlParameter[4];

                    //prm2[0] = new SqlParameter("@Guid", UserID);
                    //prm2[1] = new SqlParameter("@UserName", userInput);
                    //prm2[2] = new SqlParameter("@Operation", "عملية حفظ بيانات متطوع");
                    //prm2[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
                    //string squery = "TB_UsersOPInput_Insert";
                    //_dbHelp.ExcuteData(squery, prm2, true);
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

        private void btnImportImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileOpen = new OpenFileDialog();
                fileOpen.Title = "Open Image file";
                fileOpen.Filter = "(*.JPEG;*.BMP;*.JPG;*.PNG;*.)|*.JPEG;*.BMP;*.JPG;*.PNG";

                if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                    PicVol.Image = Image.FromFile(fileOpen.FileName);
                }
                fileOpen.Dispose();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void UCAddStudent_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("ViewStudentInfo", null, true);
                gridControl1.DataSource = dt;

                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;



                DataTable dtcob = new DataTable();
                dtcob = _dbHelp.Return_DT("selectDepartments", null, true);


                CoBDepartment.Properties.Items.Clear();

                foreach (DataRow row in dtcob.Rows)
                {
                    // Add each item from the result to the combo box
                    CoBDepartment.Properties.Items.Add(row["DepName"].ToString());

                }


                DataTable dtcob2 = new DataTable();
                dtcob2 = _dbHelp.Return_DT("selectEducationalAchievement", null, true);


                txtSchoolState.Properties.Items.Clear();

                foreach (DataRow row in dtcob2.Rows)
                {
                    // Add each item from the result to the combo box
                    txtSchoolState.Properties.Items.Add(row["name"].ToString());

                }




                // Completes the BarManager's initialization (to allow its further customization on the form load)
                barManager1.ForceInitialize();
                // Creates a popup menu.
                PopupMenu menu = new PopupMenu();
                menu.Manager = barManager1;
                // Specifies a collection of vector (SVG) icons.
                barManager1.Images = svgImageCollection1;
                // Creates and initializes the items.
                //BarSubItem itemAdd = new BarSubItem(barManager1, "Add");
                //BarButtonItem itemAddFile = new BarButtonItem(barManager1, "File", 2);
                //BarButtonItem itemAddFolder = new BarButtonItem(barManager1, "Folder", 3);
                //itemAdd.AddItems(new BarItem[] { itemAddFile, itemAddFolder });
                BarButtonItem itemImportExcel = new BarButtonItem(barManager1, "استيراد أكسل", 0);
                BarButtonItem itemExportExcel = new BarButtonItem(barManager1, "تصدير الى أكسل", 1);
                BarButtonItem itemPrinttopdf = new BarButtonItem(barManager1, "تحويل الى Pdf", 2);
                BarButtonItem itemConvertToInterview = new BarButtonItem(barManager1, "تحويل المتقدم الى المقابلة", 3);
                // Adds the items to the popup menu.
                menu.AddItems(new BarItem[] { itemImportExcel, itemExportExcel , itemPrinttopdf, itemConvertToInterview });
                // Creates a separator before the Copy item.
                itemImportExcel.Links[0].BeginGroup = true;
                // Attaches the popup menu to the form.
                barManager1.SetPopupContextMenu(this, menu);
                // Subscribes to the 'ItemClick' event handler to process item clicks.
                barManager1.ItemClick += BarManager1_ItemClick;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }


        }
        void BarManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            

            if (e.Item.Caption == "استيراد أكسل")
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
            else if (e.Item.Caption == "تصدير الى أكسل")
            {
                try
                {
                    if (dockPanel1.Visible == false)
                    {
                        dockPanel1.Visible = true;
                        ExportGridToExcel();
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
                
            }
            else if (e.Item.Caption == "تحويل المتقدم الى المقابلة")
            {
                try
                {
                    try
                    {

                        DataTable dt = GetSelectedRowsAsDataTable(gridView1);


                        int[] array = dt.AsEnumerable()
                                     .Select(row => row.Field<int>("id"))
                                     .ToArray();

                        string TR = string.Empty;

                        foreach (int item in array)
                        {
                            TR += item.ToString() + ',';
                        }

                        SqlParameter[] prm = new SqlParameter[1];

                        prm[0] = new SqlParameter("@Ids", TR);
                        string query = $"addtableinterview";
                        dt = _dbHelp.Return_DT(query, prm, true);
                        XtraMessageBox.Show("تمت عملية الاضافة الى المقابلة بنجاح");

                        gridControl2.DataSource = dt;



                        dynamic mboxResult = XtraMessageBox.Show("هل تريد فتح واجهة المقابلات ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (mboxResult == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {

                            try
                            {
                                if (_dashboard.MainPanel.Controls.Count == 1)
                                {
                                    _dashboard.MainPanel.Controls.Clear();

                                    UCInterView fr = new UCInterView();
                                    fr.Dock = DockStyle.Fill;
                                    _dashboard.MainPanel.Controls.Add(fr);
                                }
                                else
                                {

                                    UCInterView fr = new UCInterView();
                                    fr.Dock = DockStyle.Fill;
                                    _dashboard.MainPanel.Controls.Add(fr);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }

            }

        }
        private void ImportFromExcel()
        {
            openFileDialog1.Filter = "Excel File|*.xlsx;*.xls";
            openFileDialog1.Title = "Import Excel";
            openFileDialog1.Multiselect = false;

            openFileDialog1.ShowDialog();


        }

        private string GetWorkSheetNameByIndex(int p)
        {
            string filePath = openFileDialog1.FileName;
            string worksheetName = "";
            using (ISpreadsheetSource spreadsheetSource = SpreadsheetSourceFactory.CreateSource(filePath))
            {
                IWorksheetCollection worksheetCollection = spreadsheetSource.Worksheets;
                worksheetName = worksheetCollection[p].Name;
            }
            return worksheetName;
        }
        private void ExportGridToExcel()
        {

           

            dt = _dbHelp.Return_DT("SelectStudentInfoAll", null, true);
            gridView3.OptionsSelection.MultiSelect = true;
            gridView3.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            // Assuming you have a GridControl named 'gridControl1' and a GridView named 'gridView1'


            GridView gridView = gridControl3.MainView as GridView;

            if (gridView != null)
            {
                try
                {

                    
                    // Bind the DataTable to the GridView if it's not already bound
                    gridControl3.DataSource = dt;
                   

                    // Open a SaveFileDialog to prompt the user for the save location
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        FileName = "ExportedData.xlsx" // Default filename
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Export the data to the selected Excel file
                        gridView.ExportToXlsx(saveFileDialog.FileName);

                        // Display a success message to the user
                        MessageBox.Show("تم تصدير الملف بنجاح الى  " + saveFileDialog.FileName,
                                        "تصدير الملف بنجاح",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // If an error occurs during export, display the error message
                    MessageBox.Show("هنالك خطأ في تصدير البيانات: " + ex.Message,
                                    "Export Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                // If the GridView is not accessible, show an error message
                MessageBox.Show("GridView is not initialized properly.",
                                "GridView Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
          //      this.departmentsTableAdapter.FillBy(this.studentAffairsDataSet.Departments);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                txtBadge.Enabled = false;
                BtnNew.Enabled = false;

                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@id", gridView1.GetFocusedRowCellValue(STDID).ToString());
                string query = $"SelectStudentinfoByID";
                dt = _dbHelp.Return_DT(query, prm, true);
                if (dt.Rows.Count > 0)
                {
                    txtBadge.Text = dt.Rows[0]["id"].ToString();
                    txtStdName.Text = dt.Rows[0]["FullName"].ToString();

                    // Directly assign DateTime to EditValue
                    txtDateBirth.EditValue = Convert.ToDateTime(dt.Rows[0]["BirthDate"]);
                    txtSchoolState.Text = dt.Rows[0]["id_Educational_achievement"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtSpeicaillist.Text = dt.Rows[0]["Specialty"].ToString();

                    // Set mask for date (if not already done in designer)
                    txtDateBirth.Properties.Mask.MaskType = MaskType.DateTime;
                    txtDateBirth.Properties.Mask.EditMask = "dd/MM/yyyy";

                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtPhoneNumber.Text = dt.Rows[0]["Phone"].ToString();
                    DateDirect.EditValue = Convert.ToDateTime(dt.Rows[0]["Direct_date"]);

                    DateDirect.Properties.Mask.MaskType = MaskType.DateTime;
                    DateDirect.Properties.Mask.EditMask = "dd/MM/yyyy";
                

                    CoBDepartment.Text = dt.Rows[0]["id_Department"].ToString();
                    txtServiceNumber.Text = dt.Rows[0]["YearsOfService"].ToString();
                    txtSkills.Text = dt.Rows[0]["Skills"].ToString();
                    TxtOldCourses.Text = dt.Rows[0]["Previous_courses"].ToString();
                    TxtExperiance.Text = dt.Rows[0]["Experiences"].ToString();
                    TxtFiltrationMethod.Text = dt.Rows[0]["Nomination_method"].ToString();
                    DateApplication.EditValue = Convert.ToDateTime(dt.Rows[0]["Submission_date"]);

                    DateApplication.Properties.Mask.MaskType = MaskType.DateTime;
                    DateApplication.Properties.Mask.EditMask = "dd/MM/yyyy";
             

                    string ddcc = dt.Rows[0]["Desire"].ToString();
                    if (Convert.ToBoolean(ddcc) == true)
                    {
                        ch1.Checked = true;
                        ch2.Checked = false;
                    }
                    else
                    {
                        ch1.Checked = false;
                        ch2.Checked = true;
                    }

                    BtnNew.Enabled = true;
                    btnEdit1.Enabled = true;
                    btnDelete1.Enabled = true;
                    btnSave1.Enabled = false;

                    if (dt.Rows[0]["Image"] == DBNull.Value)
                    {
                        XtraMessageBox.Show("الطالب ليس لديه صورة يرجى اضافة صورة..", "تحــذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        byte[] imgData = (byte[])dt.Rows[0]["Image"];
                        MemoryStream ms = new MemoryStream(imgData);
                        Image img = Image.FromStream(ms);
                        PicVol.Image = img;
                    }
                }
            
                else
                {
                    XtraMessageBox.Show("لا يوجد اي شي");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        public DataTable GetSelectedRowsAsDataTable(GridView gridView)
        {
            // Create a DataTable to hold the selected rows
            DataTable dtSelectedRows = new DataTable();

            // Assuming your GridView is already bound to a DataTable, 
            // you can clone its structure to get the same columns
           // DataTable sourceDataTable = (DataTable)gridView.DataSource;
            dtSelectedRows = dt.Clone();

            // Get the selected row handles
            int[] selectedRowHandles = gridView.GetSelectedRows();

            // Loop through the selected rows and import their data into the new DataTable
            foreach (int rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0) // Make sure it's a valid row
                {
                    DataRow selectedRow = gridView.GetDataRow(rowHandle);
                    dtSelectedRows.ImportRow(selectedRow);
                }
            }

            return dtSelectedRows;
        }

        private void btnTo_InterView_Click(object sender, EventArgs e)
        {


            try
            {

                DataTable dt = GetSelectedRowsAsDataTable(gridView1);


                int[] array = dt.AsEnumerable()
                             .Select(row => row.Field<int>("id"))
                             .ToArray();

                string TR = string.Empty;

                foreach (int item in array)
                {
                    TR += item.ToString() + ',';
                }

                SqlParameter[] prm = new SqlParameter[1];

                prm[0] = new SqlParameter("@Ids", TR);
                string query = $"addtableinterview";
                dt = _dbHelp.Return_DT(query, prm, true);
                XtraMessageBox.Show("تمت عملية الاضافة الى المقابلة بنجاح");

                gridControl2.DataSource = dt;



                dynamic mboxResult = XtraMessageBox.Show("هل تريد فتح واجهة المقابلات ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (mboxResult == DialogResult.No)
                {
                    return;
                }
                else
                {

                    try
                    {
                        if (_dashboard.MainPanel.Controls.Count == 1)
                        {
                            _dashboard.MainPanel.Controls.Clear();

                            UCInterView fr = new UCInterView();
                            fr.Dock = DockStyle.Fill;
                            _dashboard.MainPanel.Controls.Add(fr);
                        }
                        else
                        {

                            UCInterView fr = new UCInterView();
                            fr.Dock = DockStyle.Fill;
                            _dashboard.MainPanel.Controls.Add(fr);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //try
            //{
            //    if (_dashboard.MainPanel.Controls.Count == 1)
            //    {
            //        _dashboard.MainPanel.Controls.Clear();

            //        UCInterView fr = new UCInterView(dt);
            //        fr.Dock = DockStyle.Fill;
            //        _dashboard.MainPanel.Controls.Add(fr);
            //    }
            //    else
            //    {

            //        UCInterView fr = new UCInterView(dt);
            //        fr.Dock = DockStyle.Fill;
            //        _dashboard.MainPanel.Controls.Add(fr);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

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

                        string UserID = gridView1.GetFocusedRowCellValue(STDID).ToString();
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
                                    string squery = "DeleteStudentInfoById";
                                    _dbHelp.ExcuteData(squery, prm, true);
                                }
                            }
                        }
                        else  
                        {
                            prm[0] = new SqlParameter("@id", UserID);  
                            string squery = "DeleteStudentInfoById";
                            _dbHelp.ExcuteData(squery, prm, true);
                        }

                        XtraMessageBox.Show("تمت عملية الحذف بنجاح");

                        dt = _dbHelp.Return_DT("ViewStudentInfo", null, true);
                        gridControl1.DataSource = dt;

                        //try
                        //{
                        //    string UserID = System.Guid.NewGuid().ToString();
                        //    SqlParameter[] prm2 = new SqlParameter[4];

                        //    prm2[0] = new SqlParameter("@Guid", UserID);
                        //    prm2[1] = new SqlParameter("@UserName", userInput);
                        //    prm2[2] = new SqlParameter("@Operation", "عملية حذف بيانات مشرف");
                        //    prm2[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
                        //    string squery2 = "TB_UsersOPInput_Insert";
                        //    _dbHelp.ExcuteData(squery2, prm2, true);
                        //}


                        //catch (Exception ex)
                        //{
                        //    XtraMessageBox.Show(ex.ToString());
                        //}
                    }
                 
                }
                else
                {
                    XtraMessageBox.Show("يجب تحديد صف اولاً......");
                    return;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
           
        }

        private void txtServiceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
          
        }

        private void ch1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch1.Checked == true)
            {
                ch2.Checked = false;
            }
        }

        private void ch2_CheckedChanged(object sender, EventArgs e)
        {
            if (ch2.Checked == true)
            {
                ch1.Checked = false;
            }
        }

        private void txtBadge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string DBNAme = "StudentAffairs";
                _dbHelp.DB_Backup("نسخة اخر تحديث" , DBNAme);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraOpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable newdt = new DataTable();
                foreach (GridColumn column in gridView4.VisibleColumns)
                {
                    newdt.Columns.Add(column.FieldName, column.ColumnType);
                }
                for (int i = 0; i < gridView4.DataRowCount; i++)
                {
                    DataRow row = newdt.NewRow();
                    foreach (GridColumn column in gridView4.VisibleColumns)
                    {
                        row[column.FieldName] = gridView4.GetRowCellValue(i, column);
                    }
                    newdt.Rows.Add(row);

                }

                //for (int i = 0; i < gridView3.DataRowCount; i++)
                //{
                //    rt = gridView3.GetRowCellValue(i, "Trainee_Name").ToString();
                //}

                DataTable dtnew = newdt.Copy();




                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    SqlParameter[] prm = new SqlParameter[19];
                   // UserID = System.Guid.NewGuid().ToString();
                    prm[0] = new SqlParameter("@id", newdt.Rows[i]["id"].ToString());
                    prm[1] = new SqlParameter("@FullName", newdt.Rows[i]["Full Name"].ToString());
                    prm[2] = new SqlParameter("@id_Educational_achievement", newdt.Rows[i]["Educational_achievement"].ToString());
                    prm[3] = new SqlParameter("@BirthDate", Convert.ToDateTime(newdt.Rows[i]["Birth Date"].ToString()));
                    prm[4] = new SqlParameter("@isEdit", false);
                    prm[5] = new SqlParameter("@Email", newdt.Rows[i]["Email"].ToString());
                    prm[6] = new SqlParameter("@Specialty", newdt.Rows[i]["Specialty"].ToString());
                    prm[7] = new SqlParameter("@Address", newdt.Rows[i]["Address"].ToString());
                    prm[8] = new SqlParameter("@Phone", newdt.Rows[i]["Phone"].ToString());
                    prm[9] = new SqlParameter("@Direct_date", Convert.ToDateTime(newdt.Rows[i]["Direct_date"].ToString()));
                    prm[10] = new SqlParameter("@id_Department", newdt.Rows[i]["Department"].ToString());
                    prm[11] = new SqlParameter("@YearsOfService", newdt.Rows[i]["Years Of Service"].ToString());
                    prm[12] = new SqlParameter("@Skills", newdt.Rows[i]["Skills"].ToString());
                    prm[13] = new SqlParameter("@Experiences", newdt.Rows[i]["Experiences"].ToString());
                    prm[14] = new SqlParameter("@Previous_courses", newdt.Rows[i]["Previous_courses"].ToString());
                    prm[15] = new SqlParameter("@Nomination_method", newdt.Rows[i]["Nomination_method"].ToString());
                    prm[16] = new SqlParameter("@Submission_date", Convert.ToDateTime(newdt.Rows[i]["Submission_date"].ToString()));
                    int checkrd = 0;
                    if (newdt.Rows[i]["Desire"].ToString() == "يرغب")
                    {
                        checkrd = 1;
                    }
                    else if (newdt.Rows[i]["Desire"].ToString() == "لا يرغب")
                    {
                        checkrd = 0;
                    }
                    prm[17] = new SqlParameter("@Desire", checkrd);

                    MemoryStream ms = new MemoryStream();
                    Image image = Properties.Resources._02;
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] photo_aray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(photo_aray, 0, photo_aray.Length);

                    prm[18] = new SqlParameter("@Image", photo_aray);

                    string query = $"AddEditStudentInfo";
                    dt = _dbHelp.Return_DT(query, prm, true);
                }

                XtraMessageBox.Show("تمت عملية الحفظ بنجاح");

                string userInput = Student_Affairs.Properties.Settings.Default.username;

            
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ImportFromExcel();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;

            ExcelDataSource source = new ExcelDataSource();
            source.FileName = filePath;

            ExcelWorksheetSettings worksheetSettings = new ExcelWorksheetSettings();
            worksheetSettings.WorksheetName = GetWorkSheetNameByIndex(0);

            ExcelSourceOptions sourceOptions = new ExcelSourceOptions();
            sourceOptions.ImportSettings = worksheetSettings;
            //  sourceOptions.SkipHiddenRows = false;
            // sourceOptions.SkipHiddenColumns = false;
            //   sourceOptions.UseFirstRowAsHeader = true;

            source.SourceOptions = sourceOptions;
            //source.Fill();


            // source.SourceOptions = sourceOptions;
            source.Fill();
            gridControl4.DataSource = source;
            GridColumn issueColumn = gridView4.Columns[0]; // store existing column
            gridView4.PopulateColumns(); // create and populate columns based on data source (this clears the Columns collection first)
                                         // gridView4.Columns.Insert(0, issueColumn); // reinsert the original column
            issueColumn.VisibleIndex = 0; // set its VisibleIndex to 0 so it appears as the first column.
            gridControl4.DataSource = source;
            simpleButton2.Enabled = true;
        }

        private void gridControl4_Click(object sender, EventArgs e)
        {

        }
    }
}
