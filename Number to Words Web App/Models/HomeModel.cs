using System;

namespace Number_to_Words_Web_App.Models
{
    public class HomeModel
    {
        public string ResultType { get; set; }
        public string NonNumerical { get; set; }
        public bool ShowNonNumericalVal => !string.IsNullOrEmpty(NonNumerical);
    }
}
