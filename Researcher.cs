 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum Campus
    {

       Hobart,
       Launceston,
       CradelCoast

    }

    public enum Level
    {

        A,
        B,
        C,
        D,
        E

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

        //Needs: Tenure method

    }

    class Position
    {

        public int id;
        public Level level;
        public DateTime start;
        public DateTime finish; 

        //Needs a constructor 


    }

    class Staff
    {
        public Level level;
        public string[] superviseeName;
        public Position[] positions;

        //Needs: Initialiser, threeYearAverage method & performance method 



    }

    class Student
    {

        public string degree;
        public string supervisor; 

        //Need initialiser



    }
}
