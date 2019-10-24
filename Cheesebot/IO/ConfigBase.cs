using System.IO;
using YamlDotNet.Serialization;

namespace Cheesebot.IO
{
	public abstract class ConfigBase
	{
		[System.NonSerialized] public readonly string path;
		
		[System.NonSerialized] protected ISerializer serializer = null;
		[System.NonSerialized] protected IDeserializer deserializer = null;
		
		protected ConfigBase(string path)
		{
			this.path = path;
			Directory.CreateDirectory(path);
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