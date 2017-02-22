using System;
using System.Globalization;
using System.Windows.Data;
using TextPanda.Models;

namespace TextPanda.Converters
{
    class EnumToBoolConverter : IValueConverter
    {
        public static EnumToBoolConverter ReplaceModeEndCharacterToTrueConverter = new EnumToBoolConverter(ReplaceMode.EndCharacter, ReplaceMode.Auto);

        readonly object _trueEnumValue;
        readonly object _falseEnumValue;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="trueEnumValue">The enum value that returns true;</param>
        public EnumToBoolConverter(object trueEnumValue, object falseEnumValue)
        {
            _trueEnumValue = trueEnumValue;
            _falseEnumValue = falseEnumValue;
        }

        //
        // Summary:
        //     Converts a value.
        //
        // Parameters:
        //   value:
        //     The value produced by the binding source.
        //
        //   targetType:
        //     The type of the binding target property.
        //
        //   parameter:
        //     The converter parameter to use.
        //
        //   culture:
        //     The culture to use in the converter.
        //
        // Returns:
        //     A converted value. If the method returns null, the valid null value is used.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Equals(value, _trueEnumValue);
        }

        //
        // Summary:
        //     Converts a value.
        //
        // Parameters:
        //   value:
        //     The value that is produced by the binding target.
        //
        //   targetType:
        //     The type to convert to.
        //
        //   parameter:
        //     The converter parameter to use.
        //
        //   culture:
        //     The culture to use in the converter.
        //
        // Returns:
        //     A converted value. If the method returns null, the valid null value is used.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value as bool? == true)
            {
                return _trueEnumValue;
            }

            return _falseEnumValue;
        }
    }
}
