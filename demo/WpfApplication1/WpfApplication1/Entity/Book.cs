using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WpfApplication2.Entity
{
    public class Book
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Book() { }

        public override string ToString()
        {
            return string.Format("书名：{0}，售价：{1}¥", Name, Price);
        }
    }
}
