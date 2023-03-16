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
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace CUSDK
{
    /// <summary>
    /// Represents an Order as returned from ChannelUnity.
    /// </summary>
    [XmlType]
    public class Order
    {
        public Order()
        {
        }

        [XmlElement]
        public string ServiceSku
        {
            get;
            set;
        }

        [XmlElement]
        public string Marketplace
        {
            get;
            set;
        }

        [XmlElement]
        public string OrderId
        {
            get;
            set;
        }

        [XmlElement]
        public string OrderSeq
        {
            get;
            set;
        }

        [XmlElement]
        public string PurchaseDate
        {
            get;
            set;
        }

        [XmlElement]
        public string Currency
        {
            get;
            set;
        }

        [XmlElement]
        public string TotalInvoiceAmount
        {
            get;
            set;
        }

        [XmlElement]
        public string TotalTax
        {
            get;
            set;
        }

        [XmlElement]
        public string OrderFlags
        {
            get;
            set;
        }

        [XmlElement]
        public string OrderStatus
        {
            get;
            set;
        }

        [XmlElement]
        public string StockReservedCart
        {
            get;
            set;
        }

        [XmlElement]
        public ShippingInfoType ShippingInfo
        {
            get;
            set;
        }

        [XmlElement]
        public BillingInfoType BillingInfo
        {
            get;
            set;
        }

        [XmlArray]
        public List<Item> OrderItems
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringWriter stringWriter = new StringWriter();

            stringWriter.Write("[");
            stringWriter.WriteLine("\tServiceSku=" + this.ServiceSku);
            stringWriter.WriteLine("\tMarketplace=" + this.Marketplace);
            stringWriter.WriteLine("\tOrderId=" + this.OrderId);
            stringWriter.WriteLine("\tOrderSeq=" + this.OrderSeq);
            stringWriter.WriteLine("\tPurchaseDate=" + this.PurchaseDate);
            stringWriter.WriteLine("\tCurrency=" + this.Currency);
            stringWriter.WriteLine("\tTotalInvoiceAmount=" + this.TotalInvoiceAmount);
            stringWriter.WriteLine("\tTotalTax=" + this.TotalTax);
            stringWriter.WriteLine("\tOrderFlags=" + this.OrderFlags);
            stringWriter.WriteLine("\tOrderStatus=" + this.OrderStatus);
            stringWriter.WriteLine("\tStockReservedCart=" + this.StockReservedCart);
            stringWriter.WriteLine("\tShippingInfo=" + this.ShippingInfo);
            stringWriter.WriteLine("\tBillingInfo=" + this.BillingInfo);
            if (this.OrderItems != null)
            {
                stringWriter.Write("OrderItems=[");
                foreach (var item in this.OrderItems)
                {
                    stringWriter.WriteLine("\tOrderItem=" + item);
                }
                stringWriter.Write("]");
            }
            stringWriter.Write("]");

            return stringWriter.ToString();
        }

        [XmlType]
        public class ShippingInfoType
        {
            [XmlElement]
            public string RecipientName
            {
                get;
                set;
            }

            [XmlElement]
            public string Email
            {
                get;
                set;
            }

            [XmlElement]
            public string Address1
            {
                get;
                set;
            }

            [XmlElement]
            public string Address2
            {
                get;
                set;
            }

            [XmlElement]
            public string Address3
            {
                get;
                set;
            }

            [XmlElement]
            public string City
            {
                get;
                set;
            }

            [XmlElement]
            public string State
            {
                get;
                set;
            }

            [XmlElement]
            public string PostalCode
            {
                get;
                set;
            }

            [XmlElement]
            public string Country
            {
                get;
                set;
            }

            [XmlElement]
            public string PhoneNumber
            {
                get;
                set;
            }

            [XmlElement]
            public string ShippingPrice
            {
                get;
                set;
            }

            [XmlElement]
            public string ShippingTax
            {
                get;
                set;
            }

            [XmlElement]
            public string Service
            {
                get;
                set;
            }

            [XmlElement]
            public string DeliveryInstructions
            {
                get;
                set;
            }

            [XmlElement]
            public string GiftWrapPrice
            {
                get;
                set;
            }

            [XmlElement]
            public string GiftWrapTax
            {
                get;
                set;
            }

            [XmlElement]
            public string GiftWrapType
            {
                get;
                set;
            }

            [XmlElement]
            public string GiftMessage
            {
                get;
                set;
            }

            public override string ToString()
            {
                StringWriter stringWriter = new StringWriter();

                stringWriter.Write("[");
                stringWriter.WriteLine("\t\tRecipientName=" + this.RecipientName);
                stringWriter.WriteLine("\t\tEmail=" + this.Email);
                stringWriter.WriteLine("\t\tAddress1=" + this.Address1);
                stringWriter.WriteLine("\t\tAddress2=" + this.Address2);
                stringWriter.WriteLine("\t\tAddress3=" + this.Address3);
                stringWriter.WriteLine("\t\tCity=" + this.City);
                stringWriter.WriteLine("\t\tState=" + this.State);
                stringWriter.WriteLine("\t\tPostalCode=" + this.PostalCode);
                stringWriter.WriteLine("\t\tCountry=" + this.Country);
                stringWriter.WriteLine("\t\tPhoneNumber=" + this.PhoneNumber);
                stringWriter.WriteLine("\t\tShippingPrice=" + this.ShippingPrice);
                stringWriter.WriteLine("\t\tShippingTax=" + this.ShippingTax);
                stringWriter.WriteLine("\t\tService=" + this.Service);
                stringWriter.WriteLine("\t\tDeliveryInstructions=" + this.DeliveryInstructions);
                stringWriter.WriteLine("\t\tGiftWrapPrice=" + this.GiftWrapPrice);
                stringWriter.WriteLine("\t\tGiftWrapTax=" + this.GiftWrapTax);
                stringWriter.WriteLine("\t\tGiftWrapType=" + this.GiftWrapType);
                stringWriter.WriteLine("\t\tGiftMessage=" + this.GiftMessage);
                stringWriter.Write("]");

                return stringWriter.ToString();
            }
        }

        [XmlType]
        public class BillingInfoType
        {
            [XmlElement]
            public string Name
            {
                get;
                set;
            }

            [XmlElement]
            public string Email
            {
                get;
                set;
            }

            [XmlElement]
            public string PhoneNumber
            {
                get;
                set;
            }

            public override string ToString()
            {
                StringWriter stringWriter = new StringWriter();

                stringWriter.Write("[");
                stringWriter.WriteLine("\t\tName=" + this.Name);
                stringWriter.WriteLine("\t\tEmail=" + this.Email);
                stringWriter.WriteLine("\t\tPhoneNumber=" + this.PhoneNumber);
                stringWriter.Write("]");

                return stringWriter.ToString();
            }
        }


        [XmlType]
        public class Item
        {
            [XmlElement]
            public string SKU
            {
                get;
                set;
            }

            [XmlElement]
            public string ProductID
            {
                get;
                set;
            }

            [XmlElement]
            public string Name
            {
                get;
                set;
            }

            [XmlElement]
            public float Quantity
            {
                get;
                set;
            }

            [XmlElement]
            public string Price
            {
                get;
                set;
            }

            [XmlElement]
            public string Tax
            {
                get;
                set;
            }

            public override string ToString()
            {
                StringWriter stringWriter = new StringWriter();

                stringWriter.WriteLine("[");
                stringWriter.WriteLine("\t\tSKU=" + this.SKU);
                stringWriter.WriteLine("\t\tProductID=" + this.ProductID);
                stringWriter.WriteLine("\t\tName=" + this.Name);
                stringWriter.WriteLine("\t\tQuantity=" + this.Quantity);
                stringWriter.WriteLine("\t\tPrice=" + this.Price);
                stringWriter.WriteLine("\t\tTax=" + this.Tax);
                stringWriter.WriteLine("]");

                return stringWriter.ToString();
            }
        }
    }
}
