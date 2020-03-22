using System.Collections.Generic;
using System.Text;

namespace Braixit.Console
{
	public class ConsoleBase
	{
		/// <summary>
		/// The ConsoleVariables that are currently initialised to the console.
		/// </summary>
		public static readonly List<ConsoleVariable> variables = new List<ConsoleVariable>();
		public static readonly List<ConsoleCommand> commands = new List<ConsoleCommand>();
		
		public interface ConsoleInterface
		{
			string GetInput();
			void OnOutput(string output);
		}
		
		protected readonly ConsoleInterface callback;
		public ConsoleBase(ConsoleInterface callback) => this.callback = callback;
		
		public void Parse()
		{
			IEnumerable<string> args = GetArgs(callback.GetInput());
			
		}
		
		public static IEnumerable<string> GetArgs(string line)
		{
			StringBuilder currentWord = new StringBuilder();
			List<string> args = new List<string>();
			
			bool inString = false;
			foreach(char c in line)
			{
				switch(c)
				{
					case '\"': inString = !inString; continue;
					case ' ':
						if(inString) break;
						
						args.Add(currentWord.ToString());
						currentWord.Clear();
						continue;
				}
				currentWord.Append(c.ToString());
			}
			
			return args;
		}
	}
}