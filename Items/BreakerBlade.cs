using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Busta.Items
{
	
	public class BreakerBlade : GlobalItem
	{
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.BreakerBlade) { 
				item.damage = 64;   
			}
		}
		
		
	}
}
