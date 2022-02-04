﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for NumericInputBox.xaml
    /// </summary>
    public partial class NumericInputBox : UserControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string),
            typeof(NumericInputBox),
            new FrameworkPropertyMetadata { BindsTwoWayByDefault = false, DefaultValue = default(string) });

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double),
            typeof(NumericInputBox),
            new FrameworkPropertyMetadata { BindsTwoWayByDefault = true, DefaultValue = default(double) });
        

        // Using a DependencyProperty as the backing store for RoundingMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoundingModeProperty =
            DependencyProperty.Register("RoundingMode", typeof(RoundingMode), typeof(NumericInputBox),
                new FrameworkPropertyMetadata { BindsTwoWayByDefault = true, DefaultValue = default(RoundingMode) });
        
        // Using a DependencyProperty as the backing store for DecimalSpots.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecimalSpotsProperty =
            DependencyProperty.Register("DecimalSpots", typeof(int), typeof(NumericInputBox),
                new FrameworkPropertyMetadata { BindsTwoWayByDefault = true, DefaultValue = 2 });


      // Using a DependencyProperty as the backing store for SignificantDigits.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SignificantDigitsProperty =
            DependencyProperty.Register("SignificantDigits", typeof(int), typeof(NumericInputBox),
                new FrameworkPropertyMetadata { BindsTwoWayByDefault = true, DefaultValue = 3 });



        public NumericInputBox()
        {
            InitializeComponent();
        }

        public int SignificantDigits
        {
            get => (int)GetValue(SignificantDigitsProperty);
            set => SetValue(SignificantDigitsProperty, value);
        }


        public RoundingMode RoundingMode
        {
            get => (RoundingMode)GetValue(RoundingModeProperty);
            set => SetValue(RoundingModeProperty, value);
        }

        public int DecimalSpots
        {
            get => (int)GetValue(DecimalSpotsProperty);
            set => SetValue(DecimalSpotsProperty, value);
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // no, do it as a value converter, not as a string format. Too inflexible!
        // cell editing template should show full value, cell viewing template the converter value
        public string CustomStringFormat
        {
            get
            {
                switch (RoundingMode)
                {
                    case RoundingMode.None: return "";
                        break;
                    case RoundingMode.Auto:
                    case RoundingMode.DecimalPlaces:
                        return StringFromFixedDecimalPlaces();
                        break;
                    case RoundingMode.SignificantDigits:
                        return StringFromFixedSignificantDigits
                        
                        
                    }

                }
            }
        }

        private string StringFromFixedDecimalPlaces()
        {
            if (DecimalSpots > 0)
            {
                return "#" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator +
                       String.Join("", Enumerable.Repeat("0", DecimalSpots));
            }
            else 
            {
                return "#";
            }
            
        }
    }

    public enum RoundingMode
    {
        Auto,
        SignificantDigits,
        DecimalPlaces,
        None
    }
}
