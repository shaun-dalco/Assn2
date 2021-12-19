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
        public int Id;
        public string GivenName;
        public string FamilyName;
        public string Title;
        public string School;
        public Campus Campus;
        public string Email;
        public string Photo; //url
        //public DateTime utasStart;     may not need these four
        //public DateTime currentStart;
        //public int publicationNum;
        public string Unit;


        //GetCurrentJob(): Returns Position
        //Choice of Implementation: Takes in an int, returns a Position 

        public Position GetCurrentJob(int id)
        {
            



        }

        
        //CurrentJobTitle(): Returns a String


        //CurrentJobStart(): Returns a Date


        //GetEarliestJob(): Returns a Position


        //EarliestStart(): Returns a Date


        //Tenure(): Returns a float (double)


        //PublicationsCount(): returns an int
    }
}
