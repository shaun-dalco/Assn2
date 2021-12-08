using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assn2
{

    public enum PublicationType
    {

        Conference,
        Journal,
        Other


    }


    class Publication
    {

        public string doi;
        public string title;
        public string authors;
        public int publicationYear;
        public PublicationType type;
        public string cite_as;
        public DateTime avaliable;
        public int age; 



        //Needs constuctor method 



    }
}
