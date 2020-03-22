using System.Collections.Generic;

namespace Braixit.Console
{
	public interface ConsoleCommand
	{
		void OnExecute(IEnumerable<string> args);
	}
}