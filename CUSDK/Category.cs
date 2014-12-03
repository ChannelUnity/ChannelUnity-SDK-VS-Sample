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
	public class Category
	{
		public int ID {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>
		/// The position.
		/// </value>
		public string Position {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the category path.
		/// </summary>
		/// <value>
		/// The category path.
		/// </value>
		public string CategoryPath {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the parent Id.
		/// </summary>
		/// <value>
		/// The parent Id.
		/// </value>
		public int ParentID {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		/// <value>
		/// The level.
		/// </value>
		public int Level {
			get;
			set;
		}
	}


}

