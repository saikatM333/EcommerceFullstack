using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RepositoryLayer.JsonHelper
{
    public class JsonHelper
    {
        public static async Task<string> SerializeAsync<T>(T obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };

            using (var stream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(stream, obj, options);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        public static async Task<T> DeserializeAsync<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };

            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                return await JsonSerializer.DeserializeAsync<T>(stream, options);
            }
        }
    }
}
