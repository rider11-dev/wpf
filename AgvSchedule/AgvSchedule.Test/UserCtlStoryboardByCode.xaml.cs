using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Bomb = AgvSchedule.Test.UserCtlBomb;

namespace AgvSchedule.Test
{
    /// <summary>
    /// UserCtlStoryboardByCode.xaml 的交互逻辑
    /// </summary>
    public partial class UserCtlStoryboardByCode : UserControl
    {
        private DispatcherTimer _bombTimer = new DispatcherTimer();
        private int _droppedCount = 0;
        private int _maxDroppedCount = 20;
        private int _savedCount = 0;

        //
        private double _initialSecondsBetweenBombs = 1.3;//1.3s出一个炸弹
        private double _initialSecondsToFall = 3.5;//3.5秒落地
        private double _secondsBetweenBombs;
        private double _secondsToFall;

        private Dictionary<Bomb, Storyboard> _storyboards = new Dictionary<Bomb, Storyboard>();

        //每15s加速
        private double _secondsBetweenAdjustments = 15;
        private DateTime _lastAdjustmentTime = DateTime.MinValue;
        //
        private double _secondsBetweenBombsReduction = 0.1;
        private double _secondsToFallReduction = 0.1;

        public UserCtlStoryboardByCode()
        {
            InitializeComponent();
            _bombTimer.Tick += _bombTimer_Tick;
        }


        private void _bombTimer_Tick(object? sender, EventArgs e)
        {
            var bomb = new Bomb();
            bomb.IsFalling = true;

            var random = new Random();
            bomb.SetValue(Canvas.LeftProperty, (double)(random.Next(9, (int)(canvas.ActualWidth - 50))));
            bomb.SetValue(Canvas.TopProperty, -100.0);

            canvas.Children.Add(bomb);

            bomb.MouseLeftButtonDown += bomb_MouseLeftButtonDown;

            var sbd = new Storyboard();
            //创建下落动画
            var fallAnimation = new DoubleAnimation();
            fallAnimation.To = canvas.ActualHeight;
            fallAnimation.Duration = TimeSpan.FromSeconds(_secondsToFall);
            Storyboard.SetTarget(fallAnimation, bomb);
            Storyboard.SetTargetProperty(fallAnimation, new PropertyPath("(Canvas.Top)"));
            sbd.Children.Add(fallAnimation);

            //创建炸弹抖动动画
            var wiggleAnimation = new DoubleAnimation();
            wiggleAnimation.To = 30;
            wiggleAnimation.Duration = TimeSpan.FromSeconds(0.2);
            wiggleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            wiggleAnimation.AutoReverse = true;
            Storyboard.SetTarget(wiggleAnimation, ((TransformGroup)bomb.RenderTransform).Children[0]);
            Storyboard.SetTargetProperty(wiggleAnimation, new PropertyPath("Angle"));
            sbd.Children.Add(wiggleAnimation);

            _storyboards.Add(bomb, sbd);

            sbd.Duration = fallAnimation.Duration;
            sbd.Completed += sbd_Completed;
            sbd.Begin();

            if ((DateTime.Now.Subtract(_lastAdjustmentTime).TotalSeconds > _secondsBetweenAdjustments))
            {
                _lastAdjustmentTime = DateTime.Now;
                _secondsBetweenBombs -= _secondsBetweenBombsReduction;
                _secondsToFall -= _secondsToFallReduction;

                _bombTimer.Interval = TimeSpan.FromSeconds(_secondsBetweenBombs);

                lblRate.Text = $"每{Math.Round(_secondsBetweenBombs, 2)}s释放炸弹";
                lblSpeed.Text = $"落地时间{Math.Round(_secondsToFall, 2)}s";
            }

        }

        private void sbd_Completed(object? sender, EventArgs e)
        {
            var clockGroup = (ClockGroup)sender;
            var completedAnimation = (DoubleAnimation)clockGroup.Children[0].Timeline;
            var completedBomb = (Bomb)Storyboard.GetTarget(completedAnimation);
            if (completedBomb.IsFalling)
            {
                _droppedCount++;
            }
            else
            {
                _savedCount++;
            }
            lblStatus.Text = $"丢失炸弹数:{_droppedCount}/{_maxDroppedCount},处理炸弹数:{_savedCount}";
            if (_droppedCount >= _maxDroppedCount)
            {
                _bombTimer.Stop();
                lblStatus.Text += "\r\n\r游戏结束";
                foreach (var item in _storyboards)
                {
                    item.Value.Stop();
                    canvas.Children.Remove(item.Key);
                }
                _storyboards.Clear();
                btnStart.IsEnabled = true;
            }
            else
            {
                var storyboard = (Storyboard)clockGroup.Timeline;
                storyboard.Stop();

                _storyboards.Remove(completedBomb);
                canvas.Children.Remove(completedBomb);
            }
        }

        private void bomb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var bomb = (Bomb)sender;
            bomb.IsFalling = false;

            //记录当前位置
            var currentTop = Canvas.GetTop(bomb);
            //停止下落
            var sbd = _storyboards[bomb];
            sbd.Stop();
            sbd.Children.Clear();

            //开始炸弹移除动画
            var riseAnimation = new DoubleAnimation();
            riseAnimation.From = currentTop;
            riseAnimation.To = 0;
            riseAnimation.Duration = TimeSpan.FromSeconds(2);
            Storyboard.SetTarget(riseAnimation, bomb);
            Storyboard.SetTargetProperty(riseAnimation, new PropertyPath("(Canvas.Top)"));
            sbd.Children.Add(riseAnimation);

            var slideAnimation = new DoubleAnimation();
            var currentLeft = Canvas.GetLeft(bomb);
            //将炸弹扔向近的一边
            if (currentLeft < canvas.ActualWidth / 2)
            {
                slideAnimation.To = -100;
            }
            else
            {
                slideAnimation.To = canvas.ActualWidth + 100;
            }
            slideAnimation.Duration = TimeSpan.FromSeconds(1);
            Storyboard.SetTarget(slideAnimation, bomb);
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("(Canvas.Left)"));
            sbd.Children.Add(slideAnimation);

            sbd.Duration = slideAnimation.Duration;
            sbd.Begin();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //尺寸改变，设置裁剪区域
            var rect = new RectangleGeometry();
            rect.Rect = new Rect(0, 0, canvas.ActualWidth, canvas.ActualHeight);
            canvas.Clip = rect;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;

            _droppedCount = 0;
            _savedCount = 0;
            _secondsBetweenBombs = _initialSecondsBetweenBombs;
            _secondsToFall = _initialSecondsToFall;

            _bombTimer.Interval = TimeSpan.FromSeconds(_secondsBetweenBombs);
            _bombTimer.Start();
        }
    }
}
