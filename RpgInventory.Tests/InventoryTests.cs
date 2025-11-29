using System;
using RpgInventory;
using Xunit;

namespace RpgInventory.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void AddItem_ItemAppearsInInventory()
        {
            var inventory = new Inventory();
            var factory = new MedievalItemFactory();
            var sword = factory.CreateSword("Меч новичка", 10);

            inventory.AddItem(sword);

            Assert.Contains(sword, inventory.Items);
        }

        [Fact]
        public void UsePotion_HealsPlayerAndRemovesFromInventory()
        {
            var inventory = new Inventory();
            var stats = new PlayerStats(health: 50, maxHealth: 100);
            var context = new InventoryContext(inventory, stats);
            var factory = new MedievalItemFactory();
            var potion = factory.CreateHealingPotion("Малое зелье исцеления", 30);

            inventory.AddItem(potion);

            var service = new InventoryService();
            service.UseItem(potion, context);

            Assert.Equal(80, stats.Health);
            Assert.DoesNotContain(potion, inventory.Items);
            Assert.True(potion.IsConsumed);
        }

        [Fact]
        public void EquipWeapon_WeaponBecomesEquipped()
        {
            var inventory = new Inventory();
            var stats = new PlayerStats(health: 100, maxHealth: 100);
            var context = new InventoryContext(inventory, stats);
            var factory = new MedievalItemFactory();
            var sword = factory.CreateSword("Меч рыцаря", 15);

            inventory.AddItem(sword);

            var service = new InventoryService();
            service.EquipItem(sword, context);

            Assert.True(sword.IsEquipped);
        }

        [Fact]
        public void UpgradeWeapon_IncreasesDamageAndChangesState()
        {
            var factory = new MedievalItemFactory();
            var sword = factory.CreateSword("Тупой меч", 5);
            var upgradeStrategy = new DamageUpgradeStrategy(10);

            sword.Upgrade(upgradeStrategy);

            Assert.Equal(15, sword.Damage);
            Assert.IsType<UpgradedWeaponState>(sword.State);
        }

        [Fact]
        public void BrokenWeapon_CannotBeEquipped()
        {
            var inventory = new Inventory();
            var stats = new PlayerStats(health: 100, maxHealth: 100);
            var context = new InventoryContext(inventory, stats);
            var factory = new MedievalItemFactory();
            var sword = factory.CreateSword("Сломанный меч", 1);

            sword.State = new BrokenWeaponState();

            var service = new InventoryService();

            Assert.Throws<InvalidOperationException>(() => service.EquipItem(sword, context));
        }
    }
}
