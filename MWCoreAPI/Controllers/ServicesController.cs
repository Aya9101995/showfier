using MawaqaaCodeLibrary;
using MWCoreAPI.Models.APIs.CustomersAPI;
using MWCoreAPI.Models.APIs.GlopalizationAPI;
using MWCoreAPI.Models.Filters;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MWCoreAPI.Controllers
{
    [ExceptionHandleFilter]
    public class ServicesController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetCountries")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetCountries(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();

            GlobalizationAPIRequest oGlobalizationAPIRequest = requestBody.DeserializeJsonToObject<GlobalizationAPIRequest>();
            oGlobalizationAPIRequest.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            GlobalizationAPI oGlobalizationAPI = new GlobalizationAPI();
            CountriesAPIResponse oCountriesResponseAPI = oGlobalizationAPI.GetCountries(oGlobalizationAPIRequest);
            return Request.CreateResponse(HttpStatusCode.OK, oCountriesResponseAPI);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetCities")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetCities(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();

            GlobalizationAPIRequest oGlobalizationAPIRequest = requestBody.DeserializeJsonToObject<GlobalizationAPIRequest>();
            oGlobalizationAPIRequest.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            GlobalizationAPI oGlobalizationAPI = new GlobalizationAPI();
            CitiesAPIResponse oCitiesResponseAPI = oGlobalizationAPI.GetCities(oGlobalizationAPIRequest);
            return Request.CreateResponse(HttpStatusCode.OK, oCitiesResponseAPI);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetAreas")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetAreas(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();

            GlobalizationAPIRequest oGlobalizationAPIRequest = requestBody.DeserializeJsonToObject<GlobalizationAPIRequest>();
            oGlobalizationAPIRequest.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            GlobalizationAPI oGlobalizationAPI = new GlobalizationAPI();
            AreasAPIResponse oAreasAPIResponse = oGlobalizationAPI.GetAreas(oGlobalizationAPIRequest);
            return Request.CreateResponse(HttpStatusCode.OK, oAreasAPIResponse);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetCarMakes")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetCarMakes(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();

            GlobalizationAPIRequest oGlobalizationAPIRequest = requestBody.DeserializeJsonToObject<GlobalizationAPIRequest>();
            oGlobalizationAPIRequest.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            GlobalizationAPI oGlobalizationAPI = new GlobalizationAPI();
            CarMakesAPIResponse oCarMakesAPIResponse = oGlobalizationAPI.GetCarMakes(oGlobalizationAPIRequest);
            return Request.CreateResponse(HttpStatusCode.OK, oCarMakesAPIResponse);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetCarModels")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetCarModels(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();

            GlobalizationAPIRequest oGlobalizationAPIRequest = requestBody.DeserializeJsonToObject<GlobalizationAPIRequest>();
            oGlobalizationAPIRequest.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            GlobalizationAPI oGlobalizationAPI = new GlobalizationAPI();
            CarModelsAPIResponse oCarModelsAPIResponse = oGlobalizationAPI.GetCarModels(oGlobalizationAPIRequest);
            return Request.CreateResponse(HttpStatusCode.OK, oCarModelsAPIResponse);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetTutorials")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetTutorials(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();

            GlobalizationAPIRequest oGlobalizationAPIRequest = requestBody.DeserializeJsonToObject<GlobalizationAPIRequest>();
            oGlobalizationAPIRequest.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            GlobalizationAPI oGlobalizationAPI = new GlobalizationAPI();
            TutorialsAPIResponse oTutorialsAPIResponse = oGlobalizationAPI.GetTutorials(oGlobalizationAPIRequest);
            return Request.CreateResponse(HttpStatusCode.OK, oTutorialsAPIResponse);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetFAQ")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetFAQ(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            GlobalizationAPIRequest oGlobalizationAPIRequest = requestBody.DeserializeJsonToObject<GlobalizationAPIRequest>();
            oGlobalizationAPIRequest.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            GlobalizationAPI oGlobalizationAPI = new GlobalizationAPI();
            FAQAPIResponse oFAQAPIResponse = oGlobalizationAPI.GetFAQ(oGlobalizationAPIRequest);
            return Request.CreateResponse(HttpStatusCode.OK, oFAQAPIResponse);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetCustomerAddresses")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetCustomerAddresses(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomerAdressesResponseAPI oFAQAPIResponse = oCustomersAPI.GetCustomerAddresses(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oFAQAPIResponse);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("GetCustomerWallet")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetCustomerWallet(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomerWalletResponseAPI oCustomerWalletAPIe = oCustomersAPI.GetCustomerWallet(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerWalletAPIe);
        }

        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        //[ActionName("GetCustomerCars")]
        //public async System.Threading.Tasks.Task<HttpResponseMessage> GetCustomerCars(HttpRequestMessage request)
        //{
        //    string requestBody = await request.Content.ReadAsStringAsync();
        //    CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
        //    oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
        //    CustomersAPI oCustomersAPI = new CustomersAPI();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = oCustomersAPI.GetCustomerCars(oCustomersRequestAPI);
        //    return Request.CreateResponse(HttpStatusCode.OK, oCustomerCarsResponseAPI);
        //}

        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        //[ActionName("SaveCustomerCar")]
        //public async System.Threading.Tasks.Task<HttpResponseMessage> SaveCustomerCar(HttpRequestMessage request)
        //{
        //    string requestBody = await request.Content.ReadAsStringAsync();
        //    CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
        //    oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
        //    CustomersAPI oCustomersAPI = new CustomersAPI();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = oCustomersAPI.SaveCustomerCar(oCustomersRequestAPI);
        //    return Request.CreateResponse(HttpStatusCode.OK, oCustomerCarsResponseAPI);
        //}


        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        //[ActionName("SetCarAsDefault")]
        //public async System.Threading.Tasks.Task<HttpResponseMessage> SetCarAsDefault(HttpRequestMessage request)
        //{
        //    string requestBody = await request.Content.ReadAsStringAsync();
        //    CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
        //    oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
        //    CustomersAPI oCustomersAPI = new CustomersAPI();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = oCustomersAPI.SetCarAsDefault(oCustomersRequestAPI);
        //    return Request.CreateResponse(HttpStatusCode.OK, oCustomerCarsResponseAPI);
        //}


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("SaveCustomerAddress")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SaveCustomerAddress(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomerAdressesResponseAPI oCustomerAdressesResponseAPI = oCustomersAPI.SaveCustomerAddress(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerAdressesResponseAPI);
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("DeleteCustomerAddress")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteCustomerAddress(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomerAdressesResponseAPI oCustomerAdressesResponseAPI = oCustomersAPI.DeleteCustomerAddress(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerAdressesResponseAPI);
        }

        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        //[ActionName("DeleteCustomerCar")]
        //public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteCustomerCar(HttpRequestMessage request)
        //{
        //    string requestBody = await request.Content.ReadAsStringAsync();
        //    CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
        //    oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
        //    CustomersAPI oCustomersAPI = new CustomersAPI();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = oCustomersAPI.DeleteCustomerCar(oCustomersRequestAPI);
        //    return Request.CreateResponse(HttpStatusCode.OK, oCustomerCarsResponseAPI);
        //}


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("EditCustomerAddress")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> EditCustomerAddress(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomerAdressesResponseAPI oCustomerAdressesResponseAPI = oCustomersAPI.EditCustomerAddress(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerAdressesResponseAPI);
        }

        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        //[ActionName("EditCustomerCar")]
        //public async System.Threading.Tasks.Task<HttpResponseMessage> EditCustomerCar(HttpRequestMessage request)
        //{
        //    string requestBody = await request.Content.ReadAsStringAsync();
        //    CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
        //    oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
        //    CustomersAPI oCustomersAPI = new CustomersAPI();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = oCustomersAPI.EditCustomerCar(oCustomersRequestAPI);
        //    return Request.CreateResponse(HttpStatusCode.OK, oCustomerCarsResponseAPI);
        //}


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("EditCustomerProfile")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> EditCustomerProfile(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomersResponseAPI oCustomerResponseAPI = oCustomersAPI.EditCustomerProfile(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerResponseAPI);
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("SaveCustomerProfile")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> SaveCustomerProfile(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomersResponseAPI oCustomerResponseAPI = oCustomersAPI.SaveCustomerProfile(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerResponseAPI);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("Register")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> Register(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomersResponseAPI oCustomerResponseAPI = oCustomersAPI.Register(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerResponseAPI);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("Login")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> Login(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomersResponseAPI oCustomerResponseAPI = oCustomersAPI.Login(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerResponseAPI);
        }
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [ActionName("VerifyCustomer")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> VerifyCustomer(HttpRequestMessage request)
        {
            string requestBody = await request.Content.ReadAsStringAsync();
            CustomersRequestAPI oCustomersRequestAPI = requestBody.DeserializeJsonToObject<CustomersRequestAPI>();
            oCustomersRequestAPI.APIToken = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : "";
            CustomersAPI oCustomersAPI = new CustomersAPI();
            CustomersResponseAPI oCustomerResponseAPI = oCustomersAPI.VerifyCustomer(oCustomersRequestAPI);
            return Request.CreateResponse(HttpStatusCode.OK, oCustomerResponseAPI);
        }
    }

}