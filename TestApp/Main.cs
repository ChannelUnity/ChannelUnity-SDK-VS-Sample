using CUSDK;
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
using System.Collections.Generic;

namespace TestApp
{
	public class MainClass
	{
		
		static string url = "http://94.193.82.158:80/";

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
            this.cu.MerchantName = "demoaccount1";
            this.cu.UserName = "demoaccount1";
			this.cu.Password = "password1";
		}

		/// <summary>
		/// Calls the ValidateUser API.
		/// </summary>
		public void TestValidateUser()
		{
			Response result = this.cu.ValidateUser();

			// Get API key first so we can make calls

			this.cu.ApiKey = result.ApiKey;
		}

		/// <summary>
		/// Send information about our website sources/stores to our CU account.
		/// </summary>
		public void TestStoreData()
		{
			List<Store> list = GetStoresList();
			Response result = cu.SendStoreDataToCU(list);
			Console.WriteLine(result);
		}

		/// <summary>
		/// Tests the category data.
		/// </summary>
		public void TestCategoryData()
		{
			Console.WriteLine ("Test Category Data");

			CategoryList categoryList = new CategoryList();
			categoryList.URL = url;
			categoryList.FrameworkType = "Custom";
			categoryList.WebsiteId = 1;
			categoryList.StoreId = 1;
			categoryList.StoreviewId = 1;
			categoryList.Category = GetCategoriesList ();

			Response result = cu.SendCategoryDataToCU(categoryList);

			Console.WriteLine(result);
		}

		/// <summary>
		/// Tests the sending of attributes.
		/// </summary>
		public void TestSendAttributes()
		{
			Response result = cu.SendAttributesToCU(GetAttributesList());

			Console.WriteLine(result);
		}

		/// <summary>
		/// Send products to the connected ChannelUnity account.
		/// </summary>
		public void TestSendProducts()
		{
			List<Product> productList = GetProductList ();

			Response result = cu.SendProductsToCU(productList);

			Console.WriteLine(result);
		
		}

		/// <summary>
		/// The entry point of our test application, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			Console.WriteLine ("ChannelUnity Connector Kit Test Console App");

			MainClass myApp = new MainClass ();

			// This is always needed to get our API Key
			myApp.TestValidateUser ();

			///
			/// Uncomment line(s) below to test functionality.
			///

			//myApp.TestStoreData ();

			//myApp.TestCategoryData ();

			//myApp.TestSendAttributes ();

			myApp.TestSendProducts ();

            Console.WriteLine("Press any key to exit.");
            Console.Read();
		}

		/// --------------------------------------------------------

		/// <summary>
		/// Returns data about our store.
		/// </summary>
		/// <returns>The stores list.</returns>

		public static List<Store> GetStoresList() {
			Store s = new Store();
			s.FriendlyName = "My Store";
			s.URL = url;
			s.WebsiteId = 1;
			s.StoreId = 1;
			s.StoreviewId = 1;

			List<Store> list = new List<Store>();
			list.Add(s);

			return list;
		}

		/// <summary>
		/// This sample creates a parent category of "Category1" which child categories of "Widgets" and "Things".
		/// </summary>
		/// <returns>The categories list.</returns>
		public static List<Category> GetCategoriesList ()
		{
			List<Category> catlist = new List<Category> ();
		
			Category c = new Category ();
		
			c.ID = 2;
			c.Name = "Category1";
			c.Position = "1";
			c.CategoryPath = "1/2";
			c.ParentID = 1;
			c.Level = 1;
			catlist.Add (c);

			c = new Category ();

			c.ID = 3;
			c.Name = "Widgets";
			c.Position = "1";
			c.CategoryPath = "1/2/3";
			c.ParentID = 2;
			c.Level = 2;
			catlist.Add (c);

			c = new Category ();

			c.ID = 4;
			c.Name = "Things";
			c.Position = "2";
			c.CategoryPath = "1/2/4";
			c.ParentID = 2;
			c.Level = 2;
			catlist.Add (c);

			return catlist;

		}

		
		public static List<ProductAttribute> GetAttributesList() {
			List<ProductAttribute> attributeList = new List<ProductAttribute>();
			ProductAttribute attribute = new ProductAttribute();

			attribute.Name = "tv_size";
			attribute.Type = "decimal";
			attribute.FriendlyName = "TV Size (inches)";

			attributeList.Add (attribute);

			return attributeList;
		}

		public static List<Product> GetProductList ()
		{
			List<Product> productList = new List<Product>();
			
			Product p = new Product();
			p.URL = url;
			p.RemoteId = 1;
			p.ProductType = "Default";
			p.Title = "My widget";
			p.Description = "This is a really great product. You should buy many.";
			p.SKU = "D123";
			p.Price = 11.99m;
			p.Quantity = 10;
			p.Category = "2";
			p.CategoryName = "Cat123";
			p.Image = "http://ecx.images-amazon.com/images/I/71DGVjf27lL._SL1280_.jpg";
			
	//		productList.Add(p);

			//
			// Creating a parent product (shoe) with two child items (two sizes).
			//
			Product parent = new Product();
			parent.URL = url;
			parent.RemoteId = 10;
			parent.ProductType = "Default";
			parent.Title = "Nike Trainers";
			parent.Description = "Great style for the new season.";
			parent.SKU = "NTPARNT";
			parent.Price = 45.99m;
			parent.Quantity = 10;
			parent.Category = "3";
			parent.CategoryName = "Shoes";
			parent.Image = "http://bit.ly/16qYx5H";
			parent ["colour"] = "White";

			// The attribute by which the product varies

			List<string> variationAttribute = new List<string> ();
			variationAttribute.Add ("size");
			parent.Variations = variationAttribute;

			// Which SKUs are the child products

			List<string> relatedSKUs = new List<string> ();
			relatedSKUs.Add("NTPARNT-8");
			relatedSKUs.Add("NTPARNT-9");
			parent.RelatedSKUs = relatedSKUs;

			// Now create the two child products:

			Product child1 = new Product();
			child1.URL = url;
			child1.RemoteId = 11;
			child1.ProductType = "Default";
			child1.Title = "Nike Trainers";
			child1.Description = "Great style for the new season.";
			child1.SKU = "NTPARNT-8";
			child1.Price = 45.99m;
			child1.Quantity = 10;
			child1.Category = "3";
			child1.CategoryName = "Shoes";
			child1.Image = "http://bit.ly/16qYx5H";
			child1 ["colour"] = "White";
			child1 ["size"] = "8";


			Product child2 = new Product();
			child2.URL = url;
			child2.RemoteId = 12;
			child2.ProductType = "Default";
			child2.Title = "Nike Trainers";
			child2.Description = "Great style for the new season.";
			child2.SKU = "NTPARNT-9";
			child2.Price = 45.99m;
			child2.Quantity = 10;
			child2.Category = "3";
			child2.CategoryName = "Shoes";
			child2.Image = "http://bit.ly/16qYx5H";
			child2 ["colour"] = "White";
			child2 ["size"] = "9";
			
			productList.Add(child1);
			productList.Add(child2);
			productList.Add(parent);


			return productList;
		}
	}
}
