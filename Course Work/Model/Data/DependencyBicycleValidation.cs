using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Course_Work
{
    public class DependencyBicycleValidation : DependencyObject
    {
        public static readonly DependencyProperty ModelProperty;//пустое
        public static readonly DependencyProperty ManufactureProperty;//пустое
        public static readonly DependencyProperty YearProperty;//пустое - числовое
        public static readonly DependencyProperty NumberOfSpeedsProperty;//пустое - числовое
        public static readonly DependencyProperty TypeProperty;//пустое
        public static readonly DependencyProperty MaterialProperty;//пустое
        public static readonly DependencyProperty SizeProperty;//пустое - числовое

        static DependencyBicycleValidation()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();

            ModelProperty = DependencyProperty.Register("Model", typeof(string), typeof(DependencyBicycleValidation));
            ManufactureProperty = DependencyProperty.Register("Manufacture", typeof(string), typeof(DependencyBicycleValidation));
            YearProperty = DependencyProperty.Register("Year", typeof(int?), typeof(DependencyBicycleValidation));
            NumberOfSpeedsProperty = DependencyProperty.Register("Number", typeof(int?), typeof(DependencyBicycleValidation));
            TypeProperty = DependencyProperty.Register("Type", typeof(string), typeof(DependencyBicycleValidation));
            MaterialProperty = DependencyProperty.Register("Material", typeof(string), typeof(DependencyBicycleValidation));
            SizeProperty = DependencyProperty.Register("Size", typeof(int?), typeof(DependencyBicycleValidation));
        }

        public DependencyBicycleValidation()
        { }

        public DependencyBicycleValidation(Bicycle b)
        {
            Model = b.Model;
            Manufacture = b.Manufacture;
            Year = b.Year;
            NumberOfSpeeds = b.NumberOfSpeeds;
            Type = b.Type;
            Material = b.Frame.Material;
            Size = b.Frame.Size;
        }

        //private static bool ValidateModelValue(object value)
        //{
        //    string currentValue = (string)value;
        //    if (currentValue != null) // если текущее значение от нуля и выше
        //        return true;
        //    return false;
        //}

        public string Model
        {
            get { return (string)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public string Manufacture
        {
            get { return (string)GetValue(ManufactureProperty); }
            set { SetValue(ManufactureProperty, value); }
        }

        public int? Year
        {
            get { return (int?)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        public int? NumberOfSpeeds
        {
            get { return (int?)GetValue(NumberOfSpeedsProperty); }
            set { SetValue(NumberOfSpeedsProperty, value); }
        }

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public string Material
        {
            get { return (string)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        public int? Size
        {
            get { return (int?)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public Bicycle GetBicycle()
        {
            return new Bicycle(Model, Manufacture, (int)Year, (int)NumberOfSpeeds, Type, new BicycleFrame(Material, (int)Size));
        }

        public Bicycle GetBicycle(uint id, string creationTime)
        {
            return new Bicycle(Model, Manufacture, (int)Year, (int)NumberOfSpeeds, Type, new BicycleFrame(Material, (int)Size));
        }
    }
}
