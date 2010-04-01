
using System;
using MonoTouch.AVFoundation;
using MonoTouch.Foundation;
using MonoTouch.AudioToolbox;

namespace iBabyShapes
{


    public class Util
    {
        static Util _util;
        AVAudioPlayer _audioPlayer;

        Util ()
        {
            _audioPlayer = AVAudioPlayer.FromUrl (NSUrl.FromFilename ("sounds/sound.m4v"));
            _audioPlayer.PrepareToPlay ();
        }

        public static Util Instance {
            get {
                if (_util == null)
                    _util = new Util ();
                
                return _util;
            }
        }

        public void PlaySound ()
        {
            _audioPlayer.Play ();
        }

        public static void Vibrate ()
        {
            var sound = SystemSound.Vibrate;
            sound.PlayAlertSound ();
        }
    }
}
