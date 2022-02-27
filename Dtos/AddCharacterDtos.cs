using Rpg_project.Models;

namespace Rpg_project.Dtos.AddCharacterDtos
{



    public class AddCharacterDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = "Mordor";

        public int Defence { get; set; } = 10;

        public int Skills { get; set; } = 100;

        public RpgClass Class { get; set; } = RpgClass.Cleric;

    }

}