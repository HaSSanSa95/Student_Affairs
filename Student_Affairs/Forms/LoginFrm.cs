using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using sql_builder;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Filtering.Templates;
using Student_Affairs;


namespace StoresApplication
{
    public partial class LoginFrm : DevExpress.XtraEditors.XtraForm
    {
        public LoginFrm()
        {
            InitializeComponent();
            txtUserPassword.Properties.PasswordChar = '*';
        }
        DataTable dt = new DataTable();
        DatabaseAccess  _dbHelp = new DatabaseAccess();
        string fullname = null;
        string squery = null;
        public string UserGuid = null ;
        private void CheckIsUser()
        {
            try
            {
                SqlParameter[] prm = new SqlParameter[2];

                prm[0] = new SqlParameter("@Username", txtUserName.Text);
                prm[1] = new SqlParameter("@Password", txtUserPassword.Text);

                squery = "LoginChack";
                dt = _dbHelp.Return_DT(squery, prm, true);

                if (dt.Rows.Count > 0)
                {

                   fullname = dt.Rows[0]["username"].ToString();
                  // UserGuid = dt.Rows[0]["Guid"].ToString();
                    //PublicSetting.UserGuid = dt.Rows[0]["Guid"].ToString();
                    Dashboard k = new Dashboard();

                    Student_Affairs.Properties.Settings.Default.username = txtUserName.Text;
                    Student_Affairs.Properties.Settings.Default.Save();
                    k.Show();

                    //   clsStaticForm.user_name = dt.Rows[0]["us_fullname"].ToString();

                    //   Properties.Settings.Default.userN = txtUserName.Text;
                    //   Properties.Settings.Default.Save();



                    //frmUsers fdf = new frmUsers() { Owner = this }; ;
                    //fdf.Show();

                    this.Hide();
                }
                else
                {
                    txtUserPassword.Text = "";
                    txtUserPassword.Focus();
                    XtraMessageBox.Show("المستخدم غير موجود يرجى اعادة المحاولة !", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {


       

            string userInput = Student_Affairs.Properties.Settings.Default.username;
            notifyIcon1.Icon = new Icon("01-_1_.ico");
            notifyIcon1.Text = "some text";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = " مرحباً بك  " + userInput + "  في البرنامج  ";
            notifyIcon1.BalloonTipText = "لمزيد من التفاصيل اضغط هنا";
            notifyIcon1.ShowBalloonTip(100);

            CheckIsUser();
            //try
            //{
            //    string UserID = System.Guid.NewGuid().ToString();
            //    SqlParameter[] prm = new SqlParameter[4];

            //    prm[0] = new SqlParameter("@Guid", UserID);
            //    prm[1] = new SqlParameter("@UserName", txtUserName.Text);
            //    prm[2] = new SqlParameter("@Operation", "دخول الى البرنامج");
            //    prm[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
            //    squery = "TB_UsersOPInput_Insert";
            //    _dbHelp.ExcuteData(squery, prm, true);



            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.ToString());
            //}
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
             CheckIsUser();
            //    try
            //    {
            //        string UserID = System.Guid.NewGuid().ToString();
            //        SqlParameter[] prm = new SqlParameter[4];

            //        prm[0] = new SqlParameter("@Guid", UserID);
            //        prm[1] = new SqlParameter("@UserName", txtUserName.Text);
            //        prm[2] = new SqlParameter("@Operation", "دخول الى البرنامج");
            //        prm[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
            //        squery = "TB_UsersOPInput_Insert";
            //        _dbHelp.ExcuteData(squery, prm, true);
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(ex.ToString());
            //    }
            }
        }

        private void txtUserPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CheckIsUser();
            //    try
            //    {
            //        string UserID = System.Guid.NewGuid().ToString();
            //        SqlParameter[] prm = new SqlParameter[4];

            //        prm[0] = new SqlParameter("@Guid", UserID);
            //        prm[1] = new SqlParameter("@UserName", txtUserName.Text);
            //        prm[2] = new SqlParameter("@Operation", "دخول الى البرنامج");
            //        prm[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
            //        squery = "TB_UsersOPInput_Insert";
            //        _dbHelp.ExcuteData(squery, prm, true);
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(ex.ToString());
            //    }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            try
            {
            //    string UserID = System.Guid.NewGuid().ToString();
            //    SqlParameter[] prm = new SqlParameter[4];

            //    prm[0] = new SqlParameter("@Guid", UserID);
            //    prm[1] = new SqlParameter("@UserName", txtUserName.Text);
            //    prm[2] = new SqlParameter("@Operation", "خروج من البرنامج");
            //    prm[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
            //    squery = "TB_UsersOPInput_Insert";
            //    _dbHelp.ExcuteData(squery, prm, true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
           // lblSecound.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void lblClock_Click(object sender, EventArgs e)
        {

        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Student_Affairs.Properties.Settings.Default.username;
            timer1.Start();

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; //1secound
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                circularProgressBar1.Invoke((MethodInvoker)delegate
                {

                    circularProgressBar1.Text = DateTime.Now.ToString("hh:mm:ss");
                    circularProgressBar1.SubscriptText = DateTime.Now.ToString("tt");// AM Or PM
                });

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }


        private void txtUserPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CheckIsUser();
                try
                {
                    //string UserID = System.Guid.NewGuid().ToString();
                    //SqlParameter[] prm = new SqlParameter[4];

                    //prm[0] = new SqlParameter("@Guid", UserID);
                    //prm[1] = new SqlParameter("@UserName", txtUserName.Text);
                    //prm[2] = new SqlParameter("@Operation", "دخول الى البرنامج");
                    //prm[3] = new SqlParameter("@Date_Time", Convert.ToDateTime(DateTime.Now));
                    //squery = "TB_UsersOPInput_Insert";
                    //_dbHelp.ExcuteData(squery, prm, true);


                    //string userInput = Student_Affairs.Properties.Settings.Default.username;
                    //notifyIcon1.Icon = new Icon("VolEnteerLogo.ico");
                    //notifyIcon1.Text = "some text";
                    //notifyIcon1.Visible = true;
                    //notifyIcon1.BalloonTipTitle = " مرحباً بك  " + userInput  + "  في البرنامج  ";
                    //notifyIcon1.BalloonTipText = "لمزيد من التفاصيل اضغط هنا";
                    //notifyIcon1.ShowBalloonTip(100);


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }

            }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
           // frmUsers fdf2 = new frmUsers() { Owner = this }; ;
           // fdf2.Show();
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
          //  frmUsers fdf2 = new frmUsers() { Owner = this }; ;
          // fdf2.Show();
        }
    }
}