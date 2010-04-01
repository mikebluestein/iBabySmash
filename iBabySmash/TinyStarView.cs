
using System;
using MonoTouch.CoreGraphics;
using System.Drawing;

namespace iBabyShapes
{


    public class TinyStarView : ShapeView
    {
        public TinyStarView (PointF origin) : base(origin)
        {
        }

        public override void CreateShape (CGPath path, CGContext gctx)
        {        
            path.AddLines (new PointF[] { _origin, 
                new PointF (_origin.X + 35 / 2, _origin.Y + 80 / 2), 
                new PointF (_origin.X - 50 / 2, _origin.Y + 30 / 2), 
                new PointF (_origin.X + 50 / 2, _origin.Y + 30 / 2), 
                new PointF (_origin.X - 35 / 2, _origin.Y + 80 / 2) });
            
            path.CloseSubpath ();
            
            gctx.AddPath (path);
            
            gctx.DrawPath (CGPathDrawingMode.Fill);
        }
    }
}
