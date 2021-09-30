namespace CsWpfShader
{
    using System;
    using System.Windows.Media.Effects;

    using static System.FormattableString;

    public static class Utility
    {
        public static PixelShader CreatePixelShader<T>() =>
            new PixelShader
            {
                UriSource = GetShaderUri<T>(),
            };

        public static Uri GetShaderUri<T>()
        {
            var type = typeof(T);
            var fullName = type.Name;
            var name = fullName.Substring(0, fullName.Length - "ShaderEffect".Length);

            return MakePackUri(Invariant($"{name}.ps.fx"));
        }

        public static Uri MakePackUri(string relativeFile)
        {
            var assembly = typeof (Utility).Assembly;

            // Extract the short name.
            var assemblyShortName = assembly.ToString().Split(',')[0];

            var uriString = Invariant($"pack://application:,,,/{assemblyShortName};component/Resources/{relativeFile}");

            return new Uri(uriString);
        }

    }
}
