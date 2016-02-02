using System;
using System.ComponentModel;

namespace MVVMvalidation.Models
{
    class Product : IDataErrorInfo
    {
        // Properties
        public string ProductName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // Methods
        public void Save()
        {
            // Stub.
        }

        // Validation logic
        private string ValidateName()
        {
            if (String.IsNullOrEmpty(this.ProductName))
                return "Product Name needs to be entered.";
            else if (this.ProductName.Length < 5)
                return "Product Name should have more than 5 letters.";
            else
                return String.Empty;
        }

        private string ValidateHeight()
        {
            if (this.Height <= 0)
                return "Height should be greater than 0";
            if (this.Height > this.Width)
                return "Height should be less than Width.";
            else
                return String.Empty;
        }

        private string ValidateWidth()
        {
            if (this.Width <= 0)
                return "Width should be greater than 0";
            if (this.Width < this.Height)
                return "Width should be greater than Height.";
            else
                return String.Empty;
        }

        // IDataErrorInfo interface
        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string this[string propertyName]
        {
            get
            {
                string validationResult = null;
                switch (propertyName)
                {
                    case "ProductName":
                        validationResult = ValidateName();
                        break;
                    case "Height":
                        validationResult = ValidateHeight();
                        break;
                    case "Width":
                        validationResult = ValidateWidth();
                        break;
                    default:
                        throw new ApplicationException("Unknown Property being validated on Product.");
                }
                return validationResult;
            }
        }
    }
}
