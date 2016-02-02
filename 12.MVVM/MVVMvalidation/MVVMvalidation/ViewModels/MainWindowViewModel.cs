using System;
using System.Collections.Generic;
using System.ComponentModel;
using MicroMvvm;
using MVVMvalidation.Models;
using System.Windows.Input;

namespace MVVMvalidation.ViewModels
{
    class MainWindowViewModel : ObservableObject, IDataErrorInfo
    {
        // Members
        private readonly Product currentProduct;
        private Dictionary<string, bool> validProperties;
        private bool allPropertiesValid = false;

        // Properties
        public string ProductName
        {
            get { return currentProduct.ProductName; }
            set
            {
                if (currentProduct.ProductName != value)
                {
                    currentProduct.ProductName = value;
                    RaisePropertyChanged("ProductName");
                }
            }
        }

        public int Width
        {
            get { return currentProduct.Width; }
            set
            {
                if (currentProduct.Width != value)
                {
                    currentProduct.Width = value;
                    RaisePropertyChanged("Width");
                    RaisePropertyChanged("Height");
                }
            }
        }

        public int Height
        {
            get { return currentProduct.Height; }
            set
            {
                if (currentProduct.Height != value)
                {
                    currentProduct.Height = value;
                    RaisePropertyChanged("Height");
                    RaisePropertyChanged("Width");
                }
            }
        }

        public bool AllPropertiesValid
        {
            get { return allPropertiesValid; }
            set
            {
                if (allPropertiesValid != value)
                {
                    allPropertiesValid = value;
                    RaisePropertyChanged("AllPropertiesValid");
                }
            }
        }

        // Constructors
        public MainWindowViewModel()
        {
            currentProduct = new Product();
            validProperties = new Dictionary<string, bool>();
            validProperties.Add("ProductName", false);
            validProperties.Add("Height", false);
            validProperties.Add("Width", false);
        }

        // Methods
        private void Save()
        {
            currentProduct.Save();
        }

        private void ValidateProperties()
        {
            foreach (bool isValid in validProperties.Values)
            {
                if (!isValid)
                {
                    this.AllPropertiesValid = false;
                    return;
                }
            }
            this.AllPropertiesValid = true;
        }

        // Commands
        public ICommand SaveCommand
        {
            get { return new RelayCommand(() => Save(), () => true); }
        }

        // IDataErrorInfo interface
        public string this[string propertyName]
        {
            get
            {
                string error = (currentProduct as IDataErrorInfo)[propertyName];
                validProperties[propertyName] = String.IsNullOrEmpty(error);
                ValidateProperties();
                // Save command might be available after that,
                // force.
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }

        public string Error
        {
            // Use model's method
            get { return (currentProduct as IDataErrorInfo).Error; }
        }
    }
}
