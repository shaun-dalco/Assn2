using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

//using Assn2.Research;
using Assn2.Model;


namespace Assn2.Database
{
    /*
    
    public Researcher[] fetchBasicResearcherDetails() {} DONE
    public Researcher fetchFullResearcherDetails(int id) {} DONE ***
    public Researcher completeResearcherDetails(Researcher r) {} Not Necissary? *** Just need to, somewhere, add the returned Researcher into the list where the ID equals each other
    public Publication[] fetchBasicPublicationDetails(Researcher r) {}  DONE ***
    public Publication completePublicationDetails(Publication p) {} DONE
    public int[] fetchPublicationCounts(DateTime from, DateTime to) {}

    */
    class ERDAdapter
    {
        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        public ERDAdapter()
        {
            //Create the connection object (does not actually make the connection yet)
            //Note that the RAP case study database has the same values for its name, user name and password (to keep things simple)
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
            conn = new MySqlConnection(connectionString);
        }

        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
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


        //for this researcher ID, query its full details, and send back a replacement researcher object with more details attached (to be added to a collection)
        //Could use this method to complete details of researcher
        public Researcher fetchFullResearcherDetails(int id)
        {
            Researcher researcher = new Researcher();

            MySqlConnection conn = GetConnection(); //test connection
            MySqlDataReader rdr = null; //rdr to null

            try
            {
                conn.Open(); //Open connection
                
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, unit, campus, email, photo, utas_start, current_start from researcher where researcher.id=?id", conn);
                cmd.Parameters.AddWithValue("id", id); //Ammend passed value
                rdr = cmd.ExecuteReader();

                //If there is a Researcher who matches that ID, assign all the values to the researcher object
                //Need a way to see if the researcher matches an ID
                if (rdr.Read())
                {




                    researcher.Id = rdr.GetInt32(0);
                    researcher.GivenName = rdr.GetString(1);
                    researcher.FamilyName = rdr.GetString(2);
                    researcher.Title = rdr.GetString(3);
                    researcher.Unit = rdr.GetString(4);
                    researcher.Campus = ParseEnum<Campus>(rdr.GetString(5));
                    researcher.Email = rdr.GetString(6);
                    researcher.Photo = rdr.GetString(7);
                    researcher.EarliestStart = rdr.GetDateTime(8);
                    researcher.CurrentStart= rdr.GetDateTime(9);
                    //researcher.Positions = fetchFullPositionDetails(researcher);
   

                    
                    
                    
                    
                  

                    return researcher; //return researcher with full details


                }
                
            }


            catch (MySqlException e)
            {
                Console.WriteLine("Error connection to DB: " + e);

            }

            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return null;

            
        }
                










         

     // public static Researcher completeResearcherDetails(Researcher r) 
       // 
       //

        //Take this researcher, find all publications that have their name attached, add to an array 
        public List<Publication> fetchBasicPublicationDetails(Researcher r)
        {
            int capacity = 10;
            List<Publication> researchersPublications = new List<Publication>(); //Make a new array of publications (placeholder 10 value, needs to be evaluated).
            
            try
            {

                 var publicationDataSet = new DataSet(); //Make the dataset for the query
                 var publicationAdapter = new MySqlDataAdapter("select * from publication where publication.[FIX THIS QUERY -> NEEDS TO GRAB BASED ON RESEARCHER", conn);
                 publicationAdapter.Fill(publicationDataSet, "publication");
            
                 foreach (DataRow row in publicationDataSet.Tables["publication"].Rows) //Adds basic details initially
                 {
                    Publication p = new Publication(); 
                    
                    p = completePublicationDetails(p); //Will add all publication details to the publication

                    for (int i = 0; i<capacity; i++) 
                    {//To navigate the array 
                
                        if(researchersPublications[i] == null) //If the space is empty, add the new publication.
                        {
                            researchersPublications.Add(p);
                            i = capacity;

                        } 
                        
                    }//If its full, skip this & increment until max capacity

                 }

            }
            finally
            {
                //close connection
                if (conn != null)
                {
                    conn.Close();

                }
            }

            Console.WriteLine("publications created for " + r.GivenName);
            return researchersPublications;

        }
          


                

      


        //for this publication, get its full details & send back a fully detailed replacement
        public Publication completePublicationDetails(Publication p)
      
        {
            Publication editPublication = new Publication();

            MySqlConnection conn = GetConnection(); //test connection
            MySqlDataReader rdr = null; //rdr to null

            try
            {
                conn.Open(); //Open connection

                MySqlCommand cmd = new MySqlCommand("select doi, title, authors, year, type, cite_as, avalaible from publication where publication.title=?title", conn);
                cmd.Parameters.AddWithValue("title", p.Title);
                rdr = cmd.ExecuteReader();

              
                while (rdr.Read())
                {

                    editPublication.Doi=rdr.GetString(0);
                    editPublication.Title = rdr.GetString(1);
                    editPublication.Authors = rdr.GetString(2);
                    editPublication.PublicationYear = rdr.GetInt32(3);
                    editPublication.Type = ParseEnum<PublicationType>(rdr.GetString(4));
                    editPublication.Cite_as = rdr.GetString(5);
                    editPublication.Avaliable = rdr.GetDateTime(6);


                }
            }


            catch (MySqlException e)
            {
                Console.WriteLine("Error connection to DB: " + e);

            }

            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return editPublication; //return updated publication
        }

        
        
        public static List<Position> FetchFullPositionDetails(Researcher r)
        { 
            int capacity = 10;
            List<Position> p = new List<Position>();   

            try {
                var positionDataSet = new DataSet(); //Make the dataset for the query
                var positionAdapter = new MySqlDataAdapter("select * from publication where publication.[FIX THIS QUERY -> NEEDS TO GRAB BASED ON RESEARCHER", conn);
                positionAdapter.Fill(positionDataSet, "publication");
            
                foreach (DataRow row in positionDataSet.Tables["publication"].Rows) //Adds basic details initially
                {
                    Position x = new Position(); //New position to add to the array 

                    x.Id = (int) row["id"];
                    string s = "" + row["level"];
                    x.Level = ParseEnum<EmploymentLevel>(s);
                    x.Start = row["start"];
                    x.Finish = row["End"];
               

                    for (int i = 0; i<capacity; i++) 
                    {//To navigate the array 
                
                        if(p[i] = null) //If the space is empty, add the new publication.
                        {
                             p.Add(x);
                             i = capacity;

                        } 
                        
                    }//If its full, skip this & increment until max capacity

                }

            }
            finally
            {
                //close connection
                if (conn != null)
                {
                    conn.Close();

                }
            }

            Console.WriteLine("publications created for " + r.GivenName);
            return p;

        }


        public static Position FetchPositionDetails(int id)
        {

             Position p = new Position();
             MySqlConnection conn = GetConnection();
             MySqlDataReader rdr = null; 

             try
             {

                conn.Open(); 

                MySqlCommand cmd = new MySqlCommand("select id, level, start, end from position where position.id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    p.Id = rdr.GetInt32(0);
                    p.Level = ParseEnum<EmploymentLevel>(rdr.GetString(1));
                    p.Start = rdr.GetDateTime(2);
                    p.Finish = rdr.GetDateTime(3);

                }

             }

             catch (MySqlException e)
             {
                Console.WriteLine("Error connection to DB: " + e);

             } 

             finally
             {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return p;          

        }

                  
        
       


    
       // public int[] fetchPublicationCounts(DateTime from, DateTime to) 
      //  { 
      //  }

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