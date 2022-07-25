using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentApi
{
    public class DBAccess
    {


        public static List<student> getStudents()
        {
            List<student> studentlist = new List<student>();

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["API"]);
            //  try
            //  {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand sqlServerCmd = new SqlCommand();
            sqlServerCmd.Connection = con;

            string query = "SELECT SId, Sname ,Scourse,Smarks  FROM student1 order by Sname";



            sqlServerCmd.CommandText = query;
            SqlDataReader sqlServerReader = sqlServerCmd.ExecuteReader();

            if (sqlServerReader.HasRows)
            {
                while (sqlServerReader.Read())
                {
                    student studentInfo = new student();
                    studentInfo.SId = sqlServerReader["SId"].ToString();
                    studentInfo.Sname = sqlServerReader["Sname"].ToString();
                    studentInfo.Scourse = sqlServerReader["Scourse"].ToString();
                    studentInfo.Smarks = sqlServerReader["Smarks"].ToString();


                    studentlist.Add(studentInfo);
                }

                sqlServerReader.Close();
            }


            con.Close();
            //   }
            //  catch (Exception e)
            //   {
            //      con.Close();
            //}

            return studentlist;
        }

        public static List<student> getSpecificStudent(string sid)
        {
            List<student> studentlist = new List<student>();

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["API"]);
            //  try
            //  {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand sqlServerCmd = new SqlCommand();
            sqlServerCmd.Connection = con;

            sqlServerCmd.Parameters.Add("@SId", SqlDbType.VarChar).Value = sid;
            string query = "SELECT SId, Sname ,Scourse,Smarks  FROM student1 WHERE SId=@SId";


            sqlServerCmd.CommandText = query;
            SqlDataReader sqlServerReader = sqlServerCmd.ExecuteReader();

            if (sqlServerReader.HasRows)
            {
                while (sqlServerReader.Read())
                {
                    student studentInfo = new student();
                    studentInfo.SId = sqlServerReader["SId"].ToString();
                    studentInfo.Sname = sqlServerReader["Sname"].ToString();
                    studentInfo.Scourse = sqlServerReader["Scourse"].ToString();
                    studentInfo.Smarks = sqlServerReader["Smarks"].ToString();


                    studentlist.Add(studentInfo);
                }

                sqlServerReader.Close();
            }


            con.Close();
            //   }
            //  catch (Exception e)
            //   {
            //      con.Close();
            //}

            return studentlist;
        }

        public static int postStudents(string SId, string Sname, string Scourse, string Smarks)
        {
            int affectedRows = 0;

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["API"]);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "INSERT INTO student1(SId,Sname,Scourse,Smarks) VALUES (@SId,@Sname,@Scourse,@Smarks)";
                SqlCommand sqlServerCmd = new SqlCommand();
                sqlServerCmd.Connection = con;
                sqlServerCmd.Parameters.Add("@SId", SqlDbType.VarChar).Value = SId;
                sqlServerCmd.Parameters.Add("@Sname", SqlDbType.VarChar).Value = Sname;
                sqlServerCmd.Parameters.Add("@Scourse", SqlDbType.VarChar).Value = Scourse;
                sqlServerCmd.Parameters.Add("@Smarks", SqlDbType.VarChar).Value = Smarks;





                sqlServerCmd.CommandText = query;
                affectedRows = sqlServerCmd.ExecuteNonQuery();
                con.Close();


                return affectedRows;

            }
            catch (Exception e)
            {
                con.Close();
                return affectedRows;

            }




        }

        public static int putStudents(string SId, string Sname, string Scourse, string Smarks)
        {

            int affectedRows = 0;


            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["API"]);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand sqlServerCmd = new SqlCommand();
                sqlServerCmd.Connection = con;
                sqlServerCmd.Parameters.Add("@SId", SqlDbType.VarChar).Value = SId;

                sqlServerCmd.Parameters.Add("@Sname", SqlDbType.VarChar).Value = Sname;
                sqlServerCmd.Parameters.Add("@Scourse", SqlDbType.VarChar).Value = Scourse;
                sqlServerCmd.Parameters.Add("@Smarks", SqlDbType.VarChar).Value = Smarks;



                string query = " Update student1 set Sname=@Sname ,Scourse=@Scourse,Smarks=@Smarks Where SId=@SId";



                sqlServerCmd.CommandText = query;
                affectedRows = sqlServerCmd.ExecuteNonQuery();
                con.Close();


                return affectedRows;

            }
            catch (Exception e)
            {
                con.Close();
                return affectedRows;

            }


        }


        public static int deleteStudent(string SId)
        {
            int affectedRows = 0;
            SqlConnection sqlServerCon = new SqlConnection(ConfigurationManager.AppSettings["API"]);

            try
            {

                if (sqlServerCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlServerCon.Open();
                }
                string sql = "Delete from student1  WHERE SId=@SId";
                SqlCommand sqlServerCmd = new SqlCommand();
                sqlServerCmd.Connection = sqlServerCon;
                sqlServerCmd.Parameters.Add("@SId", SqlDbType.VarChar).Value = SId;

                 
                sqlServerCmd.CommandText = sql;

                affectedRows = sqlServerCmd.ExecuteNonQuery();
                sqlServerCon.Close();

                return affectedRows;
            }


            catch (Exception e)
            {
                sqlServerCon.Close();

                return affectedRows;
            }
            // end delete name
        }




    }
}