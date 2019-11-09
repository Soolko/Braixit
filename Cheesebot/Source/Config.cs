using System;
using Cheesebot.Console;

namespace Cheesebot
{
	[Serializable]
	public struct Config
	{
		internal const string Path = "./Cheesebot.cfg";
		internal static Config Default => new Config
		{
			token = new ConsoleVariable<string>("token", null)
		};
		
		internal ConsoleVariable<string> token;
	}
}