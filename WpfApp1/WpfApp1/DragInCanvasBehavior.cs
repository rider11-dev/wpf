using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public class DragInCanvasBehavior : Behavior<UIElement>
    {
        /// <summary>
        /// 元素所在容器
        /// </summary>
        private Canvas _canvas = null;
        /// <summary>
        /// 是否正在拖放
        /// </summary>
        private bool _isDragging = false;
        /// <summary>
        /// 鼠标相对于元素的偏移
        /// </summary>
        private Point _mouseOffset;
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            this.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            this.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_canvas != null)
            {
                _canvas = (Canvas)VisualTreeHelper.GetParent(this.AssociatedObject);
            }
            _isDragging = true;

            _mouseOffset = e.GetPosition(this.AssociatedObject);
            //捕获鼠标
            //这样可以持续接收到MouseMove事件，即使鼠标抖动偏离元素范围
            AssociatedObject.CaptureMouse();
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDragging)
            {
                var offset = e.GetPosition(_canvas);//鼠标相对于Canvas容器的偏移

                //移动元素
                AssociatedObject.SetValue(Canvas.TopProperty, offset.Y - _mouseOffset.Y);//保持鼠标相对于元素的偏移不变
                AssociatedObject.SetValue(Canvas.LeftProperty, offset.X - _mouseOffset.X);
            }
        }
        private void AssociatedObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                AssociatedObject.ReleaseMouseCapture();
                _isDragging = false;
            }
        }

    }
}
