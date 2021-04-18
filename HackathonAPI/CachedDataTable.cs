using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace HackathonAPI
{
    public class CachedDataTable
    {
        private static DataTable table;
        private static DateTime lastUpdated;
        private TimeSpan timeNeededForUpdate = TimeSpan.FromMinutes(5);
        private static bool needsUpdate = true;
        public CachedDataTable()
        {
            table = new DataTable();
        }
        public static void updateDataTable(DataTable dt)
        {
            table = dt;
            lastUpdated = DateTime.Now;
        }
        public DataTable Table {
            get
            {
                if (table == null)
                {
                    table = new DataTable();
                    return table;
                }
                else return table;
            }
            set { 
                updateDataTable(value);
            }
        }
        public DateTime LastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }
        }
        public bool NeedsUpdate
        {
            get
            {
                if (table == null)
                {
                    return true;
                }
                else if (needsUpdate)
                {
                    needsUpdate = false;
                    return true;
                }
                else if (DateTime.Now.Subtract(lastUpdated) > timeNeededForUpdate)//if time since last update is greater than *some value* we can do a new Query
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { needsUpdate = value; }
        }
    }
}
