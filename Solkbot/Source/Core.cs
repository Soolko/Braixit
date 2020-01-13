using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using Solkbot.Console;
using Solkbot.Console.Commands;
using Solkbot.IO;
using Term = Colorful.Console;

namespace Solkbot
{
	public static class Core
	{
		public static DiscordClient client { get; private set; }
		public static Config config { get; private set; }
		private static ConsoleBase consoleBase;
		
		internal static void Main(string[] args)
		{
			Colorful.Console.CursorVisible = false;
			
			// Config
			bool newConfig = !File.Exists(Config.Path);
			config = !newConfig ? Serializer.Load<Config>(Config.Path) : Config.Default;
			if(newConfig) Serializer.Save(Config.Path, config);
			
			// Console
			ConsoleBase.commands.Add(new Help());
			consoleBase = new ConsoleBase(SystemConsole.Get);

			if(config.token.value == null)
			{
				Color old = Term.ForegroundColor;
				Term.ForegroundColor = Color.OrangeRed;
				Term.WriteLine("No Discord token has been set.\nTry running \"set token <Your discord token>\".");
				Term.ForegroundColor = old;
			}
			
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