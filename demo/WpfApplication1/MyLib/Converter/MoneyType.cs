using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Converter
{
    [TypeConverter(typeof(MoneyConterter))]
    public class MoneyType
    {
        double _value;
        public MoneyType() { _value = 0; }

        public MoneyType(double value) { _value = value; }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static MoneyType Parse(string value)
        {
            string str = (value as string).Trim();
            if (str[0] == '$')
            {
                string newPrice = str.Remove(0, 1);
                double price = double.Parse(newPrice);
                return new MoneyType(price * 8);
            }
            else
            {
                double price = double.Parse(value);
                return new MoneyType(price);
            }
        }
    }
}
