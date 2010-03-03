
using System;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;

namespace iBabySmash
{


    public abstract class ShapeView : UIView
    {
        UIColor[] _colors;

        protected PointF _origin;

        public ShapeView (PointF origin)
        {
            BackgroundColor = UIColor.Clear;
            _origin = origin;
            _colors = new UIColor[] { UIColor.Red, UIColor.Blue, UIColor.Green, UIColor.Yellow, UIColor.Purple, UIColor.FromPatternImage (UIImage.FromFile ("images/monkey.png")) };
        }

        public override void Draw (RectangleF rect)
        {
            base.Draw (rect);
			
            CGContext gctx = UIGraphics.GetCurrentContext ();
            
            gctx.SetLineWidth (4);
            
            _colors[new Random ().Next (6)].SetFill ();
            
            UIColor.Black.SetStroke ();
            
            CGPath path = new CGPath ();
            
            CreateShape (path, gctx); 
        }

        public abstract void CreateShape (CGPath path, CGContext gctx);
    }
}
