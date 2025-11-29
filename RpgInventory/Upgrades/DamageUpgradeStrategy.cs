using System;

namespace RpgInventory
{
    public class DamageUpgradeStrategy : IUpgradeStrategy
    {
        private readonly int _additionalDamage;

        public DamageUpgradeStrategy(int additionalDamage)
        {
            if (additionalDamage <= 0)
                throw new ArgumentOutOfRangeException(nameof(additionalDamage));

            _additionalDamage = additionalDamage;
        }

        public void Apply(Weapon weapon)
        {
            weapon.Damage += _additionalDamage;
            weapon.State = new UpgradedWeaponState();
        }
    }
}
