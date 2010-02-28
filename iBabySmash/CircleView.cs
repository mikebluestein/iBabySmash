
using System;
using MonoTouch.CoreGraphics;
using System.Drawing;

namespace iBabySmash
{


    public class CircleView : ShapeView
    {

        public CircleView (PointF origin) : base(origin)
        {
        }

        public override void CreateShape (CGPath path, CGContext gctx)
        {
            path.AddElipseInRect (new RectangleF (_origin.X, _origin.Y, 100, 100));
            
            gctx.AddPath (path);
            
            gctx.DrawPath (CGPathDrawingMode.FillStroke);
        }
    }
}
