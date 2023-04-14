using System.Text.Json.Serialization; //Added for json Converter

namespace Products.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] // returns String instead of numbers in enum category
    public enum Category
    {
        Laptop = 1,
        Cellphone = 2,
        Camera = 3
    }
}