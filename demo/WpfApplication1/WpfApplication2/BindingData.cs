using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public class BindingData
    {
        private string _name = "Red";

        public string ColorName
        {
            get { return _name; }
            set { _name = value; }
        }

        public BindingData()
        {
            ColorName = "Red";
        }
    }
}
