namespace RpgInventory
{
    public class WeaponBuilder
    {
        private string _name = "Обычный меч";
        private int _damage = 10;

        public WeaponBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public WeaponBuilder WithDamage(int damage)
        {
            _damage = damage;
            return this;
        }

        public Weapon Build()
        {
            return new Weapon(_name, _damage);
        }
    }
}