using System.IO;
using YamlDotNet.Serialization;

namespace Cheesebot.IO
{
	public abstract class ConfigBase
	{
		[System.NonSerialized] public readonly string path;
		
		[System.NonSerialized] protected ISerializer serializer = null;
		[System.NonSerialized] protected IDeserializer deserializer = null;

		public string token;
		
		protected ConfigBase(string path)
		{
			this.path = path;
			Directory.CreateDirectory(path);
			
			// Create default file if non-existent
			if(!File.Exists(path)) Save();
		}

		public Type Load<Type>()
		{
			if(deserializer == null) deserializer = new DeserializerBuilder().Build();
			
			string data = File.ReadAllText(path);
			return deserializer.Deserialize<Type>(data);
		}
		
		public void Save()
		{
			if(serializer == null) serializer = new SerializerBuilder().Build();
			
			string data = serializer.Serialize(this);
			File.WriteAllText(path, data);
		}
	}
}