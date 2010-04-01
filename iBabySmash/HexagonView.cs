
using System;
using MonoTouch.CoreGraphics;
using System.Drawing;

namespace iBabyShapes
{


	public class HexagonView : ShapeView
	{

		public HexagonView (PointF origin) : base(origin)
		{
		}

		public override void CreateShape (CGPath path, CGContext gctx)
		{
			path.AddLines (new PointF[] { 
				_origin, 
				new PointF (_origin.X + 50, _origin.Y), 
				new PointF (_origin.X + 75, _origin.Y + 50), 
				new PointF (_origin.X + 50, _origin.Y + 100), 
				new PointF (_origin.X, _origin.Y + 100), 
				new PointF (_origin.X - 25, _origin.Y + 50) });
			
			path.CloseSubpath ();
			
			gctx.AddPath (path);
			
			gctx.DrawPath (CGPathDrawingMode.FillStroke);
		}
		
	}
}
