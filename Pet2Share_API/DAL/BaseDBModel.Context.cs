﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet2Share_API.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Pet2ShareEntities : DbContext
    {
        public Pet2ShareEntities()
            : base("name=Pet2ShareEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BreedType> BreedTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PetProfile> PetProfiles { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<SocialMediaSource> SocialMediaSources { get; set; }
        public DbSet<User> Users { get; set; }
    
        public virtual int ChangeActivePetProfileById(Nullable<int> id, Nullable<bool> active)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeActivePetProfileById", idParameter, activeParameter);
        }
    
        public virtual int ChangeActiveStatusbyPersonById(Nullable<int> id, Nullable<bool> active)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeActiveStatusbyPersonById", idParameter, activeParameter);
        }
    
        public virtual int ChangeActiveStatusbyUserId(Nullable<int> id, Nullable<bool> active)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeActiveStatusbyUserId", idParameter, activeParameter);
        }
    
        public virtual int DeleteAddressById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteAddressById", idParameter);
        }
    
        public virtual int DeleteByPersonById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteByPersonById", idParameter);
        }
    
        public virtual int DeletePetProfileById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePetProfileById", idParameter);
        }
    
        public virtual int DeleteUserById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUserById", idParameter);
        }
    
        public virtual ObjectResult<GetAddressById_Result> GetAddressById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAddressById_Result>("GetAddressById", idParameter);
        }
    
        public virtual ObjectResult<GetPersonById_Result> GetPersonById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPersonById_Result>("GetPersonById", idParameter);
        }
    
        public virtual ObjectResult<GetPetProfileById_Result> GetPetProfileById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPetProfileById_Result>("GetPetProfileById", idParameter);
        }
    
        public virtual int InsertUpdateAddress(Nullable<int> id, string addressLine1, string addressLine2, string city, string state, string country, Nullable<bool> isBillingAddress, Nullable<bool> isShippingAddress, string zipCode)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var addressLine1Parameter = addressLine1 != null ?
                new ObjectParameter("AddressLine1", addressLine1) :
                new ObjectParameter("AddressLine1", typeof(string));
    
            var addressLine2Parameter = addressLine2 != null ?
                new ObjectParameter("AddressLine2", addressLine2) :
                new ObjectParameter("AddressLine2", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            var isBillingAddressParameter = isBillingAddress.HasValue ?
                new ObjectParameter("IsBillingAddress", isBillingAddress) :
                new ObjectParameter("IsBillingAddress", typeof(bool));
    
            var isShippingAddressParameter = isShippingAddress.HasValue ?
                new ObjectParameter("IsShippingAddress", isShippingAddress) :
                new ObjectParameter("IsShippingAddress", typeof(bool));
    
            var zipCodeParameter = zipCode != null ?
                new ObjectParameter("ZipCode", zipCode) :
                new ObjectParameter("ZipCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUpdateAddress", idParameter, addressLine1Parameter, addressLine2Parameter, cityParameter, stateParameter, countryParameter, isBillingAddressParameter, isShippingAddressParameter, zipCodeParameter);
        }
    
        public virtual int InsertUpdatePerson(Nullable<int> id, string firstName, string lastName, string email, Nullable<System.DateTime> dOB, Nullable<int> addressId, string primaryPhone, string secondaryPhone, string avatar, string aboutMe)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var addressIdParameter = addressId.HasValue ?
                new ObjectParameter("AddressId", addressId) :
                new ObjectParameter("AddressId", typeof(int));
    
            var primaryPhoneParameter = primaryPhone != null ?
                new ObjectParameter("PrimaryPhone", primaryPhone) :
                new ObjectParameter("PrimaryPhone", typeof(string));
    
            var secondaryPhoneParameter = secondaryPhone != null ?
                new ObjectParameter("SecondaryPhone", secondaryPhone) :
                new ObjectParameter("SecondaryPhone", typeof(string));
    
            var avatarParameter = avatar != null ?
                new ObjectParameter("Avatar", avatar) :
                new ObjectParameter("Avatar", typeof(string));
    
            var aboutMeParameter = aboutMe != null ?
                new ObjectParameter("AboutMe", aboutMe) :
                new ObjectParameter("AboutMe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUpdatePerson", idParameter, firstNameParameter, lastNameParameter, emailParameter, dOBParameter, addressIdParameter, primaryPhoneParameter, secondaryPhoneParameter, avatarParameter, aboutMeParameter);
        }
    
        public virtual int InsertUpdatePetProfile(Nullable<int> id, string name, string familyName, Nullable<int> userId, Nullable<int> petTypeId, Nullable<System.DateTime> dOB, string profilePicture, string about, string coverpic, string fevfood)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var familyNameParameter = familyName != null ?
                new ObjectParameter("FamilyName", familyName) :
                new ObjectParameter("FamilyName", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var petTypeIdParameter = petTypeId.HasValue ?
                new ObjectParameter("PetTypeId", petTypeId) :
                new ObjectParameter("PetTypeId", typeof(int));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var profilePictureParameter = profilePicture != null ?
                new ObjectParameter("ProfilePicture", profilePicture) :
                new ObjectParameter("ProfilePicture", typeof(string));
    
            var aboutParameter = about != null ?
                new ObjectParameter("About", about) :
                new ObjectParameter("About", typeof(string));
    
            var coverpicParameter = coverpic != null ?
                new ObjectParameter("coverpic", coverpic) :
                new ObjectParameter("coverpic", typeof(string));
    
            var fevfoodParameter = fevfood != null ?
                new ObjectParameter("fevfood", fevfood) :
                new ObjectParameter("fevfood", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUpdatePetProfile", idParameter, nameParameter, familyNameParameter, userIdParameter, petTypeIdParameter, dOBParameter, profilePictureParameter, aboutParameter, coverpicParameter, fevfoodParameter);
        }
    
        public virtual int InsertUpdateUser(Nullable<int> id, string username, string password, Nullable<int> personId, string email, string phone, string alternateEmail, Nullable<int> socialMediaSourceId, string socialMediaId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var personIdParameter = personId.HasValue ?
                new ObjectParameter("PersonId", personId) :
                new ObjectParameter("PersonId", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var alternateEmailParameter = alternateEmail != null ?
                new ObjectParameter("AlternateEmail", alternateEmail) :
                new ObjectParameter("AlternateEmail", typeof(string));
    
            var socialMediaSourceIdParameter = socialMediaSourceId.HasValue ?
                new ObjectParameter("SocialMediaSourceId", socialMediaSourceId) :
                new ObjectParameter("SocialMediaSourceId", typeof(int));
    
            var socialMediaIdParameter = socialMediaId != null ?
                new ObjectParameter("SocialMediaId", socialMediaId) :
                new ObjectParameter("SocialMediaId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUpdateUser", idParameter, usernameParameter, passwordParameter, personIdParameter, emailParameter, phoneParameter, alternateEmailParameter, socialMediaSourceIdParameter, socialMediaIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UserLogin(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UserLogin", usernameParameter, passwordParameter);
        }
    }
}
