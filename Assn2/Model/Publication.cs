using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assn2.Model
{


    public enum PublicationType
    {
        Conference,
        Journal,
        Other

    }

    class Publication
    {
        public string Doi;
        public string Title;
        public string Authors;
        public int PublicationYear;
        public PublicationType Type;
        public string Cite_as;
        public DateTime Avaliable;
       //ublic int Age; 

        //Needs constructor 

    }
}
