using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assn2.Control
{

    public class MainViewModel
    {
        public static StackPanel dataContext;
        public ResearcherListModel VM1 { get; set; }
        public ResearcherDetailsModel VM2 { get; set; }
        public PublicationsModel VM3 { get; set; }
    }
    public class ResearcherListModel
    {

    }

    public class ResearcherDetailsModel
    {

    }

    public class PublicationsModel
    {

    }
}