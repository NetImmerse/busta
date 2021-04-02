using Busta.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ModLoader;

namespace Busta.UI
{

	
	internal class LimitGaugeUI : UIState
	{
		
		private UIElement area;
		private UIImage barFrame;
		private int Lx;
		private int Ly;
		private string GaugeTexture;
		private float Fade;
		private int GaugeFrame;
		private Color Limit;
		private Color LimitBack;
		private Color LimitFrame;
		
		public override void OnInitialize() {
			
			area = new UIElement(); 
			Lx = Main.screenHeight / 2;
			Ly = Main.screenWidth / 2;
			area.Left.Set(Ly - 55, 0f); 
			area.Top.Set(Lx + 40, 0f); 
			area.Width.Set(182, 0f); 
			area.Height.Set(60, 0f);
			
			GaugeFrame = 0;
			GaugeTexture = "Busta/UI/LimitGaugeUI";
			
			barFrame = new UIImage(ModContent.GetTexture(GaugeTexture));
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

			Limit = Color.Pink;
			LimitBack = new Color(122, 122, 122);
			LimitFrame = new Color(39, 39, 39);
			Fade = 1f;

			area.Append(barFrame);
			Append(area);
		}
		
		protected override void DrawSelf(SpriteBatch spriteBatch) {
			base.DrawSelf(spriteBatch);

			var modPlayer = Main.LocalPlayer.GetModPlayer<BustaModPlayer>();
			float quotient = (float)modPlayer.BustaLimitGauge / 100; 
			quotient = Utils.Clamp(quotient, 0f, 1f); 
			
			if (modPlayer.BustaLimitGauge == 100){
				
				switch (Main.GameUpdateCount / 3 % 2)
				{
				case 0:
					Limit = Color.Cyan;
					break;
				case 1:
					Limit = Color.Yellow;
					break;
				}
			}
			else {
			Limit = Color.Pink;
			}
			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width = 40;
			hitbox.Y += 16;
			hitbox.Height = 8;
			
			Rectangle hitbox2 = barFrame.GetInnerDimensions().ToRectangle();
			hitbox2.X += 12;
			hitbox2.Width = 40;
			hitbox2.Y += 18;
			hitbox2.Height = 2;

			int left = hitbox.Left;
			int right = hitbox.Right;
			int steps = (int)((right - left) * quotient);


			spriteBatch.Draw(Main.magicPixel, new Rectangle(hitbox.X, hitbox.Y, hitbox.Width, hitbox.Height), LimitFrame);
			spriteBatch.Draw(Main.magicPixel, new Rectangle(hitbox.X + 2, hitbox2.Y, hitbox.Width, hitbox.Height), LimitBack);
			for (int i = 0; i < steps; i += 1) {
			
				float percent = (float)i / (right - left);
				spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Limit );
				spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox2.Y, 1, hitbox2.Height), Color.White );
			}

		}
		
		public override void Update(GameTime gameTime) {
			if (!(Main.LocalPlayer.HeldItem.modItem is BusterSword) || Main.LocalPlayer.dead )
				return;

			
			
			Lx = Main.screenHeight / 2;
			Ly = Main.screenWidth / 2;
			area.Left.Set(Ly - 55, 0f); 
			area.Top.Set(Lx + 40, 0f); 
				
			base.Update(gameTime);
		}
		
	}

}
