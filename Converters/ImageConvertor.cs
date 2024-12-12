using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace LernSchool.Converters
{
    public class ImageConvertor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                return value == null ? new Bitmap(AssetLoader.Open(new Uri("avares://LernSchool/Assets/school_logo.png"))) : new Bitmap(AssetLoader.Open(new Uri($"avares://LernSchool/Assets/{value}")));
            }
            catch
            {
                return new Bitmap(AssetLoader.Open(new Uri("avares://LernSchool/Assets/school_logo.png")));
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
