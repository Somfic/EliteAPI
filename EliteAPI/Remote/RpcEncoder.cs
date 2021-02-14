using System;
using System.IO;
using System.Linq;

using EliteAPI.Event.Models.Abstractions;

using Microsoft.Extensions.Logging;

using ProtoBuf;
using ProtoBuf.Meta;

public class RpcEncoder
{
    private readonly ILogger<RpcEncoder> _log;

    private bool _initialized;
    
    public RpcEncoder(ILogger<RpcEncoder> log)
    {
        _log = log;
        
        var classes = typeof(IEvent).Assembly.GetTypes().Where(x => typeof(IEvent).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract && !x.IsInterface).ToList();
        for (var i = 0; i < classes.Count; i++)
        {
            var type = classes[i];
            
            RuntimeTypeModel.Default[typeof(IEvent)].AddSubType(100 + i, type.BaseType);
            RuntimeTypeModel.Default[type.BaseType].AddSubType(100, type);
        }
    }
    
    public MemoryStream Encode(IEvent entry)
    {
        var stream = new MemoryStream();
        Serializer.Serialize(stream, entry);

        return stream;
    }

    public T Decode<T>(string encoded)
    {
        byte[] deserialized = Convert.FromBase64String(encoded);
        MemoryStream deserializerStream = new MemoryStream(deserialized);
        return Serializer.Deserialize<T>(deserializerStream);
    }
}