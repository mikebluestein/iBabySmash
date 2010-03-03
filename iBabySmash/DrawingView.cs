
using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.AVFoundation;
using MonoTouch.CoreGraphics;
using MonoTouch.ObjCRuntime;

namespace iBabySmash
{


    [Register("DrawingView")]
    public class DrawingView : UIView
    {
        ShapeView _sv;
        int c = 0;

        public DrawingView (IntPtr p) : base(p)
        {
        }

        public override void Draw (RectangleF rect)
        {
            base.Draw (rect);        
        }

        public override void TouchesEnded (NSSet touches, UIEvent evt)
        {
            base.TouchesEnded (touches, evt);
                      
            UIView.BeginAnimations ("pulse");
            
            UIView.SetAnimationDelegate(this);
            UIView.SetAnimationDidStopSelector (new Selector ("pulseFinished"));      
            UIView.SetAnimationDuration (0.5f);        
            UIView.SetAnimationRepeatAutoreverses(true);

            _sv.Transform = CGAffineTransform.MakeScale(1.4f, 1.4f);
            
            UIView.CommitAnimations ();
        }
        
        [Export ("pulseFinished")]
        public void PulseFinished()
        {        
            _sv.Transform = CGAffineTransform.MakeScale(1.0f, 1.0f);
        }

        public override void TouchesBegan (NSSet touches, UIEvent evt)
        {
            base.TouchesBegan (touches, evt);
            
            UITouch touch = touches.AnyObject as UITouch;
            
            if (touch != null) {
                if (c > 10) {
                    foreach (UIView v in Subviews) {
                        v.RemoveFromSuperview ();
                    }
                    c = 0;
                    Util.Vibrate ();
                    
                } else {
                    PointF pt = touch.LocationInView (this);
                    
                    _sv = CreateShapeView (pt);
                    
                    this.AddSubview (_sv);
                }
                
                c++;
            }
        }

        ShapeView CreateShapeView (PointF pt)
        {
            Random r = new Random ();
            int i = r.Next (7);
            
            ShapeView sv = null;
            
            switch (i) {
            case 0:
                
                sv = new SquareView (pt);
                break;
            case 1:
                sv = new TriangleView (pt);
                break;
            case 2:
                sv = new CharacterView (pt, true);
                break;
            case 3:
                sv = new CircleView (pt);
                break;
            case 4:
                sv = new CharacterView (pt, false);
                break;
            case 5:
                sv = new HexagonView (pt);
                break;
            case 6:
                sv = new StarView (pt);
                break;
            }
            
            sv.Frame = this.Bounds;
            return sv;
        }
        
    }
}
