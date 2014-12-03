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
using System.Collections.Generic;
using System.Collections;

namespace CUSDK
{
	/// <summary>
	/// Product.
	/// </summary>
	public class Product 
	{
		// Backing store for custom attributes
		Dictionary <string,string> customAttrs = new Dictionary<string,string>();

		public Product ()
		{
		}

		public string URL {
			get;
			set;
		}

		public int StoreViewId {
			get;
			set;
		}

		public int RemoteId {
			get;
			set;
		}

		public string ProductType {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public string SKU {
			get;
			set;
		}

		public decimal Price {
			get;
			set;
		}

		public int Quantity {
			get;
			set;
		}

		public string Category {
			get;
			set;
		}

		public string CategoryName {
			get;
			set;
		}

		public string Image {
			get;
			set;
		}

		// ---------------------------------------

		// RelatedSKUs
		public IList<string> RelatedSKUs {
			get;
			set;
		}

		// Variations
		public IList<string> Variations {
			get;
			set;
		}

		// Custom attributes
		public string this[string attrCode]
		{
			get
			{
				return customAttrs[attrCode];
			}
			set {
				customAttrs [attrCode] = value;
			}
		}

		public Dictionary<string, string>.KeyCollection AllCustomKeys()
		{
			return customAttrs.Keys;
		}
	}
}

