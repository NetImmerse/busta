using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace Busta.Sounds
{
	public class LimitBraver : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type) {
			// By checking if the input soundInstance is playing, we can prevent the sound from firing while the sound is still playing, allowing the sound to play out completely. Non-ModSound behavior is to restart the sound, only permitting 1 instance.


			soundInstance.Volume = volume * .7f;
			soundInstance.Pan = pan;
			return soundInstance;
		}
	}
}
