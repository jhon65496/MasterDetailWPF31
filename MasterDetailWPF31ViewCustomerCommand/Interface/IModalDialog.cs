﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterDetailWPF31ViewCustomerCommand.Interface
{
    public interface IModalDialog
    {
        void BindViewModel<TViewModel>(TViewModel viewModel); //bind to viewModel

        void ShowDialog();  //show the modal window 

        void Close();  //close the dialog   
    }
}
