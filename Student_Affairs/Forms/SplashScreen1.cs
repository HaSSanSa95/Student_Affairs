using DevExpress.XtraSplashScreen;
using StoresApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace DXApplication6
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; 
            SetRoundedCorners(60);
        }

        private void SetRoundedCorners(int radius)
        {
            // إنشاء مسار رسومي لرسم مستطيل مع زوايا مقوسة
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // الزاوية العلوية اليسرى
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // الزاوية العلوية اليمنى
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // الزاوية السفلية اليمنى
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // الزاوية السفلية اليسرى
            path.CloseFigure(); // إغلاق الشكل

            // تعيين الشكل كمنطقة للنموذج (أي جعل النموذج بهذا الشكل)
            this.Region = new Region(path);
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        private void SplashScreen1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2500);
            LoginFrm loginForm = new LoginFrm();
        }
    }
}