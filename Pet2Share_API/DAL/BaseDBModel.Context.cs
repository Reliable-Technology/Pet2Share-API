﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet2Share_API.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
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
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<BreedType> BreedTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PetProfile> PetProfiles { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<Post_Upload> Post_Uploads { get; set; }
        public virtual DbSet<PostLike> PostLikes { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; }
        public virtual DbSet<SocialMediaSource> SocialMediaSources { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
    
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
    
        public virtual int DeletePersonById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePersonById", idParameter);
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
    
        public virtual ObjectResult<Nullable<decimal>> InsertUpdateAddress(Nullable<int> id, string addressLine1, string addressLine2, string city, string state, string country, Nullable<bool> isBillingAddress, Nullable<bool> isShippingAddress, string zipCode)
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
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertUpdateAddress", idParameter, addressLine1Parameter, addressLine2Parameter, cityParameter, stateParameter, countryParameter, isBillingAddressParameter, isShippingAddressParameter, zipCodeParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertUpdatePetProfile(Nullable<int> id, string name, string familyName, Nullable<int> userId, Nullable<int> petTypeId, Nullable<System.DateTime> dOB, string profilePicture, string about, string coverPicture, string favFood)
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
    
            var coverPictureParameter = coverPicture != null ?
                new ObjectParameter("CoverPicture", coverPicture) :
                new ObjectParameter("CoverPicture", typeof(string));
    
            var favFoodParameter = favFood != null ?
                new ObjectParameter("FavFood", favFood) :
                new ObjectParameter("FavFood", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertUpdatePetProfile", idParameter, nameParameter, familyNameParameter, userIdParameter, petTypeIdParameter, dOBParameter, profilePictureParameter, aboutParameter, coverPictureParameter, favFoodParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertUpdateUser(Nullable<int> id, string username, string password, Nullable<int> primaryPersonId, string email, string phone, Nullable<int> socialMediaSourceId, string socialMediaUsername)
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
    
            var primaryPersonIdParameter = primaryPersonId.HasValue ?
                new ObjectParameter("PrimaryPersonId", primaryPersonId) :
                new ObjectParameter("PrimaryPersonId", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var socialMediaSourceIdParameter = socialMediaSourceId.HasValue ?
                new ObjectParameter("SocialMediaSourceId", socialMediaSourceId) :
                new ObjectParameter("SocialMediaSourceId", typeof(int));
    
            var socialMediaUsernameParameter = socialMediaUsername != null ?
                new ObjectParameter("SocialMediaUsername", socialMediaUsername) :
                new ObjectParameter("SocialMediaUsername", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertUpdateUser", idParameter, usernameParameter, passwordParameter, primaryPersonIdParameter, emailParameter, phoneParameter, socialMediaSourceIdParameter, socialMediaUsernameParameter);
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
    
        public virtual ObjectResult<GetPetProfileByUserId_Result> GetPetProfileByUserId(Nullable<int> userId, Nullable<int> isActive)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPetProfileByUserId_Result>("GetPetProfileByUserId", userIdParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertUpdatePost(Nullable<int> id, Nullable<int> postTypeId, string description, Nullable<int> postedBy, Nullable<bool> isPostByPet)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var postTypeIdParameter = postTypeId.HasValue ?
                new ObjectParameter("PostTypeId", postTypeId) :
                new ObjectParameter("PostTypeId", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var postedByParameter = postedBy.HasValue ?
                new ObjectParameter("PostedBy", postedBy) :
                new ObjectParameter("PostedBy", typeof(int));
    
            var isPostByPetParameter = isPostByPet.HasValue ?
                new ObjectParameter("IsPostByPet", isPostByPet) :
                new ObjectParameter("IsPostByPet", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertUpdatePost", idParameter, postTypeIdParameter, descriptionParameter, postedByParameter, isPostByPetParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertUpdatePostComment(Nullable<int> id, Nullable<int> postId, Nullable<int> commentedBy, Nullable<bool> isCommentedByPet, string comment)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("PostId", postId) :
                new ObjectParameter("PostId", typeof(int));
    
            var commentedByParameter = commentedBy.HasValue ?
                new ObjectParameter("CommentedBy", commentedBy) :
                new ObjectParameter("CommentedBy", typeof(int));
    
            var isCommentedByPetParameter = isCommentedByPet.HasValue ?
                new ObjectParameter("IsCommentedByPet", isCommentedByPet) :
                new ObjectParameter("IsCommentedByPet", typeof(bool));
    
            var commentParameter = comment != null ?
                new ObjectParameter("Comment", comment) :
                new ObjectParameter("Comment", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertUpdatePostComment", idParameter, postIdParameter, commentedByParameter, isCommentedByPetParameter, commentParameter);
        }
    
        public virtual int DeletePostById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePostById", idParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertUpdatePerson(Nullable<int> id, string firstName, string lastName, string email, string alternateEmail, Nullable<System.DateTime> dOB, Nullable<int> addressId, string primaryPhone, string secondaryPhone, string avatar, string coverPicture, string aboutMe)
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
    
            var alternateEmailParameter = alternateEmail != null ?
                new ObjectParameter("AlternateEmail", alternateEmail) :
                new ObjectParameter("AlternateEmail", typeof(string));
    
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
    
            var coverPictureParameter = coverPicture != null ?
                new ObjectParameter("CoverPicture", coverPicture) :
                new ObjectParameter("CoverPicture", typeof(string));
    
            var aboutMeParameter = aboutMe != null ?
                new ObjectParameter("AboutMe", aboutMe) :
                new ObjectParameter("AboutMe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertUpdatePerson", idParameter, firstNameParameter, lastNameParameter, emailParameter, alternateEmailParameter, dOBParameter, addressIdParameter, primaryPhoneParameter, secondaryPhoneParameter, avatarParameter, coverPictureParameter, aboutMeParameter);
        }
    
        public virtual int DeletePostCommentById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePostCommentById", idParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> ApproveConnection(Nullable<int> id, Nullable<int> aUserId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var aUserIdParameter = aUserId.HasValue ?
                new ObjectParameter("AUserId", aUserId) :
                new ObjectParameter("AUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("ApproveConnection", idParameter, aUserIdParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> DeleteConnection(Nullable<int> iUserId, Nullable<int> aUserId)
        {
            var iUserIdParameter = iUserId.HasValue ?
                new ObjectParameter("IUserId", iUserId) :
                new ObjectParameter("IUserId", typeof(int));
    
            var aUserIdParameter = aUserId.HasValue ?
                new ObjectParameter("AUserId", aUserId) :
                new ObjectParameter("AUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("DeleteConnection", iUserIdParameter, aUserIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertUpdateConnection(Nullable<int> id, Nullable<int> iUserId, Nullable<int> aUserId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var iUserIdParameter = iUserId.HasValue ?
                new ObjectParameter("IUserId", iUserId) :
                new ObjectParameter("IUserId", typeof(int));
    
            var aUserIdParameter = aUserId.HasValue ?
                new ObjectParameter("AUserId", aUserId) :
                new ObjectParameter("AUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertUpdateConnection", idParameter, iUserIdParameter, aUserIdParameter);
        }
    
        public virtual ObjectResult<GetAvailableConnection_Result> GetAvailableConnection(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAvailableConnection_Result>("GetAvailableConnection", userIdParameter);
        }
    
        public virtual ObjectResult<GetMyConnection_Result> GetMyConnection(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMyConnection_Result>("GetMyConnection", userIdParameter);
        }
    }
}
