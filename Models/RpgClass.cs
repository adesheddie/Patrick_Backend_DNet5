using System.Text.Json.Serialization;

namespace Rpg_project.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {


        Knight,
        Mage,
        Cleric
//

    }

}