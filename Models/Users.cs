using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg_project.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public List<Characters> Character { get; set; }
    }
}