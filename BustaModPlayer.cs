using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Busta
{
		//are ya coding son

	public class BustaModPlayer : ModPlayer
	{
		public int BustaLimitGauge;
		public bool BustaLimit = false;
		public bool BustaLimitPing = false;
		
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			if (BustaLimitGauge < 100 && BustaLimit == true)
			BustaLimitGauge += damage * 250 / player.statLifeMax2 ;
				if (BustaLimitGauge > 100)
				{
					BustaLimitGauge = 100;
					if(BustaLimitPing == false)
					{
						Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/LimitPing"));
						BustaLimitPing = true;
					}
				}
				if (BustaLimitGauge == 100 && BustaLimitPing == false)
				{
					Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/LimitPing"));
					BustaLimitPing = true;
				}
		}
	}
}