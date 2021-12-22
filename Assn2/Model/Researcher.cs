using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assn2.Model
{
   
    public enum Campus
    {
        Hobart,
        Launceston,
        CradelCoast

    }
    
    
    class Researcher
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public Campus Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime EarliestStart { get; set; }
        public DateTime CurrentStart { get; set; }
        public string Unit { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Position> Positions { get; set; }

        public string FormattedName
        {
            get
            {
                return (FamilyName + ", " + GivenName + " (" + Title + ")");
            }
            set
            {
                // not settable
            }
        }

        //GetCurrentJob(): Returns Position
        //Here we just want to loook for whatever position has no END date -> position with no end date = current job.
        public Position GetCurrentJob(Researcher r)
        {
            Position returnPosition = new Position(); //To return

            //Go through all elements of the array until that content is equal to null
            for (int i= 0; r.Positions[i] != null; i++)
            {

                
                if (r.Positions[i].Start != null && r.Positions[i].Finish == null) //If this position has a start date, but no finish date, it is the currentJob
                {

                    returnPosition = Positions[i];

                }


            }

            if (returnPosition.Id != null)
            {

                return returnPosition;
            } else
            {

                Console.WriteLine("No current Job");
                return returnPosition; //Is there an exit code I can put here instead of returning empty position???
            }
        }

        //GetEarliestJob(): Returns a Position - The arrays are, by default, build to which the earliest date will be the first entry in the database -> this method will 
        //Function as if that was not the case 
        public Position GetEarliestJob(Researcher r)
        {

            Position temp = new Position(); //Will hold values
            temp = r.Positions[0]; //Set it to hold initial entry 

            for (int i = 1; r.Positions[i] != null; i++) //Go through the array until we run out of Positions (Skip the first one cause temp will hold its value)
            {
                if(DateTime.Compare(temp.Start, r.Positions[i].Start) > 0) //When these are compared, if the returned value is >0, date 2 is earlier than date 1)
                {
                    temp = r.Positions[i]; //update temp 

                }


            }

            return temp; //Returns Position with the earliest Job 

        }

        
        //CurrentJobTitle(): Returns a String (Do this with a switch & the enum? need the value)
        public string CurrentJobTitle(Researcher r)
        {



            return "";
        }


        //Tenure(): Returns a float (double): Needs to access database details that are NOT stored within the clas
        //Edit:

        public double Tenure(Researcher r)
        {


            return 0.0f;
        }

        //PublicationsCount(): returns an int
        public int PublicationsCount(Researcher r)
        {
            
            return 0;



        }
    }
}
