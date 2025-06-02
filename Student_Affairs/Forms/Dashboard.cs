using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using Student_Affairs.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Affairs
{
    public partial class Dashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

 

        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainPanel.Controls.Count == 1)
            {
                MainPanel.Controls.Clear();

                // Show the wait form
                splashScreenManager1.ShowWaitForm();

                // Create the user control
                UCAddStudent fr = new UCAddStudent(this)
                {
                    // After the wait, add the user control
                    Dock = DockStyle.Fill
                };
                MainPanel.Controls.Add(fr);

                // Close the wait form
                splashScreenManager1.CloseWaitForm();
            }
            else
            {
                // Show the wait form
                splashScreenManager1.ShowWaitForm();

                // Create the user control
                UCAddStudent fr = new UCAddStudent(this)
                {
                    Dock = DockStyle.Fill
                };
                MainPanel.Controls.Add(fr);

                // Close the wait form immediately or after some condition
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

          

            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCInterView fr = new UCInterView
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCInterView fr = new UCInterView
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

       

        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCAcademicStage fr = new UCAcademicStage
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCAcademicStage fr = new UCAcademicStage
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCMaterialStudent fr = new UCMaterialStudent
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCMaterialStudent fr = new UCMaterialStudent
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCVicationAndAbsences fr = new UCVicationAndAbsences
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCVicationAndAbsences fr = new UCVicationAndAbsences
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCResearch fr = new UCResearch
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCResearch fr = new UCResearch
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCActivities fr = new UCActivities
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCActivities fr = new UCActivities
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCDisplayAllStd fr = new UCDisplayAllStd
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCDisplayAllStd fr = new UCDisplayAllStd
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCPractical fr = new UCPractical
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCPractical fr = new UCPractical
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCHomeliness fr = new UCHomeliness
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCHomeliness fr = new UCHomeliness
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                

                    MainPanel.Show();
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    MainPanel.Controls.Clear();
                    MainPanel.Show();
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    USStdEnrollCancel fr = new USStdEnrollCancel
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    USStdEnrollCancel fr = new USStdEnrollCancel
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    US_STD_Status fr = new US_STD_Status
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    US_STD_Status fr = new US_STD_Status
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MainPanel.Controls.Count == 1)
                {
                    MainPanel.Controls.Clear();
                    splashScreenManager1.ShowWaitForm();
                    UCReportDesgin fr = new UCReportDesgin
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    UCReportDesgin fr = new UCReportDesgin
                    {
                        Dock = DockStyle.Fill
                    };
                    MainPanel.Controls.Add(fr);
                    splashScreenManager1.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}