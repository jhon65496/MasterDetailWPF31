using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


using MasterDetailWPF31ViewCustomerCommand.ViewModels;
using MasterDetailWPF31ViewCustomerCommand.Services;

namespace MasterDetailWPF31ViewCustomerCommand
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        CustomerListViewModel customerList;


        protected override void OnStartup(StartupEventArgs e)
        {   
            customerList = new CustomerListViewModel();            
            MasterDetailWPF31ViewCustomerCommand.MainWindow mainWindow = new MainWindow()
            {
                DataContext = customerList
            };

            mainWindow.Show();
            
            base.OnStartup(e);
        }
    }
}
