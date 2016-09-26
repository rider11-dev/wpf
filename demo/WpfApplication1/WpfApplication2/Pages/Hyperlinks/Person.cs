using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2.Pages.Hyperlinks
{
    public class Person
    {
        public string name { get; set; }
        public string sex { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            return string.Format("姓名：{0}，性别：{1}，年龄：{2}", name, sex, age);
        }
    }
}
