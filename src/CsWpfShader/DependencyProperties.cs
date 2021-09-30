
namespace CsWpfShader
{
    using System.Windows;

    // ------------------------------------------------------------------------
    partial class MainWindow
    {
        // --------------------------------------------------------------------
        #region Time Property Details
        public readonly static DependencyProperty TimeProperty = DependencyProperty.Register(
                @"Time"
            ,   typeof(double)
            ,   typeof(MainWindow)
            ,   new PropertyMetadata(
                  default(double)
                , OnTimePropertyChangedStatic
                , OnTimeCoerceValueStatic
                )
            );

        static void OnTimePropertyChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t         = (MainWindow)d;
            var oldValue  = (double)e.OldValue;
            var newValue  = (double)e.NewValue;
            t.OnTimePropertyChanged(oldValue, newValue);
        }

        static object OnTimeCoerceValueStatic(DependencyObject d, object baseValue)
        {
            var t           = (MainWindow)d;
            var bv          = (double)baseValue;
            var cv          = default(double);
            var isProcessed = false;
            t.OnTimeCoerceValue(bv, ref cv, ref isProcessed);
            return isProcessed ? cv : baseValue;
        }

        #endregion

        partial void OnTimePropertyChanged(double oldValue, double newValue);
        partial void OnTimeCoerceValue(double baseValue, ref double coercedValue, ref bool isProcessed);
        public double Time
        {
           get => (double)GetValue(TimeProperty);
           set => SetValue(TimeProperty, value);
        }
        // --------------------------------------------------------------------

    }
    // ------------------------------------------------------------------------

}

