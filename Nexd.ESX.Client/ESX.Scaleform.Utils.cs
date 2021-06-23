namespace Nexd.ESX.Client
{
    public static partial class ESX
    {
        public static partial class Scaleform
        {
            public class Utils
            {
                public static dynamic Raw => ESX.Raw.Scaleform.Utils;

                public static int RequestScaleformMovie(string movie) => Raw.RequestScaleformMovie(movie);
            }
        }
    }
}