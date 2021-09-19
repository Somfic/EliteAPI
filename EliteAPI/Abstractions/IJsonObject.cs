namespace EliteAPI.Abstractions
{
    public interface IJsonObject
    {
        /// <summary>
        /// Generates this objects's Json
        /// </summary>
        string ToJson();
    }
}