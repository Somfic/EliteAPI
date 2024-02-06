using EliteAPI.Events.Generator;
using Newtonsoft.Json.Linq;

var schemas = Schemas.GetSchemas();

foreach (var rawSchema in schemas)
{
	var schema = JObject.Parse(rawSchema.schema);
	
	var description = schema["description"]?.Value<string>();
	
	var properties = new List<(string type, string name)>();

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

			if (!content.Contains(jsonPropertyAttribute))
			{
				Console.WriteLine($"Property {property.name} not found in {rawSchema.name}Event.cs");
				
				var propertyLine = $"\n    {jsonPropertyAttribute}\n    {propertyAttribute}";
				
				// Add the property to the class file, just before the last bracket
				
				var lastBracket = content.LastIndexOf('}');
				
				content = content.Insert(lastBracket, propertyLine);
				
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
		_ => jsonType
	};
}