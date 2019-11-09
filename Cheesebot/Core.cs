using System;
using System.IO;
using System.Threading.Tasks;
using Cheesebot.Console;
using Cheesebot.IO;
using DSharpPlus;

namespace Cheesebot
{
	public static class Core
	{
		public static DiscordClient client { get; private set; }
		internal static Config config { get; private set; }
		
		
		internal static void Main(string[] args)
		{
			// Config
			bool newConfig = !File.Exists(Config.Path);
			config = !newConfig ? Serializer.Load<Config>(Config.Path) : Config.Default;
			if(newConfig) Serializer.Save(Config.Path, config);
			
			// Console
			
			
			// DSharpPlus
			MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
		}
		
		private static async Task MainAsync(string[] args)
		{
			client = new DiscordClient
			(
				new DiscordConfiguration
				{
					Token = config.token.value,
					TokenType = TokenType.Bot
				}
			);
		}
		
		[Serializable]
		internal struct Config
		{
			internal const string Path = "./Cheesebot.cfg";
			
			internal static Config Default => new Config
			{
				token = new ConsoleVariable<string>("token", null)
			};
			
			internal ConsoleVariable<string> token;
		}
	}
}