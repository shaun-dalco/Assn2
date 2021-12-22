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
using System.Diagnostics;

using Assn2.Database;
using Assn2.Model;
using Assn2.Control;

namespace Assn2.View
{
    /// <summary>
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    public partial class ResearcherListView : UserControl
    {
        ResearchController rController;
        List<Researcher> newItems;
        
        public ResearcherListView()
		{

			InitializeComponent();

            rController = new ResearchController();
            newItems = rController.LoadResearchers();


            // temp data
            //List<Researcher> newItems = new List<Researcher>();
            //newItems.Add(new Researcher() { GivenName = "John", FamilyName = "Doe", Title = "Mr" });
            //newItems.Add(new Researcher() { GivenName = "Jane", FamilyName = "Doe", Title = "Miss" });


            nameList.ItemsSource = newItems;
        }

        public void textBox_KeyUp(object sender, RoutedEventArgs e)
        {
            //nameList.ItemsSource = rController.FilterByName(textBox.Text);
        }

        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            MainViewModel.dataContext.DataContext = newItems[nameList.Items.IndexOf(nameList.SelectedItem)];
        }
	}

}
