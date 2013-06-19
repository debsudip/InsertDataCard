using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philips.DigitalServices.Eloqua.EloquaCloudProductConnector
{
    public class ProductOwner
    {
        public string EmailID { get; set; }
        public string ProductOwn1 { get; set; }
        public string ProductDetails1 { get; set; }
        public string ProductImage1 { get; set; }
        public string ProductOwn2 { get; set; }
        public string ProductDetails2 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductOwn3 { get; set; }
        public string ProductDetails3 { get; set; }
        public string ProductImage3 { get; set; }

        public ProductOwner(string emailID, string productOwn1, string productDetails1, string productImage1,
           string productOwn2, string productDetails2, string productImage2, string productOwn3, string productDetails3, string productImage3)
        {
            // TODO: Complete member initialization
            this.EmailID = emailID;
            this.ProductOwn1 = productOwn1;
            this.ProductDetails1 = productDetails1;
            this.ProductImage1 = productImage1;
            this.ProductOwn2 = productOwn2;
            this.ProductDetails2 = productDetails2;
            this.ProductImage2 = productImage2;
            this.ProductOwn3 = productOwn3;
            this.ProductDetails3 = productDetails3;
            this.ProductImage3 = productImage3;
        }

    }
}