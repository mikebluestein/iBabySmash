
using System;
using MonoTouch.AVFoundation;
using MonoTouch.Foundation;
using MonoTouch.AudioToolbox;

namespace iBabySmash
{


	public class Util
	{

		public Util ()
		{
		}

		public static void Vibrate ()
		{	
			var sound = SystemSound.Vibrate;
			sound.PlayAlertSound ();
		}
	}
}
