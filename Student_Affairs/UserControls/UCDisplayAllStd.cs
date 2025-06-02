using DevExpress.DashboardWin.Design;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using sql_builder;
using Student_Affairs.Forms;
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
 
using Image = System.Drawing.Image;

namespace Student_Affairs.UserControls
{
    public partial class UCDisplayAllStd : DevExpress.XtraEditors.XtraUserControl
    {
        public UCDisplayAllStd()
        {
            InitializeComponent();
        }


        DatabaseAccess _dbHelp = new DatabaseAccess();
        DataTable dt = new DataTable();

        private void UCDisplayAllStd_Load(object sender, EventArgs e)
        {
            try
            {
                dt = _dbHelp.Return_DT("VStudentInfo", null, true);

                // Set the data source for the GridControl
                gridControl1.DataSource = dt;
                gridView1.ExpandAllGroups();
                gridView1.OptionsSelection.MultiSelect = true;
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                // Assuming the "Image" column in the DataTable is of type byte[]
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    byte[] imgData = (byte[])dt.Rows[i]["Image"];  // Get the image byte array for the current row
                    if (imgData != null && imgData.Length > 0)
                    {
                        // Convert the byte array to an Image (for other use cases, if needed)
                        MemoryStream ms = new MemoryStream(imgData);
                        Image img = Image.FromStream(ms);

                        // Update the image column in the DataTable (if necessary)
                        dt.Rows[i]["Image"] = imgData;

                        // Update the GridView cell with the byte array for image
                        gridView1.SetRowCellValue(i, "image", imgData); // "Image" is the column name
                    }
                }

                // Ensure the column "Image" is using the RepositoryItemPictureEdit for image display
                if (gridView1.Columns["image"] != null)
                {
                    gridView1.Columns["image"].ColumnEdit = repositoryItemPictureEdit1;
                }





            }
            catch (Exception ex)
            {
 
                XtraMessageBox.Show(ex.ToString());
            }


        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

        }

        private void barManager1_ItemClick(object sender, ItemClickEventArgs e)
        { 
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {

            try
            {
                // First, remove the current UserControl (UCDisplayAllStd) from its parent container
                //  this.Parent.Controls.Remove(this);
                int term = (int)Convert.ToInt64(gridView1.GetFocusedRowCellValue(STDID));
                FormSTDProile fr = new FormSTDProile(term);
                fr.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
    }
}
