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
        public string Doi { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int PublicationYear { get; set; }
        public PublicationType Type { get; set; }
        public string Cite_as { get; set; }
        public DateTime Avaliable { get; set; }
     

        public int Age()
        {
            


        }

    }
}
