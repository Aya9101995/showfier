namespace MWCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MW_Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                        AccumulationFactor = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.MW_Areas_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AreaID = c.Int(nullable: false),
                        AreaName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Areas", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.MW_Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        DeliveryCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.MW_Cities_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                        CityName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.MW_Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Flag = c.String(),
                        PhoneCode = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Countries_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        CountryName = c.String(nullable: false),
                        Prefix = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.MW_Banners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MakeID = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                        PlateNumber = c.Int(nullable: false),
                        VehicleTypeID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_CarsModels", t => t.ModelID, cascadeDelete: true)
                .ForeignKey("dbo.MW_VehicleTypes", t => t.VehicleTypeID, cascadeDelete: true)
                .Index(t => t.ModelID)
                .Index(t => t.VehicleTypeID);
            
            CreateTable(
                "dbo.MW_Cars_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CarID = c.Int(nullable: false),
                        languageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Cars", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.MW_CarsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarMakeID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_CarsMakes", t => t.CarMakeID, cascadeDelete: true)
                .Index(t => t.CarMakeID);
            
            CreateTable(
                "dbo.MW_CarsMakes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_CarsMakes_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarMakeID = c.Int(nullable: false),
                        CarMakeName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_CarsMakes", t => t.CarMakeID, cascadeDelete: true)
                .Index(t => t.CarMakeID);
            
            CreateTable(
                "dbo.MW_CarsModels_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarModelID = c.Int(nullable: false),
                        CarModelName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_CarsModels", t => t.CarModelID, cascadeDelete: true)
                .Index(t => t.CarModelID);
            
            CreateTable(
                "dbo.MW_CarsModelsYears",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarModelID = c.Int(nullable: false),
                        RangeFrom = c.Int(nullable: false),
                        RangeTo = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_CarsModels", t => t.CarModelID, cascadeDelete: true)
                .Index(t => t.CarModelID);
            
            CreateTable(
                "dbo.MW_VehicleTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        BaseFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumFare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerMinute = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerKM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerDelayedMinute = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Taxes", t => t.TaxID, cascadeDelete: true)
                .Index(t => t.TaxID);
            
            CreateTable(
                "dbo.MW_Taxes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        TaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Taxes_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaxID = c.Int(nullable: false),
                        TaxName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Taxes", t => t.TaxID, cascadeDelete: true)
                .Index(t => t.TaxID);
            
            CreateTable(
                "dbo.MW_VehicleTypes_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleTypeID = c.Int(nullable: false),
                        VehicleName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_VehicleTypes", t => t.VehicleTypeID, cascadeDelete: true)
                .Index(t => t.VehicleTypeID);
            
            CreateTable(
                "dbo.MW_Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ColorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Colors", t => t.ColorID, cascadeDelete: true)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.MW_Categories_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Title = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.MW_Colors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ColorCode = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Colors_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ColorID = c.Int(nullable: false),
                        ColorName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Colors", t => t.ColorID, cascadeDelete: true)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.MW_ContentPages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_ContentPages_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        PageTitle = c.String(),
                        PageDetails = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_ContentPages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.MW_Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhoneCode = c.String(),
                        PhoneNumber = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        DefaultLanguageID = c.Int(nullable: false),
                        SubscribedToNewsLetter = c.Boolean(nullable: false),
                        ApproveToTermsAndConditions = c.Boolean(nullable: false),
                        IsProfileCompleted = c.Boolean(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_CustomersAddresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                        AddressTitle = c.String(),
                        BlockName = c.String(),
                        StreetName = c.String(),
                        BuildingName = c.String(),
                        FloorName = c.String(),
                        OfficeName = c.String(),
                        AvenueName = c.String(),
                        OtherNotes = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.MW_CustomersDevices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ApiToken = c.String(),
                        DeviceID = c.String(),
                        DeviceToken = c.String(),
                        DevicePlatform = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.MW_CustomersVerificationCodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        VerificationCode = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_CustomersWallets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Ballance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.MW_CustomersWalletsTransactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WalletID = c.Int(nullable: false),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceType = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        Notes = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_CustomersWallets", t => t.WalletID, cascadeDelete: true)
                .Index(t => t.WalletID);
            
            CreateTable(
                "dbo.MW_DriverRejectionReasons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_DriverRejectionReasons_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RejectionReasonID = c.Int(nullable: false),
                        RejectionName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_DriverRejectionReasons", t => t.RejectionReasonID, cascadeDelete: true)
                .Index(t => t.RejectionReasonID);
            
            CreateTable(
                "dbo.MW_EmailSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmailTo = c.String(),
                        OutgoingServer = c.String(),
                        EnableSSL = c.Boolean(),
                        PortID = c.Int(),
                        SenderEmail = c.String(),
                        SenderPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_FAQ",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SortOrder = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_FAQ_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FAQID = c.Int(),
                        FAQQuetion = c.String(nullable: false),
                        FAQAnswer = c.String(nullable: false),
                        LanguageID = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_FAQ", t => t.FAQID)
                .Index(t => t.FAQID);
            
            CreateTable(
                "dbo.MW_Gallery",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GalleryAlbumID = c.Int(nullable: false),
                        FileType = c.Int(nullable: false),
                        FileName = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_GalleryAlbums", t => t.GalleryAlbumID, cascadeDelete: true)
                .Index(t => t.GalleryAlbumID);
            
            CreateTable(
                "dbo.MW_GalleryAlbums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CoverIamge = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_GalleryAlbums_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GalleryAlbumID = c.Int(nullable: false),
                        Title = c.String(),
                        Desc = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_GalleryAlbums", t => t.GalleryAlbumID, cascadeDelete: true)
                .Index(t => t.GalleryAlbumID);
            
            CreateTable(
                "dbo.MW_GroupPlociesPages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                        PageTitle = c.String(),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_GroupPolicies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_GroupPoliciesPermissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        PageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_NewsLettersSubscriptions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsPage = c.Boolean(nullable: false),
                        IsPreDefinedPage = c.Boolean(nullable: false),
                        PageBanner = c.String(),
                        ParentID = c.Int(nullable: false),
                        ShowInMenu = c.Boolean(nullable: false),
                        ShowInFooter = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Pages_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        PageTitle = c.String(),
                        PageName = c.String(),
                        PageTags = c.String(),
                        PageURL = c.String(),
                        PageDetails = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Pages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.MW_PagesKeys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        KeyName = c.String(),
                        KeyType = c.String(),
                        KeySourceID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Pages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.MW_PagesKeys_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KeyID = c.Int(nullable: false),
                        KeyValue = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_PagesKeys", t => t.KeyID, cascadeDelete: true)
                .Index(t => t.KeyID);
            
            CreateTable(
                "dbo.MW_PaymentMethods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentMethodType = c.Int(nullable: false),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_PaymentMethods_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LanguageID = c.Int(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_PaymentMethods", t => t.PaymentMethodID, cascadeDelete: true)
                .Index(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.MW_Sizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Sizes_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SizeID = c.Int(nullable: false),
                        SizeName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Sizes", t => t.SizeID, cascadeDelete: true)
                .Index(t => t.SizeID);
            
            CreateTable(
                "dbo.MW_SocialMedia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SocialMediaType = c.String(nullable: false),
                        SocialMediaLink = c.String(nullable: false),
                        SocialMediaIcon = c.String(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        SortOrder = c.Int(nullable: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_StatusManager",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusForID = c.Int(nullable: false),
                        StatusNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_StatusManager_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusManagerID = c.Int(nullable: false),
                        StatusTitle = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_StatusManager", t => t.StatusManagerID, cascadeDelete: true)
                .Index(t => t.StatusManagerID);
            
            CreateTable(
                "dbo.MW_SystemLanguages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                        LanguageCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_SystemSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Tutorials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Tutorials_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TutorialID = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Tutorials", t => t.TutorialID, cascadeDelete: true)
                .Index(t => t.TutorialID);
            
            CreateTable(
                "dbo.MW_UserRejectionReasons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_UserRejectionReasons_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RejectionReasonID = c.Int(nullable: false),
                        RejectionName = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_UserRejectionReasons", t => t.RejectionReasonID, cascadeDelete: true)
                .Index(t => t.RejectionReasonID);
            
            CreateTable(
                "dbo.MW_Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(),
                        Mobile = c.String(nullable: false),
                        Username = c.String(),
                        Password = c.String(nullable: false),
                        UserImage = c.String(nullable: false),
                        PolicyGroupID = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CanPublish = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UsernameOrder = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_GroupPolicies", t => t.PolicyGroupID, cascadeDelete: true)
                .Index(t => t.PolicyGroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MW_Users", "PolicyGroupID", "dbo.MW_GroupPolicies");
            DropForeignKey("dbo.MW_UserRejectionReasons_Loc", "RejectionReasonID", "dbo.MW_UserRejectionReasons");
            DropForeignKey("dbo.MW_Tutorials_Loc", "TutorialID", "dbo.MW_Tutorials");
            DropForeignKey("dbo.MW_StatusManager_Loc", "StatusManagerID", "dbo.MW_StatusManager");
            DropForeignKey("dbo.MW_Sizes_Loc", "SizeID", "dbo.MW_Sizes");
            DropForeignKey("dbo.MW_PaymentMethods_Loc", "PaymentMethodID", "dbo.MW_PaymentMethods");
            DropForeignKey("dbo.MW_PagesKeys_Loc", "KeyID", "dbo.MW_PagesKeys");
            DropForeignKey("dbo.MW_PagesKeys", "PageID", "dbo.MW_Pages");
            DropForeignKey("dbo.MW_Pages_Loc", "PageID", "dbo.MW_Pages");
            DropForeignKey("dbo.MW_GalleryAlbums_Loc", "GalleryAlbumID", "dbo.MW_GalleryAlbums");
            DropForeignKey("dbo.MW_Gallery", "GalleryAlbumID", "dbo.MW_GalleryAlbums");
            DropForeignKey("dbo.MW_FAQ_Loc", "FAQID", "dbo.MW_FAQ");
            DropForeignKey("dbo.MW_DriverRejectionReasons_Loc", "RejectionReasonID", "dbo.MW_DriverRejectionReasons");
            DropForeignKey("dbo.MW_CustomersWalletsTransactions", "WalletID", "dbo.MW_CustomersWallets");
            DropForeignKey("dbo.MW_CustomersWallets", "CustomerID", "dbo.MW_Customers");
            DropForeignKey("dbo.MW_CustomersDevices", "CustomerID", "dbo.MW_Customers");
            DropForeignKey("dbo.MW_CustomersAddresses", "CustomerID", "dbo.MW_Customers");
            DropForeignKey("dbo.MW_ContentPages_Loc", "PageID", "dbo.MW_ContentPages");
            DropForeignKey("dbo.MW_Categories", "ColorID", "dbo.MW_Colors");
            DropForeignKey("dbo.MW_Colors_Loc", "ColorID", "dbo.MW_Colors");
            DropForeignKey("dbo.MW_Categories_Loc", "CategoryID", "dbo.MW_Categories");
            DropForeignKey("dbo.MW_Cars", "VehicleTypeID", "dbo.MW_VehicleTypes");
            DropForeignKey("dbo.MW_VehicleTypes_Loc", "VehicleTypeID", "dbo.MW_VehicleTypes");
            DropForeignKey("dbo.MW_VehicleTypes", "TaxID", "dbo.MW_Taxes");
            DropForeignKey("dbo.MW_Taxes_Loc", "TaxID", "dbo.MW_Taxes");
            DropForeignKey("dbo.MW_Cars", "ModelID", "dbo.MW_CarsModels");
            DropForeignKey("dbo.MW_CarsModelsYears", "CarModelID", "dbo.MW_CarsModels");
            DropForeignKey("dbo.MW_CarsModels_Loc", "CarModelID", "dbo.MW_CarsModels");
            DropForeignKey("dbo.MW_CarsModels", "CarMakeID", "dbo.MW_CarsMakes");
            DropForeignKey("dbo.MW_CarsMakes_Loc", "CarMakeID", "dbo.MW_CarsMakes");
            DropForeignKey("dbo.MW_Cars_Loc", "CarID", "dbo.MW_Cars");
            DropForeignKey("dbo.MW_Areas", "CityID", "dbo.MW_Cities");
            DropForeignKey("dbo.MW_Countries_Loc", "CountryID", "dbo.MW_Countries");
            DropForeignKey("dbo.MW_Cities", "CountryID", "dbo.MW_Countries");
            DropForeignKey("dbo.MW_Cities_Loc", "CityID", "dbo.MW_Cities");
            DropForeignKey("dbo.MW_Areas_Loc", "AreaID", "dbo.MW_Areas");
            DropIndex("dbo.MW_Users", new[] { "PolicyGroupID" });
            DropIndex("dbo.MW_UserRejectionReasons_Loc", new[] { "RejectionReasonID" });
            DropIndex("dbo.MW_Tutorials_Loc", new[] { "TutorialID" });
            DropIndex("dbo.MW_StatusManager_Loc", new[] { "StatusManagerID" });
            DropIndex("dbo.MW_Sizes_Loc", new[] { "SizeID" });
            DropIndex("dbo.MW_PaymentMethods_Loc", new[] { "PaymentMethodID" });
            DropIndex("dbo.MW_PagesKeys_Loc", new[] { "KeyID" });
            DropIndex("dbo.MW_PagesKeys", new[] { "PageID" });
            DropIndex("dbo.MW_Pages_Loc", new[] { "PageID" });
            DropIndex("dbo.MW_GalleryAlbums_Loc", new[] { "GalleryAlbumID" });
            DropIndex("dbo.MW_Gallery", new[] { "GalleryAlbumID" });
            DropIndex("dbo.MW_FAQ_Loc", new[] { "FAQID" });
            DropIndex("dbo.MW_DriverRejectionReasons_Loc", new[] { "RejectionReasonID" });
            DropIndex("dbo.MW_CustomersWalletsTransactions", new[] { "WalletID" });
            DropIndex("dbo.MW_CustomersWallets", new[] { "CustomerID" });
            DropIndex("dbo.MW_CustomersDevices", new[] { "CustomerID" });
            DropIndex("dbo.MW_CustomersAddresses", new[] { "CustomerID" });
            DropIndex("dbo.MW_ContentPages_Loc", new[] { "PageID" });
            DropIndex("dbo.MW_Colors_Loc", new[] { "ColorID" });
            DropIndex("dbo.MW_Categories_Loc", new[] { "CategoryID" });
            DropIndex("dbo.MW_Categories", new[] { "ColorID" });
            DropIndex("dbo.MW_VehicleTypes_Loc", new[] { "VehicleTypeID" });
            DropIndex("dbo.MW_Taxes_Loc", new[] { "TaxID" });
            DropIndex("dbo.MW_VehicleTypes", new[] { "TaxID" });
            DropIndex("dbo.MW_CarsModelsYears", new[] { "CarModelID" });
            DropIndex("dbo.MW_CarsModels_Loc", new[] { "CarModelID" });
            DropIndex("dbo.MW_CarsMakes_Loc", new[] { "CarMakeID" });
            DropIndex("dbo.MW_CarsModels", new[] { "CarMakeID" });
            DropIndex("dbo.MW_Cars_Loc", new[] { "CarID" });
            DropIndex("dbo.MW_Cars", new[] { "VehicleTypeID" });
            DropIndex("dbo.MW_Cars", new[] { "ModelID" });
            DropIndex("dbo.MW_Countries_Loc", new[] { "CountryID" });
            DropIndex("dbo.MW_Cities_Loc", new[] { "CityID" });
            DropIndex("dbo.MW_Cities", new[] { "CountryID" });
            DropIndex("dbo.MW_Areas_Loc", new[] { "AreaID" });
            DropIndex("dbo.MW_Areas", new[] { "CityID" });
            DropTable("dbo.MW_Users");
            DropTable("dbo.MW_UserRejectionReasons_Loc");
            DropTable("dbo.MW_UserRejectionReasons");
            DropTable("dbo.MW_Tutorials_Loc");
            DropTable("dbo.MW_Tutorials");
            DropTable("dbo.MW_SystemSettings");
            DropTable("dbo.MW_SystemLanguages");
            DropTable("dbo.MW_StatusManager_Loc");
            DropTable("dbo.MW_StatusManager");
            DropTable("dbo.MW_SocialMedia");
            DropTable("dbo.MW_Sizes_Loc");
            DropTable("dbo.MW_Sizes");
            DropTable("dbo.MW_PaymentMethods_Loc");
            DropTable("dbo.MW_PaymentMethods");
            DropTable("dbo.MW_PagesKeys_Loc");
            DropTable("dbo.MW_PagesKeys");
            DropTable("dbo.MW_Pages_Loc");
            DropTable("dbo.MW_Pages");
            DropTable("dbo.MW_NewsLettersSubscriptions");
            DropTable("dbo.MW_GroupPoliciesPermissions");
            DropTable("dbo.MW_GroupPolicies");
            DropTable("dbo.MW_GroupPlociesPages");
            DropTable("dbo.MW_GalleryAlbums_Loc");
            DropTable("dbo.MW_GalleryAlbums");
            DropTable("dbo.MW_Gallery");
            DropTable("dbo.MW_FAQ_Loc");
            DropTable("dbo.MW_FAQ");
            DropTable("dbo.MW_EmailSettings");
            DropTable("dbo.MW_DriverRejectionReasons_Loc");
            DropTable("dbo.MW_DriverRejectionReasons");
            DropTable("dbo.MW_CustomersWalletsTransactions");
            DropTable("dbo.MW_CustomersWallets");
            DropTable("dbo.MW_CustomersVerificationCodes");
            DropTable("dbo.MW_CustomersDevices");
            DropTable("dbo.MW_CustomersAddresses");
            DropTable("dbo.MW_Customers");
            DropTable("dbo.MW_ContentPages_Loc");
            DropTable("dbo.MW_ContentPages");
            DropTable("dbo.MW_Colors_Loc");
            DropTable("dbo.MW_Colors");
            DropTable("dbo.MW_Categories_Loc");
            DropTable("dbo.MW_Categories");
            DropTable("dbo.MW_VehicleTypes_Loc");
            DropTable("dbo.MW_Taxes_Loc");
            DropTable("dbo.MW_Taxes");
            DropTable("dbo.MW_VehicleTypes");
            DropTable("dbo.MW_CarsModelsYears");
            DropTable("dbo.MW_CarsModels_Loc");
            DropTable("dbo.MW_CarsMakes_Loc");
            DropTable("dbo.MW_CarsMakes");
            DropTable("dbo.MW_CarsModels");
            DropTable("dbo.MW_Cars_Loc");
            DropTable("dbo.MW_Cars");
            DropTable("dbo.MW_Banners");
            DropTable("dbo.MW_Countries_Loc");
            DropTable("dbo.MW_Countries");
            DropTable("dbo.MW_Cities_Loc");
            DropTable("dbo.MW_Cities");
            DropTable("dbo.MW_Areas_Loc");
            DropTable("dbo.MW_Areas");
        }
    }
}
