using System;
using System.Collections.Generic;

namespace Accord
{
	// Token: 0x02000012 RID: 18
	public static class PolishExpression
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00002ED4 File Offset: 0x00001ED4
		public static double Evaluate(string expression, double[] variables)
		{
			string[] array = expression.Trim().Split(new char[]
			{
				' '
			});
			Stack<double> stack = new Stack<double>();
			foreach (string text in array)
			{
				if (char.IsDigit(text[0]))
				{
					stack.Push(double.Parse(text));
				}
				else
				{
					if (text[0] != '$')
					{
						double num = stack.Pop();
						uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text);
						if (num2 <= 789356349U)
						{
							if (num2 <= 705468254U)
							{
								if (num2 != 671913016U)
								{
									if (num2 == 705468254U)
									{
										if (text == "/")
										{
											stack.Push(stack.Pop() / num);
											goto IL_284;
										}
									}
								}
								else if (text == "-")
								{
									stack.Push(stack.Pop() - num);
									goto IL_284;
								}
							}
							else if (num2 != 772578730U)
							{
								if (num2 == 789356349U)
								{
									if (text == "*")
									{
										stack.Push(stack.Pop() * num);
										goto IL_284;
									}
								}
							}
							else if (text == "+")
							{
								stack.Push(stack.Pop() + num);
								goto IL_284;
							}
						}
						else if (num2 <= 1923516200U)
						{
							if (num2 != 1127334399U)
							{
								if (num2 == 1923516200U)
								{
									if (text == "exp")
									{
										stack.Push(Math.Exp(num));
										goto IL_284;
									}
								}
							}
							else if (text == "ln")
							{
								stack.Push(Math.Log(num));
								goto IL_284;
							}
						}
						else if (num2 != 2112764879U)
						{
							if (num2 != 3761252941U)
							{
								if (num2 == 4220379804U)
								{
									if (text == "cos")
									{
										stack.Push(Math.Cos(num));
										goto IL_284;
									}
								}
							}
							else if (text == "sin")
							{
								stack.Push(Math.Sin(num));
								goto IL_284;
							}
						}
						else if (text == "sqrt")
						{
							stack.Push(Math.Sqrt(num));
							goto IL_284;
						}
						throw new ArgumentException("Unsupported function: " + text);
					}
					stack.Push(variables[int.Parse(text.Substring(1))]);
				}
				IL_284:;
			}
			if (stack.Count != 1)
			{
				throw new ArgumentException("Incorrect expression.");
			}
			return stack.Pop();
		}
	}
}
