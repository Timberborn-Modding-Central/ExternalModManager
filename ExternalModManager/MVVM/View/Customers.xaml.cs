using System;
using System.Windows.Controls;
using ExternalModManager.MVVM.ViewModel;

namespace ExternalModManager.MVVM.View
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();

            var test = DataContext;

            if(test is CustomerVM)
            {
                Console.WriteLine("WOOOOOO");
            }
        }
    }
}
