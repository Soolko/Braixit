namespace Solkbot.Console
{
	public struct SystemConsole : ConsoleBase.ConsoleInterface
	{
		public static readonly SystemConsole Get = new SystemConsole();
		public string GetInput() => System.Console.In.ReadLine();
		
		public void OnOutput(string output) => System.Console.WriteLine(output);
	}
}