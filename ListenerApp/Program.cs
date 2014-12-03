/// <summary>
/// This source code is provided "as is" and without warranties as to performance or merchantability. 
/// The author and/or distributors of this source code may have made statements about this source code. 
/// Any such statements do not constitute warranties and shall not be relied on by the user in deciding 
/// whether to use this source code.
/// 
/// This source code is provided without any express or implied warranties whatsoever. 
/// Because of the diversity of conditions and hardware under which this source code may 
/// be used, no warranty of fitness for a particular purpose is offered. The user is advised 
/// to test the source code thoroughly before relying on it. The user must assume the entire 
/// risk of using the source code.
/// 
/// Camiloo Limited grants you a nonexclusive copyright license to use all programming code examples 
/// from which you can generate similar function tailored to your own specific needs.
/// </summary>

using System;
using CUSDK;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;
using TestApp;

namespace ListenerApp
{
	class MainClass
	{
		static string url = "http://localhost/"; //"http://94.193.82.158:80/";

		private ConnectorKit cu;

		/// <summary>
		/// Setup demo app with CU account credentials.
		/// </summary>
		public MainClass ()
		{
			this.cu = new ConnectorKit();

			//
			// NB - Change these details as necessary
			//
			this.cu.MerchantName = "pjhtest";
			this.cu.UserName = "admin";
			this.cu.Password = "d6f7g8";
		}


		public static void Main (string[] args)
		{
			Console.WriteLine ("Now listening for incoming notifications from ChannelUnity");

			MainClass myApp = new MainClass ();

			myApp.StartListening(new string[] { url });
		}

		private string HandleProductData(Response rsp) {
			List<Product> productList = TestApp.MainClass.GetProductList ();
			string payload = cu.GetProductDataPayload (productList);
			string responseString = cu.GetXml(rsp.Notification.Type, payload);
			Console.WriteLine(":::Sending ProductData in response:::\n"+responseString);

			return responseString;
		}

		private string HandlePing(Response rsp) {

			string responseString = "";
			Response vuresponse = cu.ValidateUser();

			if (vuresponse.MerchantName != null
			    && vuresponse.MerchantName.Length > 0) {

				responseString = "<?xml version=\"1.0\"?>\n<ChannelUnity><Status>OK</Status></ChannelUnity>";
			}
			else {
				responseString = "<ChannelUnity><Status>"+vuresponse.Status+"</Status></ChannelUnity>";
			}

			return responseString;
		}



		// This example requires the System and System.Net namespaces. 
		public void StartListening (string[] prefixes)
		{
			if (!HttpListener.IsSupported) {
				Console.WriteLine ("Windows XP SP2 or Server 2003 is required");
				return;
			}

			// Create a listener
			HttpListener listener = new HttpListener ();
			// Add the prefixes
			foreach (string s in prefixes) {
				listener.Prefixes.Add (s);
			}
			listener.Start ();
			Console.WriteLine ("Listening...");
			try {

				while (true) {
					// Note: The GetContext method blocks while waiting for a request
					HttpListenerContext context = listener.GetContext ();
					HttpListenerRequest request = context.Request;

					string xmlrecv = GetRequestData (request);

					XmlSerializer x = new XmlSerializer (typeof(Response));
					Response rsp = (Response)x.Deserialize (new XmlTextReader (new StringReader (xmlrecv)));

					Console.WriteLine("ChannelUnity sent us the following:::::::::");
					Console.WriteLine (xmlrecv);
					Console.WriteLine (rsp);

					Console.WriteLine("Checking if there is a payload to be decrypted::::::::::");

					if(rsp.Notification.Payload != null && rsp.Notification.Payload.Length > 0) {

						Console.WriteLine("There was a payload, now sending to VerifyNotification");

						Response vnrsp = cu.VerifyNotification(rsp.Notification.Payload);

						Console.WriteLine("VerifyNotification came back with...");

						Console.WriteLine(vnrsp);
					}
					else {
						Console.WriteLine("There was no payload");
					}

					// Obtain a response object
					HttpListenerResponse response = context.Response;
					// Construct a response
					string responseString = "";

					if (rsp.Notification.Type == "ProductData") {
						responseString += HandleProductData(rsp);
					}
					else if (rsp.Notification.Type == "Ping") {

						responseString += HandlePing(rsp);

					}
					else if (rsp.Notification.Type == "GetAllSKUs") {
						List<Product> productList = TestApp.MainClass.GetProductList ();
						responseString = cu.GetAllSKUsXML(productList);
					}
					else if (rsp.Notification.Type == "CartDataRequest") {

						List<Store> list = TestApp.MainClass.GetStoresList();
						Response resultStores = cu.SendStoreDataToCU(list);

						CategoryList categoryList = new CategoryList();
						categoryList.URL = url;
						categoryList.FrameworkType = "Custom";
						categoryList.WebsiteId = 1;
						categoryList.StoreId = 1;
						categoryList.StoreviewId = 1;
						categoryList.Category = TestApp.MainClass.GetCategoriesList ();

						Response resultCategories = cu.SendCategoryDataToCU(categoryList);

						Response resultAttributes = cu.SendStoreDataToCU(list);

						responseString = "<?xml version=\"1.0\"?>\n<ChannelUnity><StoreStatus><Status>"+resultStores.Status+"</Status></StoreStatus>"
							+"<CategoryStatus>"+resultCategories.Status+"</CategoryStatus>"
								+"<ProductAttributeStatus>"+resultAttributes.Status+"</ProductAttributeStatus></ChannelUnity>";

					}
					else if (rsp.Notification.Type == "OrderNotification") {

						// TODO: Store the marketplace order somewhere
					}

					Console.WriteLine("Sending back this...");
					Console.WriteLine(responseString);

					byte[] buffer = System.Text.Encoding.UTF8.GetBytes (responseString);
					// Get a response stream and write the response to it.
					response.ContentLength64 = buffer.Length;
					System.IO.Stream output = response.OutputStream;
					output.Write (buffer, 0, buffer.Length);
					// You must close the output stream.
					output.Close ();
				}

			} catch (Exception x) {
				Console.WriteLine(x.ToString());
				Console.WriteLine(x.StackTrace);

				listener.Stop();
			}

		}



		public static string GetRequestData (HttpListenerRequest request)
		{
			if (!request.HasEntityBody) {
				Console.WriteLine ("No client data was sent with the request.");
				return "";
			}
			Stream body = request.InputStream;
			Encoding encoding = request.ContentEncoding;

			StreamReader reader = new StreamReader(body, encoding);

			// Convert the data to a string and display it on the console
			string s = reader.ReadToEnd();
			s = HttpUtility.UrlDecode(s);

			int datastart = s.IndexOf("<?xml");

			int dataend = s.IndexOf("</ChannelUnity>");

			s = s.Substring(datastart, dataend - datastart + 15);

			body.Close();
			reader.Close();
			return s;
		}
	}
}
