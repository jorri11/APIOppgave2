using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace HackathonAPI
{
    public class dbStuff
    {
        private static CachedDataTable birtYearsCdt= new CachedDataTable();
        private static CachedDataTable membersCdt= new CachedDataTable();
        private static CachedDataTable majorsCdt= new CachedDataTable(); 
        
        private MySqlConnection connectdb()
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=heihei;database=hackathondb";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                return conn;
            }
            catch(MySqlException ex)
            {
                throw ex;
            }
        }

        public void updateDB(string query)
        {
            MySqlConnection conn = connectdb();
            try
            {
                conn.Open();
                string sql = query;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            majorsCdt.NeedsUpdate = true;//Since we update the table, the cahced info in this table wil be outdated
            conn.Close();
        }

        private DataTable executeQuery(string query)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = connectdb();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    dt.Load(rdr);
                }
                conn.Close();
                return dt;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        private CachedDataTable executeQuery(string query, CachedDataTable cdt)
        {
            
            //DataTable dt = new DataTable();
            if (cdt.NeedsUpdate)
            {
                cdt.Table.Clear();
                MySqlConnection conn = connectdb();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        cdt.Table.Load(rdr);
                    }
                    cdt.LastUpdated = DateTime.Now;
                    conn.Close();
                    return cdt;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return cdt;
            }
        }



        public int getNumberOfMembers()
        {
            //DataTable dt;
            string query = "select count(*) from medlemmer";
            try
            {
                membersCdt = executeQuery(query,membersCdt);
                DataRow row = membersCdt.Table.Rows[0];
                int numberOfMembers = Convert.ToInt32(row.ItemArray[0]);
                return numberOfMembers;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }


        public int getNumberOfMajorStudents(Controllers.majors major)
        {
            string query = $"select count(*) from medlemmer where studie='{major.ToString()}'";
            try
            {
                majorsCdt = executeQuery(query, majorsCdt);
                DataRow row = majorsCdt.Table.Rows[0];
                int numberOfMajorStudents = Convert.ToInt32(row.ItemArray[0]);
                return numberOfMajorStudents;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        

        public int getAvreageAge()
        {
            int currentYear = DateTime.Now.Year;
            //DataTable dt;
            string query = "select foedselsaar from medlemmer";
            int ageSum = 0;
            int avgAge;
            try
            {
                birtYearsCdt = executeQuery(query,birtYearsCdt);
                DataRowCollection birthYears = birtYearsCdt.Table.Rows;
                foreach (DataRow item in birthYears)
                {
                    int age = currentYear - Convert.ToInt32(item.ItemArray[0]);
                    ageSum += age;
                }
                avgAge = ageSum / birthYears.Count;
                return avgAge;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
