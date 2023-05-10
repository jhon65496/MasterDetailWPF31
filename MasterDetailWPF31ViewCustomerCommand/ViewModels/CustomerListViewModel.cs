using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.ObjectModel;

using System.Windows.Input;

using MasterDetailWPF31ViewCustomerCommand.Common;
using MasterDetailWPF31ViewCustomerCommand.Models;
using MasterDetailWPF31ViewCustomerCommand.Services;

using MasterDetailWPF31ViewCustomerCommand.Interface;
using MasterDetailWPF31ViewCustomerCommand.Views;
using System.Windows;

// using MasterDetailWPF31ViewCustomerCommand.Models;
// using MasterDetailWPF31ViewCustomerCommand.Service;

// "CustomerListViewModel" "clr-namespace:MasterDetailWPF31ViewCustomerCommand.ViewModels".	
// 
namespace MasterDetailWPF31ViewCustomerCommand.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        #region Property Title
        private string title = "Title - MasterDetailWPF31ViewCustomerCommand";

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        #endregion
                

        private static CustomerListViewModel instance = null;

        //the selected customer (for showing orders for that customer)
        private CustomerViewModel selectedCustomer = null;

        // для открытия окна Добавления клиента
        // for opening up the Add Customer window
        private ICommand showAddCommand;

        // полный список клиентов
        // the complete customer list
        private ObservableCollection<CustomerViewModel> customerList = null;
                
        public ObservableCollection<CustomerViewModel> CustomerList
        {
            get
            {
                Debug.WriteLine("=== Свойство CustomerList. Класс CustomerListViewModel ===");
                return GetCustomers();
            }
            set
            {
                customerList = value;
                OnPropertyChanged("CustomerList");
            }
        }

        //the currently selected customer
        public CustomerViewModel SelectedCustomer
        {
            get
            {
                // selectedCustomer = customerList[3];
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;                
                OnPropertyChanged("SelectedCustomer");
            }
        }

        public ICommand ShowAddCommand
        {
            get
            {
                if (showAddCommand == null)
                {
                    showAddCommand = new CommandBase(i => this.ShowAddDialog(), null);
                }
                return showAddCommand;
            }
        }


        public static CustomerListViewModel Instance()
        {
            if (instance == null)
                instance = new CustomerListViewModel();
            return instance;
        }

       

        // === === === === === === === ===
        /// <summary>
        /// Констурктор
        /// </summary>
        #region Конструктор
        public CustomerListViewModel()
        {

        }
        #endregion

        public void LoadData()
        {
            Debug.WriteLine(" === Метод LoadData(). Класс CustomerListViewModel ===");
            
            this.CustomerList = GetCustomers();
        }




        

        internal ObservableCollection<CustomerViewModel> GetCustomers()
        {
            if (customerList == null)
                customerList = new ObservableCollection<CustomerViewModel>();
            customerList.Clear();

            foreach (Customer i in TestData.Customers)
            {
                CustomerViewModel c = new CustomerViewModel(i);
                customerList.Add(c);

                Debug.WriteLine($"FirstName {i.FirstName}");
            }

            Debug.WriteLine($"`customerList` заполнена");

            return customerList;
        }


        private void ShowAddDialog()
        {
            CustomerViewModel customer = new CustomerViewModel();
            customer.Mode = Mode.Add;

            // IModalDialog dialog = ServiceProvider.Instance.Get<IModalDialog>();
            IModalDialog dialog = new CustomerViewDialog();
            dialog.BindViewModel(customer);
            dialog.ShowDialog();
        }
    }
}
