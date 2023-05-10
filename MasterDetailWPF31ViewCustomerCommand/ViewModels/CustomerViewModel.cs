using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;
using MasterDetailWPF31ViewCustomerCommand.Common;
using MasterDetailWPF31ViewCustomerCommand.Views;
// using MasterDetailWPF31ViewCustomerCommand.Interface;
using MasterDetailWPF31ViewCustomerCommand.Services;
using MasterDetailWPF31ViewCustomerCommand.Models;
using MasterDetailWPF31ViewCustomerCommand.Interface;
using System;
using System.Diagnostics;
using System.Windows;

namespace MasterDetailWPF31ViewCustomerCommand.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private string firstName;
        private string lastName;
        private IList<Order> orders;

        

        private ObservableCollection<OrderViewModel> ordersViewModel = null;        

        //for opening up the Edit Customer window
        private ICommand showEditCommand;

        ////for adding/saving customer information
        //private ICommand updateCommand;

        //for deleting a customer
        private ICommand deleteCommand;             
  
        ////for cancel an Edit
        //private ICommand cancelCommand;

        private CustomerViewModel originalValue;

        // private readonly OrdersManager _OrderManager;

        Customer customer;

        #region Model === ===
        public int CustomerId
        {
            get;
            set;
        }

        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set 
            { 
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        #endregion

        #region Mode        
        /// <summary>
        /// Для определения того, находитесь ли вы в режиме добавления клиента или редактирования клиента
        /// For determining if you are in Add Customer or Edit Customer mode
        /// </summary>
        public Mode Mode
        {
            get;
            set;
        }
        #endregion

        // для доступа к CustomerListViewModel, который содержит эту CustomerViewModel
        // for accessing the CustomerListViewModel that holds this CustomerViewModel
        public CustomerListViewModel Container
        {
            get { return CustomerListViewModel.Instance(); }
        }

        // список заказов от клиента
        // list of orders from the customer
        public ObservableCollection<OrderViewModel> OrdersViewModel
        {
            get { return GetOrders(); }  
            set
            {
                ordersViewModel = value;
                OnPropertyChanged("Orders");
            }
        }

        public IList<Order> Orders
        {
            get { return orders; }
            set 
            { 
                orders = value;
                OnPropertyChanged("Orders");
            }
        }



        #region Commands === ===        
        public ICommand ShowEditCommand
        {
            get
            {
                if (showEditCommand == null)
                {
                    showEditCommand = new CommandBase(i => this.ShowEditDialog(), null);
                }
                return showEditCommand;
            }
        }

        //public ICommand UpdateCommand
        //{
        //    get
        //    {
        //        if (updateCommand == null)
        //        {
        //            updateCommand = new CommandBase(i => this.Update(), null);
        //        }
        //        return updateCommand;
        //    }
        //}

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new CommandBase(i => this.Delete(), null);
                }
                return deleteCommand;
            }
        }

        //public ICommand CancelCommand
        //{
        //    get
        //    {
        //        if (cancelCommand == null)
        //        {
        //            cancelCommand = new CommandBase(i => this.Undo(), null);
        //        }
        //        return cancelCommand;
        //    }
        //}

        #endregion
               

        // === === === === === ===
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="c"></param>
        #region Constructors
        public CustomerViewModel(Customer c)
        {
            CustomerId = c.Id;
            firstName = c.FirstName;
            lastName = c.LastName;
            orders = c.Orders;

            this.customer = c;

            //copy the current value so in case cancel you can undo
            this.originalValue = (CustomerViewModel)this.MemberwiseClone();
        }

        internal CustomerViewModel()
        {
        }
        #endregion


        internal ObservableCollection<OrderViewModel> GetOrders()
        {
            ordersViewModel = new ObservableCollection<OrderViewModel>();
            //get the orders from the service tier
            // svcOrder.OrderServiceClient c = new svcOrder.OrderServiceClient();
            var fdf = this.OrdersViewModel;
            foreach (Order i in orders)
            {
                OrderViewModel order = new OrderViewModel(i);
                order.Customer = this;
                ordersViewModel.Add(order);
            }
            return ordersViewModel;
        }

        private void ShowEditDialog()
        {
            this.Mode = ViewModels.Mode.Edit;

            // IModalDialog dialog = ServiceProvider.Instance.Get<IModalDialog>();
            IModalDialog dialog = new CustomerViewDialog();
            dialog.BindViewModel(this); //bind to this viewModel
            dialog.ShowDialog();
        }

        private void Delete()
        {
            // svcCustomer.CustomerServiceClient c = new svcCustomer.CustomerServiceClient();
            // c.DeleteCustomer(this.CustomerId);
            
                Customer customerDeleted = this.customer;
                // TestData.Customers.
            

            // refresh the view
            this.Container.CustomerList = this.Container.GetCustomers();
        }

    }
}
