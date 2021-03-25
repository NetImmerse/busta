using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Busta.Projectiles
{
	
	//are ya coding son

	
	public class BladeBeamGround : ModProjectile
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blade Beam");
		}
		
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
			projectile.ignoreWater = true;
		}
		

			
		public override void AI() {
			// This part makes the projectile do a shime sound every 10 ticks as long as it is moving.
			
			projectile.ai[0]++;
			if(projectile.ai[0] > 5) {
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X, -projectile.velocity.Y, mod.ProjectileType("BladeBeamGroundTrail"), 0, 0, projectile.owner);
				projectile.ai[0] = 0;
			}
			
			if (projectile.timeLeft == 65) {Main.PlaySound(SoundID.Item20, projectile.position);}

			if (projectile.timeLeft > 10)
			{
				Dust dust;
				Vector2 position = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 15) + 26);
				dust = Terraria.Dust.NewDustPerfect(position, 74, new Vector2(0f, 0f), 0, new Color(255,255,255), 1f);
			
			}
			if (projectile.timeLeft <= 10)
			{
				projectile.alpha += 25;
				projectile.friendly = false;
				projectile.hostile = false;
				projectile.tileCollide = false;
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
	

public class BladeBeamTrail : ModProjectile
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blade Beam Trail");
		}
		
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			//projectile.aiStyle = 27; // Vanilla magic missile uses this aiStyle, but using it wouldn't let us fine tune the projectile speed or dust
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.light = 0.3f;
			projectile.tileCollide = false;
			projectile.timeLeft = 11;
			drawOriginOffsetY = -15;
			drawOriginOffsetX = 0;
			drawOffsetX = -15;
			projectile.ignoreWater = true;
			projectile.alpha = 255;
		}


		//public override Color? GetAlpha(Color lightColor) => new Color(0, 255, 0, 0);
		
		public override void AI() {		
			if (projectile.timeLeft == 11)
			{projectile.alpha = 0;}
			if (projectile.timeLeft <= 10 )
			{	
				projectile.alpha += 25;
				projectile.scale -= 0.02f;
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
	}

public class BladeBeamLimitTrail : ModProjectile
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blade Beam Trail");
		}
		
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			//projectile.aiStyle = 27; // Vanilla magic missile uses this aiStyle, but using it wouldn't let us fine tune the projectile speed or dust
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.light = 0.3f;
			projectile.tileCollide = false;
			projectile.timeLeft = 11;
			drawOriginOffsetY = -15;
			drawOriginOffsetX = 0;
			drawOffsetX = -15;
			projectile.ignoreWater = true;
			projectile.alpha = 255;
		}


		//public override Color? GetAlpha(Color lightColor) => new Color(0, 255, 0, 0);
		
		public override void AI() {		
			if (projectile.timeLeft == 11)
			{projectile.alpha = 0;}
			if (projectile.timeLeft <= 10 )
			{	
				projectile.alpha += 25;
				projectile.scale -= 0.02f;
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
	}



public class BladeBeamGroundTrail : ModProjectile
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ground Blade Beam Trail");
		}
		
		public override void SetDefaults() {
			projectile.width = 50;
			projectile.height = 50;
			//projectile.aiStyle = 0; // Vanilla magic missile uses this aiStyle, but using it wouldn't let us fine tune the projectile speed or dust
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.light = 0.8f;
			projectile.tileCollide = false;
			projectile.timeLeft = 11;
			drawOriginOffsetY = -4;
			drawOriginOffsetX = 0;
			drawOffsetX = 4;
			projectile.ignoreWater = true;
			projectile.alpha = 255;
		}


		//public override Color? GetAlpha(Color lightColor) => new Color(0, 255, 0, 0);
		
		public override void AI() {		
			if (projectile.timeLeft == 11)
			{projectile.alpha = 0;}
			if (projectile.timeLeft <= 10 )
			{	
				projectile.alpha += 25;
				projectile.scale -= 0.02f;
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
	}


public class BladeBeamGroundLimitTrail : ModProjectile
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ground Blade Beam Trail");
		}
		
		public override void SetDefaults() {
			projectile.width = 50;
			projectile.height = 50;
			//projectile.aiStyle = 0; // Vanilla magic missile uses this aiStyle, but using it wouldn't let us fine tune the projectile speed or dust
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.light = 0.8f;
			projectile.tileCollide = false;
			projectile.timeLeft = 11;
			drawOriginOffsetY = -4;
			drawOriginOffsetX = 0;
			drawOffsetX = 4;
			projectile.ignoreWater = true;
			projectile.alpha = 255;
		}


		//public override Color? GetAlpha(Color lightColor) => new Color(0, 255, 0, 0);
		
		public override void AI() {		
			if (projectile.timeLeft == 11)
			{projectile.alpha = 0;}
			if (projectile.timeLeft <= 10 )
			{	
				projectile.alpha += 25;
				projectile.scale -= 0.02f;
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
	}

	
	// Code adapted from the vanilla's magic missile.
	public class BladeBeam : ModProjectile
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blade Beam");
		}
		
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
			projectile.ignoreWater = true;
		}


		//public override Color? GetAlpha(Color lightColor) => new Color(0, 255, 0, 0);
		
		public override void AI() {
			
			projectile.ai[0]++;
			if(projectile.ai[0] > 5) {
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X, -projectile.velocity.Y, mod.ProjectileType("BladeBeamTrail"), 0, 0, projectile.owner);
				projectile.ai[0] = 0;
			}
			
			if (projectile.timeLeft == 125) {Main.PlaySound(SoundID.Item20, projectile.position); projectile.alpha = 255;}
			
			if (projectile.timeLeft > 120 )
			{
					
				projectile.alpha -= 55;
			}


			if (projectile.timeLeft <= 10)
			{
				projectile.alpha += 25;
				projectile.friendly = false;
				projectile.hostile = false;
				projectile.tileCollide = false;
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
				if (projectile.timeLeft >= 90)
				{
				float x = 5f * projectile.spriteDirection;
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, x, 0f, mod.ProjectileType("BladeBeamGround"), (int)(projectile.damage * 1.2f), 0, projectile.owner);
				Main.projectile[a].tileCollide = true;
				projectile.Kill();
				}
				else
				{
				for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 107, 0, 0, 100, Color.Lime, 1.2f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 107, 0f, 0f, 100, Color.Lime, 1.5f);
				}
				projectile.Kill();
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
	
	
	public class BladeBeamLimit : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blade Beam");
		}
		
		public override void SetDefaults() {
			projectile.CloneDefaults(mod.ProjectileType("BladeBeam"));
			projectile.maxPenetrate = 9;
			projectile.penetrate = 9;
		}
		
		
		public override void AI() {
			// This part makes the projectile do a shime sound every 10 ticks as long as it is moving.
			
			projectile.ai[0]++;
			if(projectile.ai[0] > 5) {
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X, -projectile.velocity.Y, mod.ProjectileType("BladeBeamLimitTrail"), 0, 0, projectile.owner);
				projectile.ai[0] = 0;
			}
			
			if (projectile.timeLeft == 125) {Main.PlaySound(SoundID.Item20, projectile.position); projectile.alpha = 255;}
			
			if (projectile.timeLeft > 120)
			{
				
				projectile.alpha -= 55;
			}


			if (projectile.timeLeft <= 10)
			{
				projectile.alpha += 25;
				projectile.friendly = false;
				projectile.hostile = false;
				projectile.tileCollide = false;
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

				if (projectile.timeLeft >= 90)
				{
				float x = 7f * projectile.spriteDirection;
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, x, 0f, mod.ProjectileType("BladeBeamGroundLimit"), (int)(projectile.damage * 1.1f), 0, projectile.owner);
				Main.projectile[a].tileCollide = true;
				projectile.Kill();
				}
				else
				{
				for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 156, 0f, 0f, 0, new Color(255,255,255), 1.052632f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 156, 0f, 0f, 0, new Color(255,255,255), 1.052632f);
				}
				projectile.Kill();
				}

			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
			if (projectile.penetrate == 1)
            {
               for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 156, 0, 0, 100, Color.Cyan, 1.2f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 156, 0f, 0f, 100, Color.Cyan, 1.5f);
				}
            }
        }

		public override void Kill(int timeLeft) 
		{
			


			
		}
		
		
	}
	
	
	
	public class BladeBeamGroundLimit : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blade Beam");
		}
		
		public override void SetDefaults() {
			projectile.CloneDefaults(mod.ProjectileType("BladeBeamGround"));
			projectile.maxPenetrate = 9;
			projectile.penetrate = 9;
		}
		
		
		
			
		public override void AI() {
			projectile.ai[0]++;
			if(projectile.ai[0] > 5) {
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X, -projectile.velocity.Y, mod.ProjectileType("BladeBeamGroundLimitTrail"), 0, 0, projectile.owner);
				projectile.ai[0] = 0;
			}
			
			
			if (projectile.timeLeft == 65) {Main.PlaySound(SoundID.Item20, projectile.position);}

			if (projectile.timeLeft > 10)
			{
				Dust dust;
				Vector2 position = projectile.Center + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 15) + 26);
				dust = Terraria.Dust.NewDustPerfect(position, 110, new Vector2(0f, 0f), 0, new Color(255,255,255), 1f);
			
			}
			if (projectile.timeLeft <= 10)
			{
				projectile.alpha += 25;
				projectile.friendly = false;
				projectile.hostile = false;
				projectile.tileCollide = false;
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
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 156, 0, 0, 100, Color.Cyan, 1.2f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 156, 0f, 0f, 100, Color.Cyan, 1.5f);
				}
				
			return true;
		}
		
				public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            {
               for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 156, 0, 0, 100, Color.Cyan, 1.2f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width * 2, projectile.height * 2, 156, 0f, 0f, 100, Color.Cyan, 1.5f);
				}
            }
        }
		
		public override void Kill(int timeLeft) 
		{
		}
		
		
	}
	
}








