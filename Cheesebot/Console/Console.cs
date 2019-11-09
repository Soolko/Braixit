using System.Collections.Generic;

namespace Cheesebot.Console
{
	public class Console
	{
		/// <summary>
		/// The ConsoleVariables that are currently initialised to the console.
		/// </summary>
		public static readonly List<ConsoleVariable> variables = new List<ConsoleVariable>();

		protected ConsoleInterface callback;
		public Console(ConsoleInterface callback) => this.callback = callback;
		
		public static void Parse(string input)
		{
			string[] split = input.Split(" ");
			const int argsIndex = 1;
			
			if(split.Length == 0)
			{
				// Run help
				Help();
				return;
			}
			string command = split[0];
		}
		
		public interface ConsoleInterface
		{
			void OnOutput(string output);
		}
	}
}