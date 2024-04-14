using System.Diagnostics;

namespace EliteAPI.Events.Generator;

public class Schemas
{
	public static IEnumerable<(string name, string schema)> GetSchemas()
	{
		Process.Start("git", "clone https://github.com/Somfic/journal-Schemas.git Schemas-repo").WaitForExit();

		var files = Directory.GetFiles("Schemas-repo", "*.json", SearchOption.AllDirectories);
		var schemas = new List<(string, string)>();

		foreach (var file in files)
		{
			var name = Path.GetFileNameWithoutExtension(file);

			if (name is "_Event" or "ShipLockerBackpack" or "ShipLockerMaterials")
				continue;

			var schema = File.ReadAllText(file);

			schemas.Add((name, schema));
		}

		return schemas;
	}
}