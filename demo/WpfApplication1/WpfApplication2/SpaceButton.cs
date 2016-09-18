using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2
{
    /// <summary>
    /// 自定义按钮
    /// </summary>
    public class SpaceButton : Button
    {
        //①
        string _txt;
        public string Text
        {
            set
            {
                _txt = value;
                Content = SpaceOutText(_txt);
            }
            get
            {
                return _txt;
            }
        }

        //②依赖属性
        public static readonly DependencyProperty SpaceProperty;

        //③.NET属性包装器
        public int Space
        {
            get
            {
                return (int)GetValue(SpaceProperty);
            }
            set
            {
                SetValue(SpaceProperty, value);
            }
        }

        //④静态构造函数
        static SpaceButton()
        {
            //定义元数据
            FrameworkPropertyMetadata metaData = new FrameworkPropertyMetadata();
            metaData.DefaultValue = 0;
            metaData.PropertyChangedCallback += OnSpacePropertyChanged;
            metaData.Inherits = true;//属性值继承
            //注册依赖属性
            SpaceProperty = DependencyProperty.Register("Space", typeof(int), typeof(SpaceButton), metaData, ValidateSpaceValue);
        }

        //⑤值验证回调函数
        static bool ValidateSpaceValue(object val)
        {
            if (val == null)
            {
                return false;
            }
            var space = 0;
            int.TryParse(val.ToString(), out space);

            return space >= 0;
        }

        //⑥属性值改变的回调函数
        static void OnSpacePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SpaceButton btn = d as SpaceButton;
            string txt = btn.Content as string;
            if (txt == null)
            {
                return;
            }
            btn.Content = btn.SpaceOutText(txt);
        }

        //⑦为字符间距添加空格
        private object SpaceOutText(string str)
        {
            if (str == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            foreach (char ch in str)
            {
                sb.Append(ch + new string(' ', Space));
            }
            return sb.ToString();
        }
    }
}
