using System.Globalization;
using WpfShaderEffects.DirectX;

using static System.FormattableString;

Environment.CurrentDirectory    = AppDomain.CurrentDomain.BaseDirectory;

CultureInfo defaultCulture      = CultureInfo.InvariantCulture;
CultureInfo.CurrentCulture      = defaultCulture;
CultureInfo.CurrentUICulture    = defaultCulture;

var inputs = new []
{
    "basic.ps"      ,
    "background.ps" ,
};

Console.WriteLine(Invariant($"Compiling {inputs.Length} pixel shaders"));

Console.WriteLine("Creating compiler...");
using var compiler = new EffectCompiler();

foreach (var input in inputs)
{
    Console.WriteLine(Invariant($"Processing: {input}"));

    var output = Invariant($"{input}.fx");

    Console.WriteLine("  Reading...");
    var source = File.ReadAllText(input);


    Console.WriteLine("  Compiling...");
    var bytes = compiler.CompilePixelShader(source);
    Console.WriteLine($"  Writing: {output}");

    File.WriteAllBytes(output, bytes);
}

Console.WriteLine("Done");
Environment.ExitCode = 0;

