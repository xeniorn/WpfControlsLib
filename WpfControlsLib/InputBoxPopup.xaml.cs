using System.Windows;

namespace WpfControlsLib
{
    /// <summary>
    ///     Interaction logic for InputBoxPopup.xaml
    /// </summary>
    public partial class InputBoxPopup : Window
    {
        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(InputBoxPopup),
                new FrameworkPropertyMetadata { BindsTwoWayByDefault = true, DefaultValue = "" });

        // Using a DependencyProperty as the backing store for PromptText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromptTextProperty =
            DependencyProperty.Register("PromptText", typeof(string), typeof(InputBoxPopup),
                new FrameworkPropertyMetadata { BindsTwoWayByDefault = false, DefaultValue = "" });

        public InputBoxPopup()
        {
            InitializeComponent();
            PromptText = "Input text:";
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }


        public string PromptText
        {
            get => (string)GetValue(PromptTextProperty);
            set => SetValue(PromptTextProperty, value);
        }
    }
}