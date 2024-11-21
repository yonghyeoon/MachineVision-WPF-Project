using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfMachineVision.Support.Local.Behaviors
{
    public class SliderValueChangedBehavior : Behavior<Slider>
    {
        public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(SliderValueChangedBehavior), new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(SliderValueChangedBehavior), new PropertyMetadata(null));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ValueChanged += OnSliderValueChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.ValueChanged -= OnSliderValueChanged;
        }

        private void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (Command?.CanExecute(CommandParameter ?? e.NewValue) == true)
                {
                    Command.Execute(CommandParameter ?? e.NewValue);
                }
            }
            catch (Exception ex)
            {
                // 예외 처리 (문제를 로깅하거나 무시)
                MessageBox.Show($"SliderValueChangedBehavior Error: {ex.Message}");
            }
        }
    }
}
