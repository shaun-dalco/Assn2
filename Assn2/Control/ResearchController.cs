using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Assn2.Research;
using Assn2.Model; //Changle later
using Assn2.Database;


namespace Assn2.Control
{
    class ResearchController
    {
        private ERDAdapter adapter;

        public ResearchController()
        {
            adapter = new ERDAdapter();
        }

        public List<Researcher> LoadResearchers()
        {
            List<Researcher> list = new List<Researcher>(); //Create new list 
            list = adapter.fetchBasicResearcherDetails(); //fill list from adapter (Just Basic Details (Noted in spec)) 
            return list; //return the list 
            
        }
        public void FilterByLevel(EmploymentLevel level)
        {
          
        }
        public void FilterByName(string name)
        {

        }
        public Researcher LoadResearcherDetails(Researcher r) 
        {
            //Part 1 -> update the researcher 

            Researcher newR = new Researcher(); 
            newR = adapter.fetchFullResearcherDetails(r.Id); //Will fully update the researcher
            return newR; //Return the list 

        }
    }
}
