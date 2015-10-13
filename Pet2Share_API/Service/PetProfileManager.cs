using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;
using Pet2Share_API.Utility;

namespace Pet2Share_API.Service
{
    public class PetProfileManager
    {
        //Methods to add and edit pet profile
        public Pet pet { get; set; }

        private PetProfileManager()
        {

        }

        public PetProfileManager(int petId)
        {
            this.pet = new Pet(petId);
        }

        public PetProfileManager(Pet pet)
        {
            this.pet = pet;
        }

        public BoolExt UpdateAvatar(string avatarURL)
        {
            return new BoolExt(false);
        }

        public BoolExt ActivateProfile()
        {
            return new BoolExt(false);
        }

        public BoolExt DeactivateProfile(string reason)
        {
            return new BoolExt(false);
        }

        public BoolExt AddProfile()
        {
            return new BoolExt(false);
        }

        public static BoolExt AddProfile(Pet pet)
        {
            return new BoolExt(false);
        }

        public static BoolExt AddProfile(string name, string familyName, int userId, int? petTypeId, DateTime? dob, string profilePicture, string coverPicture, string about, string favFood)
        {
            Pet pet = new Pet();

            pet.Name = string.IsNullOrEmpty(name) ? pet.Name : name;
            pet.FamilyName = string.IsNullOrEmpty(familyName) ? pet.FamilyName : familyName;

            pet.UserId = userId;
            pet.PetTypeId = petTypeId == null ? pet.PetTypeId : petTypeId;
            pet.DOB = dob == null ? pet.DOB : dob;
            pet.ProfilePicture = string.IsNullOrEmpty(profilePicture) ? pet.ProfilePicture : profilePicture;
            pet.CoverPicture = string.IsNullOrEmpty(coverPicture) ? pet.CoverPicture : coverPicture;
            pet.About = string.IsNullOrEmpty(about) ? pet.About : about;
            pet.FavFood = string.IsNullOrEmpty(favFood) ? pet.FavFood : favFood;

            int result = pet.Save();
            if (result > 0)
                return new BoolExt(true, "");
            else
                return new BoolExt(false, "Update Failed, Please check application logs for more details");
        }

        public BoolExt UpdateProfile()
        {
            return new BoolExt(false);
        }

        public static BoolExt UpdateProfile(Pet pet)
        {
            return new BoolExt(false);
        }

        public static BoolExt UpdateProfile(int petId, string name, string familyName, int userId, int? petTypeId, DateTime? dob, string profilePicture, string coverPicture, string about, string favFood)
        {
            Pet pet = new Pet(petId);

            pet.Name = string.IsNullOrEmpty(name) ? pet.Name : name;
            pet.FamilyName = string.IsNullOrEmpty(familyName) ? pet.FamilyName : familyName;

            pet.UserId = userId;
            pet.PetTypeId = petTypeId == null ? pet.PetTypeId : petTypeId;
            pet.DOB = dob == null ? pet.DOB : dob;
            pet.ProfilePicture = string.IsNullOrEmpty(profilePicture) ? pet.ProfilePicture : profilePicture;
            pet.CoverPicture = string.IsNullOrEmpty(coverPicture) ? pet.CoverPicture : coverPicture;
            pet.About = string.IsNullOrEmpty(about) ? pet.About : about;
            pet.FavFood = string.IsNullOrEmpty(favFood) ? pet.FavFood : favFood;

            int result = pet.Save();
            if (result == petId)
                return new BoolExt(true, "");
            else
                return new BoolExt(false, "Update Failed, Please check application logs for more details");

        }

        public BoolExt UpdateProfilePicture(Byte[] binaryImage, string filename, ImageType imageType)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + pet.UserId + "/" + pet.Id;
            fullFileName = pet.UserId.ToString() + "_" + pet.Id.ToString() + "_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            this.pet.ProfilePicture = relativePath + "/" + filename;
            this.pet.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }

        public static BoolExt UpdateProfilePicture(Byte[] binaryImage, string filename, ImageType imageType, int petId)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            Pet pet = new Pet(petId);

            relativePath = "/" + pet.UserId + "/" + pet.Id;
            fullFileName = pet.UserId.ToString() + "_" + pet.Id.ToString() + "_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            pet.ProfilePicture = relativePath + "/" + filename;
            pet.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }

        public BoolExt UpdateCoverPicture(Byte[] binaryImage, string filename, ImageType imageType)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + pet.UserId + "/" + pet.Id;
            fullFileName = pet.UserId.ToString() + "_" + pet.Id.ToString() + "_cover_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            this.pet.CoverPicture = relativePath + "/" + filename;
            this.pet.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }

        public static BoolExt UpdateCoverPicture(Byte[] binaryImage, string filename, ImageType imageType, int petId)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            Pet pet = new Pet(petId);

            relativePath = "/" + pet.UserId + "/" + pet.Id;
            fullFileName = pet.UserId.ToString() + "_" + pet.Id.ToString() + "_cover_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            pet.CoverPicture = relativePath + "/" + filename;
            pet.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }
    }
}
