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

        public PostType(string name)
        {
            this.Name = name;
            this.DateAdded = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }
    }

    [DataContract]
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
        public string CommentDescription { get; set; }        
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

        public Comment(DAL.PostComment dalComment)
        {
            this.Id = dalComment.Id;
            this.PostId = dalComment.PostId;
            this.CommentedBy = dalComment.CommentedBy;
            this.IsCommentedByPet = dalComment.IsCommentedByPet;
            this.CommentDescription = dalComment.Comment;
        }

        public Comment(int postId, int commenterId, bool isCommentedByPet, string comment) : base()
        {
            this.PostId = postId;
            this.CommentedBy = commenterId;
            this.IsCommentedByPet = isCommentedByPet;
            this.CommentDescription = comment;
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

        public static bool Validate(Comment comment)
        {
            if (string.IsNullOrEmpty(comment.CommentDescription) || comment.CommentedBy <= 0)
                return false;
            else
                return true;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.CommentDescription) || this.CommentedBy <= 0)
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
                    result = Convert.ToInt32(context.InsertUpdatePostComment(this.Id, this.PostId, this.CommentedBy, this.IsCommentedByPet, this.CommentDescription).FirstOrDefault());
                    if (result > 0)
                        this.Id = result;
                }
            }
            return result;
        }

        public static int Save(Comment comment)
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

        public bool Delete()
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

        public static bool DeleteById(int id)
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
        public List<int> PostLikedBy { get; set; }
        [DataMember]
        public int PostCommentCount { get; set; }
        [DataMember]
        public List<Comment> Comments { get; set; }
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
            this.PostLikedBy = new List<int>();
            this.PostCommentCount = 0;
            this.Comments = new List<Comment>();
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
            this.PostLikedBy = post.PostLikedBy;
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
            this.PostLikedBy = post.PostLikedBy;
            this.PostCommentCount = post.PostCommentCount;
            this.DateAdded = post.DateAdded;
            this.DateModified = post.DateModified;
            this.IsActive = post.IsActive;
            this.IsDeleted = post.IsDeleted;
        }

        public Post(DAL.Post post) : base()
        {
            this.Id = post.Id;
            this.PostTypeId = post.PostTypeId;
            this.Description = post.Description;
            this.PostedBy = post.PostedBy;
            this.IsPostByPet = post.IsPostByPet;
            this.PostLikeCount = post.PostLikeCount;
            if (post.PostLikedBy.Contains(','))
            {
                string[] arrStr = post.PostLikedBy.Split(',');
                foreach (string id in arrStr)
                    this.PostLikedBy.Add(Convert.ToInt32(id));
            }
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
            if (string.IsNullOrEmpty(this.Description) || this.PostedBy <= 0 || this.PostTypeId <= 0)
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
                    result = Convert.ToInt32(context.InsertUpdatePost(this.Id, this.PostTypeId, this.Description, this.PostedBy, this.IsPostByPet).FirstOrDefault());
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
                    result = Convert.ToInt32(context.InsertUpdatePost(post.Id, post.PostTypeId, post.Description, post.PostedBy, post.IsPostByPet).FirstOrDefault());
                    if (result > 0)
                        post.Id = result;
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
                result = context.DeletePostById(this.Id);
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
                result = context.DeletePostById(id);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        #endregion
    }
}
