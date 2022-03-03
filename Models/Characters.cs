namespace Rpg_project.Models
{


    public class Characters
    {


        public int Id { get; set; }

        public string Name { get; set; } = "Mordor";

        public int Defence { get; set; } = 10;

        public int Skills { get; set; } = 100;

        public RpgClass Class { get; set; } = RpgClass.Cleric;

        public Users User { get; set; }

    }


}