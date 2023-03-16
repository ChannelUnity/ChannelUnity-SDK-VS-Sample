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
/// ChannelUnity Limited grants you a nonexclusive copyright license to use all programming code examples 
/// from which you can generate similar function tailored to your own specific needs.
/// </summary>
using System;
using System.Diagnostics;
using System.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CUSDK
{
	/// <summary>
	/// ChannelUnity Connector Kit API Implementation.
	/// </summary>
	public class ConnectorKit
	{
		/// <summary>
		/// The ChannelUnity endpoint to which API requests are made.
		/// </summary>
		public static string CU_ENDPOINT = "https://my.channelunity.com/event.php";

		public ConnectorKit ()
		{
		}

		public string MerchantName;
		public string UserName;
		public string Password;
		public string ApiKey;

		/*
		 * API Calls are here
		 */

		public Response ValidateUser ()
		{
			string result = this.PostToChannelUnity(null, "ValidateUser");
			
//			Console.WriteLine("We have received the following back.... "+result);

			XmlSerializer x = new XmlSerializer(typeof (Response));
			Response rsp = (Response)x.Deserialize(new XmlTextReader(new StringReader(result)));

			return rsp;
		}

		public Response VerifyNotification (string encrypted)
		{
			string result = this.PostToChannelUnity(encrypted, "VerifyNotification");

//			Console.WriteLine("We have received the following back.... "+result);
			
			XmlSerializer x = new XmlSerializer(typeof (Response));
			Response rsp = (Response)x.Deserialize(new XmlTextReader(new StringReader(result)));
			
			return rsp;
		}

		public Response SendStoreDataToCU (IList<Store> storelist)
		{
			// Create the store list as XML

			StringWriter stringWriter = new StringWriter ();
			XmlTextWriter writer = new XmlTextWriter (stringWriter);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;
			writer.WriteStartElement ("StoreList");

			foreach (Store store in storelist) {
				writer.WriteStartElement ("Store");
				writer.WriteElementString ("FriendlyName", store.FriendlyName);
				writer.WriteElementString ("URL", store.URL);
				writer.WriteElementString("MainCountry", store.MainCountry);
				writer.WriteElementString("FrameworkType", store.FrameworkType);
				writer.WriteElementString("WebsiteId", store.WebsiteId.ToString());
				writer.WriteElementString("StoreId", store.StoreId.ToString());
				writer.WriteElementString("StoreviewId", store.StoreviewId.ToString());
				writer.WriteEndElement ();
			}

			writer.WriteEndElement ();
			writer.Close ();
			string payload = stringWriter.ToString();

			string result = this.PostToChannelUnity(payload, "StoreData");

//			Console.WriteLine(result);

			XmlSerializer x = new XmlSerializer(typeof (Response));
			Response rsp = (Response)x.Deserialize(new XmlTextReader(new StringReader(result)));

			return rsp;
		}

		/// <summary>
		/// Sends the category data to ChannelUnity.
		/// </summary>
		/// <returns>
		/// The category data to ChannelUnity.
		/// </returns>
		/// <param name='categoryList'>
		/// Category list.
		/// </param>
		public Response SendCategoryDataToCU (CategoryList categoryList)
		{
			StringWriter stringWriter = new StringWriter ();
			XmlTextWriter writer = new XmlTextWriter (stringWriter);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;

			writer.WriteStartElement ("CategoryList");
			writer.WriteElementString("URL", categoryList.URL);
			writer.WriteElementString ("FrameworkType", categoryList.FrameworkType);
			writer.WriteElementString("WebsiteId", categoryList.WebsiteId.ToString());
			writer.WriteElementString("StoreId", categoryList.StoreId.ToString());
			writer.WriteElementString("StoreviewId", categoryList.StoreviewId.ToString());

			foreach (Category item in categoryList.Category) {
				writer.WriteStartElement ("Category");
				writer.WriteElementString("ID", item.ID.ToString());
				writer.WriteElementString("Name", item.Name);
				writer.WriteElementString("Position", item.Position);
				writer.WriteElementString("CategoryPath", item.CategoryPath);
				writer.WriteElementString("ParentID", item.ParentID.ToString());
				writer.WriteElementString("Level", item.Level.ToString());
				writer.WriteEndElement ();
			}

			writer.WriteEndElement ();
			writer.Close ();
			string payload = stringWriter.ToString();
			Console.WriteLine (payload);
			
			Response rsp = SubmitWithPayload (payload, "CategoryData");
			return rsp;
		}

		/// <summary>
		/// Sends product attributes to ChannelUnity.
		/// </summary>
		/// <returns>
		/// 
		/// </returns>
		/// <param name='attributeList'>
		/// Attribute list.
		/// </param>
		public Response SendAttributesToCU (IList<ProductAttribute> attributeList)
		{
			StringWriter stringWriter = new StringWriter ();
			XmlTextWriter writer = new XmlTextWriter (stringWriter);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;
			
			writer.WriteStartElement ("ProductAttributes");

			foreach (ProductAttribute item in attributeList) {
				writer.WriteStartElement ("Attribute");
				writer.WriteElementString("Name", item.Name);
				writer.WriteElementString("Type", item.Type);
				writer.WriteElementString("FriendlyName", item.FriendlyName);
				writer.WriteEndElement ();
			}
			
			writer.WriteEndElement ();
			writer.Close ();
			string payload = stringWriter.ToString();
			
			Response rsp = SubmitWithPayload (payload, "ProductAttributes");
			return rsp;
		}

		/// <summary>
		/// Sends the products to ChannelUnity.
		/// </summary>
		/// <returns>
		/// The products to ChannelUnity.
		/// </returns>
		/// <param name='productList'>
		/// Product list.
		/// </param>
		public Response SendProductsToCU (IList<Product> productList)
		{
			string payload = GetProductDataPayload(productList);
			Response rsp = SubmitWithPayload (payload, "ProductData");
			return rsp;
		}

		/**
		 * Gets an XML message for a product list.
		 */
		public string GetProductDataPayload (IList<Product> productList)
		{
			StringWriter stringWriter = new StringWriter ();
			XmlTextWriter writer = new XmlTextWriter (stringWriter);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;
			
			writer.WriteStartElement ("Products");
			
			foreach (Product item in productList) {
				writer.WriteStartElement ("Product");
				writer.WriteElementString("RemoteId", item.RemoteId.ToString());
				writer.WriteElementString("SourceURL", item.URL);
				writer.WriteElementString("StoreViewId", item.StoreViewId.ToString());
				writer.WriteElementString("ProductType", item.ProductType);
				writer.WriteElementString("Title", item.Title);
				writer.WriteElementString("Description", item.Description);
				writer.WriteElementString("SKU", item.SKU);
				writer.WriteElementString("Price", item.Price.ToString());
				writer.WriteElementString("Quantity", item.Quantity.ToString());
				writer.WriteElementString("Category", item.Category);
				writer.WriteElementString("CategoryName", item.CategoryName);
				writer.WriteElementString("Image", item.Image);

				if (item.RelatedSKUs != null) {

					writer.WriteStartElement ("RelatedSKUs");
					foreach (string relatedSKU in item.RelatedSKUs) {
						writer.WriteElementString ("SKU", relatedSKU);
					}
					writer.WriteEndElement ();

				}

				if (item.Variations != null) {

					writer.WriteStartElement ("Variations");
					foreach (string variationAttr in item.Variations) {
						writer.WriteElementString ("Variation", variationAttr);
					}
					writer.WriteEndElement ();
				}

				writer.WriteStartElement ("Custom");
				foreach (string customField in item.AllCustomKeys()) {
					writer.WriteElementString(customField, item[customField]);
				}
				writer.WriteEndElement ();

				writer.WriteEndElement ();
			}

			writer.WriteElementString("RangeNext", "0");
			writer.WriteElementString("TotalProducts", productList.Count.ToString());
			
			writer.WriteEndElement ();
			writer.Close ();
			string payload = stringWriter.ToString();
			return payload;
		}

		/*
		 * Internal functions are here
		 */
		
		private Response SubmitWithPayload (string payload, string requestType)
		{
			string result = this.PostToChannelUnity (payload, requestType);
			Console.WriteLine (result);
			XmlSerializer x = new XmlSerializer (typeof(Response));
			Response rsp = (Response)x.Deserialize (new XmlTextReader (new StringReader (result)));
			return rsp;
		}

		/// <summary>
		/// Gets the xml.
		/// </summary>
		/// <returns>
		/// The xml.
		/// </returns>
		/// <param name='requestType'>
		/// Request type.
		/// </param>
		/// <param name='payload'>
		/// Payload.
		/// </param>
		public string GetXml (string requestType, string payload = null)
		{
			StringWriter stringWriter = new StringWriter();

			XmlTextWriter writer = new XmlTextWriter (stringWriter);

			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;
			writer.WriteStartElement ("ChannelUnity");
			writer.WriteElementString ("MerchantName", this.MerchantName);
			writer.WriteElementString ("Authorization", this.getAuthorizationString ());

			if (this.ApiKey != null) {

				writer.WriteElementString ("ApiKey", this.ApiKey);
			}

			writer.WriteElementString ("RequestType", requestType);

			if (payload != null) {
				// Write raw element data
				writer.WriteRaw("<Payload>" + payload + "</Payload>\n");
			}

			writer.WriteEndElement ();
			writer.Close ();
			return stringWriter.ToString ();
		}

		public string GetAllSKUsXML (IList<Product> productList)
		{
			StringWriter stringWriter = new StringWriter();
			
			XmlTextWriter writer = new XmlTextWriter (stringWriter);
			
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;
			writer.WriteStartElement ("ChannelUnity");

			writer.WriteElementString ("RequestType", "GetAllSKUs");

			writer.WriteStartElement ("Payload");
			foreach (var p in productList) {
				
				writer.WriteElementString ("SKU", p.SKU);
			}

			writer.WriteEndElement ();
			writer.WriteEndElement ();
			writer.Close ();
			return stringWriter.ToString ();
		}

		/// <summary>
		/// Posts to channel unity.
		/// </summary>
		/// <returns>
		///  
		/// </returns>
		/// <param name='xml'>
		/// Xml.
		/// </param>
		/// <param name='requestType'>
		/// Request type.
		/// </param>
		private string PostToChannelUnity (string payload, string requestType)
		{
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(CU_ENDPOINT);
			request.Method = "POST";
			Stream requestStream = request.GetRequestStream();
			request.ContentType = "application/x-www-form-urlencoded";
			
			string xmlplain = this.GetXml (requestType, payload);

			Console.WriteLine(xmlplain);

			StreamWriter sw = new StreamWriter(requestStream);
			string encxml = HttpUtility.UrlEncode(xmlplain);

//			Console.WriteLine("***"+encxml+"***");

			sw.Write("message=" + encxml);

			sw.Close();
			
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string value = (new StreamReader(response.GetResponseStream()).ReadToEnd());
			return value;
		}

		/// <summary>
		/// Generates the authorization string based on the current username and password.
		/// </summary>
		/// <returns>
		/// The authorization string.
		/// </returns>
		private string getAuthorizationString()
		{
			SHA256 mySHA256 = SHA256Managed.Create();
			byte[] passbytes = Encoding.UTF8.GetBytes(this.Password);
			string auth = this.UserName + ":" + HexCharsEncode (mySHA256.ComputeHash(passbytes));
			auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));
			return auth;
		}

		/// <summary>
		/// Converts a byte array to a string of hex characters.
		/// </summary>
		/// <param name="inputBytes"></param>
		private string HexCharsEncode(byte[] inputBytes)
		{
			string strTemp = "";
			for (int x = 0; x <= inputBytes.GetUpperBound(0); x++)
			{
				int number = int.Parse(inputBytes[x].ToString());
				strTemp += number.ToString("x").PadLeft(2, '0');
			}

			return strTemp;
		}
	}
}

