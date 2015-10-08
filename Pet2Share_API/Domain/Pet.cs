using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [DataContract]
    public class PetType
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    [DataContract]
    public class Pet
    {
        #region members
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FamilyName { get; set; }
        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public int? PetTypeId { get; set; }
        [DataMember]
        public DateTime? DOB { get; set; }
        [DataMember]
        public string ProfilePicture { get; set; }
        [DataMember]
        public string CoverPicture { get; set; }
        [DataMember]
        public string About { get; set; }
        [DataMember]
        public string FavFood { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region constructors

        public Pet()
        {
            this.Id = -1;
            this.Name = "Pet Guest";
            this.DateAdded = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }

        public Pet(int id) : base()
        {
            Pet pet = Pet.GetById(id);
            this.Name = pet.Name;
            this.FamilyName = pet.FamilyName;
            this.UserId = pet.UserId;
            this.PetTypeId = pet.PetTypeId;
            this.DOB = pet.DOB;
            this.ProfilePicture = pet.ProfilePicture;
            this.CoverPicture = pet.CoverPicture;
            this.About = pet.About;
            this.FavFood = pet.FavFood;
            this.DateAdded = pet.DateAdded;
            this.DateModified = pet.DateModified;
            this.IsActive = pet.IsActive;
            this.IsDeleted = pet.IsDeleted;
        }

        public Pet(Pet pet) : base()
        {
            this.Name = pet.Name;
            this.FamilyName = pet.FamilyName;
            this.UserId = pet.UserId;
            this.PetTypeId = pet.PetTypeId;
            this.DOB = pet.DOB;
            this.ProfilePicture = pet.ProfilePicture;
            this.CoverPicture = pet.CoverPicture;
            this.About = pet.About;
            this.FavFood = pet.FavFood;
            this.DateAdded = pet.DateAdded;
            this.DateModified = pet.DateModified;
            this.IsActive = pet.IsActive;
            this.IsDeleted = pet.IsDeleted;
        }

        public Pet(DAL.PetProfile pet) : base()
        {
            this.Name = pet.Name;
            this.FamilyName = pet.FamilyName;
            this.UserId = pet.UserId;
            this.PetTypeId = pet.PetTypeId;
            this.DOB = pet.DOB;
            this.ProfilePicture = pet.ProfilePicture;
            this.CoverPicture = pet.CoverPicture;
            this.About = pet.About;
            this.FavFood = pet.FavFood;
            this.DateAdded = pet.DateAdded;
            this.DateModified = pet.DateModified;
            this.IsActive = pet.IsActive;
            this.IsDeleted = pet.IsDeleted;
        }

        public Pet(string name, string familyName, int userId, int? petTypeId, DateTime? dob, string profilePicture, string coverPicture, string about, string favFood) : base()
        {
            this.Name = name;
            this.FamilyName = familyName;
            this.UserId = userId;
            this.PetTypeId = petTypeId;
            this.DOB = dob;
            this.ProfilePicture = profilePicture;
            this.CoverPicture = coverPicture;
            this.About = about;
            this.FavFood = favFood;
        }

        #endregion

        #region methods

        public static Pet GetById(int id)
        {
            DAL.PetProfile petObj;
            using(DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                petObj = context.PetProfiles.Where(p => p.Id == id).FirstOrDefault();
            }
            if (petObj != null)
            {
                Pet pet = new Pet(petObj);
                return pet;
            }
            return new Pet();
        }

        public static bool Validate(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name) || pet.UserId == null || pet.UserId <= 0)
                return false;
            else
                return true;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.Name) || this.UserId == null || this.UserId <= 0)
                return false;
            else
                return true;
        }

        public int Save()
        {
            //Check if all the objects in User's object is saved
            int result = -1;

            if (Validate())
            {
                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdatePetProfile(this.Id, this.Name, this.FamilyName, this.UserId, this.PetTypeId, this.DOB, this.ProfilePicture, this.About, this.CoverPicture, this.FavFood).FirstOrDefault());
                    if (result > 0)
                        this.Id = result;
                }
            }
            return result;
        }

        public static int Save(Pet pet)
        {
            int result = -1;

            if (Validate(pet))
            {
                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdatePetProfile(pet.Id, pet.Name, pet.FamilyName, pet.UserId, pet.PetTypeId, pet.DOB, pet.ProfilePicture, pet.About, pet.CoverPicture, pet.FavFood).FirstOrDefault());
                    if (result > 0)
                        pet.Id = result;
                }
            }
            return result;
        }

        public bool Delete()
        {
            int result = -1;
            if (this.Id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeletePetProfileById(this.Id);
                if (result > 0)
                    this.Id = result;
            }
            return result > 0 ? true : false ;
        }

        public static bool DeleteById(int id)
        {
            int result = -1;
            if (id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeletePetProfileById(id);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        #endregion
    }


}
