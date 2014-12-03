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

namespace CUSDK
{
	/// <summary>
	/// Store.
	/// </summary>
	public class Store
	{
		public Store ()
		{
		}

		/// <summary>
		/// Gets or sets the friendly name for this store.
		/// </summary>
		/// <value>
		/// The store friendly name.
		/// </value>
		public string FriendlyName {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the store URL.
		/// </summary>
		/// <value>
		/// The store URL.
		/// </value>
		public string URL {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the main country.
		/// </summary>
		/// <value>
		/// The main country.
		/// </value>
		public string MainCountry {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the type of the framework.
		/// </summary>
		/// <value>
		/// The type of the framework.
		/// </value>
		public string FrameworkType {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the website identifier.
		/// </summary>
		/// <value>
		/// The website identifier.
		/// </value>
		public int WebsiteId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the store identifier.
		/// </summary>
		/// <value>
		/// The store identifier.
		/// </value>
		public int StoreId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the storeview identifier.
		/// </summary>
		/// <value>
		/// The storeview identifier.
		/// </value>
		public int StoreviewId {
			get;
			set;
		}
	}
}

