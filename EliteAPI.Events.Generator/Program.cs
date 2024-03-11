using EliteAPI.Events.Generator;
using Newtonsoft.Json.Linq;

var schemas = Schemas.GetSchemas();

foreach (var rawSchema in schemas)
{
	var schema = JObject.Parse(rawSchema.schema);
	
	var description = schema["description"]?.Value<string>();
	
	var properties = new List<(string type, string name)>();
	var subClasses = new Dictionary<string, List<(string type, string name)>>();

	if(schema["properties"] == null)
	{
		continue;
	}
	
	foreach (var property in schema["properties"]!)
	{
		var propertyName = ((JProperty)property).Name;
		
		if(propertyName.EndsWith("_Localised"))
			continue;
		
		var propertyType = (string)property.First!["type"]!;
		
		if (propertyName.EndsWith("ID") || propertyName.EndsWith("Address"))
			propertyType = "string";
		
		var propertyTypeName = GetCSharpType(propertyType);
		properties.Add((propertyTypeName, propertyName));
	}

	var file = new FileInfo($"../../../../EliteAPI.Events/{rawSchema.name}Event.cs");

	if (file.Exists)
	{
		var content = File.ReadAllText(file.FullName);

		foreach (var property in properties)
		{
			var jsonPropertyAttribute = $"[JsonProperty(\"{property.name}\")]";
			var propertyAttribute = $"public {property.type} {property.name} {{ get; init; }}";

			if(property.type.StartsWith("SUBCLASS"))
				continue;
			
			if (!content.Contains(jsonPropertyAttribute))
			{
				Console.WriteLine($"Property {property.name} not found in {rawSchema.name}Event.cs");
				
				var propertyLine = $"\n    {jsonPropertyAttribute}\n    {propertyAttribute}\n";
				
				// Add the property to the class file, just before the last bracket
				
				var lastBracket = content.LastIndexOf('}');
				
				content = content.Insert(lastBracket, propertyLine);
				
				// Format the file
				content = content.Replace("\n\n\n", "\n\n");
				
				// Indent based on brackets
				var lines = content.Split('\n');
				var indent = 0;
				for (var i = 0; i < lines.Length; i++)
				{
					var line = lines[i].Trim();
					indent -= line.Count(c => c == '}');
					indent += line.Count(c => c == '{');

					if (line.StartsWith('{'))
					{
						lines[i] = new string('\t', indent - 1) + line;
					}
					else
					{
						lines[i] = new string('\t', indent) + line;
					}


				}
				
				content = string.Join('\n', lines);
				
				File.WriteAllText(file.FullName, content);
			}
		}
	}
	else
	{
		Console.WriteLine($"File {rawSchema.name}Event.cs not found");
	}
}

string GetCSharpType(string jsonType)
{
	return jsonType switch
	{
		"string" => "string",
		"number" => "double",
		"integer" => "int",
		"boolean" => "bool",
		"object" => "SUBCLASS:OBJECT",
		"array" => "SUBCLASS:ARRAY",
		_ => jsonType
	};
}