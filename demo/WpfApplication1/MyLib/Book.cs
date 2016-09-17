using MyLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MyLib
{
    [ContentProperty("Remark")]
    public class Book
    {
        public string Name { get; set; }

        public MoneyType Price { get; set; }

        public string Remark { get; set; }

        public Book() { }

        public override string ToString()
        {
            return string.Format("书名：{0}，售价：{1}¥，备注：{2}", Name, Price, Remark);
        }
    }
}
