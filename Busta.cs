using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Busta.UI;
using Busta.Items;
using Busta.Projectiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;


namespace Busta
{
	public class Busta : Mod
	{
		
		
		internal LimitGaugeUI LimitGaugeUI;
        public UserInterface BustaInterface;

        public override void Load()
        {
            
            if (!Main.dedServ)
            {
                LimitGaugeUI = new LimitGaugeUI();
                LimitGaugeUI.Initialize();
                BustaInterface = new UserInterface();
                BustaInterface.SetState(LimitGaugeUI);
            }
        }
		
		 public override void UpdateUI(GameTime gameTime)
        {
            if (!Main.gameMenu
                && (Main.LocalPlayer.HeldItem.modItem is BusterSword))
            {
                BustaInterface?.Update(gameTime);
            }
			
			
        }
		
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(new LegacyGameInterfaceLayer("Cool Mod: Something UI", DrawBustaUI, InterfaceScaleType.UI));
        }
		

		private bool DrawBustaUI()
        {
           
			BustaModPlayer modPlayer = Main.LocalPlayer.GetModPlayer<BustaModPlayer>();
			
            if (!Main.gameMenu
                && (Main.LocalPlayer.HeldItem.modItem is BusterSword) && !Main.LocalPlayer.dead && modPlayer.BustaLimitGauge != 0)
            {
                BustaInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
		
			
			

	}
}