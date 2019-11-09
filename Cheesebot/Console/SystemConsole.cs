namespace Cheesebot.Console
{
	public struct SystemConsole : ConsoleBase.ConsoleInterface
	{
		public static SystemConsole Get => new SystemConsole();
		public string GetInput()
		{
			return "";
		}
			
		public void OnOutput(string output) => System.Console.WriteLine(output);
	}
}