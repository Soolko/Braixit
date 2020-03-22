using System;
using Braixit.Console;

namespace Braixit
{
	[Serializable]
	public struct Config
	{
		internal const string Path = "./Braixit.cfg";
		internal static Config Default => new Config
		{
			token = new ConsoleVariable<string>("token", null)
		};
		
		internal ConsoleVariable<string> token;
	}
}