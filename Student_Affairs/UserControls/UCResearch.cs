using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using sql_builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.Pdf;
using DevExpress.XtraPrinting;

using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraReports.UI;

namespace Student_Affairs.UserControls
{
    public partial class UCResearch : DevExpress.XtraEditors.XtraUserControl
    {
        public UCResearch()
        {
            InitializeComponent();
        }
        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();
        public String STDID;
        private void UCResearch_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("ResearchSelectSTDName_ID", null, true);
                gridControl2.DataSource = dt;

                dt = _dbHelp.Return_DT("ResearchSelect", null, true);
                gridControl1.DataSource = dt;
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
               
                txtSTDName.Text = "";
                txtTilteResearch.Enabled = true;
                txtTilteResearch.Text = "";
             
                txtFilepath.Text = "";
                pdfViewer1.CloseDocument();
                txtEvaluation.Enabled = true;
                txtEvaluation.Text = "";
                txtDateDis.Enabled = true;
                txtDateDis.Text = "";

                txtApper.Enabled = true;
                txtApper.Text = "";

                btnSave1.Enabled = true;
                txtNotes.Enabled = true;
                txtNotes.Text = "";

                btnAddFile.Enabled = true;
                BtnstdShow.Enabled = true;
                btnFileOpen.Enabled = true;
                //DateDirect.Text = "";
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

        private void gridView3_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txtFilepath.Text;

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

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtTilteResearch.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل عنوان البحث", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSTDName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtFilepath.Text == "") { XtraMessageBox.Show("الرجاء رفع حقل رابط الملف", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtEvaluation.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التقييم النهائي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNotes.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل الملاحظات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtApper.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التقدير النهائي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtDateDis.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ المناقشة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }





                //string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

                //// Define the "Research" directory
                //string researchDirectory = Path.Combine(projectDirectory, "Research");

                //// Get the file path from the text box
                //string filePath = txtFilepath.Text  ;

                //// Create the Research directory if it doesn't exist
                //if (!Directory.Exists(researchDirectory))
                //{
                //    Directory.CreateDirectory(researchDirectory);
                //}

                //// Define the file name and destination path
                //string fileName = Path.GetFileName(filePath);
                //string destinationPath = Path.Combine(researchDirectory, fileName);

                //// Check if the file already exists in the destination path
                //if (File.Exists(destinationPath))
                //{
                //    // File exists, delete the old one
                //    File.Delete(destinationPath);
                //}

                //// Copy the new file to the destination directory
                //File.Copy(filePath, destinationPath, overwrite: false);  // Don't overwrite if the file exists, since we already deleted it

                //// Optionally, show the relative path of the copied file
                //string relativePath = Path.GetFullPath(destinationPath).Replace(Path.GetPathRoot(destinationPath), "").TrimStart(Path.DirectorySeparatorChar);
                //// XtraMessageBox.Show(relativePath); // Display the relative path

                //try
                //{
                //    File.Copy(filePath, destinationPath, overwrite: false);  // Don't overwrite if the file exists (we've already deleted it)
                //                                                             // Optionally, show the relative path of the copied file
                //    string relativePath1 = Path.GetFullPath(destinationPath).Replace(Path.GetPathRoot(destinationPath), "").TrimStart(Path.DirectorySeparatorChar);
                //    XtraMessageBox.Show("File copied to: " + relativePath1);  // Display the relative path (or any other message)
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show("Error copying file: " + ex.Message);  // Show error if there is one
                //}

                //// You can build the relative path string like this:
                //string slash = "\\Research\\" +   fileName;

                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Define the "Research" directory on your local machine
                string researchDirectory = Path.Combine(projectDirectory, "Research");

                // Get the file path from the text box (this should be the path of the file you want to copy)
                string filePath = txtFilepath.Text;  // Example: "\\\\10.112.30.20\\sharezaid\\std\\Student_Affairs_Files\\fileName.extension"

                // Ensure the "Research" directory exists locally
                if (!Directory.Exists(researchDirectory))
                {
                    Directory.CreateDirectory(researchDirectory);
                }

                // Get the file name from the full file path
                string fileName = Path.GetFileName(filePath);

                // Define the destination path for the local "Research" directory
                string destinationPath = Path.Combine(researchDirectory, fileName);

                // Check if the file already exists in the local destination path
                if (File.Exists(destinationPath))
                {
                    // If the file exists, delete it before copying the new one
                    File.Delete(destinationPath);
                }

                // Copy the file to the local "Research" directory
                try
                {
                    // Copy the file to the local "Research" directory
                    File.Copy(filePath, destinationPath, overwrite: false);  // Don't overwrite if the file exists (we've already deleted it)

                    // Optionally, show the relative path of the copied file
                    string relativePath = Path.GetFullPath(destinationPath).Replace(Path.GetPathRoot(destinationPath), "").TrimStart(Path.DirectorySeparatorChar);
                   // XtraMessageBox.Show("تم نسخ الملف في ملف البرنامج: " + relativePath);  // Display the relative path (or any other message)

                    // Now copy the file to the server path
                    string serverDirectory = @"\\10.112.30.20\sharezaid\std\Student_Affairs_Files\Research";  // Server directory path
                    string serverDestinationPath = Path.Combine(serverDirectory, fileName);

                    // Check if the file already exists on the server path
                    if (File.Exists(serverDestinationPath))
                    {
                        // If the file exists, delete it before copying the new one
                        File.Delete(serverDestinationPath);
                    }

                    // Copy the file to the server directory
                    File.Copy(filePath, serverDestinationPath, overwrite: false);  // Don't overwrite if the file exists (we've already deleted it)

                   // XtraMessageBox.Show("تم نسخ الملف في السيرفر: " + serverDestinationPath);  // Display server copy message
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error copying file: " + ex.Message);  // Show error if there is one
                }
                string slash = "\\Research\\" + fileName;



                SqlParameter[] prm = new SqlParameter[8];

                prm[0] = new SqlParameter("@id_Student", Convert.ToInt32(STDID));
                prm[1] = new SqlParameter("@title", txtTilteResearch.Text);
                prm[2] = new SqlParameter("@date", txtDateDis.Text);
                prm[3] = new SqlParameter("@FilePath",  slash);
                prm[4] = new SqlParameter("@IsEdit", false);
                prm[5] = new SqlParameter("@Evaluation", txtEvaluation.Text);
                prm[6] = new SqlParameter("@Appreciation", (txtApper.Text));
                prm[7] = new SqlParameter("@Notes", txtNotes.Text);
                string query = $"ResearchEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                dt = _dbHelp.Return_DT("ResearchSelect", null, true);
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

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {

                SqlParameter[] prm = new SqlParameter[1];
                prm[0] = new SqlParameter("@id_Student", gridView1.GetFocusedRowCellValue(ID).ToString());
                string query = $"ResearchSelectById";
                dt = _dbHelp.Return_DT(query, prm, true);

                if (dt.Rows.Count > 0)
                {
                    txtSTDName.Text = dt.Rows[0]["FullName"].ToString();
                    //txtDateDis.Text = dt.Rows[0]["rdate"].ToString();
                    txtApper.Text = dt.Rows[0]["Appreciation"].ToString();

                    txtDateDis.EditValue = Convert.ToDateTime(dt.Rows[0]["rdate"]);

                    txtDateDis.Properties.Mask.MaskType = MaskType.DateTime;
                    txtDateDis.Properties.Mask.EditMask = "dd/MM/yyyy";

                    txtEvaluation.Text = dt.Rows[0]["Evaluation"].ToString();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString();
                    STDID = dt.Rows[0]["id_Student"].ToString();


                    string serverDirectory = @"\\10.112.30.20\sharezaid\std\Student_Affairs_Files";  // Server directory path


                    string path = serverDirectory + dt.Rows[0]["FilePath"].ToString();

            

                   

                    txtFilepath.Text = path;
                    txtTilteResearch.Text = dt.Rows[0]["title"].ToString(); ;   
                }
                BtnNew.Enabled = true;
                btnDelete1.Enabled = true;
                btnEdit1.Enabled = true;    
                btnSave1.Enabled = false;    

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Set the filter for PDF and Word documents
                    openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|Word Files (*.doc;*.docx)|*.doc;*.docx";
                    openFileDialog.Title = "Select a PDF or Word Document";

                    // Show the dialog and get the result
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected file path
                        string filePath = openFileDialog.FileName;
                        txtFilepath.Text = filePath.ToString();
                    }
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

                if (txtTilteResearch.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل عنوان البحث", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtSTDName.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل اسم الطالب", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtFilepath.Text == "") { XtraMessageBox.Show("الرجاء رفع حقل رابط الملف", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtEvaluation.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التقييم النهائي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtNotes.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل الملاحظات", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtApper.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل التقدير النهائي", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txtDateDis.Text == "") { XtraMessageBox.Show("الرجاء ملئ حقل تاريخ المناقشة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Define the "Research" directory on your local machine
                string researchDirectory = Path.Combine(projectDirectory, "Research");

                // Get the file path from the text box (this should be the path of the file you want to copy)
                string filePath = txtFilepath.Text;  // Example: "\\\\10.112.30.20\\sharezaid\\std\\Student_Affairs_Files\\fileName.extension"

                // Ensure the "Research" directory exists locally
                if (!Directory.Exists(researchDirectory))
                {
                    Directory.CreateDirectory(researchDirectory);
                }

                // Get the file name from the full file path
                string fileName = Path.GetFileName(filePath);

                // Define the destination path for the local "Research" directory
                string destinationPath = Path.Combine(researchDirectory, fileName);

                // Check if the file already exists in the local destination path
                if (File.Exists(destinationPath))
                {
                    // If the file exists, delete it before copying the new one
                    File.Delete(destinationPath);
                }

                try
                {
                    // If it's a text file, you can read and modify the content here
                    if (filePath.EndsWith(".txt"))  // Check if the file is a text file
                    {
                        // Read the content of the text file
                        string fileContent = File.ReadAllText(filePath);

                        // Example modification: Append a line of text
                        fileContent += "\nThis is the modified content added during the editing process.";

                        // Save the modified content back to the file (you could overwrite it or save to a new file)
                        File.WriteAllText(filePath, fileContent);
                    }

                    // Now copy the file to the local "Research" directory
                    File.Copy(filePath, destinationPath, overwrite: false);  // Don't overwrite if the file exists (we've already deleted it)

                    // Optionally, show the relative path of the copied file
                    string relativePath = Path.GetFullPath(destinationPath).Replace(Path.GetPathRoot(destinationPath), "").TrimStart(Path.DirectorySeparatorChar);
             //       XtraMessageBox.Show("File copied to local path: " + relativePath);  // Display the relative path (or any other message)

                    // Now copy the file to the server path
                    string serverDirectory = @"\\10.112.30.20\sharezaid\std\Student_Affairs_Files\Research";  // Server directory path
                    string serverDestinationPath = Path.Combine(serverDirectory, fileName);

                    // Check if the file already exists on the server path
                    if (File.Exists(serverDestinationPath))
                    {
                        // If the file exists, delete it before copying the new one
                        File.Delete(serverDestinationPath);
                    }

                    // Copy the file to the server directory
                    File.Copy(filePath, serverDestinationPath, overwrite: false);  // Don't overwrite if the file exists (we've already deleted it)

                   // XtraMessageBox.Show("File copied to server path: " + serverDestinationPath);  // Display server copy message
                }
                catch (Exception ex)
                {
                  //  XtraMessageBox.Show("Error copying file: " + ex.Message);  // Show error if there is one
                }

                string slash = "\\Research\\" +   fileName;



                SqlParameter[] prm = new SqlParameter[8];

                prm[0] = new SqlParameter("@id_Student", Convert.ToInt32(STDID));
                prm[1] = new SqlParameter("@title", txtTilteResearch.Text);
                prm[2] = new SqlParameter("@date", txtDateDis.Text);
                prm[3] = new SqlParameter("@FilePath", slash );
                prm[4] = new SqlParameter("@IsEdit", true);
                prm[5] = new SqlParameter("@Evaluation", txtEvaluation.Text);
                prm[6] = new SqlParameter("@Appreciation", (txtApper.Text));
                prm[7] = new SqlParameter("@Notes", txtNotes.Text);
                string query = $"ResearchEditAdd";
                dt = _dbHelp.Return_DT(query, prm, true);
                dt = _dbHelp.Return_DT("ResearchSelect", null, true);
                gridControl1.DataSource = dt;



                XtraMessageBox.Show("تمت عملية الـــتعديل بنجــاح" );
                btnEdit1.Enabled = true;



                BtnNew.Enabled = true;
                btnSave1.Enabled = false;

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
                                    prm[0] = new SqlParameter("@id_Student", id);

                                    // Execute the stored procedure to delete the row by ID
                                    string squery = "ResearchDelete";
                                    _dbHelp.ExcuteData(squery, prm, true);
                                }
                            }
                        }
                        else
                        {
                            prm[0] = new SqlParameter("@id_Student", UserID);
                            string squery = "ResearchDelete";
                            _dbHelp.ExcuteData(squery, prm, true);
                        }

                      
                        XtraMessageBox.Show("تمت عملية الـــحذف بنجاح", "تأكــيد", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dt = _dbHelp.Return_DT("ResearchSelect", null, true);
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
    }
}
