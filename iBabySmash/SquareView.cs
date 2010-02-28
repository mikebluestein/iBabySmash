
using System;
using MonoTouch.CoreGraphics;
using System.Drawing;

namespace iBabySmash
{


    public class SquareView : ShapeView
    {
        public SquareView (PointF origin) : base(origin)
        {
        }

        public override void CreateShape (CGPath path, CGContext gctx)
        {
            path.AddRect (new RectangleF (_origin, new SizeF (100, 100)));
            gctx.AddPath (path);
            
            gctx.DrawPath (CGPathDrawingMode.FillStroke);
        }
        
    }
}
