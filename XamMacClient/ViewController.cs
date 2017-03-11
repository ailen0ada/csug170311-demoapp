using System;
using System.Threading.Tasks;
using AppKit;
using Foundation;
using SharedClient;

namespace XamMacClient
{
	public partial class ViewController : NSViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Do any additional setup after loading the view.
		}

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

		#region bindables

		NSString message;

		[Outlet]
		public NSString Message
		{
			get { return message; }
			set
			{
				WillChangeValue(nameof(Message));
				message = value;
				DidChangeValue(nameof(Message));
			}
		}

		NSString endpoint;

		[Outlet]
		public NSString Endpoint
		{
			get
			{
				return endpoint;
			}

			set
			{
				WillChangeValue(nameof(Endpoint));
				endpoint = value;
				DidChangeValue(nameof(Endpoint));
			}
		}

		NSString apiKey;

		[Outlet]
		public NSString ApiKey
		{
			get
			{
				return apiKey;
			}

			set
			{
				WillChangeValue(nameof(ApiKey));
				apiKey = value;
				DidChangeValue(nameof(ApiKey));
			}
		}

		bool isCommunicating;

		[Outlet]
		public bool IsCommunicating
		{
			get
			{
				return isCommunicating;
			}

			set
			{
				WillChangeValue(nameof(IsCommunicating));
				isCommunicating = value;
				DidChangeValue(nameof(IsCommunicating));
			}
		}

		#endregion

#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
		async partial void RaiseMessage(NSObject sender)
		{
			IsCommunicating = true;
			var client = new ApiClient
			{
				Endpoint = endpoint,
				ApiKey = apiKey
			};
			try
			{
				var msg = await client.GetReplyAsync(message);
				using (var alert = new NSAlert())
				{
					alert.MessageText = "おへんじがきたよ！";
					alert.InformativeText = msg;
					alert.AlertStyle = NSAlertStyle.Informational;

					alert.RunSheetModal(View.Window);
				}
			}
			catch (Exception ex)
			{
				using (var alert = new NSAlert())
				{
					alert.MessageText = "おへんじがもらえなかったよ！";
					alert.InformativeText = ex.ToString();
					alert.AlertStyle = NSAlertStyle.Critical;

					alert.RunSheetModal(View.Window);
				}
			}
			finally
			{
				IsCommunicating = false;
			}
		}
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
	}
}
