using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    public class PostType
    {
        #region members
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        public PostType(string name)
        {
            this.Name = name;
            this.DateAdded = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }
    }

    public class Comment
    {
        #region members
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public int CommentedBy { get; set; }
        [DataMember]
        public bool IsCommentedByPet { get; set; }
        [DataMember]
        public string Comment { get; set; }        
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        #endregion

        #region Constructors

        private Comment()
        {
            this.Id = 0;
            this.DateAdded = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }

        public Comment(int postId, int commenterId, bool isCommentedByPet, string comment) : base()
        {
            this.PostId = postId;
            this.CommentedBy = posterId;
            this.IsCommentedByPet = isPosterPet;
            this.Comment = comment;
        }

        #endregion
    }

    public class Post
    {
        #region members
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PostTypeId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int PostedBy { get; set; }
        [DataMember]
        public bool IsPostByPet { get; set; }
        [DataMember]
        public int PostLikeCount { get; set; }
        [DataMember]
        public int[] PostLikedBy { get; set; }
        [DataMember]
        public int PostCommentCount { get; set; }
        [DataMember]
        public Comment[] Comments { get; set; }
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

        private Post()
        {
            this.Id = 0;
            this.Description = "Please post something!";
            this.PostLikeCount = 0;
            this.PostLikedBy = new int[] { };
            this.PostCommentCount = 0;
            this.Comments = new Comment[] { };
            this.DateAdded = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }

        public Post(string description, int postedBy, bool isPostByPet) : base()
        {
            this.Description = description;
            this.PostedBy = postedBy;
            this.IsPostByPet = isPostByPet;
        }

        public Post(int postId) : base()
        {
            Post post = Post.GetById(postId);
            this.Id = post.Id;
            this.PostTypeId = post.PostTypeId;
            this.Description = post.Description;
            this.PostedBy = post.PostedBy;
            this.IsPostByPet = post.IsPostByPet;
            this.PostLikeCount = post.PostLikeCount;
            this.PostCommentCount = post.PostCommentCount;
            this.DateAdded = post.DateAdded;
            this.DateModified = post.DateModified;
            this.IsActive = post.IsActive;
            this.IsDeleted = post.IsDeleted;
        }

        public Post(Post post) : base()
        {
            this.Id = post.Id;
            this.PostTypeId = post.PostTypeId;
            this.Description = post.Description;
            this.PostedBy = post.PostedBy;
            this.IsPostByPet = post.IsPostByPet;
            this.PostLikeCount = post.PostLikeCount;
            this.PostCommentCount = post.PostCommentCount;
            this.DateAdded = post.DateAdded;
            this.DateModified = post.DateModified;
            this.IsActive = post.IsActive;
            this.IsDeleted = post.IsDeleted;
        }

        public Post(DAL.Post post) : base()
        {
            this.Id = post.ID;
            this.PostTypeId = post.PostTypeID;
            this.Description = post.Description;
            this.PostedBy = post.PostedBy;
            this.IsPostByPet = post.IsPostByPet;
            this.PostLikeCount = post.PostLikeCount;
            this.PostCommentCount = post.PostCommentCount;
            this.DateAdded = post.DateAdded;
            this.DateModified = post.DateModified;
            this.IsActive = post.IsActive;
            this.IsDeleted = post.IsDeleted;
        }

        public Post(string description, int postedById, bool isPostByPet, int postTypeId) : base()
        {
            this.PostTypeId = postTypeId;
            this.Description = description;
            this.PostedBy = postedById;
            this.IsPostByPet = isPostByPet;
        }

        #endregion

        #region methods

        public static Post GetById(int id)
        {
            DAL.Post postObj;
            using(DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                postObj = context.Posts.Where(post => post.Id == id).FirstOrDefault();
            }
            if (postObj != null)
            {
                Post post = new Post(postObj);
                return post;
            }
            return new Post();
        }

        public static bool Validate(Post post)
        {
            if (string.IsNullOrEmpty(post.Description) || post.PostedBy <= 0 || post.PostTypeId <= 0)
                return false;
            else
                return true;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.Description) || this.PostedBy == null || this.PostTypeId <= 0)
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
                    result = Convert.ToInt32(context.InsertUpdatePost(this.Id, this.Name, this.FamilyName, this.UserId, this.PetTypeId, this.DOB, this.ProfilePicture, this.About, this.CoverPicture, this.FavFood).FirstOrDefault());
                    if (result > 0)
                        this.Id = result;
                }
            }
            return result;
        }

        public static int Save(Post post)
        {
            int result = -1;

            if (Validate(post))
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
