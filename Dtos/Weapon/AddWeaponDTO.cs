namespace Patrick_Backend_DNet5.Dtos.Weapon
{
    public class AddWeaponDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Damage { get; set; }

        public int CharacterId { get; set; }
    }
}