using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assn2.Model
{

    public enum EmploymentLevel
    {
        A,
        B,
        C,
        D,
        E

    }



    class Position
    {

        public int Id { get; set; }
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish {  get; set; }

        public string Title() //Is also in the Researcher Source file 
        {


        }

        public string ToTitle(EmploymentLevel l)
        {



        }

        

    }
}
