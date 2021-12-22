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

using Assn2.Control;

namespace Assn2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel mvm = new MainViewModel();
            mvm.VM1 = new ResearcherListModel();
            mvm.VM2 = new ResearcherDetailsModel();

            DataContext = mvm;
        }

        private void ResearcherList_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ResearcherDetailsModel();
        }
    }
}