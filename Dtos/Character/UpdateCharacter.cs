using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg_project.Models;

namespace Rpg_project.Dtos
{
    public class UpdateCharacterDTO
    {
           public int Id { get; set; }

        public string Name { get; set; } = "Mordor";

        public int Defence { get; set; } = 10;

        public int Attack { get; set; } = 100;

        public RpgClass Class { get; set; } = RpgClass.Cleric;

    }
}