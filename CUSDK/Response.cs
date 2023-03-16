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
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace CUSDK
{
	/// <summary>
	/// General Response returned by calls to the Connector Kit API.
	/// </summary>
	[XmlType(TypeName="ChannelUnity")]
	[XmlRoot]
	public class Response
	{
		public Response ()
		{}

		[XmlElement]
		public string Status;
		[XmlElement]
		public Notification Notification;
		[XmlElement]
		public string MerchantName;
		[XmlElement]
		public string ApiKey;
		[XmlElement]
		public string DatabaseLocation;
		[XmlElement]
		public string CreatedDate;
		[XmlElement]
		public string VersionId;
		[XmlElement]
		public string SubscriptionId;
		[XmlArray]
		public List<User> Users;
		[XmlArray]
		public List<Subscription> Subscriptions;
		[XmlElement]
		public int CreatedStoreId;



		/* Elements specific to ProductData callback
		 *
		 */
		[XmlElement]
		public int RangeFrom;
		[XmlElement]
		public int SourceId;
		[XmlElement]
		public string FriendlyName;
		[XmlElement]
		public string URL;
		[XmlElement]
		public string MainCountry;
		[XmlElement]
		public string FrameworkType;
		[XmlElement]
		public int WebsiteId;
		[XmlElement]
		public int StoreId;
		[XmlElement]
		public int StoreviewId;

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="CUSDK.Response"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="CUSDK.Response"/>.
		/// </returns>
		public override string ToString ()
		{
			StringWriter stringWriter = new StringWriter ();

			stringWriter.Write ("[");

			if (this.Status != null) {
				stringWriter.WriteLine ("Status=" + this.Status);
			}
			if (this.Notification != null) {
				stringWriter.WriteLine(this.Notification);
			}
			if (this.MerchantName != null) {
				stringWriter.WriteLine ("MerchantName=" + this.MerchantName);
			}
			if (this.ApiKey != null) {
				stringWriter.WriteLine ("ApiKey=" + this.ApiKey);
			}
			if (this.DatabaseLocation != null) {
				stringWriter.WriteLine ("DatabaseLocation=" + this.DatabaseLocation);
			}
			if (this.CreatedDate != null) {
				stringWriter.WriteLine ("CreatedDate=" + this.CreatedDate);
			}
			if (this.VersionId != null) {
				stringWriter.WriteLine ("VersionId=" + this.VersionId);
			}
			if (this.SubscriptionId != null) {
				stringWriter.WriteLine ("SubscriptionId=" + this.SubscriptionId);
			}
			if (this.Users != null && this.Users.Count > 0) {
				stringWriter.WriteLine ("Users=[");
				foreach (var item in Users) {
					stringWriter.WriteLine (item.ToString ());
				}
				stringWriter.WriteLine ("]");
			}
			if (this.Subscriptions != null && this.Subscriptions.Count > 0) {
				stringWriter.WriteLine("Subscriptions=[");
				foreach (var item in Subscriptions) {
					stringWriter.WriteLine (item.ToString ());
				}
				stringWriter.WriteLine ("]");
			}
			if (this.CreatedStoreId > 0) {
				stringWriter.WriteLine ("CreatedStoreId=" + this.CreatedStoreId);
			}
			if (this.RangeFrom > 0) {
				stringWriter.WriteLine ("RangeFrom=" + this.RangeFrom);
			}
			if (this.SourceId > 0) {
				stringWriter.WriteLine ("SourceId=" + this.SourceId);
			}
			if (this.FriendlyName != null) {
				stringWriter.WriteLine ("FriendlyName=" + this.FriendlyName);
			}
			if (this.URL != null) {
				stringWriter.WriteLine ("URL=" + this.URL);
			}
			if (this.MainCountry != null) {
				stringWriter.WriteLine ("MainCountry=" + this.MainCountry);
			}
			if (this.FrameworkType != null) {
				stringWriter.WriteLine ("FrameworkType=" + this.FrameworkType);
			}
			if (this.WebsiteId > 0) {
				stringWriter.WriteLine ("WebsiteId=" + this.WebsiteId);
			}
			if (this.StoreId > 0) {
				stringWriter.WriteLine ("StoreId=" + this.StoreId);
			}
			if (this.StoreviewId > 0) {
				stringWriter.WriteLine ("StoreviewId=" + this.StoreviewId);
			}

			stringWriter.Write("]");

			return stringWriter.ToString();
		}
	}

	/// <summary>
	/// Represents a ChannelUnity User login.
	/// </summary>
	[XmlType]
	public class User
	{
		/// <summary>
		/// The name of the user.
		/// </summary>
		[XmlElement]
		public string UserName;
		/// <summary>
		/// The name.
		/// </summary>
		[XmlElement]
		public string Name;
		/// <summary>
		/// The company.
		/// </summary>
		[XmlElement]
		public string Company;
		/// <summary>
		/// The mobile number.
		/// </summary>
		[XmlElement]
		public string MobileNumber;
		/// <summary>
		/// The email address.
		/// </summary>
		[XmlElement]
		public string EmailAddress;
		/// <summary>
		/// The country.
		/// </summary>
		[XmlElement]
		public string Country;

		public override string ToString ()
		{
			StringWriter stringWriter = new StringWriter ();
			
			stringWriter.Write ("    [");

			if (this.UserName != null) {
				stringWriter.WriteLine("    UserName="+this.UserName);
			}
			if (this.Name != null) {
				stringWriter.WriteLine("    Name="+this.Name);
			}
			if (this.Company != null) {
				stringWriter.WriteLine("    Company="+this.Company);
			}
			if (this.MobileNumber != null) {
				stringWriter.WriteLine("    MobileNumber="+this.MobileNumber);
			}
			if (this.EmailAddress != null) {
				stringWriter.WriteLine("    EmailAddress="+this.EmailAddress);
			}
			if (this.Country != null) {
				stringWriter.WriteLine("    Country="+this.Country);
			}

			stringWriter.Write("    ]");
			
			return stringWriter.ToString();
		}
	}

	/// <summary>
	/// Subscription.
	/// </summary>
	[XmlType]
	public class Subscription
	{
		/// <summary>
		/// The date added.
		/// </summary>
		[XmlElement]
		public string DateAdded;
		/// <summary>
		/// The service sku.
		/// </summary>
		[XmlElement]
		public string ServiceSku;
		/// <summary>
		/// The settings link identifier.
		/// </summary>
		[XmlElement]
		public int SettingsLinkId;
		/// <summary>
		/// The trial expiry warned.
		/// </summary>
		[XmlElement]
		public string TrialExpiryWarned;
		/// <summary>
		/// The service status.
		/// </summary>
		[XmlElement]
		public string ServiceStatus;
		/// <summary>
		/// The service status indicator.
		/// </summary>
		[XmlElement]
		public int ServiceStatusInd;

		//PaidTo?

		public override string ToString ()
		{
			StringWriter stringWriter = new StringWriter ();
			
			stringWriter.Write ("    [");
			if (this.DateAdded != null) {
				stringWriter.WriteLine("    DateAdded="+this.DateAdded);
			}
			if (this.ServiceSku != null) {
				stringWriter.WriteLine("    ServiceSku="+this.ServiceSku);
			}

				stringWriter.WriteLine("    SettingsLinkId="+this.SettingsLinkId);

			if (this.TrialExpiryWarned != null) {
				stringWriter.WriteLine("    TrialExpiryWarned="+this.TrialExpiryWarned);
			}
			if (this.ServiceStatus != null) {
				stringWriter.WriteLine("    ServiceStatus="+this.ServiceStatus);
			}

				stringWriter.WriteLine("    ServiceStatusInd="+this.ServiceStatusInd);

			stringWriter.Write("    ]");
			
			return stringWriter.ToString();
		}
	}
}
