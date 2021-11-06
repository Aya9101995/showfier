using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Customers;
using MWCore.Areas.MWCore.Models.Modules.Customers.Models;
using MWCore.Areas.MWCore.Models.Modules.SystemLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MWCore.Areas.MWCore.Models.Modules.Customers.Components
{
    public class CustomersCOM
    {
        public bool Login(string PhoneCode, string PhoneNumber,int LanguageID)
        {
            CustomersModel oModel = new CustomersModel();

            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Customers oCustomer = db.MW_Customers.FirstOrDefault(x => x.PhoneCode == PhoneCode && x.PhoneNumber == PhoneNumber);

                if (oCustomer == null)
                {
                    oCustomer = new MW_Customers()
                    {
                        PhoneCode = PhoneCode,
                        PhoneNumber = PhoneNumber,
                        IsProfileCompleted = false,
                        DefaultLanguageID = LanguageID
                    };
                    db.MW_Customers.Add(oCustomer);
                    db.SaveChanges();

                    MW_CustomersWallets oWallet = new MW_CustomersWallets()
                    {
                        CustomerID = oCustomer.ID,
                        Ballance = 0,
                    };
                    db.MW_CustomersWallets.Add(oWallet);
                    db.SaveChanges();
                }

                if (oCustomer != null && oCustomer.IsBlocked)
                {
                    return false; // blocked customer
                }
                MW_CustomersVerificationCodes oCode = db.MW_CustomersVerificationCodes.FirstOrDefault(x => x.CustomerID == oCustomer.ID);
                bool IsNew = oCode == null ? true : false;
                if (IsNew)
                {
                    oCode = new MW_CustomersVerificationCodes();
                }
                oCode.CreatedDate = DateTime.Now;
                oCode.CustomerID = oCustomer.ID;
                oCode.VerificationCode = "1234";// GenerateActivationCode();
                if (IsNew)
                {
                    db.MW_CustomersVerificationCodes.Add(oCode);
                }
                db.SaveChanges();
                return true;
                //Send SMS
            }
        }

        public bool VerifyCustomer(CustomersModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                int CustomerID = (from customer in db.MW_Customers
                                  join verification in db.MW_CustomersVerificationCodes on customer.ID equals verification.CustomerID
                                  where customer.PhoneCode == oModel.PhoneCode && customer.PhoneNumber == oModel.PhoneNumber && verification.VerificationCode == oModel.oVerificationCode.VerificationCode
                                  select customer.ID).FirstOrDefault();
                if (CustomerID > 0)
                {
                    MW_CustomersDevices oDevice = db.MW_CustomersDevices.FirstOrDefault(x => x.CustomerID == CustomerID);
                    bool IsNew = oDevice == null ? true : false;
                    if (IsNew)
                    {
                        oDevice = new MW_CustomersDevices();
                    }
                    oDevice.ApiToken = GenerateAPIToken();
                    oDevice.CustomerID = CustomerID;
                    oDevice.DeviceID = oModel.oDevice.DeviceID;
                    oDevice.DevicePlatform = oModel.oDevice.DevicePlatform;
                    oDevice.DeviceToken = oModel.oDevice.DeviceToken;
                    if (IsNew)
                    {
                        db.MW_CustomersDevices.Add(oDevice);
                    }
                    db.MW_CustomersVerificationCodes.Remove(db.MW_CustomersVerificationCodes.FirstOrDefault(x => x.CustomerID == CustomerID));
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Register(CustomersModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Customers oCustomer = db.MW_Customers.Where(x => x.ID == oModel.CustomerID).FirstOrDefault();
                if (oCustomer != null)
                {
                    oCustomer.FullName = oModel.FullName;
                    oCustomer.Email = oModel.Email;
                    oCustomer.SubscribedToNewsLetter = oModel.SubscribedToNewsLetter;
                    oCustomer.ApproveToTermsAndConditions = oModel.ApproveToTermsAndConditions;
                    oCustomer.IsProfileCompleted = true;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<CustomersModel> SaveCustomer(CustomersModel oModel, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Customers oCustomer = new MW_Customers();
                if (oModel.CustomerID > 0)
                {
                    oCustomer = db.MW_Customers.FirstOrDefault(x => x.ID == oModel.CustomerID);
                }
                oCustomer.FullName = oModel.FullName;
                oCustomer.DateOfBirth = oModel.DateOfBirth;
                oCustomer.DefaultLanguageID = oModel.DefaultLanguageID;
                oCustomer.Email = oModel.Email;
                oCustomer.Gender = oModel.Gender;
                oCustomer.PhoneCode = oModel.PhoneCode;
                oCustomer.PhoneNumber = oModel.PhoneNumber;
                oCustomer.SubscribedToNewsLetter = oModel.SubscribedToNewsLetter;
                oCustomer.CategoryID = (int)(oModel.CategoryID != null ? oModel.CategoryID : null);
                if (oCustomer.ID == 0)
                {
                    db.MW_Customers.Add(oCustomer);
                }
                db.SaveChanges();

                //MW_CustomersDevices oDevice = db.MW_CustomersDevices.FirstOrDefault(x => x.CustomerID == oCustomer.ID);
                //if (oDevice == null)
                //{
                //    oDevice = new MW_CustomersDevices();
                //}
                //oDevice.ApiToken = GenerateAPIToken();
                //oDevice.DeviceID = oModel.oDevice == null ? "" : oModel.oDevice.DeviceID;
                //oDevice.DevicePlatform = oModel.oDevice == null ? 0 : oModel.oDevice.DevicePlatform;
                //oDevice.DeviceToken = oModel.oDevice == null ? "" : oModel.oDevice.DeviceToken;
                //oDevice.CustomerID = oCustomer.ID;
                //if (oDevice.ID == 0)
                //{
                //    db.MW_CustomersDevices.Add(oDevice);
                //}


                db.SaveChanges();
                return GetCustomers(LanguageID);
            }
        }

        public CustomersModel SaveCustomerAPI(CustomersModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Customers oCustomer = new MW_Customers();
                if (oModel.CustomerID > 0)
                {
                    oCustomer = db.MW_Customers.FirstOrDefault(x => x.ID == oModel.CustomerID);
                }
                oCustomer.FullName = oModel.FullName;
                oCustomer.DateOfBirth = oModel.DateOfBirth;
                oCustomer.DefaultLanguageID = oModel.DefaultLanguageID;
                oCustomer.Email = oModel.Email;
                oCustomer.Gender = oModel.Gender;
                oCustomer.PhoneCode = oModel.PhoneCode;
                oCustomer.PhoneNumber = oModel.PhoneNumber;
                oCustomer.SubscribedToNewsLetter = oModel.SubscribedToNewsLetter;
                if (oCustomer.ID == 0)
                {
                    db.MW_Customers.Add(oCustomer);
                }
                db.SaveChanges();
                MW_CustomersDevices oDevice = db.MW_CustomersDevices.FirstOrDefault(x => x.CustomerID == oCustomer.ID);
                if (oDevice == null)
                {
                    oDevice = new MW_CustomersDevices();
                }

                oDevice.ApiToken = GenerateAPIToken();
                oDevice.DeviceID = oModel.DeviceID;
                oDevice.DevicePlatform = oModel.DevicePlatform;
                oDevice.DeviceToken = oModel.DeviceToken;
                oDevice.CustomerID = oCustomer.ID;
                if (oDevice.ID == 0)
                {
                    db.MW_CustomersDevices.Add(oDevice);
                }
                db.SaveChanges();
                return GetCustomerDetails(oCustomer.ID);
            }
        }

        public static int GetCustomerIDByAPIToken(string Token)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from device in db.MW_CustomersDevices
                        where device.ApiToken == Token
                        select device.CustomerID).FirstOrDefault();
            }
        }

        public CustomersModel GetCustomerDetails(int CustomerID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                CustomersModel oCustomer = (from customer in db.MW_Customers
                                            join device in db.MW_CustomersDevices on customer.ID equals device.CustomerID
                                            where customer.ID == CustomerID
                                            select new CustomersModel()
                                            {
                                                CustomerID = customer.ID,
                                                DateOfBirth = customer.DateOfBirth,
                                                DefaultLanguageID = customer.DefaultLanguageID,
                                                Email = customer.Email,
                                                FullName = customer.FullName,
                                                Gender = customer.Gender,
                                                PhoneCode = customer.PhoneCode,
                                                PhoneNumber = customer.PhoneNumber,
                                                SubscribedToNewsLetter = customer.SubscribedToNewsLetter,
                                                oDevice = new CustomersDevicesModel()
                                                {
                                                    ApiToken = device.ApiToken,
                                                    CustomerDeviceID = device.ID,
                                                    CustomerID = device.CustomerID,
                                                    DevicePlatform = device.DevicePlatform,
                                                    DeviceID = device.DeviceID,
                                                    DeviceToken = device.DeviceToken
                                                }
                                            }).FirstOrDefault();
                if (oCustomer != null)
                {
                    if (!string.IsNullOrEmpty(oCustomer.Email) && !string.IsNullOrEmpty(oCustomer.FullName))
                    {
                        oCustomer.IsProfileCompleted = true;
                    }
                }
                return oCustomer;
            }
        }

        public List<CustomersAddressesModel> GetCustomerAddresses(int CustomerID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from address in db.MW_CustomersAddresses
                        join country in db.MW_Countries on address.CountryID equals country.ID
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID

                        join city in db.MW_Cities on address.CityID equals city.ID
                        join city_loc in db.MW_Cities_Loc on city.ID equals city_loc.CityID

                        join area in db.MW_Areas on address.AreaID equals area.ID
                        join area_loc in db.MW_Areas_Loc on area.ID equals area_loc.AreaID
                        where address.CustomerID == CustomerID && country_loc.LanguageID == LanguageID
                        && city_loc.LanguageID == LanguageID && area_loc.LanguageID == LanguageID
                        && !address.IsDeleted && !area.IsDeleted && !city.IsDeleted && !country.IsDeleted
                        select new CustomersAddressesModel()
                        {
                            AddressID = address.ID,
                            AddressTitle = address.AddressTitle,
                            AreaID = area.ID,
                            AreaName = area_loc.AreaName,
                            AvenueName = address.AvenueName,
                            BlockName = address.BlockName,
                            BuildingName = address.BuildingName,
                            CityID = city.ID,
                            CityName = city_loc.CityName,
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            CustomerID = CustomerID,
                            FloorName = address.FloorName,
                            IsDefault = address.IsDefault,
                            LanguageID = LanguageID,
                            Latitude = address.Latitude,
                            Longitude = address.Longitude,
                            OfficeName = address.OfficeName,
                            OtherNotes = address.OtherNotes,
                            StreetName = address.StreetName
                        }).ToList();
            }
        }

       

        public CustomersWalletsModel GetCustomerWallet(int CustomerID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from wallet in db.MW_CustomersWallets
                        join transaction in db.MW_CustomersWalletsTransactions on wallet.ID equals transaction.WalletID into Transactions
                        from transaction in Transactions.DefaultIfEmpty()
                        where wallet.CustomerID == CustomerID
                        select new
                        {
                            WalletID = wallet.ID,
                            Ballance = wallet.Ballance,
                            TransactionID = transaction != null ? transaction.ID : 0,
                            CredDebitit = transaction != null ? transaction.Credit : 0,
                            Debit = transaction != null ? transaction.Debit : 0,
                            TransactionDate = transaction != null ? transaction.TransactionDate : DateTime.Now,
                            ReferenceType = transaction != null ? transaction.ReferenceType : 0,
                            ReferenceID = transaction != null ? transaction.ReferenceID : 0,
                            Notes = transaction != null ? transaction.Notes : "",

                        }).AsEnumerable().GroupBy(x => x.WalletID).Select(wallet => new CustomersWalletsModel()
                        {
                            Ballance = wallet.FirstOrDefault().Ballance,
                            CustomerID = CustomerID,
                            WalletID = wallet.FirstOrDefault().WalletID,
                            lstTransactions = (from transactions in wallet
                                               where transactions.TransactionID > 0
                                               select new CustomersWalletsTransactionsModel()
                                               {
                                                   TransactionID = transactions.TransactionID,
                                                   Credit = transactions.TransactionID,
                                                   Debit = transactions.Debit,
                                                   Notes = transactions.Notes,
                                                   ReferenceID = transactions.ReferenceID,
                                                   ReferenceType = transactions.ReferenceType,
                                                   TransactionDate = transactions.TransactionDate,
                                                   WalletID = transactions.WalletID
                                               }).ToList()
                        }).FirstOrDefault();
            }
        }

        public CustomersModel GetCustomersFullDetails(int CustomerID, int LanguageID)
        {
            CustomersModel oCustomer = GetCustomerDetails(CustomerID);
            if (oCustomer != null)
            {
                oCustomer.lstAddresses = GetCustomerAddresses(CustomerID, LanguageID);         
                oCustomer.oWallet = GetCustomerWallet(CustomerID);
            }
            return oCustomer;
        }

        public List<CustomersModel> GetCustomers(int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from customer in db.MW_Customers
                        join category in db.MW_Categories on customer.CategoryID equals category.ID
                        join category_loc in db.MW_Categories_Loc on category.ID equals category_loc.CategoryID
                        where category_loc.LanguageID == LanguageID
                        select new CustomersModel()
                        {
                            CustomerID = customer.ID,
                            DateOfBirth = customer.DateOfBirth,
                            DefaultLanguageID = customer.DefaultLanguageID,
                            Email = customer.Email,
                            FullName = customer.FullName,
                            Gender = customer.Gender,
                            PhoneCode = customer.PhoneCode,
                            PhoneNumber = customer.PhoneNumber,
                            SubscribedToNewsLetter = customer.SubscribedToNewsLetter,
                            IsBlocked = customer.IsBlocked,
                            CategoryName = category_loc.Title
                        }).ToList();
            }
        }

        public static string GenerateAPIToken()
        {
            var key = new byte[2048];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            string apiKey = Convert.ToBase64String(key);
            return apiKey;
        }

        public string GenerateActivationCode()
        {
            Random random = new Random();
            string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool CheckEmail(CustomersModel oCustomer)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                if (oCustomer.CustomerID == 0)
                {
                    return !db.MW_Customers.Any(x => x.Email == oCustomer.Email);
                }
                else
                {
                    return !db.MW_Customers.Any(x => x.Email == oCustomer.Email && x.ID != oCustomer.CustomerID);
                }
            }
        }

        public bool CheckPhoneNumber(CustomersModel oCustomer)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                if (oCustomer.CustomerID == 0)
                {
                    return !db.MW_Customers.Any(x => x.PhoneCode == oCustomer.PhoneCode && x.PhoneNumber == oCustomer.PhoneNumber);
                }
                else
                {
                    return !db.MW_Customers.Any(x => x.PhoneCode == oCustomer.PhoneCode && x.PhoneNumber == oCustomer.PhoneNumber && x.ID != oCustomer.CustomerID);
                }
            }
        }

        public List<CustomersModel> ChangeStatus(int CustomerID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Customers customer = db.MW_Customers.Where(x => x.ID == CustomerID).FirstOrDefault();
                if (customer != null)
                {
                    customer.IsBlocked = customer.IsBlocked == true ? false : true;
                    db.SaveChanges();
                }
                return GetCustomers(LanguageID);
            }
        }

      

     

        public List<CustomersAddressesModel> SaveCustomerAddress(CustomersAddressesModel oModel, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CustomersAddresses oCustomerAddress = new MW_CustomersAddresses();
                if (oModel.AddressID > 0)
                {
                    oCustomerAddress = db.MW_CustomersAddresses.FirstOrDefault(x => x.ID == oModel.AddressID);
                }
                MW_Customers oCustomer = db.MW_Customers.FirstOrDefault(x => x.ID == oModel.CustomerID);
                oCustomerAddress.AddressTitle = oModel.AddressTitle;
                oCustomerAddress.AreaID = oModel.AreaID;
                oCustomerAddress.BlockName = oModel.BlockName;
                oCustomerAddress.BuildingName = oModel.BuildingName;
                oCustomerAddress.CityID = oModel.CityID;
                oCustomerAddress.CountryID = oModel.CountryID;
                oCustomerAddress.CustomerID = (int)oModel.CustomerID;
                oCustomerAddress.FloorName = oModel.FloorName;
                oCustomerAddress.OfficeName = oModel.OfficeName;
                oCustomerAddress.OtherNotes = oModel.OtherNotes;
                oCustomerAddress.StreetName = oModel.StreetName;
                oCustomerAddress.IsDefault = oModel.IsDefault;
                oCustomerAddress.AvenueName = oModel.AvenueName;
                if (oModel.AddressID <= 0)
                {
                    db.MW_CustomersAddresses.Add(oCustomerAddress);
                }
                db.SaveChanges();
                if (oCustomerAddress.IsDefault)
                {
                    db.MW_CustomersAddresses.Where(x => x.ID != oCustomerAddress.ID && x.CustomerID == oModel.CustomerID).ToList().ForEach(x => x.IsDefault = false);
                    db.SaveChanges();
                }
                return GetCustomerAddresses((int)oModel.CustomerID, LanguageID);
            }
        }

   
        public List<CustomersAddressesModel> DeleteCustomerAddress(int CustomerID, int AddressID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_CustomersAddresses AddressToDelete = db.MW_CustomersAddresses.Where(x => x.ID == AddressID && x.CustomerID == CustomerID).FirstOrDefault();
                if (AddressToDelete != null)
                {
                    AddressToDelete.IsDeleted = true;
                    AddressToDelete.IsDefault = false;
                    db.SaveChanges();
                }
                return GetCustomerAddresses(CustomerID, LanguageID);
            }
        }

        public CustomersAddressesModel GetCustomerAddressDetails(int AddressID, int LanguageID)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                return (from address in db.MW_CustomersAddresses
                        join country in db.MW_Countries on address.CountryID equals country.ID
                        join country_loc in db.MW_Countries_Loc on country.ID equals country_loc.CountryID

                        join city in db.MW_Cities on address.CityID equals city.ID
                        join city_loc in db.MW_Cities_Loc on city.ID equals city_loc.CityID

                        join area in db.MW_Areas on address.AreaID equals area.ID
                        join area_loc in db.MW_Areas_Loc on area.ID equals area_loc.AreaID
                        where address.ID == AddressID && country_loc.LanguageID == LanguageID
                        && city_loc.LanguageID == LanguageID && area_loc.LanguageID == LanguageID
                        && !address.IsDeleted && !area.IsDeleted && !city.IsDeleted && !country.IsDeleted
                        select new CustomersAddressesModel()
                        {
                            AddressID = address.ID,
                            AddressTitle = address.AddressTitle,
                            AreaID = area.ID,
                            AreaName = area_loc.AreaName,
                            AvenueName = address.AvenueName,
                            BlockName = address.BlockName,
                            BuildingName = address.BuildingName,
                            CityID = city.ID,
                            CityName = city_loc.CityName,
                            CountryID = country.ID,
                            CountryName = country_loc.CountryName,
                            CustomerID = address.CustomerID,
                            FloorName = address.FloorName,
                            IsDefault = address.IsDefault,
                            LanguageID = LanguageID,
                            Latitude = address.Latitude,
                            Longitude = address.Longitude,
                            OfficeName = address.OfficeName,
                            OtherNotes = address.OtherNotes,
                            StreetName = address.StreetName
                        }).FirstOrDefault();
            }
        }

    }
}