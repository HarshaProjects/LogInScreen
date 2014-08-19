using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LogInScreen
{
    class LogInViewModel : INotifyPropertyChanged
    {

        public LogInViewModel()
        {          

            Model = new LogInModel(); 
        }

        private LogInModel Model;
        private bool EnableDisable()
        {
            return true;
        }

       

        private string _UserName;

        public string UserName
        {
            get 
            { 
                return _UserName; 
            }
            set 
            {
                if (_UserName != value && !string.IsNullOrEmpty(value))
                {
                    _UserName = value;
                    RaisePropertyChanged(UserName);

                }
            }
        }

        #region Password
        private string _Password;
        public string Password
        {
            private get 
            { 
                return _Password; 
            }
            set 
            {
                if (_Password != value && string.IsNullOrEmpty(value))
                {
                    _Password = value;
                    RaisePropertyChanged(Password);
                }
            }
        }
        #endregion

        public string _ErrorMessage;
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }
       
        public ICommand SubMitCommand
        {
            get
            {
                return new RelayCommand(param => this.GetApproval(param));
            }
        }
       



        public event PropertyChangedEventHandler PropertyChanged;     


        public void RaisePropertyChanged(string PropertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


        private void GetApproval(object Parameter)
        {
            //Here VM knows about the View, voilating MVVM Rules. Next Version I will address it.
            this.ErrorMessage = "";
            PasswordBox Password = Parameter as PasswordBox;

            if (Password.Password != string.Empty && !string.IsNullOrEmpty(this.UserName))
            {
                bool approved = Model.GetApproval(this.UserName, Password.Password);
                if (!approved)
                {
                    this.ErrorMessage = "Either UserName or Password is incorrect";
                }
                else
                {
                    this.ErrorMessage = "User Name found";
                }
            }
        }

        
    }
}
