using Terraria;
using Busta.Dusts;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;



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
			item.width = 40; // The item texture's width
			item.height = 40; 
			item.scale = 1f;// The item texture's height
			item.useTime = 28; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 28; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			item.knockBack = 9; // The force of knockback of the weapon. Maximum is 20
			item.value = Item.buyPrice(gold: 9); // The value of the weapon in copper coins
			item.rare = ItemRarityID.Pink; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
			item.UseSound = SoundID.Item1; // The sound when the weapon is being used
			item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button
			item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = ModContent.ProjectileType<Projectiles.BladeBeam>();
			item.shootSpeed = 8f;
			

		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 40);
			recipe.AddIngredient(ItemID.HallowedBar, 20);
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
				item.useTime = 36;
				item.useAnimation = 36;
				item.damage = 131;
				item.shoot = ProjectileID.None;
				item.UseSound = SoundID.Item71;

				
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 28;
				item.useAnimation = 28;
				item.damage = 97;
				item.shoot = ModContent.ProjectileType<Projectiles.BladeBeam>();
				item.UseSound = SoundID.Item1;
			}
			return base.CanUseItem(player);
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (player.altFunctionUse == 2) {
				target.AddBuff(BuffID.BrokenArmor, 10);
			}
		}
		
			/* public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (player.altFunctionUse == 2) {
				//Emit dusts when the sword is swung
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(new Vector2(hitbox.X + 4f, hitbox.Y + 4f), hitbox.Width/2, hitbox.Height/2, 51, 0f, 0f, 0, new Color(255,255,255), 1f)];
				dust.noGravity = true;
			}
			}  */
		
		
		
	}
}


