using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;
using System.Reflection;

namespace Bob.Core
{
    public static class Runner
    {
        public static IBob Compile(string text)
        {
            CSharpCompilation compilation =
                CSharpCompilation.Create(Path.GetRandomFileName())
                    .AddSyntaxTrees(CSharpSyntaxTree.ParseText(text))
                    .AddReferences(MetadataReference.CreateFromAssembly(Assembly.GetAssembly(typeof(Console)), MetadataReferenceProperties.Assembly))
                    .AddReferences(MetadataReference.CreateFromAssembly(typeof(Runner).Assembly))
                    .WithOptions(new CSharpCompilationOptions(outputKind: OutputKind.DynamicallyLinkedLibrary));

            foreach (Diagnostic diagnose in compilation.GetDiagnostics())
            {
                Console.WriteLine(diagnose);
            }

            using (MemoryStream stream = new MemoryStream())
            {
                compilation.Emit(stream);

                Assembly assembly = Assembly.Load(stream.ToArray());

                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IBob).IsAssignableFrom(type))
                    {
                        return (IBob)Activator.CreateInstance(type);
                    }
                }
            }

            return null;
        }
    }
}
