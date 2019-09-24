using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace Course_Work
{
    class IntYearValidationRule : ValidationRule
    {
        private int min = 2000;
        private int max = 2019;
        public int Min
        {
            get { return min; }
            set { min = value; }
        }
        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int year = 0;

            try
            {
                if (((string)value).Length > 0)
                    year = Int32.Parse((string)value, NumberStyles.Any, cultureInfo);
            }
            catch
            {
                // Недопустимые символы. 
                return new ValidationResult(false, "Illegal characters");
            }

            if ((year < Min) || (year > Max))
            {
                // Выход за пределы диапазона, 
                return new ValidationResult(false, "Not in the range " + Min + " to " + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
