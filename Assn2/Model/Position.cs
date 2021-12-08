using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assn2.Model
{

    public enum Level
    {
        A,
        B,
        C,
        D,
        E

    }



    class Position
    {
        public int id;
        public Level level;
        public DateTime start;
        public DateTime finish;

        //Needs constructor 

    }
}
