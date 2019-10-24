using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace Cheesebot
{
	public static class Core
	{
		public static DiscordClient client { get; private set; }
		
		internal static void Main(string[] args)
		{
			MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
		}
		
		private static async Task MainAsync(string[] args)
		{
			client = new DiscordClient
			(
				new DiscordConfiguration
				{
					Token = "",
					TokenType = TokenType.Bot
				}
			);
		}
	}
}