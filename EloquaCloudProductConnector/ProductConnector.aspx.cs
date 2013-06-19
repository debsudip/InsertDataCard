// <copyright file="ProductConnector.aspx.cs" company="cognizant.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>CTS</author>
namespace Philips.DigitalServices.Eloqua.EloquaCloudProductConnector
{
    #region using declaratives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml.Linq;
    using System.IO;
    using System.Configuration;
    using Philips.DigitalServices.Eloqua.EloquaCloudProductConnector.EloquaServiceNew;
    #endregion

    /// <summary>
    /// It has the logic to perform :
    /// 1. Read Product Purchase and Interest related Information from xml
    /// 2. Load the selected Contacts
    /// 3. Insert the customer interested/purchased product into CDO by mapping them with the contact
    /// </summary>
    public partial class ProductConnector : System.Web.UI.Page
    {


        #region Main Button Click
        /// <summary>
        /// It invokes the methods of read product, read contact & insert the interesed product details into CDO datacards
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void btnContactProduct_Click(object sender, EventArgs e)
        {

            InsertDataCard();

        }
        #endregion


        #region Setting Eloqua Credentials
        /// <summary>
        /// Connect to the instance and create proxy
        /// </summary>
        private void SetEloquaServices(EloquaServiceClient serviceProxy, EloquaProgramService.ExternalActionServiceClient programServiceProxy)
        {
            //string strInstanceName = "CSStuartOrmistonE10";
            //string strUserID = "Prashanth.Govindaiah";
            //string strUserPassword = "Infy1234";

            string strInstanceName = "CognizantTechnologySolutionsNetherlandsB";
            string strUserID = "Deb.Sudip";
            string strUserPassword = "Welcome1";

            serviceProxy.ClientCredentials.UserName.UserName = strInstanceName + "\\" + strUserID;
            serviceProxy.ClientCredentials.UserName.Password = strUserPassword;

            programServiceProxy = new EloquaProgramService.ExternalActionServiceClient();
            programServiceProxy.ClientCredentials.UserName.UserName = strInstanceName + "\\" + strUserID;
            programServiceProxy.ClientCredentials.UserName.Password = strUserPassword;
        }
        #endregion

        private void InsertDataCard()
        {
            int dataCardId = 0;
            var dataCardIDs = new int[1];


            EloquaServiceClient ServiceProxy = new EloquaServiceClient();
            EloquaProgramService.ExternalActionServiceClient ProgramServiceProxy = new EloquaProgramService.ExternalActionServiceClient();

            ////Perform the authentication
            this.SetEloquaServices(ServiceProxy, ProgramServiceProxy);

            //// Build a DataCardSet Entity Type object - (the ID is the ID of an existing DataCardSet in Eloqua)
            EntityType entityType = new EntityType { ID = 8, Name = "Product_Interested_Info", Type = "DataCardSet" };



            //// Create an Array of Dynamic Entities
            DynamicEntity[] dynamicEntities = new DynamicEntity[1];

            //// Create a new Dynamic Entity and add it to the Array of Entities
            dynamicEntities[0] = new DynamicEntity();
            dynamicEntities[0].EntityType = entityType;

            //// Create a Dynamic Entity's Field Value Collection
            dynamicEntities[0].FieldValueCollection = new DynamicEntityFields();


            dynamicEntities[0].FieldValueCollection.Add("Email_Address1", "sudip.deb@cognizant.com");
            dynamicEntities[0].FieldValueCollection.Add("PI11", "<B>" + "P1" + "</B>");
            dynamicEntities[0].FieldValueCollection.Add("PI21", "<B>" + "P2" + "</B>");
            dynamicEntities[0].FieldValueCollection.Add("PI31", "<B>" + "P3" + "</B>");
            dynamicEntities[0].FieldValueCollection.Add("PI1Desc1", "Shaver");
            dynamicEntities[0].FieldValueCollection.Add("PI2Desc1", "Razor");
            dynamicEntities[0].FieldValueCollection.Add("PI3Desc1", "Saving Blade");
            dynamicEntities[0].FieldValueCollection.Add("PI1Image1", "<" + "ImageShaver" + "/>");
            dynamicEntities[0].FieldValueCollection.Add("PI2Image1", "<" + "ImageRazor" + "/>");
            dynamicEntities[0].FieldValueCollection.Add("PI3Image1", "<" + "ImageBlade" + "/>");
            dynamicEntities[0].FieldValueCollection.Add("MappedEntityType", "1");
            dynamicEntities[0].FieldValueCollection.Add("MappedEntityID", "1");

            //// Execute the request
            var result = ServiceProxy.Create(dynamicEntities);

            //// Verify the status of each DataCard Create request in the results
            foreach (CreateResult t in result)
            {
                //// Successfull requests return a positive integer value for ID
                if (t.ID != -1)
                {
                    dataCardId = t.ID;
                }
                else
                {
                    // Extract the Error Message and Error Code for each failed Create request
                    foreach (Error createError in t.Errors)
                    {
                        Response.Write("Exception Message: " + createError.ErrorCode.ToString());
                    }
                }



            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

    }
}

