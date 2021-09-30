namespace CsWpfShader
{
  using System.Windows;
  using System.Windows.Media.Effects;

    // ------------------------------------------------------------------------
    public partial class BasicShaderEffect : ShaderEffect
    {
        static readonly PixelShader _pixelShader = Utility.CreatePixelShader<BasicShaderEffect>();

        public BasicShaderEffect()
        {
            PixelShader = _pixelShader;
            UpdateShaderValue(TimeProperty);
        }

        public readonly static DependencyProperty TimeProperty = DependencyProperty.Register(
                @"Time"
            ,   typeof(double)
            ,   typeof(BasicShaderEffect)
            ,   new PropertyMetadata(
                  default(double)
                , PixelShaderConstantCallback(0)
                , OnTimeCoerceValueStatic
                )
            );

        partial void OnTimeCoerceValue(
                double      baseValue
            ,   ref double  newValue
            ,   ref bool        isProcessed
            );

        static object OnTimeCoerceValueStatic(
                DependencyObject  instance
            ,   object            baseValue
            )
        {
           var inst = (BasicShaderEffect)instance;
           if(inst != null)
           {
              var bv          = (double)baseValue;
              var newValue    = default(double);
              var isProcessed = false;
              inst.OnTimeCoerceValue(
                 bv,
                 ref newValue,
                 ref isProcessed);
              if (isProcessed)
              {
                 return newValue;
              }
              else
              {
                 return baseValue;
              }
           }
           else
           {
              return baseValue;
           }
        }

      public double Time
      {
         get
         {
            return (double)GetValue(TimeProperty);
         }
         set
         {
            SetValue(TimeProperty, value);
         }
      }

    }
    // ------------------------------------------------------------------------

    // ------------------------------------------------------------------------
    public partial class BackgroundShaderEffect : ShaderEffect
    {
        static readonly PixelShader _pixelShader = Utility.CreatePixelShader<BackgroundShaderEffect>();

        public BackgroundShaderEffect()
        {
            PixelShader = _pixelShader;
            UpdateShaderValue(TimeProperty);
            UpdateShaderValue(ResolutionProperty);
        }

        public readonly static DependencyProperty TimeProperty = DependencyProperty.Register(
                @"Time"
            ,   typeof(double)
            ,   typeof(BackgroundShaderEffect)
            ,   new PropertyMetadata(
                  default(double)
                , PixelShaderConstantCallback(0)
                , OnTimeCoerceValueStatic
                )
            );

        partial void OnTimeCoerceValue(
                double      baseValue
            ,   ref double  newValue
            ,   ref bool        isProcessed
            );

        static object OnTimeCoerceValueStatic(
                DependencyObject  instance
            ,   object            baseValue
            )
        {
           var inst = (BackgroundShaderEffect)instance;
           if(inst != null)
           {
              var bv          = (double)baseValue;
              var newValue    = default(double);
              var isProcessed = false;
              inst.OnTimeCoerceValue(
                 bv,
                 ref newValue,
                 ref isProcessed);
              if (isProcessed)
              {
                 return newValue;
              }
              else
              {
                 return baseValue;
              }
           }
           else
           {
              return baseValue;
           }
        }

      public double Time
      {
         get
         {
            return (double)GetValue(TimeProperty);
         }
         set
         {
            SetValue(TimeProperty, value);
         }
      }
        public readonly static DependencyProperty ResolutionProperty = DependencyProperty.Register(
                @"Resolution"
            ,   typeof(Point)
            ,   typeof(BackgroundShaderEffect)
            ,   new PropertyMetadata(
                  default(Point)
                , PixelShaderConstantCallback(1)
                , OnResolutionCoerceValueStatic
                )
            );

        partial void OnResolutionCoerceValue(
                Point      baseValue
            ,   ref Point  newValue
            ,   ref bool        isProcessed
            );

        static object OnResolutionCoerceValueStatic(
                DependencyObject  instance
            ,   object            baseValue
            )
        {
           var inst = (BackgroundShaderEffect)instance;
           if(inst != null)
           {
              var bv          = (Point)baseValue;
              var newValue    = default(Point);
              var isProcessed = false;
              inst.OnResolutionCoerceValue(
                 bv,
                 ref newValue,
                 ref isProcessed);
              if (isProcessed)
              {
                 return newValue;
              }
              else
              {
                 return baseValue;
              }
           }
           else
           {
              return baseValue;
           }
        }

      public Point Resolution
      {
         get
         {
            return (Point)GetValue(ResolutionProperty);
         }
         set
         {
            SetValue(ResolutionProperty, value);
         }
      }

    }
    // ------------------------------------------------------------------------

}

