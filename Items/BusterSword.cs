using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;



namespace Busta.Items
{

	public class BusterSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Buster Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Primary attack: Blade Beam"
				+ "\nSecondary attack: Braver (applies Broken Armor debuff)"
				+ "\n\"Not interested.\"");
		}
		


		public override void SetDefaults() 
		{

			item.damage = 97; // The damage your item deals
			item.melee = true; // Whether your item is part of the melee class
			item.width = 55; // The item texture's width
			item.height = 63; 
			item.scale = 1.5f;// The item texture's height
			item.useTime = 28; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 28; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			item.knockBack = 9; // The force of knockback of the weapon. Maximum is 20
			item.value = Item.buyPrice(gold: 30); // The value of the weapon in copper coins
			item.rare = 7; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
			item.UseSound = SoundID.Item1; // The sound when the weapon is being used
			item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button
			item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
			item.useStyle = ItemUseStyleID.SwingThrow;
				
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 40);
			recipe.AddIngredient(ItemID.HallowedBar, 20);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddIngredient(ItemID.BreakerBlade, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.shoot = ProjectileID.None;
				item.UseSound = SoundID.Item71;
				BustaModPlayer modPlayer = player.GetModPlayer<BustaModPlayer>();
				if (modPlayer.BustaLimitGauge == 100){
					item.damage = 202;
					item.useTime = 22;
					item.useAnimation = 22;
					item.knockBack = 14;
					item.crit = 25;
				}
				else{
					item.damage = 111;
					item.useTime = 36;
					item.useAnimation = 36;
					item.knockBack = 9;
					item.crit = 6;
				}
					
			}
			else {
				
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 28;
				item.useAnimation = 28;
				item.UseSound = SoundID.Item1;
				BustaModPlayer modPlayer = player.GetModPlayer<BustaModPlayer>();
				if (modPlayer.BustaLimitGauge == 100)
					{
						item.damage = 152;
						item.shoot = ModContent.ProjectileType<Projectiles.BladeBeamLimit>();
						item.shootSpeed = 10f;
						modPlayer.BustaLimitGauge = 0;
						modPlayer.BustaLimitPing = false;
					}
				else
					{
						item.damage = 97;
						item.shoot = ModContent.ProjectileType<Projectiles.BladeBeam>();
						item.shootSpeed = 8f;
					}
			}
			return base.CanUseItem(player);
		}
		
		
		public override void HoldItem (Player player)
		{
			
            player.itemLocation.Y = player.Center.Y - 2 * player.direction;
            player.itemLocation.X = player.Center.X - 2 * player.direction;
			
			BustaModPlayer modPlayer = player.GetModPlayer<BustaModPlayer>();
			modPlayer.BustaLimit = true;
			
			if (modPlayer.BustaLimitGauge == 100)
				{	
					Dust dust;
					Vector2 position = Main.LocalPlayer.Center;
					position.X -= 20f;
					position.Y += 20f;
					dust = Terraria.Dust.NewDustDirect(position, 42, 21, 160, 0f, -4.210526f, 0, new Color(255,255,255), 1.052632f);
					dust.noGravity = true;
				}

		} 
		
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			BustaModPlayer modPlayer = player.GetModPlayer<BustaModPlayer>();
			if (player.altFunctionUse == 2 && modPlayer.BustaLimitGauge == 100)  {
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 160);
			}
}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
				if (player.altFunctionUse == 2) 
				{
					BustaModPlayer modPlayer = player.GetModPlayer<BustaModPlayer>();
					if (modPlayer.BustaLimitGauge == 100){
						target.AddBuff(BuffID.BrokenArmor, 1800);
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/LimitBraver"));
						modPlayer.BustaLimitGauge = 0;
						modPlayer.BustaLimitPing = false;
					}
					else{
						target.AddBuff(BuffID.BrokenArmor, 300);
						Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Braver"));
					}
				}
		}
		

		
		
	}
}


