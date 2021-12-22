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

using Assn2.Database;
using Assn2.Model;
using Assn2.Control;

namespace Assn2.View
{
    /// <summary>
    /// Interaction logic for ResearcherDetailsView.xaml
    /// </summary>
    public partial class ResearcherDetailsView : UserControl
    {
        public ResearcherDetailsView()
        {

            InitializeComponent();
            List<Researcher> newItems = new List<Researcher>();
            Researcher someone = new Researcher() { GivenName = "John", FamilyName = "Doe", Title = "Mr" };

            DetailsPanel.DataContext = someone;
            MainViewModel.dataContext = DetailsPanel;
        }
    }

}
