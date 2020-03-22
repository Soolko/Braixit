using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Braixit.IO
{
	public static class Serializer
	{
		public static void Save(string path, object obj)
		{
			using FileStream file = File.Create(path);
			new BinaryFormatter().Serialize(file, obj);
		}
		
		public static Type Load<Type>(string path)
		{
			using FileStream file = File.Open(path, FileMode.Open);
			return (Type) new BinaryFormatter().Deserialize(file);
		}
	}
}