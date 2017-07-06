using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RSSwagga.Model
{
    public class HiScoreData
    {
        public string skill { get; set; }
        public string rank { get; set; }
        public string level { get; set; }
        public string xp { get; set; }
    }
}
