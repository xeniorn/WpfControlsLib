﻿using System;
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

namespace WpfControlsLib
{
    /// <summary>
    /// Interaction logic for IntegerInputBox.xaml
    /// </summary>
    public partial class IntegerInputBox : UserControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(IntegerInputBox), 
            new FrameworkPropertyMetadata() {BindsTwoWayByDefault = false,DefaultValue = default(string)});
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(IntegerInputBox), 
            new FrameworkPropertyMetadata() { BindsTwoWayByDefault = true, DefaultValue = default(int) });


        public IntegerInputBox()
        {
            InitializeComponent();
        }

        public string Label
        {
            get { return (string) GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public int Value
        {
            get { return (int) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
