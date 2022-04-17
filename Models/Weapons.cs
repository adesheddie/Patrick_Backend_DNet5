namespace Rpg_project.Models
{


    public class Weapon
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Alias { get; set; }

        public int Damage { get; set; }

        public Characters Character { get; set; }


    }


}