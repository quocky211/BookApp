using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TechieApp.Model
{
    public class Exchange
    {
        private static Exchange _instance;
        public static Exchange Data
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Exchange();
                }
                return _instance;
            }
        }
        public ObservableCollection<Product> Xes { get; set; }
        public CollectionView MyCoView { get; set; }
        public Filter MyFilter { get; set; }

    }
}
