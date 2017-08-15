﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CompanyCaptureDBEntities2 : DbContext
    {
        public CompanyCaptureDBEntities2()
            : base("name=CompanyCaptureDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BusinessSector_tbl> BusinessSector_tbl { get; set; }
        public virtual DbSet<CompanyName_tbl> CompanyName_tbl { get; set; }
        public virtual DbSet<CompanyType_tbl> CompanyType_tbl { get; set; }
        public virtual DbSet<Country_tbl> Country_tbl { get; set; }
        public virtual DbSet<Exchange_tbl> Exchange_tbl { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User_tbl> User_tbl { get; set; }
    
        public virtual int deleteCompanyName(string companyName)
        {
            var companyNameParameter = companyName != null ?
                new ObjectParameter("companyName", companyName) :
                new ObjectParameter("companyName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteCompanyName", companyNameParameter);
        }
    
        public virtual int insertBusinessSector(string businessSectorDesc)
        {
            var businessSectorDescParameter = businessSectorDesc != null ?
                new ObjectParameter("businessSectorDesc", businessSectorDesc) :
                new ObjectParameter("businessSectorDesc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertBusinessSector", businessSectorDescParameter);
        }
    
        public virtual int insertCompany(string companyName, string shortCode, string corpInfo, Nullable<System.DateTime> updateDate, Nullable<int> countryID, string exchangeCodeID, Nullable<int> companyTypeID, Nullable<int> businessSectorID)
        {
            var companyNameParameter = companyName != null ?
                new ObjectParameter("companyName", companyName) :
                new ObjectParameter("companyName", typeof(string));
    
            var shortCodeParameter = shortCode != null ?
                new ObjectParameter("shortCode", shortCode) :
                new ObjectParameter("shortCode", typeof(string));
    
            var corpInfoParameter = corpInfo != null ?
                new ObjectParameter("corpInfo", corpInfo) :
                new ObjectParameter("corpInfo", typeof(string));
    
            var updateDateParameter = updateDate.HasValue ?
                new ObjectParameter("updateDate", updateDate) :
                new ObjectParameter("updateDate", typeof(System.DateTime));
    
            var countryIDParameter = countryID.HasValue ?
                new ObjectParameter("countryID", countryID) :
                new ObjectParameter("countryID", typeof(int));
    
            var exchangeCodeIDParameter = exchangeCodeID != null ?
                new ObjectParameter("exchangeCodeID", exchangeCodeID) :
                new ObjectParameter("exchangeCodeID", typeof(string));
    
            var companyTypeIDParameter = companyTypeID.HasValue ?
                new ObjectParameter("companyTypeID", companyTypeID) :
                new ObjectParameter("companyTypeID", typeof(int));
    
            var businessSectorIDParameter = businessSectorID.HasValue ?
                new ObjectParameter("businessSectorID", businessSectorID) :
                new ObjectParameter("businessSectorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertCompany", companyNameParameter, shortCodeParameter, corpInfoParameter, updateDateParameter, countryIDParameter, exchangeCodeIDParameter, companyTypeIDParameter, businessSectorIDParameter);
        }
    
        public virtual int insertCompanyName(string companyName, string shortCode, string corpInfo, Nullable<int> countryID, string exchangeCodeID, Nullable<int> companyTypeID, Nullable<int> businessSectorID)
        {
            var companyNameParameter = companyName != null ?
                new ObjectParameter("companyName", companyName) :
                new ObjectParameter("companyName", typeof(string));
    
            var shortCodeParameter = shortCode != null ?
                new ObjectParameter("shortCode", shortCode) :
                new ObjectParameter("shortCode", typeof(string));
    
            var corpInfoParameter = corpInfo != null ?
                new ObjectParameter("corpInfo", corpInfo) :
                new ObjectParameter("corpInfo", typeof(string));
    
            var countryIDParameter = countryID.HasValue ?
                new ObjectParameter("countryID", countryID) :
                new ObjectParameter("countryID", typeof(int));
    
            var exchangeCodeIDParameter = exchangeCodeID != null ?
                new ObjectParameter("exchangeCodeID", exchangeCodeID) :
                new ObjectParameter("exchangeCodeID", typeof(string));
    
            var companyTypeIDParameter = companyTypeID.HasValue ?
                new ObjectParameter("companyTypeID", companyTypeID) :
                new ObjectParameter("companyTypeID", typeof(int));
    
            var businessSectorIDParameter = businessSectorID.HasValue ?
                new ObjectParameter("businessSectorID", businessSectorID) :
                new ObjectParameter("businessSectorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertCompanyName", companyNameParameter, shortCodeParameter, corpInfoParameter, countryIDParameter, exchangeCodeIDParameter, companyTypeIDParameter, businessSectorIDParameter);
        }
    
        public virtual int insertCompanyType(string companyTypeDesc)
        {
            var companyTypeDescParameter = companyTypeDesc != null ?
                new ObjectParameter("companyTypeDesc", companyTypeDesc) :
                new ObjectParameter("companyTypeDesc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertCompanyType", companyTypeDescParameter);
        }
    
        public virtual int insertCountry(string countryName, string countryCode, string currenctDesc)
        {
            var countryNameParameter = countryName != null ?
                new ObjectParameter("countryName", countryName) :
                new ObjectParameter("countryName", typeof(string));
    
            var countryCodeParameter = countryCode != null ?
                new ObjectParameter("countryCode", countryCode) :
                new ObjectParameter("countryCode", typeof(string));
    
            var currenctDescParameter = currenctDesc != null ?
                new ObjectParameter("currenctDesc", currenctDesc) :
                new ObjectParameter("currenctDesc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertCountry", countryNameParameter, countryCodeParameter, currenctDescParameter);
        }
    
        public virtual int insertExchange(string exchangeCodeID, string exchangeName, Nullable<int> countryID)
        {
            var exchangeCodeIDParameter = exchangeCodeID != null ?
                new ObjectParameter("exchangeCodeID", exchangeCodeID) :
                new ObjectParameter("exchangeCodeID", typeof(string));
    
            var exchangeNameParameter = exchangeName != null ?
                new ObjectParameter("exchangeName", exchangeName) :
                new ObjectParameter("exchangeName", typeof(string));
    
            var countryIDParameter = countryID.HasValue ?
                new ObjectParameter("countryID", countryID) :
                new ObjectParameter("countryID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertExchange", exchangeCodeIDParameter, exchangeNameParameter, countryIDParameter);
        }
    
        public virtual ObjectResult<selectAllBusinessSector_Result> selectAllBusinessSector()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectAllBusinessSector_Result>("selectAllBusinessSector");
        }
    
        public virtual ObjectResult<selectAllCompanyName_Result> selectAllCompanyName()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectAllCompanyName_Result>("selectAllCompanyName");
        }
    
        public virtual ObjectResult<selectAllCompanyType_Result> selectAllCompanyType()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectAllCompanyType_Result>("selectAllCompanyType");
        }
    
        public virtual ObjectResult<selectAllCountry_Result> selectAllCountry()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectAllCountry_Result>("selectAllCountry");
        }
    
        public virtual ObjectResult<selectAllExchange_Result> selectAllExchange()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectAllExchange_Result>("selectAllExchange");
        }
    
        public virtual ObjectResult<selectAllUsers_Result> selectAllUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectAllUsers_Result>("selectAllUsers");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int UpdateCompanyName(string companyName, string shortCode, Nullable<int> companyTypeID)
        {
            var companyNameParameter = companyName != null ?
                new ObjectParameter("companyName", companyName) :
                new ObjectParameter("companyName", typeof(string));
    
            var shortCodeParameter = shortCode != null ?
                new ObjectParameter("shortCode", shortCode) :
                new ObjectParameter("shortCode", typeof(string));
    
            var companyTypeIDParameter = companyTypeID.HasValue ?
                new ObjectParameter("companyTypeID", companyTypeID) :
                new ObjectParameter("companyTypeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCompanyName", companyNameParameter, shortCodeParameter, companyTypeIDParameter);
        }
    }
}