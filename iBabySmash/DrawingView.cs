
using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.AVFoundation;
using MonoTouch.CoreGraphics;
using MonoTouch.ObjCRuntime;

namespace iBabyShapes
{


    [Register("DrawingView")]
    public class DrawingView : UIView
    {
        ShapeView _sv;
        
        int c = 0;
        int n = 1;

        string[] _monkeys = new string[] { "purplemonkey", "redmonkey", "greenmonkey", "yellowmonkey", "monkey" };

        const int MAX_SHAPES = 10;
        
       // TinyStarView _tinyStar;

        public DrawingView (IntPtr p) : base(p)
        {
        }

        public override void Draw (RectangleF rect)
        {
            base.Draw (rect);
            
           // _tinyStar = new TinyStarView (new PointF(35, 10));
           // _tinyStar.Frame = this.Bounds;
        }

        public override void TouchesBegan (NSSet touches, UIEvent evt)
        {
            base.TouchesBegan (touches, evt);
            
            UITouch touch = touches.AnyObject as UITouch;
            
            if (touch != null) {
                if (c > MAX_SHAPES) {
                    
                    foreach (UIView v in this.Subviews) {
                        if (v != Subviews[0])
                            v.RemoveFromSuperview ();
                    }
                    
                    var monkeyView = Subviews[0];
                    
                    UIView.BeginAnimations ("flip");
                    monkeyView.Transform = CGAffineTransform.MakeRotation ((float)Math.PI * n);
                    (monkeyView as UIImageView).Image = SwapMonkey ();
                    UIView.CommitAnimations ();
                    Util.Instance.PlaySound ();
                    n++;
                    c = 0;
                    
                } else {
                    PointF pt = touch.LocationInView (this);
                    _sv = CreateShapeView (pt);
                    this.AddSubview (_sv);
                }
                
                c++;
            }
            
            PulseShape ();
        }

        [Export("pulseFinished")]
        public void PulseFinished ()
        {
            UIView.BeginAnimations ("un-pulse");
            
            UIView.SetAnimationDuration (0.1f);
            
            _sv.Transform = CGAffineTransform.MakeScale (1f, 1f);
            
            UIView.CommitAnimations ();
        }
        
        void PulseShape ()
        {
            
            UIView.BeginAnimations ("pulse");
            
            UIView.SetAnimationDelegate (this);
            UIView.SetAnimationDidStopSelector (new Selector ("pulseFinished"));
            UIView.SetAnimationDuration (0.2f);
            
            _sv.Transform = CGAffineTransform.MakeScale (1.1f, 1.1f);
            
            UIView.CommitAnimations ();
            Util.Instance.PlaySound ();
        }
        
        UIImage SwapMonkey ()
        {
            return UIImage.FromFile (String.Format ("images/{0}.png", _monkeys[new Random ().Next (5)]));
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
