using System;
using Busta.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Busta.Projectiles
{
	
	

	
	public class BladeBeamGround : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 50;
			projectile.height = 50;
			//projectile.aiStyle = 0; // Vanilla magic missile uses this aiStyle, but using it wouldn't let us fine tune the projectile speed or dust
			projectile.friendly = true;
			projectile.light = 0.8f;
			projectile.melee = true;
			projectile.tileCollide = true;
			projectile.timeLeft = 65;
			drawOriginOffsetY = -4;
			drawOriginOffsetX = 0;
			drawOffsetX = 4;
		}
		

		
		public override void AI() {
			// This part makes the projectile do a shime sound every 10 ticks as long as it is moving.
			
			if (projectile.timeLeft == 65) {Main.PlaySound(SoundID.Item20, projectile.position);}

			if (projectile.timeLeft > 10)
			{
				Dust dust;
				Vector2 position = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 15) + 26);
				dust = Terraria.Dust.NewDustPerfect(position, 74, new Vector2(0f, 0f), 0, new Color(255,255,255), 1f);
			
			}
			if (projectile.timeLeft < 10)
			{
				projectile.alpha += 25;
				projectile.width = 0;
				projectile.height = 0;
			}
			
			
			
			if (projectile.velocity != Vector2.Zero) {

			projectile.spriteDirection = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();
			// Adding Pi to rotation if facing left corrects the drawing
			projectile.rotation = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
			if (projectile.spriteDirection == 1) // facing right
			{
				drawOriginOffsetY = 0;
				drawOriginOffsetX = 0;
				drawOffsetX = -2;
			}
			else
			{
			// Facing left.
			// You can figure these values out if you flip the sprite in your drawing program.
				drawOffsetX = -13; // 0 since now the top left corner of the hitbox is on the far left pixel.
				drawOriginOffsetY = 0; // doesn't change
				drawOriginOffsetX = -2; // Math works out that this is negative of the other value.
			}
				
				

				
				
			
			}
			
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity) {

				 for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 107, 0, 0, 100, Color.Lime, 1.2f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 107, 0f, 0f, 100, Color.Lime, 1.5f);
				}
				
			return true;
		}
		
				public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            {
               for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 107, 0, 0, 100, Color.Lime, 1.2f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 107, 0f, 0f, 100, Color.Lime, 1.5f);
				}
            }
        }
		
		public override void Kill(int timeLeft) 
		{
			
			

		}
		
	}
	

	
	// Code adapted from the vanilla's magic missile.
	public class BladeBeam : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			//projectile.aiStyle = 27; // Vanilla magic missile uses this aiStyle, but using it wouldn't let us fine tune the projectile speed or dust
			projectile.friendly = true;
			projectile.light = 0.8f;
			projectile.melee = true;
			projectile.tileCollide = true;
			projectile.timeLeft = 125;
			drawOriginOffsetY = -15;
			drawOriginOffsetX = 0;
			drawOffsetX = -15;
			projectile.alpha = 255;
		}


		//public override Color? GetAlpha(Color lightColor) => new Color(0, 255, 0, 0);
		
		public override void AI() {
			// This part makes the projectile do a shime sound every 10 ticks as long as it is moving.
			
			if (projectile.timeLeft == 125) {Main.PlaySound(SoundID.Item20, projectile.position);}
			
			if (projectile.timeLeft > 120)
			{
					
				projectile.alpha -= 130;
			}

			if (projectile.timeLeft == 120)
			{		
				projectile.alpha = 0;
			}
			if (projectile.timeLeft < 10)
			{
				projectile.alpha += 25;
				projectile.width = 0;
				projectile.height = 0;
			}
			
			// Set the rotation so the projectile points towards where it's going.
			if (projectile.velocity != Vector2.Zero) {
				projectile.spriteDirection = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();
			// Adding Pi to rotation if facing left corrects the drawing
			projectile.rotation = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
			if (projectile.spriteDirection == 1) // facing right
			{
				drawOriginOffsetY = -16;
				drawOriginOffsetX = 0;
				drawOffsetX = -16;
			}
			else
			{
				drawOffsetX = -16; 
				drawOriginOffsetY = -16; 
				drawOriginOffsetX = 0;
			}
				
			}
		}
		
		
		public override bool OnTileCollide(Vector2 oldVelocity) {

				float x = 5f * projectile.spriteDirection;
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, x, 0f, mod.ProjectileType("BladeBeamGround"), (int)(projectile.damage * 1.2f), 0, projectile.owner);
				Main.projectile[a].tileCollide = true;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            {
               for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 107, 0, 0, 100, Color.Lime, 1.2f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 107, 0f, 0f, 100, Color.Lime, 1.5f);
				}
            }
        }

		public override void Kill(int timeLeft) 
		{
		}
	}
}








