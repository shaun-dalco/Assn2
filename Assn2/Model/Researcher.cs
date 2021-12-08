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
        public int id;
        public string givenName;
        public string familyName;
        public string jobTitle;
        public string unit;
        public Campus campus;
        public string email;
        public string photo;
        public DateTime utasStart;
        public DateTime currentStart;
        public int publicationNum;


        //Needs tenure method 

    }
}
