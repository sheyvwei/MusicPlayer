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
    ///     <MyNamespace:MusicButton/>
    ///
    /// </summary>
    public class MusicButton : Button
    {
        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(MusicButton), new PropertyMetadata(Brushes.Red));
        public Brush MouseOverBackground     //鼠标进入背景
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(MusicButton), new PropertyMetadata(Brushes.Black));
        public Brush MouseOverForeground        //鼠标进入前景
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty MusicIconProperty =
            DependencyProperty.Register("MusicIcon", typeof(string), typeof(MusicButton), new PropertyMetadata("\ue604"));
        public string MusicIcon     //图标编码
        {
            get { return (string)GetValue(MusicIconProperty); }
            set { SetValue(MusicIconProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(int), typeof(MusicButton), new PropertyMetadata(12));
        public int IconSize     //图标尺寸
        {
            get { return (int)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(MusicButton), new PropertyMetadata(new Thickness(0, 1, 3, 1)));
        public Thickness IconMargin     //图标位置
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        public static readonly DependencyProperty AllowsAnimationProperty =
            DependencyProperty.Register("AllowsAnimation", typeof(bool), typeof(MusicButton), new PropertyMetadata(false));
        public bool AllowsAnimation     //是否要动画效果，（旋转...)
        {
            get { return (bool)GetValue(AllowsAnimationProperty); }
            set { SetValue(AllowsAnimationProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MusicButton), new PropertyMetadata(new CornerRadius(2)));
        public CornerRadius CornerRadius        //圆角
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty ContentDecorationsProperty =
            DependencyProperty.Register("ContentDecorations", typeof(TextDecorationCollection), typeof(MusicButton), new PropertyMetadata(null));
        public TextDecorationCollection ContentDecorations      //文本装饰
        {
            get { return (TextDecorationCollection)GetValue(ContentDecorationsProperty); }
            set { SetValue(ContentDecorationsProperty, value); }
        }
        static MusicButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MusicButton), new FrameworkPropertyMetadata(typeof(MusicButton)));
        }
    }
}
