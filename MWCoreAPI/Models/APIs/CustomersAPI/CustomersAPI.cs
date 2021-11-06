using MWCore.Areas.MWCore.Models.Modules.Customers.Components;
using MWCore.Areas.MWCore.Models.Modules.Customers.Models;
using MWCoreAPI.Models.APIBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWCoreAPI.Models.APIs.CustomersAPI
{
    public class CustomersAPI
    {
        public CustomersResponseAPI Login(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersResponseAPI oCustomersResponseAPI = new CustomersResponseAPI();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            bool CanLogin = oCustomersCOM.Login(oCustomersRequestAPI.PhoneCode, oCustomersRequestAPI.PhoneNumber, oCustomersRequestAPI.LanguageID);
            if (CanLogin)
            {
                oCustomersResponseAPI.APIStatus = 1;
                oCustomersResponseAPI.APIMessage = "Success";
            }
            else
            {
                oCustomersResponseAPI.APIStatus = -1;
                oCustomersResponseAPI.APIMessage = "Customer Blocked";
            }
            return oCustomersResponseAPI;
        }

        public CustomersResponseAPI VerifyCustomer(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersResponseAPI oCustomersResponseAPI = new CustomersResponseAPI();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            bool IsVerified = oCustomersCOM.VerifyCustomer(oCustomersRequestAPI.oCustomer);
            if (IsVerified)
            {
                oCustomersResponseAPI.APIStatus = 1;
                oCustomersResponseAPI.APIMessage = "Success";
            }
            else
            {
                oCustomersResponseAPI.APIStatus = -1;
                oCustomersResponseAPI.APIMessage = "Not Verified";
            }
            return oCustomersResponseAPI;
        }

        public CustomersResponseAPI Register(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersResponseAPI oCustomersResponseAPI = new CustomersResponseAPI();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            oCustomersResponseAPI.oCustomer.IsProfileCompleted = oCustomersCOM.Register(oCustomersRequestAPI.oCustomer);
            if (oCustomersResponseAPI.oCustomer.IsProfileCompleted)
            {
                oCustomersResponseAPI.APIStatus = 1;
                oCustomersResponseAPI.APIMessage = "Register Completed";
            }
            else
            {
                oCustomersResponseAPI.APIStatus = -1;
                oCustomersResponseAPI.APIMessage = "Register is Incompleted";
            }
            return oCustomersResponseAPI;
        }


        public CustomerAdressesResponseAPI GetCustomerAddresses(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersCOM oCustomersCOM = new CustomersCOM();
            CustomerAdressesResponseAPI oCustomerAdressesResponseAPI = new CustomerAdressesResponseAPI();
            int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
            oCustomerAdressesResponseAPI.lstCustomerAddresses = oCustomersCOM.GetCustomerAddresses(CustomerID, oCustomersRequestAPI.LanguageID);
            oCustomerAdressesResponseAPI.APIStatus = 1;
            oCustomerAdressesResponseAPI.APIMessage = "Success";
            return oCustomerAdressesResponseAPI;
        }
        public CustomerWalletResponseAPI GetCustomerWallet(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersCOM oCustomersCOM = new CustomersCOM();
            CustomerWalletResponseAPI oCustomerWalletAPI = new CustomerWalletResponseAPI();
            int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
            oCustomerWalletAPI.oCustomerWallet = oCustomersCOM.GetCustomerWallet(CustomerID);
            oCustomerWalletAPI.APIStatus = 1;
            oCustomerWalletAPI.APIMessage = "Success";
            return oCustomerWalletAPI;
        }

        //public CustomerCarsResponseAPI GetCustomerCars(CustomersRequestAPI oCustomersRequestAPI)
        //{
        //    CustomersCOM oCustomersCOM = new CustomersCOM();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = new CustomerCarsResponseAPI();
        //    int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
        //    oCustomerCarsResponseAPI.lstCustomerCars = oCustomersCOM.GetCustomerCars(CustomerID, oCustomersRequestAPI.LanguageID);
        //    oCustomerCarsResponseAPI.APIStatus = 1;
        //    oCustomerCarsResponseAPI.APIMessage = "Success";
        //    return oCustomerCarsResponseAPI;
        //}

        //public CustomerCarsResponseAPI SaveCustomerCar(CustomersRequestAPI oCustomersRequestAPI)
        //{
        //    CustomersCOM oCustomersCOM = new CustomersCOM();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = new CustomerCarsResponseAPI();
        //    int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
        //    oCustomersRequestAPI.oCustomerCar.CustomerID = CustomerID;
        //    oCustomerCarsResponseAPI.lstCustomerCars = oCustomersCOM.SaveCustomerCar(oCustomersRequestAPI.oCustomerCar, oCustomersRequestAPI.LanguageID);
        //    oCustomerCarsResponseAPI.APIStatus = 1;
        //    oCustomerCarsResponseAPI.APIMessage = "Success";
        //    return oCustomerCarsResponseAPI;
        //}

        //public CustomerCarsResponseAPI SetCarAsDefault(CustomersRequestAPI oCustomersRequestAPI)
        //{
        //    CustomersCOM oCustomersCOM = new CustomersCOM();
        //    CustomerCarsResponseAPI oCustomerCarsResponseAPI = new CustomerCarsResponseAPI();
        //    int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
        //    oCustomerCarsResponseAPI.lstCustomerCars = oCustomersCOM.SetCarAsDefault(CustomerID, oCustomersRequestAPI.CarID, oCustomersRequestAPI.LanguageID);
        //    oCustomerCarsResponseAPI.APIStatus = 1;
        //    oCustomerCarsResponseAPI.APIMessage = "Success";
        //    return oCustomerCarsResponseAPI;
        //}

        public CustomerAdressesResponseAPI SaveCustomerAddress(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersCOM oCustomersCOM = new CustomersCOM();
            CustomerAdressesResponseAPI oCustomerAdressesResponseAPI = new CustomerAdressesResponseAPI();
            int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
            oCustomersRequestAPI.oCustomerAddress.CustomerID = CustomerID;
            oCustomerAdressesResponseAPI.lstCustomerAddresses = oCustomersCOM.SaveCustomerAddress(oCustomersRequestAPI.oCustomerAddress, oCustomersRequestAPI.LanguageID);
            oCustomerAdressesResponseAPI.APIStatus = 1;
            oCustomerAdressesResponseAPI.APIMessage = "Success";
            return oCustomerAdressesResponseAPI;
        }
        public CustomerAdressesResponseAPI DeleteCustomerAddress(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomerAdressesResponseAPI oCustomerAddressesResponseAPI = new CustomerAdressesResponseAPI();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
            oCustomerAddressesResponseAPI.lstCustomerAddresses = oCustomersCOM.DeleteCustomerAddress(CustomerID, oCustomersRequestAPI.AddressID, oCustomersRequestAPI.LanguageID);
            oCustomerAddressesResponseAPI.APIStatus = 1;
            oCustomerAddressesResponseAPI.APIMessage = "Success";
            return oCustomerAddressesResponseAPI;
        }
        //public CustomerCarsResponseAPI DeleteCustomerCar(CustomersRequestAPI oCustomersRequestAPI)
        //{
        //    CustomerCarsResponseAPI oCustomerCarssResponseAPI = new CustomerCarsResponseAPI();
        //    CustomersCOM oCustomersCOM = new CustomersCOM();
        //    int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
        //    oCustomerCarssResponseAPI.lstCustomerCars = oCustomersCOM.DeleteCustomerCar(CustomerID, oCustomersRequestAPI.CarID, oCustomersRequestAPI.LanguageID);
        //    oCustomerCarssResponseAPI.APIStatus = 1;
        //    oCustomerCarssResponseAPI.APIMessage = "Success";
        //    return oCustomerCarssResponseAPI;
        //}
        public CustomerAdressesResponseAPI EditCustomerAddress(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomerAdressesResponseAPI oCustomerAddressesResponseAPI = new CustomerAdressesResponseAPI();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            oCustomerAddressesResponseAPI.oCustomerAddress = oCustomersCOM.GetCustomerAddressDetails(oCustomersRequestAPI.AddressID, oCustomersRequestAPI.LanguageID);
            oCustomerAddressesResponseAPI.APIStatus = 1;
            oCustomerAddressesResponseAPI.APIMessage = "Success";
            return oCustomerAddressesResponseAPI;
        }
        //public CustomerCarsResponseAPI EditCustomerCar(CustomersRequestAPI oCustomersRequestAPI)
        //{
        //    CustomerCarsResponseAPI oCustomerCarResponseAPI = new CustomerCarsResponseAPI();
        //    CustomersCOM oCustomersCOM = new CustomersCOM();
        //    oCustomerCarResponseAPI.oCustomerCar = oCustomersCOM.GetCustomerCarDetails(oCustomersRequestAPI.CarID, oCustomersRequestAPI.LanguageID);
        //    oCustomerCarResponseAPI.APIStatus = 1;
        //    oCustomerCarResponseAPI.APIMessage = "Success";
        //    return oCustomerCarResponseAPI;
        //}
        public CustomersResponseAPI EditCustomerProfile(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersResponseAPI oCustomerResponseAPI = new CustomersResponseAPI();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            int CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
            oCustomerResponseAPI.oCustomer = oCustomersCOM.GetCustomerDetails(CustomerID);
            oCustomerResponseAPI.APIStatus = 1;
            oCustomerResponseAPI.APIMessage = "Success";
            return oCustomerResponseAPI;
        }
        public CustomersResponseAPI SaveCustomerProfile(CustomersRequestAPI oCustomersRequestAPI)
        {
            CustomersResponseAPI oCustomerResponseAPI = new CustomersResponseAPI();
            CustomersCOM oCustomersCOM = new CustomersCOM();
            oCustomersRequestAPI.oCustomer.CustomerID = CustomersCOM.GetCustomerIDByAPIToken(oCustomersRequestAPI.APIToken);
            oCustomerResponseAPI.oCustomer = oCustomersCOM.SaveCustomerAPI(oCustomersRequestAPI.oCustomer);
            oCustomerResponseAPI.APIStatus = 1;
            oCustomerResponseAPI.APIMessage = "Success";
            return oCustomerResponseAPI;
        }


    }
    public class CustomersRequestAPI : APIModel
    {
        public CustomersModel oCustomer { get; set; }
        public CustomersCarsModel oCustomerCar { get; set; }
        public CustomersAddressesModel oCustomerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneCode { get; set; }
        public int CarID { get; set; }
        public int AddressID { get; set; }
    }
    public class CustomersResponseAPI : APIModel
    {
        public CustomersModel oCustomer { get; set; }
    }
    public class CustomerAdressesResponseAPI : APIModel
    {
        public List<CustomersAddressesModel> lstCustomerAddresses { get; set; }
        public CustomersAddressesModel oCustomerAddress { get; set; }
    }
    public class CustomerWalletResponseAPI : APIModel
    {
        public CustomersWalletsModel oCustomerWallet { get; set; }
    }
    public class CustomerCarsResponseAPI : APIModel
    {
        public List<CustomersCarsModel> lstCustomerCars { get; set; }
        public CustomersCarsModel oCustomerCar { get; set; }
    }

}