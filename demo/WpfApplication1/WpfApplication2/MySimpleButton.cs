using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2
{
    public class MySimpleButton : Button
    {
        //自定义事件，路由策略Bubble
        public static readonly RoutedEvent CustomClickEvent = EventManager.RegisterRoutedEvent("CustomClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MySimpleButton));

        public event RoutedEventHandler CustomClick
        {
            add { AddHandler(CustomClickEvent, value); }
            remove { RemoveHandler(CustomClickEvent, value); }
        }

        static MySimpleButton()
        {
            //将CustomClickEvent和一个Class Handler关联起来
            EventManager.RegisterClassHandler(typeof(MySimpleButton), CustomClickEvent, new RoutedEventHandler(CustomClickClassHandler), false);
        }

        public event EventHandler ClassHandlerProcessed;
        public static void CustomClickClassHandler(object sender, RoutedEventArgs e)
        {
            MySimpleButton btnMySimple = sender as MySimpleButton;
            EventArgs args = new EventArgs();
            btnMySimple.ClassHandlerProcessed(sender, args);
        }


        //触发事件
        void RaiseCustomClickEvent()
        {
            RoutedEventArgs e = new RoutedEventArgs(CustomClickEvent);
            RaiseEvent(e);
        }

        //OnClick触发CustomClickEvent
        protected override void OnClick()
        {
            RaiseCustomClickEvent();
        }
    }
}
