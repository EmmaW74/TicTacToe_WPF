using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TicTacToe_WPF.ViewModel.ValueConverters
{
    public class BoolToXOConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Nullable<bool> GridValue = (Nullable<bool>) value;
            if (GridValue == true)
            {
                return "X";
            } 
            else if (GridValue == false)
            {
                return "O";
            }
            else
            {
                return "";
            }
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
    }
}
