using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

using Assn2.Research;

namespace Assn2.Database
{
    /*
    
    public Researcher[] fetchBasicResearcherDetails() {}
    public Researcher fetchFullResearcherDetails(int id) {}
    public Researcher completeResearcherDetails(Researcher r) {}
    public Publication[] fetchBasicPublicationDetails(Researcher r) {}
    public Publication completePublicationDetails(Publication p) {}
    public int[] fetchPublicationCounts(DateTime from, DateTime to) {}

    */
    class ERDAdapter
    {
        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private MySqlConnection conn;

        public ERDAdapter()
        {
            //Create the connection object (does not actually make the connection yet)
            //Note that the RAP case study database has the same values for its name, user name and password (to keep things simple)
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
            conn = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Using the ExecuteReader method to select from a single table
        /// </summary>
        public void ReadData()
        {
            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select given_name, family_name from researcher", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    Console.WriteLine("{0} {1}", rdr[0], rdr.GetString(1));
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Using the ExecuteReader method to select from a single table
        /// </summary>
        public void ReadIntoDataSet()
        {
            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select * from researcher", conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    //Again illustrating that indexer (based on column name) gives access to whatever data
                    //type was obtained from a given column, but can call ToString() on an entry if needed.
                    Console.WriteLine("Name: {0} {1}", row["given_name"], row["family_name"].ToString());
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<Researcher> fetchBasicResearcherDetails() {
            //int num = GetNumberOfRecords();
            List<Researcher> researcher = new List<Researcher>();
            try
            { 
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select * from researcher", conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    //Again illustrating that indexer (based on column name) gives access to whatever data
                    //type was obtained from a given column, but can call ToString() on an entry if needed.
                    Researcher r = new Researcher();
                    r.GivenName = "" + row["given_name"];
                    r.FamilyName = "" + row["family_name"];
                    r.Title = "" + row["title"];
                    researcher.Add(r);
                   

                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.WriteLine("name of second researcher: {0}", researcher[1].FamilyName);
            return researcher;
        }


        /// <summary>
        /// Using the ExecuteScalar method
        /// </summary>
        /// <returns>number of records</returns>
        public int GetNumberOfRecords()
        {
            int count = -1;
            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                MySqlCommand cmd = new MySqlCommand("select COUNT(*) from researcher", conn);

                // 2. Call ExecuteScalar to send command
                // This convoluted approach is safe since cannot predict actual return type
                count = int.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }
    }
}