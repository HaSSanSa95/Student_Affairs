using DevExpress.DashboardCommon.DataProcessing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraRichEdit;
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

namespace Student_Affairs.Forms
{
    public partial class FormSTDProile : DevExpress.XtraEditors.XtraForm
    {
        public int yyyys = 0;
        public FormSTDProile(int ID)
        {
            InitializeComponent();

            yyyys = ID;
        }

        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        private void FormSTDProile_Load(object sender, EventArgs e)
        {


            try
            {
                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@StudentId", yyyys);
                dt = _dbHelp.Return_DT("VStudentInfo", prm, true);

                if (dt.Rows.Count > 0)
                {
                    txtBadge.Text = dt.Rows[0]["id"].ToString();
                    txtStdName.Text = dt.Rows[0]["FullName"].ToString();

                    // Handling BirthDate with DBNull check
                    if (dt.Rows[0]["BirthDate"] != DBNull.Value)
                    {
                        txtDateBirth.EditValue = Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtDateBirth.EditValue = string.Empty; // or another default value
                    }

                    txtSchoolState.Text = dt.Rows[0]["EducationalAchievement"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtSpeicaillist.Text = dt.Rows[0]["Specialty"].ToString();

                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtPhoneNumber.Text = dt.Rows[0]["Phone"].ToString();

                    // Handling Direct_date with DBNull check
                    if (dt.Rows[0]["Direct_date"] != DBNull.Value)
                    {
                        DateDirect.EditValue = Convert.ToDateTime(dt.Rows[0]["Direct_date"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        DateDirect.EditValue = string.Empty; // or another default value
                    }

                    CoBDepartment.Text = dt.Rows[0]["Department"].ToString();
                    txtServiceNumber.Text = dt.Rows[0]["YearsOfService"].ToString();
                    txtSkills.Text = dt.Rows[0]["Skills"].ToString();
                    TxtOldCourses.Text = dt.Rows[0]["Previous_courses"].ToString();
                    TxtExperiance.Text = dt.Rows[0]["Experiences"].ToString();
                    TxtFiltrationMethod.Text = dt.Rows[0]["Nomination_method"].ToString();

                    // Handling Submission_date with DBNull check
                    if (dt.Rows[0]["Submission_date"] != DBNull.Value)
                    {
                        DateApplication.EditValue = Convert.ToDateTime(dt.Rows[0]["Submission_date"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        DateApplication.EditValue = string.Empty; // or another default value
                    }

                    ldisre.Text = dt.Rows[0]["Desire"].ToString();
                    Laccepted.Text = dt.Rows[0]["accepted"].ToString();
                    txtTestDgree.Text = dt.Rows[0]["Test_grade"].ToString();

                    // Handling Test_date with DBNull check
                    if (dt.Rows[0]["Test_date"] != DBNull.Value)
                    {
                        txtTest_Date.Text = Convert.ToDateTime(dt.Rows[0]["Test_date"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        XtraMessageBox.Show("الطالب ليس لديه تاريخ اختبار..", "تحــذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTest_Date.Text = string.Empty; // or another default value
                    }

                    // Handling Interview_date with DBNull check
                    if (dt.Rows[0]["Interview_date"] != DBNull.Value)
                    {
                        txtInterview_Date.Text = Convert.ToDateTime(dt.Rows[0]["Interview_date"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        XtraMessageBox.Show("الطالب ليس لديه تاريخ مقابلة..", "تحــذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtInterview_Date.Text = string.Empty; // or another default value
                    }

                    txt_Interview_Dgree.Text = dt.Rows[0]["Interview_degree"].ToString();
                    txtNotes.Text = dt.Rows[0]["Nodes"].ToString();

                    // Handling Image field with DBNull check
                    if (dt.Rows[0]["Image"] == DBNull.Value)
                    {
                        XtraMessageBox.Show("الطالب ليس لديه صورة يرجى اضافة صورة..", "تحــذير", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                SqlParameter[] prm2 = new SqlParameter[1];
                prm2[0] = new SqlParameter("@StudentId", yyyys);
                dt = _dbHelp.Return_DT("VStudentIMaterial", prm2, true);
                gridControl2.DataSource = dt;
                gridView2.ExpandAllGroups();

                SqlParameter[] prm3 = new SqlParameter[1];
                prm3[0] = new SqlParameter("@FullName", txtStdName.Text);
                dt = _dbHelp.Return_DT("V_ActivityStudentSelect", prm3, true);
                gridControl1.DataSource = dt;
                gridView1.ExpandAllGroups();

                SqlParameter[] prm4 = new SqlParameter[1];
                prm4[0] = new SqlParameter("@FullName", txtStdName.Text);
                dt = _dbHelp.Return_DT("V_VacationsAndAbsencesSelect", prm4, true);
                gridControl3.DataSource = dt;
                gridView3.ExpandAllGroups();

                SqlParameter[] prm5 = new SqlParameter[1];
                prm5[0] = new SqlParameter("@FullName", txtStdName.Text);
                dt = _dbHelp.Return_DT("V_HomelinessSelect", prm5, true);
                gridControl4.DataSource = dt;
                gridView4.ExpandAllGroups();

                SqlParameter[] prm6 = new SqlParameter[1];
                prm6[0] = new SqlParameter("@FullName", txtStdName.Text);
                dt = _dbHelp.Return_DT("V_PracticalitySelect", prm6, true);
                gridControl5.DataSource = dt;
                gridView5.ExpandAllGroups();

                SqlParameter[] prm7 = new SqlParameter[1];
                prm7[0] = new SqlParameter("@FullName", txtStdName.Text);
                dt = _dbHelp.Return_DT("V_ResearchSelect", prm7, true);
                gridControl6.DataSource = dt;
                gridView6.ExpandAllGroups();

                // Completes the BarManager's initialization (to allow its further customization on the form load)
                barManager1.ForceInitialize();
                // Creates a popup menu.
                PopupMenu menu = new PopupMenu();
                menu.Manager = barManager1;
                // Specifies a collection of vector (SVG) icons.
                barManager1.Images = svgImageCollection1;
                // Creates and initializes the items.
                BarButtonItem itemPDF = new BarButtonItem(barManager1, "تحويل الى PDF", 0);
                BarButtonItem itemShow1 = new BarButtonItem(barManager1, "عرض  ملف التطبيق العملي", 1);
                BarButtonItem itemShow2 = new BarButtonItem(barManager1, "عرض  ملف البحوث", 2);
                menu.AddItems(new BarItem[] { itemPDF, itemShow1, itemShow2 });
                barManager1.SetPopupContextMenu(this, menu);
                barManager1.ItemClick += barManager1_ItemClick;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }



        }
        private void OpenPdfInViewer(string filePath)
        {
            try
            {
                // Ensure pdfViewer1 is the PdfViewer control
                pdfViewer1.LoadDocument(filePath); // Load the PDF document directly
                pdfViewer1.ZoomMode = (DevExpress.XtraPdfViewer.PdfZoomMode)100;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenWordInViewer(string filePath)
        {
            try
            {
                using (RichEditDocumentServer server = new RichEditDocumentServer())
                {
                    server.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);

                    using (MemoryStream pdfStream = new MemoryStream())
                    {
                        server.ExportToPdf(pdfStream);
                        pdfStream.Position = 0; // Reset stream position
                        LoadPdfInViewer(pdfStream);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading Word document: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPdfInViewer(Stream pdfStream)
        {
            try
            {
                pdfViewer1.LoadDocument(pdfStream);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void barManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Caption == "تحويل الى PDF")
            {

                try
                {
                  

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
            }
            else if (e.Item.Caption == "عرض  ملف التطبيق العملي")
            {
                if (dockPanel1.Visible == false)
                {
                    dockPanel1.Visible = true;

                    try
                    {
                        string filePath = Application.StartupPath + gridView5.GetFocusedRowCellValue("ReportPath").ToString();

               

                        if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                        {
                            XtraMessageBox.Show("الملف غير موجود", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string extension = Path.GetExtension(filePath).ToLower();

                        if (extension == ".pdf")
                        {
                            OpenPdfInViewer(filePath);
                        }
                        else if (extension == ".doc" || extension == ".docx")
                        {
                            OpenWordInViewer(filePath);
                        }
                        else
                        {
                            XtraMessageBox.Show("Unsupported file type. Please select a Word or PDF document.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else if (e.Item.Caption == "عرض  ملف البحوث")
            {
                if (dockPanel1.Visible == false)
                {
                    dockPanel1.Visible = true;

                    try
                    {
                        string filePath = Application.StartupPath + gridView6.GetFocusedRowCellValue("FilePath").ToString();



                        if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                        {
                            XtraMessageBox.Show("الملف غير موجود", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string extension = Path.GetExtension(filePath).ToLower();

                        if (extension == ".pdf")
                        {
                            OpenPdfInViewer(filePath);
                        }
                        else if (extension == ".doc" || extension == ".docx")
                        {
                            OpenWordInViewer(filePath);
                        }
                        else
                        {
                            XtraMessageBox.Show("Unsupported file type. Please select a Word or PDF document.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}