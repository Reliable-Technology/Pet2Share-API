using Pet2Share_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [DataContract]
    public class PostType : DomainBase
    {
        #region members

        [DataMember]
        public string Name { get; set; }
        
        #endregion

        #region Constructors

        public PostType(int id)
        {
            PostType postType = PostType.GetById(id);
            this.Name = postType.Name;
            this.DateAdded = postType.DateAdded;
            this.DateModified = postType.DateModified;
            this.IsActive = postType.IsActive;
            this.IsDeleted = postType.IsDeleted;
        }

        public PostType(PostType postType)
        {
            this.Name = postType.Name;
            this.DateAdded = postType.DateAdded;
            this.DateModified = postType.DateModified;
            this.IsActive = postType.IsActive;
            this.IsDeleted = postType.IsDeleted;
        }

        public PostType(DAL.PostType postType)
        {
            this.Name = postType.Name;
            this.DateAdded = postType.DateAdded;
            this.DateModified = postType.DateModified;
            this.IsActive = postType.IsActive;
            this.IsDeleted = postType.IsDeleted;
        }

        private PostType(string name)
        {
            this.Id = 0;
            this.Name = name;
            this.DateAdded = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }

        #endregion

        #region Methods

        public static PostType GetById(int id)
        {
            DAL.PostType postTypeObj;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                postTypeObj = context.PostTypes.Where(pt => pt.ID == id).FirstOrDefault();
            }
            if (postTypeObj != null)
            {
                PostType postType = new PostType(postTypeObj);
                return postType;
            }
            return null;
        }

        #endregion
    }

    [DataContract]
    public class Comment : DomainBase
    {
        #region members

        string _commentDescription;

        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public int CommentedBy { get; set; }
        [DataMember]
        public bool IsCommentedByPet { get; set; }
        [DataMember]
        public string CommentDescription
        {
            get { return Uri.UnescapeDataString(_commentDescription); }
            set { _commentDescription = Uri.UnescapeDataString(value); }
        }
        [DataMember]
        public SmallUser SUser { get; set; }

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

        public Comment(DAL.PostComment dalComment) : base()
        {
            this.Id = dalComment.Id;
            this.PostId = dalComment.PostId;
            this.CommentedBy = dalComment.CommentedBy;
            this.IsCommentedByPet = dalComment.IsCommentedByPet;
            this.CommentDescription = dalComment.Comment;
            this.SUser = new SmallUser(CommentedBy);
        }

        public Comment(int postId, int commenterId, bool isCommentedByPet, string comment) : base()
        {
            this.PostId = postId;
            this.CommentedBy = commenterId;
            this.IsCommentedByPet = isCommentedByPet;
            this.CommentDescription = comment;
            this.SUser = new SmallUser(CommentedBy);
        }

        #endregion

        #region methods

        public static Comment GetById(int id)
        {
            DAL.PostComment commentObj;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                commentObj = context.PostComments.Where(c => c.Id == id).FirstOrDefault();
            }
            if (commentObj != null)
            {
                Comment comment = new Comment(commentObj);
                return comment;
            }
            return new Comment();
        }

        internal static bool Validate(Comment comment)
        {
            if (string.IsNullOrEmpty(comment.CommentDescription) || comment.CommentedBy <= 0)
                return false;
            else
                return true;
        }

        internal bool Validate()
        {
            if (string.IsNullOrEmpty(this.CommentDescription) || this.CommentedBy <= 0)
                return false;
            else
                return true;
        }

        internal int Save()
        {
            //Check if all the objects in User's object is saved
            int result = -1;

            if (Validate())
            {
                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdatePostComment(this.Id, this.PostId, this.CommentedBy, this.IsCommentedByPet, this.CommentDescription).FirstOrDefault());
                    if (result > 0)
                        this.Id = result;
                }
            }
            return result;
        }

        internal static int Save(Comment comment)
        {
            int result = -1;

            if (Validate(comment))
            {
                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdatePostComment(comment.Id, comment.PostId, comment.CommentedBy, comment.IsCommentedByPet, comment.CommentDescription).FirstOrDefault());
                    if (result > 0)
                        comment.Id = result;
                }
            }
            return result;
        }

        internal bool Delete()
        {
            int result = -1;
            if (this.Id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeletePostCommentById(this.Id);
                if (result > 0)
                    this.Id = result;
            }
            return result > 0 ? true : false;
        }

        internal static bool Delete(int id, int userId)
        {
            int result = -1;
            if (id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeleteUserComment(id, userId);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        internal static bool DeleteById(int id)
        {
            int result = -1;
            if (id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeletePostCommentById(id);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        #endregion
    }

    [DataContract]
    public class Post : DomainBase
    {
        #region members
        string _description;

        [DataMember]
        public int PostTypeId { get; set; }
        [DataMember]
        public PostType PType 
        { 
            get
            {
                return new PostType(this.PostTypeId);
            }
            set
            {
                PType = value;
            }
        }
        [DataMember]
        public string Description
        {
            get { return Uri.UnescapeDataString(_description); }
            set { _description = Uri.UnescapeDataString(value); }
        }
        [DataMember]
        public int PostedBy { get; set; }
        [DataMember]
        public bool IsPostByPet { get; set; }
        [DataMember]
        public string PostURL { get; set; }
        [DataMember]
        public int PostLikeCount { get; set; }
        [DataMember]
        public List<int> PostLikedBy { get; set; }
        [DataMember]
        public int PostCommentCount { get; set; }
        [DataMember]
        public List<Comment> Comments { get; set; }
        [DataMember]
        public bool IsPublic { get; set; }
        [DataMember]
        public SmallUser SUser { get; set; }
        [DataMember]
        public SmallPet SPet { get; set; }

        #endregion

        #region constructors

        private Post()
        {
            this.Id = 0;
            this.Description = "Please post something!";
            this.PostTypeId = 1;
            this.PostURL = "";
            this.PostLikeCount = 0;
            this.PostLikedBy = new List<int>();
            this.PostCommentCount = 0;
            this.Comments = new List<Comment>();
            this.IsPublic = true;
            this.DateAdded = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }

        public Post(string description, int postedBy, bool isPostByPet, string postURL = "") : base()
        {
            this.Description = description;
            this.PostURL = postURL;
            this.PostedBy = postedBy;
            this.IsPostByPet = isPostByPet;
        }

        public Post(int postId) : base()
        {
            Post post = Post.GetById(postId);
            this.Id = post.Id;
            this.PostTypeId = post.PostTypeId;
            this.Description = post.Description;
            this.PostURL = post.PostURL;
            this.PostedBy = post.PostedBy;
            this.IsPostByPet = post.IsPostByPet;
            this.PostLikeCount = post.PostLikeCount;
            this.PostLikedBy = post.PostLikedBy;
            this.PostCommentCount = post.PostCommentCount;
            this.IsPublic = post.IsPublic;
            this.DateAdded = post.DateAdded;
            this.DateModified = post.DateModified;
            this.IsActive = post.IsActive;
            this.IsDeleted = post.IsDeleted;
            if (post.IsPostByPet)
            {
                this.SPet = new SmallPet(post.PostedBy);
                this.SUser = new SmallUser(SPet.userId.HasValue ? SPet.userId.Value : 0);
            }
            else
                this.SUser = new SmallUser(post.PostedBy);
        }

        public Post(Post post) : base()
        {
            this.Id = post.Id;
            this.PostTypeId = post.PostTypeId;
            this.Description = post.Description;
            this.PostURL = post.PostURL;
            this.PostedBy = post.PostedBy;
            this.IsPostByPet = post.IsPostByPet;
            this.PostLikeCount = post.PostLikeCount;
            this.PostLikedBy = post.PostLikedBy;
            this.PostCommentCount = post.PostCommentCount;
            this.IsPublic = this.IsPublic;
            this.DateAdded = post.DateAdded;
            this.DateModified = post.DateModified;
            this.IsActive = post.IsActive;
            this.IsDeleted = post.IsDeleted;
            if (post.IsPostByPet)
            {
                this.SPet = new SmallPet(post.PostedBy);
                this.SUser = new SmallUser(SPet.userId.HasValue ? SPet.userId.Value : 0);
            }
            else
                this.SUser = new SmallUser(post.PostedBy);
        }

        public Post(DAL.Post post) : base()
        {
            this.Id = post.Id;
            this.PostTypeId = post.PostTypeId;
            this.Description = post.Description;

            if (!string.IsNullOrEmpty(post.PostURL))
            {
                if (post.PostURL.Contains("http://"))
                    this.PostURL = post.PostURL;
                else
                    this.PostURL = ConfigMember.ImageURL + post.PostURL;
            }
            else
                this.PostURL = "";

            this.PostedBy = post.PostedBy;
            this.IsPostByPet = post.IsPostByPet;
            this.PostLikeCount = post.PostLikeCount;
            if (!string.IsNullOrEmpty(post.PostLikedBy) && post.PostLikedBy.Contains(','))
            {
                string[] arrStr = post.PostLikedBy.Split(',');
                foreach (string id in arrStr)
                {
                    int i = 0;
                    if (Int32.TryParse(id, out i))
                        this.PostLikedBy.Add(i);
                }
            }
            this.PostCommentCount = post.PostCommentCount;
            this.IsPublic = post.IsPublic;
            this.DateAdded = post.DateAdded;
            this.DateModified = post.DateModified;
            this.IsActive = post.IsActive;
            this.IsDeleted = post.IsDeleted;
            if (post.IsPostByPet)
            {
                this.SPet = new SmallPet(post.PostedBy);
                this.SUser = new SmallUser(SPet.userId.HasValue ? SPet.userId.Value : 0);
            }
            else
                this.SUser = new SmallUser(post.PostedBy);
        }

        public Post(string description, int postedById, bool isPostByPet, int postTypeId, string postURL  = "", bool isPublic = true) : base()
        {
            this.PostTypeId = postTypeId;
            this.Description = description;
            this.PostURL = postURL;
            this.PostedBy = postedById;
            this.IsPostByPet = isPostByPet;
            this.IsPublic = isPublic;
            if (isPostByPet)
            {
                this.SPet = new SmallPet(postedById);
                this.SUser = new SmallUser(SPet.userId.HasValue ? SPet.userId.Value : 0);
            }
            else
                this.SUser = new SmallUser(postedById);

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

        internal static bool Validate(Post post)
        {
            if (string.IsNullOrEmpty(post.Description) || post.PostedBy <= 0 || post.PostTypeId <= 0)
                return false;
            else
                return true;
        }

        internal bool Validate()
        {
            if (string.IsNullOrEmpty(this.Description) || this.PostedBy <= 0)
                return false;
            else
                return true;
        }

        internal int Save()
        {
            //Check if all the objects in User's object is saved
            int result = -1;

            if (Validate())
            {
                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdatePost(this.Id, this.PostTypeId, this.Description, this.PostURL, this.PostedBy, this.IsPostByPet, this.IsPublic).FirstOrDefault());
                    if (result > 0)
                        this.Id = result;
                }
            }
            return result;
        }

        internal static int Save(Post post)
        {
            int result = -1;

            if (Validate(post))
            {
                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdatePost(post.Id, post.PostTypeId, post.Description, post.PostURL, post.PostedBy, post.IsPostByPet, post.IsPublic).FirstOrDefault());
                    if (result > 0)
                        post.Id = result;
                }
            }
            return result;
        }

        internal bool Delete()
        {
            int result = -1;
            if (this.Id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeletePostById(this.Id);
                if (result > 0)
                    this.Id = result;
            }
            return result > 0 ? true : false ;
        }

        internal static bool Delete(int id, int postedBy, bool isPostedByPet)
        {
            int result = -1;
            if (id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeletePost(id, postedBy, isPostedByPet);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        internal static bool DeleteById(int id)
        {
            int result = -1;
            if (id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeletePostById(id);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        #endregion
    }
}
