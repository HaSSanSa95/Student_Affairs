using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace sql_builder
{
    class DatabaseAccess
    {
        public static SqlConnection constr1;
        public string conStr = null;

        public DatabaseAccess()
        {

            string path = Application.StartupPath + "\\constr.txt";
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            constr1 = new SqlConnection(line);
            conStr = line;


        }


        /// <summary>
        ///  Return DataTable Using Stored Procedure
        ///  1- Stored Procedure
        ///  else
        ///  any no : query string
        /// </summary>
        /// <returns>dt</returns>
        /// 
        public DataTable Return_DT(string ProcOrQueryName, SqlParameter[] parm, Boolean isProcedure)
        {
            DataTable dt = new DataTable();
            try
            {
                if (constr1.State == ConnectionState.Closed) { constr1.Open(); }

                SqlCommand sCommand = new SqlCommand();

                if (isProcedure == true)
                { sCommand.CommandType = CommandType.StoredProcedure; }
                else
                { sCommand.CommandType = CommandType.Text; }

                sCommand.CommandText = ProcOrQueryName;
                sCommand.Connection = constr1;

                if (parm != null)
                {
                    sCommand.Parameters.AddRange(parm);
                }

                SqlDataAdapter da = new SqlDataAdapter(sCommand);
                da.Fill(dt);
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                if (constr1.State == ConnectionState.Open)
                { constr1.Close(); }
            }
            return dt;
        }

        /// <summary>
        ///  Return DataSet Using Stored Procedure 
        ///  1- Stored Procedure
        ///  else
        ///  any no : query string
        /// </summary>
        /// <returns>ds</returns>
        public DataSet Return_DS(string ProcOrQueryName, SqlParameter[] parm, Boolean isProcedure)
        {
            DataSet ds = new DataSet();
            try
            {
                if (constr1.State == ConnectionState.Closed) { constr1.Open(); }

                SqlCommand sCommand = new SqlCommand();

                if (isProcedure == true)
                { sCommand.CommandType = CommandType.StoredProcedure; }
                else
                { sCommand.CommandType = CommandType.Text; }

                sCommand.CommandText = ProcOrQueryName;
                sCommand.Connection = constr1;

                if (parm != null)
                {
                    sCommand.Parameters.AddRange(parm);
                }

                SqlDataAdapter da = new SqlDataAdapter(sCommand);
                da.Fill(ds);
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                if (constr1.State == ConnectionState.Open)
                { constr1.Close(); }
            }
            return ds;
        }

        /// <summary>
        ///  Insert, Update, Delete
        ///  1- Stored Procedure
        ///  else
        ///  any no : query string
        /// </summary>
        public void ExcuteData(string ProcOrQueryName, SqlParameter[] parm, Boolean isProcedure)
        {
            try
            {
                if (constr1.State == ConnectionState.Closed) { constr1.Open(); }

                SqlCommand sCommand = new SqlCommand();

                if (isProcedure == true)
                { sCommand.CommandType = CommandType.StoredProcedure; }
                else
                { sCommand.CommandType = CommandType.Text; }

                sCommand.CommandText = ProcOrQueryName;
                sCommand.Connection = constr1;

                if (parm != null)
                {
                    sCommand.Parameters.AddRange(parm);
                }

                sCommand.ExecuteNonQuery();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                if (constr1.State == ConnectionState.Open)
                { constr1.Close(); }
            }
        }

        /// <summary>
        /// Get Last ID For Any Table
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public int Get_LastID(string TableName)
        {
            DataTable dt = new DataTable();
            int id = 0;
            try
            {
                if (constr1.State == ConnectionState.Closed) { constr1.Open(); }

                SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT IDENT_CURRENT('{0}')", TableName), constr1);
                da.Fill(dt);
                id = Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                if (constr1.State == ConnectionState.Open)
                { constr1.Close(); }
            }
            return id;
        }

        /// <summary>
        ///  Backup DataBase 
        /// </summary>
        /// <param name="Notes"></param>
        /// <param name="DbName"></param>
        public void DB_Backup(string Notes, string DbName)
        {

            try
            {
                string backupFolderPath = Application.StartupPath + "\\Backup\\";
                if (!Directory.Exists(backupFolderPath))
                {
                    Directory.CreateDirectory(backupFolderPath);
                }

                // Open the connection if it's not open
                if (constr1.State == ConnectionState.Closed)
                {
                    constr1.Open();
                }

                // Set the date format
                System.Globalization.DateTimeFormatInfo GregorianDTF = new System.Globalization.CultureInfo("Ar-Sy", true).DateTimeFormat;
                GregorianDTF.Calendar = new System.Globalization.GregorianCalendar();

                // Generate backup file name with current date and time
                string DToday = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss", GregorianDTF) + ".bak"; // Use 24-hour format for clarity

                // Construct the SQL backup command
                string sCommand = $"BACKUP DATABASE {DbName} TO DISK = N'{backupFolderPath}{DToday}' " +
                                  $"WITH DESCRIPTION = N'{Notes}', NOFORMAT, NOINIT, NAME = N'Mechanisms', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                // Execute the SQL backup command
                SqlCommand SqlCom = new SqlCommand(sCommand, constr1);
                SqlCom.ExecuteNonQuery();

                MessageBox.Show("تمت عملية النسخ الإحتياطي لقاعدة البيانات بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the connection
                if (constr1.State == ConnectionState.Open)
                {
                    constr1.Close();
                }
            }


        }


        public void DB_Restore( string str)
        {

            try
            {
           
                if (constr1.State == ConnectionState.Closed) { constr1.Open(); }
                String database = constr1.Database.ToString();
                try
                {

                    string sql1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand cmd1 = new SqlCommand(sql1, constr1);
                    cmd1.ExecuteNonQuery();

                    string sql2 = string.Format("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + str + "' WITH REPLACE;");
                    SqlCommand cmd2 = new SqlCommand(sql2, constr1);
                    cmd2.ExecuteNonQuery();

                    string sql3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand cmd3 = new SqlCommand(sql3, constr1);
                    cmd3.ExecuteNonQuery();
                    // s.Speak("Database Restored successfully");
                    MessageBox.Show("تم استيراد قاعدة البيانات بنجاح", "استيراد قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //  button2.Enabled = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    constr1.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                if (constr1.State == ConnectionState.Open)
                { constr1.Close(); }
            }

        }


        /// <summary>
        /// Check Is Number
        /// </summary>
        public void CheckNO(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

    }
}
