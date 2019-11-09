using System.IO;
using System.Threading.Tasks;
using Cheesebot.Console;
using Cheesebot.Console.Commands;
using Cheesebot.IO;
using DSharpPlus;

namespace Cheesebot
{
	public static class Core
	{
		public static DiscordClient client { get; private set; }
		public static Config config { get; private set; }
		private static ConsoleBase consoleBase;
		
		internal static void Main(string[] args)
		{
			// Config
			bool newConfig = !File.Exists(Config.Path);
			config = !newConfig ? Serializer.Load<Config>(Config.Path) : Config.Default;
			if(newConfig) Serializer.Save(Config.Path, config);
			
			// Console
			ConsoleBase.commands.Add(new Help());
			consoleBase = new ConsoleBase(SystemConsole.Get);
			
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
	}
}