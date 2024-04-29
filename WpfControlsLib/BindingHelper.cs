using System.Windows;
using System.Windows.Data;

namespace WpfControlsLib
{
    public static class BindingHelper
    {
        public static void BindSourceToTargetDependencyProperty(object sourceObject,
            string sourcePropertyPathString,
            DependencyObject targetDependencyObject,
            DependencyProperty targetDependencyProperty,
            BindingMode targetBindingMode = BindingMode.TwoWay,
            IValueConverter iConverter = null)
        {
            BindSourceToTargetDependencyProperty(sourceObject, new PropertyPath(sourcePropertyPathString),
                targetDependencyObject, targetDependencyProperty, targetBindingMode, iConverter);
        }

        public static void BindSourceToTargetDependencyProperty(object sourceObject,
            PropertyPath sourcePropertyPath,
            DependencyObject targetDependencyObject,
            DependencyProperty targetDependencyProperty,
            BindingMode targetBindingMode = BindingMode.TwoWay,
            IValueConverter iConverter = null)
        {
            var tempBind = new Binding
            {
                Mode = targetBindingMode,
                Path = sourcePropertyPath,
                Source = sourceObject
            };
            if (iConverter != null) tempBind.Converter = iConverter;

            BindingOperations.SetBinding(targetDependencyObject, targetDependencyProperty, tempBind);
        }

        public static void UnbindTargetDependencyProperty(DependencyObject targetDependencyObject,
            DependencyProperty targetDependencyProperty)
        {
            BindingOperations.ClearBinding(targetDependencyObject, targetDependencyProperty);
        }
    }
}