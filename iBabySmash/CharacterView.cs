
using System;
using MonoTouch.CoreGraphics;
using System.Drawing;
using MonoTouch.UIKit;
using System.Text;

namespace iBabySmash
{


    public class CharacterView : ShapeView
    {

        bool _lowerCase;
        
        public CharacterView (PointF origin, bool lowerCase) : base(origin)
        {
            _lowerCase = lowerCase;
        }

        public override void CreateShape (CGPath path, CGContext gctx)
        {
            DrawString (RandomString(1, _lowerCase) , _origin, UIFont.BoldSystemFontOfSize (100));
        }
        
        //from Jonas John - http://www.jonasjohn.de/snippets/csharp/random-helper-class.htm
        public static string RandomString(int size, bool lowerCase)
        {
            Random randomSeed = new Random();
            
            // StringBuilder is faster than using strings (+=)
            StringBuilder RandStr = new StringBuilder(size);
 
            // Ascii start position (65 = A / 97 = a)
            int Start = (lowerCase) ? 97 : 65;
 
            // Add random chars
            for (int i = 0; i < size; i++)
                RandStr.Append((char)(26 * randomSeed.NextDouble() + Start));
 
            return RandStr.ToString();
        }
    }
}
