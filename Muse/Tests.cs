using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace Muse
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the iOS app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			//
			// The iOS project should have the Xamarin.TestCloud.Agent NuGet package
			// installed. To start the Test Cloud Agent the following code should be
			// added to the FinishedLaunching method of the AppDelegate:
			//
			//    #if ENABLE_TEST_CLOUD
			//    Xamarin.Calabash.Start();
			//    #endif
			app = ConfigureApp
				.iOS
				// TODO: Update this path to point to your iOS app and uncomment the
				// code if the app is not included in the solution.
				.InstalledApp("com.interaxon.musedev")
				.StartApp();
		}

		[Test]
		public void TappingChevronBlueIcon()
		{
			app.WaitForElement("Sign In Now");
			app.Screenshot("App has started");

			app.Tap("Sign In Now");
			app.Screenshot("Tapped 'Sign In Now' Button");

			app.WaitForElement("Email");
			app.Screenshot("Waiting for element, 'E-mail' to appear");

			app.EnterText("Email", "ab.low22@gmail.com");
			app.Screenshot("Entered in my E-Mail information");

			app.EnterText("Password", "snoop222");
			app.Screenshot("Entered in my Password");

			app.Tap("Sign In");
			app.Screenshot("Tapped 'Sign In' Button");

			app.WaitForElement("chevron_blueIcon.png");
			app.Screenshot("Waiting for element, 'chevron_blueIcon.png'");

			app.Tap(x => x.Id("chevron_blueIcon.png").Index(0));
			app.Screenshot("Tapped on First 'chevron_blueIcon.png");
		}
	}
}
