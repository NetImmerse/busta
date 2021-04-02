using Microsoft.Xna.Framework;
using Busta.UI;
using Busta.Items;
using Busta.Projectiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Busta
{
		//are ya coding son

	public class BustaModPlayer : ModPlayer
	{
		public float BustaLimitGauge;
		public bool BustaLimitPing = false;

		
 
		
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{

			float a = 250f / player.statLifeMax2;
			if (BustaLimitGauge < 100f && Main.LocalPlayer.HeldItem.modItem is BusterSword && !Main.LocalPlayer.dead)
			BustaLimitGauge += (float) damage * a ;
				if (BustaLimitGauge > 100f)
				{
					BustaLimitGauge = 100f;
					if(BustaLimitPing == false)
					{
						Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/LimitPing"));
						BustaLimitPing = true;
					}
				}
				if (BustaLimitGauge == 100f && BustaLimitPing == false)
				{
					Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/LimitPing"));
					BustaLimitPing = true;
				}
		}
		
		public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
		{

			float a = 250f / player.statLifeMax2;
			if (BustaLimitGauge < 100f && Main.LocalPlayer.HeldItem.modItem is BusterSword && !Main.LocalPlayer.dead)
			BustaLimitGauge += (float) damage * a;
				if (BustaLimitGauge > 100f)
				{
					BustaLimitGauge = 100;
						Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/LimitPing"));
						BustaLimitPing = true;
				}
				if (BustaLimitGauge == 100f && BustaLimitPing == false)
				{
					Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/LimitPing"));
					BustaLimitPing = true;
				}
		}
		
		
		
		
		public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
			BustaLimitGauge = 0;
			BustaLimitPing = false;
		}
		
		
	}
}