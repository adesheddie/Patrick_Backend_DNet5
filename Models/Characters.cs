using System.Collections.Generic;
using Patrick_Backend_DNet5.Models;

namespace Rpg_project.Models
{


    public class Characters
    {


        public int Id { get; set; }

        public string Name { get; set; } = "Mordor";

        public int Defence { get; set; } = 10;

        public int Attack { get; set; } = 100;

        public RpgClass Class { get; set; } = RpgClass.Cleric;

        public Users User { get; set; }

        public Weapon Weapon {get;set;}

        public List<Skill> Skills {get;set;}

    }


}