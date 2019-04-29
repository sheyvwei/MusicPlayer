using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomControlLibrary.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary.Controls;assembly=WpfCustomControlLibrary.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:BaseSlider/>
    ///
    /// </summary>
    public class BaseSlider : Slider
    {
        public static DependencyProperty IsShowBorderProperty = DependencyProperty.Register("IsShowBorder", typeof(bool), typeof(BaseSlider));

        public bool IsShowBorder
        {
            get { return (bool)GetValue(IsShowBorderProperty); }
            set { SetValue(IsShowBorderProperty, value); }
        }

        public static DependencyProperty ThicknessProperty = DependencyProperty.Register("Thickness", typeof(double),
            typeof(BaseSlider));

        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static DependencyProperty ActualBorderBrushProperty = DependencyProperty.Register("ActualBorderBrush", typeof(Brush),
            typeof(BaseSlider));

        public Brush ActualBorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        public static DependencyProperty LeftBrushProperty = DependencyProperty.Register("LeftBrush", typeof(Brush),
            typeof(BaseSlider));

        public Brush LeftBrush
        {
            get { return (Brush)GetValue(LeftBrushProperty); }
            set { SetValue(LeftBrushProperty, value); }
        }

        public static DependencyProperty RightBrushProperty = DependencyProperty.Register("RightBrush", typeof(Brush),
            typeof(BaseSlider));

        public Brush RightBrush
        {
            get { return (Brush)GetValue(RightBrushProperty); }
            set { SetValue(RightBrushProperty, value); }
        }

        public static DependencyProperty ThumbImageProperty = DependencyProperty.Register("ThumbImage", typeof(ImageSource),
            typeof(BaseSlider));

        public ImageSource ThumbImage
        {
            get { return (ImageSource)GetValue(ThumbImageProperty); }
            set { SetValue(ThumbImageProperty, value); }
        }

        public static DependencyProperty IsPlayProgressProperty = DependencyProperty.Register("IsPlayProgress", typeof(bool),
            typeof(BaseSlider));

        public bool IsPlayProgress
        {
            get { return (bool)GetValue(IsPlayProgressProperty); }
            set { SetValue(IsPlayProgressProperty, value); }
        }

        /// <summary>
        /// IsPlayProgress为true时有效
        /// </summary>
        public bool IsMouseDown { get; private set; }

        private Track _track;
        private bool _isThumb;
        private bool _isMouseCauseValueChange;
        private double _oldValue;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _track = (Track)GetTemplateChild("PART_Track");

            if (_track != null && IsPlayProgress)
            {
                _track.DecreaseRepeatButton.Command = null;
                _track.IncreaseRepeatButton.Command = null;
            }
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            if (IsPlayProgress)
            {
                if (!IsMouseDown && _isMouseCauseValueChange)
                {
                    _isMouseCauseValueChange = false;
                    base.OnValueChanged(oldValue, newValue);
                }
            }
            else
            {
                base.OnValueChanged(oldValue, newValue);
            }
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsPlayProgress)
            {
                _oldValue = Value;
                _isMouseCauseValueChange = true;

                if (IsMoveToPointEnabled && _track?.Thumb != null && !_track.Thumb.IsMouseOver)
                {
                    _isThumb = false;
                    IsMouseDown = false;
                    Point pt = e.MouseDevice.GetPosition(_track);
                    Value = _track.ValueFromPoint(pt);
                }
                else
                {
                    _isThumb = true;
                    IsMouseDown = true;
                    base.OnPreviewMouseLeftButtonDown(e);
                }
            }
            else
            {
                base.OnPreviewMouseLeftButtonDown(e);
            }
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (IsPlayProgress)
            {
                if (_isThumb)
                {
                    IsMouseDown = false;
                    OnValueChanged(_oldValue, Value);
                }
            }
            else
            {
                base.OnPreviewMouseLeftButtonUp(e);
            }
        }
        static BaseSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseSlider), new FrameworkPropertyMetadata(typeof(BaseSlider)));
        }
    }
}
