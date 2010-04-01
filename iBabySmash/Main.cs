
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iBabyShapes
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	public partial class AppDelegate : UIApplicationDelegate
	{

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
            Util.Instance.PlaySound ();
            
            UIImageView monkeyView = new UIImageView (UIImage.FromFile ("images/monkey.png"));
            monkeyView.SizeToFit ();
            monkeyView.Center = viewController.View.Center;
            
            viewController.View.AddSubview (monkeyView);          
            
			window.AddSubview (viewController.View);
			
			window.MakeKeyAndVisible ();
			
			return true;
		}

		public override void OnActivated (UIApplication application)
		{
		}
	}
}
