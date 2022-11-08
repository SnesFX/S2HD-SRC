using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp;

namespace SonicOrca.Core
{
	// Token: 0x02000143 RID: 323
	internal static class ScriptImport
	{
		// Token: 0x06000D54 RID: 3412 RVA: 0x000327C4 File Offset: 0x000309C4
		public static Type[] Compile(string sourceCode)
		{
			if (sourceCode.StartsWith("#use "))
			{
				string useNamespace = ScriptImport.ReadToWhitespace(sourceCode.Substring(5));
				return (from x in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly x) => x.GetTypes())
				where x.Namespace == useNamespace
				select x).ToArray<Type>();
			}
			IReadOnlyList<string> referenceAssemblyNames = new string[]
			{
				"SonicOrca"
			};
			CompilerParameters compilerParameters = new CompilerParameters((from x in AppDomain.CurrentDomain.GetAssemblies()
			where referenceAssemblyNames.Contains(x.GetName().Name)
			select x.Location).ToArray<string>());
			compilerParameters.GenerateInMemory = true;
			CompilerResults compilerResults = new CSharpCodeProvider().CompileAssemblyFromSource(compilerParameters, new string[]
			{
				sourceCode
			});
			if (compilerResults.Errors.Count > 0)
			{
				throw new Exception("Compile errors:\n" + string.Join(Environment.NewLine, from x in compilerResults.Errors.OfType<CompilerError>()
				select string.Format("  Line {0}, {1}", x.Line, x.ErrorText)));
			}
			return compilerResults.CompiledAssembly.GetTypes();
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00032920 File Offset: 0x00030B20
		private static string ReadToWhitespace(string input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (char.IsWhiteSpace(input[i]))
				{
					return input.Substring(0, i);
				}
			}
			return input;
		}
	}
}
