using System.Collections.Generic;

namespace Solkbot.Console
{
	public interface ConsoleCommand
	{
		void OnExecute(IEnumerable<string> args);
	}
}