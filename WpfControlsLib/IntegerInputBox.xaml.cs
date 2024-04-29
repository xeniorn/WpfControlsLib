using System.Windows;
using System.Windows.Controls;

namespace WpfControlsLib
{
    /// <summary>
    ///     Interaction logic for IntegerInputBox.xaml
    /// </summary>
    public partial class IntegerInputBox : UserControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string),
            typeof(IntegerInputBox),
            new FrameworkPropertyMetadata { BindsTwoWayByDefault = false, DefaultValue = default(string) });

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int),
            typeof(IntegerInputBox),
            new FrameworkPropertyMetadata { BindsTwoWayByDefault = true, DefaultValue = default(int) });


        public IntegerInputBox()
        {
            InitializeComponent();
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}