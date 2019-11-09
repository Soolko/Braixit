using System.Collections.Generic;

namespace Cheesebot.Console
{
	public interface ConsoleCommand
	{
		void OnExecute(IEnumerable<string> args);
	}
}