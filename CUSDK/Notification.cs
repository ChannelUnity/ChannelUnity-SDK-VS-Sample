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
	[XmlType]
	public class Notification
	{

		[XmlElement]
		public string ID;

		[XmlElement]
		public string Timestamp;

		[XmlElement]
		public string Type;

		[XmlElement]
		public string Payload;

		public override string ToString ()
		{
			return "Notification=[\nID="+ID+"\nTimestamp="+Timestamp+"\nType="+Type+"\nPayload="+Payload+"]";
		}
	}
	
}
