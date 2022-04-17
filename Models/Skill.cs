using System.Collections.Generic;
using Rpg_project.Models;

namespace Patrick_Backend_DNet5.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points {get;set;}

        public List<Characters> Characters {get;set;}


    }
}