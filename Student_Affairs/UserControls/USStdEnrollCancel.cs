using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using sql_builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Student_Affairs.UserControls
{
    public partial class USStdEnrollCancel : DevExpress.XtraEditors.XtraUserControl
    {
        public USStdEnrollCancel()
        {
            InitializeComponent();
        }
        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();

        private void USStdEnrollCancel_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("V_ViewStatusSM", null, true);
                gridControl1.DataSource = dt;

                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

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
                BarButtonItem itemPrinttopdf = new BarButtonItem(barManager1, "تحويل الى Pdf", 0);

                // Adds the items to the popup menu.
                menu.AddItems(new BarItem[] { itemPrinttopdf});
                // Creates a separator before the Copy item.
                itemPrinttopdf.Links[0].BeginGroup = true;
                // Attaches the popup menu to the form.
                barManager1.SetPopupContextMenu(this, menu);
                // Subscribes to the 'ItemClick' event handler to process item clicks.
                barManager1.ItemClick += barManager1_ItemClick;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void barManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Caption == "تحويل الى Pdf")
            {

                try
                {
                    // Assume 'gridView1' is your GridView control
                    GridView gridView = gridControl1.MainView as GridView;

                    if (gridView != null)
                    {
                        // Temporarily disable paging to export all rows
                        gridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.False;
                        gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;

                        // Ensure that the grid contains all rows (even from all pages) for export
                        gridView.OptionsView.ShowFooter = true; // Show footer if required
                        gridView.PopulateColumns(); // Ensure that all columns are populated

                        // Create a SaveFileDialog to allow the user to select the location and filename
                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "PDF Files (*.pdf)|*.pdf", // Filter for PDF files
                            Title = "Save GridView as PDF",
                            DefaultExt = "pdf", // Default file extension
                            FileName = "GridViewExport.pdf" // Default file name
                        };

                        // Show the SaveFileDialog and check if the user clicked "Save"
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Get the file path chosen by the user
                            string filePath = saveFileDialog.FileName;

               


                            // Export the GridView to the selected PDF file with the export options
                            gridView.ExportToPdf(filePath);

                            // Inform the user that the export was successful
                            MessageBox.Show($"Grid exported to PDF successfully!\nSaved to: {filePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Ask the user if they want to open the file
                            DialogResult openFileDialogResult = MessageBox.Show("Would you like to open the PDF file?", "Open File?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            // If the user clicked "Yes", open the PDF file
                            if (openFileDialogResult == DialogResult.Yes)
                            {
                                try
                                {
                                    // Open the PDF file using the default viewer
                                    Process.Start(filePath);
                                }
                                catch (Exception ex)
                                {
                                    // Handle any errors that might occur when trying to open the file
                                    MessageBox.Show($"An error occurred while trying to open the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }

            }
        }
    }
}
