using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Busta.Items
{
	
	public class BreakerBlade : GlobalItem
	{
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.BreakerBlade) { 
				item.damage = 64;   //now it can actually serve you quite a while in hardmode
			}
		}
	}
}
