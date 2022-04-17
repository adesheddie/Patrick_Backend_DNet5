namespace Rpg_project.Models
{


    public class Weapon
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Alias { get; set; }

        public int Damage { get; set; }

        public Characters Character { get; set; }

        public int CharacterId {get;set;} // one to one R, using naming convention, <DbSet name><Id>
        // ^^^ if we do not explicitly define an ID field, that will make it one to many R


    }


}