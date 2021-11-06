using Hangfire;
using MawaqaaCodeLibrary;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.Modules.Customers.Components;
using MWCoreAPI.Models.APIBaseModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MWCoreAPI.Models.APIHandler
{
    public class APIRequestAndResponseHandler : DelegatingHandler
    {
        List<string> lstApisWithoutAuth { get; set; }
        protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                lstApisWithoutAuth = GetApisWithoutAuth();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                string sAPIKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"].ToString();
                string requestBody = await request.Content.ReadAsStringAsync();
                APIModel oAPIModel = requestBody.DeserializeJsonToObject<APIModel>();
                bool IsValidToken = false;
                if (lstApisWithoutAuth.Any(x => x.ToLower() == request.RequestUri.Segments[request.RequestUri.Segments.Length - 1].ToLower()))
                {
                    if (request.RequestUri.Segments[request.RequestUri.Segments.Length - 1].ToLower() == "uploadimageforweb" || request.RequestUri.Segments[request.RequestUri.Segments.Length - 1].ToLower() == "uploadfile" || request.RequestUri.Segments[request.RequestUri.Segments.Length - 1].ToLower() == "knetresponse" || request.RequestUri.Segments[request.RequestUri.Segments.Length - 1].ToLower() == "kneterror" || request.RequestUri.Segments[request.RequestUri.Segments.Length - 1].ToLower() == "getimages")
                    {
                        IsValidToken = true;
                    }
                    else
                    {
                        if (oAPIModel.APIKey == sAPIKey)
                        {
                            IsValidToken = true;
                        }
                        else
                        {
                            IsValidToken = false;
                        }
                    }

                }
                else
                {
                    if (request.Headers.Authorization != null && request.Headers.Authorization.Scheme.ToLower() == "bearer")
                    {
                        string sToken = request.Headers.Authorization.Parameter;

                        oAPIModel.APIToken = sToken;
                        oAPIModel.UserID = (int)CustomersCOM.GetCustomerIDByAPIToken(sToken);
                        IsValidToken = oAPIModel.UserID > 0;
                    }
                    else
                    {
                        oAPIModel.LanguageID = oAPIModel.LanguageID != 0 ? oAPIModel.LanguageID : 1;
                        oAPIModel.APIStatus = -3;
                        // oAPIModel.APIMessage = PagesKeysCOM.GetPageKeyValueByName("NotAuthorized", oAPIModel.LanguageID); ;
                        return request.CreateResponse(HttpStatusCode.OK, oAPIModel);
                    }
                }
                if (IsValidToken)
                {
                    // log request body


                    // let other handlers process the request
                    var result = await base.SendAsync(request, cancellationToken);
                    var responseBody = "";
                    if (result.Content != null)
                    {
                        // once response body is ready, log it
                        responseBody = await result.Content.ReadAsStringAsync();
                    }
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                    if (!request.RequestUri.AbsoluteUri.ToLower().Contains("updatedriverlocation"))
                    {
                        BackgroundJob.Enqueue(() => SaveLog(request.RequestUri.AbsoluteUri, requestBody, responseBody, elapsedTime));
                    }
                    return result;
                }
                else
                {
                    oAPIModel.APIStatus = -3;
                    oAPIModel.APIMessage = "you are not authorized to access";
                    return request.CreateResponse(HttpStatusCode.OK, oAPIModel);
                }

            }
            catch (Exception ex)
            {
                APIModel oAPIModel = new APIModel();
                oAPIModel.APIStatus = -1;
                oAPIModel.APIMessage = ex.Message;
                return request.CreateResponse(HttpStatusCode.OK, oAPIModel);
            }

        }

        public void SaveLog(string sLink, string sRequest, string sResponse, string elapsedTime)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                //MW_WebAPILogger oLogger = new MW_WebAPILogger();
                //oLogger.RequestDateTime = DateTime.Now;
                //oLogger.ServiceLink = sLink;
                //oLogger.RequestString = sRequest;
                //oLogger.ResponseString = sResponse;
                //oLogger.ElapsedTime = elapsedTime;
                //db.MW_WebAPILogger.Add(oLogger);
                //db.SaveChanges();
            }
        }
        public List<string> GetApisWithoutAuth()
        {
            List<string> lstApis = new List<string>();

            lstApis.Add("GetCountries");
            lstApis.Add("GetCities");
            lstApis.Add("GetAreas");
            lstApis.Add("GetCarMakes");
            lstApis.Add("GetCarModels");
            lstApis.Add("GetTutorials");
            lstApis.Add("GetFAQ");
            lstApis.Add("GetTutorials");
            lstApis.Add("EditCustomerCar");
            lstApis.Add("EditCustomerAddress");
            lstApis.Add("Register");
            lstApis.Add("Login");
            lstApis.Add("VerifyCustomer");


            lstApis.Add("UploadImage");
            lstApis.Add("UploadFile");
            lstApis.Add("GetColors");
            lstApis.Add("GetPaymentsMethods");
            lstApis.Add("GetImages");
            lstApis.Add("LogingWithSocialMedia");
            lstApis.Add("GetOrderDetailsByPaymentID");


            ///CustomerAppAPI

            lstApis.Add("GetSizes");
            lstApis.Add("GetBanners");
            lstApis.Add("GetFreeDelivery");
            lstApis.Add("GetCategories");
            lstApis.Add("GetNewToTry");
            lstApis.Add("GetOffers");
            lstApis.Add("GetShopBranchDetails");
            lstApis.Add("GetNearestShopBranchDetails");
            lstApis.Add("Search");
            lstApis.Add("GetAboutUs");
            lstApis.Add("GetPrivacyPolicy");
            lstApis.Add("GetTerms");
            lstApis.Add("GetFAQs");
            lstApis.Add("GetTutorials");
            lstApis.Add("ContactUs");
            lstApis.Add("GetCustomerCart");
            lstApis.Add("AddToCart");
            lstApis.Add("UpdateCart");
            lstApis.Add("RemoveFromCart");
            lstApis.Add("CleareCustomerCart");
            lstApis.Add("GetProducts");
            lstApis.Add("Checkout");
            lstApis.Add("GetProductDetails");
            lstApis.Add("VerifyPhoneNumber");
            lstApis.Add("KnetResponse");
            lstApis.Add("KnetError");
            lstApis.Add("GetOrderDetailsByPaymentID");
            lstApis.Add("GetOrderDetails");
            lstApis.Add("ApplyPromoCode");
            lstApis.Add("RemovePromoCode");
            lstApis.Add("ClearCart");


            lstApis.Add("ClearShoppingList");
            lstApis.Add("CalculateForCheckout");
            lstApis.Add("GetCustomerAddressFromMap");
            lstApis.Add("ChangePickupAddress");
            lstApis.Add("GetSocialMedias");
            lstApis.Add("GetCustomerDetails");
            lstApis.Add("UpdateCustomerProfile");
            lstApis.Add("SaveCustomerAddress");
            lstApis.Add("ChangeCustomerPassword");
            lstApis.Add("LoginCustomer");
            lstApis.Add("RegisterCustomer");
            lstApis.Add("RegisterCustomerDevice");
            lstApis.Add("CheckVerificationCodeForgotPwdMobile");
            lstApis.Add("CheckVerificationCodeForgotPwdEmail");
            lstApis.Add("DeleteCustomerAddress");
            lstApis.Add("ForgotPasswordEmail");
            lstApis.Add("ForgotPasswordPhone");
            lstApis.Add("ResetPassword");

            lstApis.Add("RateOrder");

            lstApis.Add("GetCustomerOrders");
            lstApis.Add("GetChatUrl");
            lstApis.Add("GetCustomerNotifications");
            lstApis.Add("GetLastOrderDetails");


            lstApis.Add("TrackOrder");
            lstApis.Add("SetCityIDForShoppingList");
            return lstApis;
        }
    }
}