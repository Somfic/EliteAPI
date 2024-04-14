using LibGit2Sharp;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

Console.WriteLine("Cloning EDDN schemas from remote ...");
var repoPath = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
Repository.Clone("https://github.com/EDCD/EDDN.git", repoPath);

// Checkout the live branch
var repo = new Repository(repoPath);
Commands.Checkout(repo, "live");
Commands.Fetch(repo, "origin", new string[0], null, null);

var schemas = Directory.GetFiles(Path.Join(repoPath, "schemas"), "*.json");

Console.WriteLine("Generating C# classes ...");

foreach (var schemaFile in schemas)
{
	var schema = await JsonSchema.FromFileAsync(schemaFile);
	var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings()
	{
		Namespace = $"EliteAPI.EDDN.Schemas.{Path.GetFileNameWithoutExtension(schemaFile).Replace(".", "_").Replace("-", "_")}",
		ClassStyle = CSharpClassStyle.Poco,
		JsonLibrary = CSharpJsonLibrary.NewtonsoftJson,
		DateTimeType = "DateTime",
		DateType = "DateTime",
	});

	var content = "using System;\n \n" + generator.GenerateFile().Replace("@$", "@");
	
	var path = Path.GetFullPath(Path.Join("../../../../EliteAPI.EDDN/Models/", Path.GetFileNameWithoutExtension(schemaFile), "Message.cs"));
	Directory.CreateDirectory(Path.GetDirectoryName(path)!);

	Console.WriteLine($"Generated {path}");
	
	await File.WriteAllTextAsync(path, content);
}

Console.WriteLine("Done!");

