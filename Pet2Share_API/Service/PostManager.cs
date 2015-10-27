using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API;
using Pet2Share_API.Domain;
using Pet2Share_API.Utility;

namespace Pet2Share_API.Service
{
    public class PostManager
    {
        Post post;

        public PostManager()
        {

        }

        public PostManager(int postId)
        {
            post = new Post(postId);
        }

        #region PostSection

        public static List<Post> GetPostsByUser(int userId, int postCount = 0, int pageNumber = 1, bool? privatePosts = null)
        {
            List<Post> postList = new List<Post>();

            int postStartCount = postCount * (pageNumber - 1);
            int postEndCount = postCount * (pageNumber);
            int forCounter = 0;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                DAL.Post[] dalPosts;
                if (privatePosts == null)
                    dalPosts = context.Posts.Where(p => p.PostedBy == userId && p.IsPostByPet == false).OrderByDescending(post => post.DateAdded).ToArray<DAL.Post>();
                else
                    dalPosts = context.Posts.Where(p => p.PostedBy == userId && p.IsPostByPet == false && p.IsPublic != privatePosts).OrderByDescending(post => post.DateAdded).ToArray<DAL.Post>();

                foreach (DAL.Post dalPost in dalPosts)
                {
                    //TODO: Not a good practice at all, need to change this so that only one instance of context is used
                    if (postEndCount != 0)
                    {
                        if (forCounter >= postStartCount && forCounter < postEndCount)
                        {
                            Post post = new Post(dalPost);
                            post.Comments = GetComments(post.Id, 3);
                            postList.Add(post);

                        }
                        else if (forCounter >= postEndCount)
                            break;
                    }
                    else
                    {
                        Post post = new Post(dalPost);
                        post.Comments = GetComments(post.Id, 3);
                        postList.Add(post);
                    }
                    forCounter++;
                }
            }
            return postList;
        }

        public static List<Post> GetPostsByPet(int petId, int postCount = 0, int pageNumber = 1, bool? privatePosts = null)
        {
            List<Post> postList = new List<Post>();

            int postStartCount = postCount * (pageNumber - 1);
            int postEndCount = postCount * (pageNumber);
            int forCounter = 0;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                DAL.Post[] dalPosts;
                if (privatePosts == null)
                    dalPosts = context.Posts.Where(p => p.PostedBy == petId && p.IsPostByPet == true).OrderByDescending(post => post.DateAdded).ToArray<DAL.Post>();
                else
                    dalPosts = context.Posts.Where(p => p.PostedBy == petId && p.IsPostByPet == true && p.IsPublic != privatePosts).OrderByDescending(post => post.DateAdded).ToArray<DAL.Post>();

                foreach (DAL.Post dalPost in dalPosts)
                {
                    if (postEndCount != 0)
                    {
                        if (forCounter >= postStartCount && forCounter < postEndCount)
                        {
                            Post post = new Post(dalPost);
                            post.Comments = GetComments(post.Id, 3);
                            postList.Add(post);

                        }
                        else if (forCounter >= postEndCount)
                            break;
                    }
                    else
                    {
                        Post post = new Post(dalPost);
                        post.Comments = GetComments(post.Id, 3);
                        postList.Add(post);
                    }
                    forCounter++;
                }
            }
            return postList;
        }

        public static List<Post> GetMyFeed(int id, bool isRequesterPet = true, int postCount = 0, int pageNumber = 1)
        {
            List<Post> postList = new List<Post>();

            int postStartCount = postCount * (pageNumber - 1);
            int postEndCount = postCount * (pageNumber);
            int forCounter = 0;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetMyFeed_Result> results = context.GetMyFeed(id, isRequesterPet).ToList();
                foreach (DAL.GetMyFeed_Result result in results)
                {
                    if (postEndCount != 0)
                    {
                        if (forCounter >= postStartCount && forCounter < postEndCount)
                        {

                            DAL.Post dalPost = new DAL.Post();
                            dalPost.Id = result.Id;
                            dalPost.PostTypeId = result.PostTypeId;
                            dalPost.Description = result.Description;
                            dalPost.PostURL = result.PostURL;
                            dalPost.PostedBy = result.PostedBy;
                            dalPost.IsPostByPet = result.IsPostByPet;
                            dalPost.PostLikeCount = result.PostLikeCount;
                            dalPost.PostLikedBy = result.PostLikedBy;
                            dalPost.PostCommentCount = result.PostCommentCount;
                            dalPost.IsPublic = result.IsPublic;
                            dalPost.DateAdded = result.DateAdded;
                            dalPost.DateModified = result.DateModified;
                            dalPost.IsActive = result.IsActive;
                            dalPost.IsDeleted = result.IsDeleted;
                            Post post = new Post(dalPost);
                            post.Comments = GetComments(post.Id, 3);
                            postList.Add(post);
                        }
                        else if (forCounter >= postEndCount)
                            break;
                    }
                    else
                    {
                        DAL.Post dalPost = new DAL.Post();
                        dalPost.Id = result.Id;
                        dalPost.PostTypeId = result.PostTypeId;
                        dalPost.Description = result.Description;
                        dalPost.PostURL = result.PostURL;
                        dalPost.PostedBy = result.PostedBy;
                        dalPost.IsPostByPet = result.IsPostByPet;
                        dalPost.PostLikeCount = result.PostLikeCount;
                        dalPost.PostLikedBy = result.PostLikedBy;
                        dalPost.PostCommentCount = result.PostCommentCount;
                        dalPost.IsPublic = result.IsPublic;
                        dalPost.DateAdded = result.DateAdded;
                        dalPost.DateModified = result.DateModified;
                        dalPost.IsActive = result.IsActive;
                        dalPost.IsDeleted = result.IsDeleted;
                        Post post = new Post(dalPost);
                        post.Comments = GetComments(post.Id, 3);
                        postList.Add(post);
                    }
                    forCounter++;
                }
            }

            return postList.OrderByDescending(p => p.DateAdded).ToList();
        }

        public static Post AddPost(Post post)
        {
            post.Save();
            return post;
        }

        public static Post AddPost(int postTypeId, string description, int postedById, bool isPostedByPet, bool isPublic = true)
        {
            Post post = new Post(description, postedById, isPostedByPet, postTypeId, string.Empty, isPublic);
            post.Save();
            return post;
        }

        public static Post AddPost(int postTypeId, string description, int postedById, bool isPostedByPet, string postURL, bool isPublic = true)
        {
            Post post = new Post(description, postedById, isPostedByPet, postTypeId, postURL, isPublic);
            post.Save();
            return post;
        }

        public static BoolExt UploadPostPicture(Byte[] binaryImage, string filename, ImageType imageType, int postId)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            Post post = new Post(postId);

            if (post.IsPostByPet == false)
            {
                relativePath = "/" + post.PostedBy + "/Post/" + post.Id;
            }
            else
            {
                Pet pet = new Pet(post.PostedBy);
                relativePath = "/" + pet.UserId + "/" + post.PostedBy + "/Post/" + post.Id;
            }


            fullFileName = post.PostedBy.ToString() + "_" + post.Id.ToString() + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            post.PostURL = relativePath + "/" + fullFileName;
            post.Save();

            BoolExt result = new BoolExt(true, ConfigMember.ImageURL + post.PostURL);

            return result;
        }

        public static Post UpdatePost(Post post)
        {
            post.Save();
            return post;
        }

        public static Post UpdatePost(int postId, string description)
        {
            Post post = new Post(postId);
            post.Description = description;
            post.Save();
            return post;
        }

        public static BoolExt DeletePost(int postId)
        {
            bool isDeleted = Post.DeleteById(postId);

            if (isDeleted)
                return new BoolExt(isDeleted, "");
            else
                return new BoolExt(isDeleted, "Delete failed, please contact system admin!");
        }

        #endregion

        #region LikeSection

        public static int ToggleLike(int postId, int userId)
        {
            Post post = new Post(postId);
            if (post.PostLikedBy.Contains(userId))
            {
                post.PostLikeCount--;
                post.PostLikedBy.Remove(userId);
                post.Save();
            }
            else
            {
                post.PostLikeCount++;
                post.PostLikedBy.Add(userId);
                post.Save();
            }
            return post.PostLikeCount;
        }

        #endregion

        #region commentsSection

        public static List<Comment> GetComments(int postId, int commentCount = 0) //Sending commentCount = 0 to fetch all the comments;
        {
            List<Comment> listComments = new List<Comment>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                DAL.PostComment[] dalComments;

                if (commentCount == 0)
                {
                    dalComments = context.PostComments.Where(pc => pc.PostId == postId).OrderByDescending(c => c.DateAdded).ToArray<DAL.PostComment>();
                }
                else if (commentCount > 0)
                {
                    dalComments = context.PostComments.Where(pc => pc.PostId == postId).OrderByDescending(c => c.DateAdded).Take(commentCount).ToArray<DAL.PostComment>();
                }
                else
                {
                    dalComments = new DAL.PostComment[] { };
                }

                foreach (DAL.PostComment dalComment in dalComments)
                {
                    listComments.Add(new Comment(dalComment));
                }
            }
            return listComments;
        }

        public static Comment AddComment(Comment comment)
        {
            comment.Save();
            return comment;
        }

        public static Comment AddComment(int postId, int commentedById, bool isCommenterPet, string commentDescription)
        {
            Comment comment = new Comment(postId, commentedById, isCommenterPet, commentDescription);
            comment.Save();
            return comment;
        }

        public static BoolExt DeleteComment(int commentId)
        {
            bool isCommentDeleted = Comment.DeleteById(commentId);

            if (isCommentDeleted)
                return new BoolExt(isCommentDeleted, "");
            else
                return new BoolExt(isCommentDeleted, "Failed to delete comment");
        }

        public static Comment UpdateComment(int commentId, string commentDescription)
        {
            Comment comment = Comment.GetById(commentId);
            comment.CommentDescription = commentDescription;
            comment.Save();
            return comment;
        }

        #endregion
    }
}
