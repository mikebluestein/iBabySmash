
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iBabyShapes
{
	public partial class DrawingViewController : UIViewController
	{
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public DrawingViewController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public DrawingViewController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public DrawingViewController () : base("DrawingViewController", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();			
		}	
	}
}
