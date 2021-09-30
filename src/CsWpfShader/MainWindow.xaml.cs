namespace CsWpfShader
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Effects;
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        readonly BackgroundShaderEffect _effect     = new BackgroundShaderEffect();

        public MainWindow()
        {
            InitializeComponent();
            BackgroundEffect.Effect = _effect;
            var from = 0.0;
            var to   = 1E6;
            var dur  = new Duration(TimeSpan.FromSeconds(to - from));
            var anim = new DoubleAnimation(from, to, dur);
            anim.Freeze();
            this.BeginAnimation(TimeProperty, anim);
        }

        partial void OnTimePropertyChanged(double oldValue, double newValue)
        {
            _effect.Resolution  = new Point(BackgroundEffect.ActualWidth, BackgroundEffect.ActualHeight);
            _effect.Time        = newValue;
            BackgroundEffect.InvalidateVisual();
        }
    }
}
