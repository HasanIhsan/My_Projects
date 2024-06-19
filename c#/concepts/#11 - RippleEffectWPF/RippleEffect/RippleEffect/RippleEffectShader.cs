using System;
using System.Windows.Media.Effects;
using System.Windows;
using System.Windows.Media;

namespace RippleEffect
{
    public class RippleEffectShader : ShaderEffect
    {
        private static readonly PixelShader _pixelShader = new PixelShader()
        {
            UriSource = new Uri("pack://application:,,,/RippleEffect;component/RippleEffect.ps")
        };


        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register(
            "Center", typeof(Point), typeof(RippleEffectShader), new UIPropertyMetadata(new Point(0.5, 0.5), PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
            "Time", typeof(double), typeof(RippleEffectShader), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(1)));

        public static readonly DependencyProperty AmplitudeProperty = DependencyProperty.Register(
            "Amplitude", typeof(double), typeof(RippleEffectShader), new UIPropertyMetadata(0.1, PixelShaderConstantCallback(2)));

        public static readonly DependencyProperty FrequencyProperty = DependencyProperty.Register(
            "Frequency", typeof(double), typeof(RippleEffectShader), new UIPropertyMetadata(10.0, PixelShaderConstantCallback(3)));

        public RippleEffectShader()
        {
            PixelShader = _pixelShader;

            UpdateShaderValue(CenterProperty);
            UpdateShaderValue(TimeProperty);
            UpdateShaderValue(AmplitudeProperty);
            UpdateShaderValue(FrequencyProperty);
        }

        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        public double Time
        {
            get { return (double)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public double Amplitude
        {
            get { return (double)GetValue(AmplitudeProperty); }
            set { SetValue(AmplitudeProperty, value); }
        }

        public double Frequency
        {
            get { return (double)GetValue(FrequencyProperty); }
            set { SetValue(FrequencyProperty, value); }
        }
    }
}
