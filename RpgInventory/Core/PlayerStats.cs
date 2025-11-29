using System;

namespace RpgInventory
{
    public class PlayerStats
    {
        public int Health { get; private set; }
        public int MaxHealth { get; }

        public PlayerStats(int health, int maxHealth)
        {
            if (maxHealth <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxHealth));

            MaxHealth = maxHealth;
            Health = Math.Min(Math.Max(health, 0), maxHealth);
        }

        public void Heal(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Health = Math.Min(MaxHealth, Health + amount);
        }
    }
}