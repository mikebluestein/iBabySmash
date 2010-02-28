
using System;
using MonoTouch.CoreGraphics;
using System.Drawing;

namespace iBabySmash
{


    public class StarView : ShapeView
    {
        public StarView (PointF origin) : base(origin)
        {
        }

        public override void CreateShape (CGPath path, CGContext gctx)
        {
            path.AddLines (new PointF[] { 
				_origin, 
				new PointF (_origin.X + 35, _origin.Y + 80),
				new PointF (_origin.X - 50, _origin.Y + 30),
				new PointF (_origin.X + 50, _origin.Y + 30),
				new PointF (_origin.X - 35, _origin.Y + 80) });
            
            path.CloseSubpath ();
            
            gctx.AddPath (path);
            
            gctx.DrawPath (CGPathDrawingMode.Fill);
        }
    }
}
