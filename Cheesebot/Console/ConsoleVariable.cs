namespace Cheesebot.Console
{
	public interface ConsoleVariable { }
	
	[System.Serializable]
	public struct ConsoleVariable<Type> : ConsoleVariable where Type : class
	{
		public string key;
		public Type value;
		
		public ConsoleVariable(string key, Type value = default(Type))
		{
			this.key = key;
			this.value = value;
			
			ConsoleBase.variables.Add(this);
		}
	}
}