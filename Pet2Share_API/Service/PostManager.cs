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
        User user;
        Pet pet;

        public PostManager()
        {
            
        }

        public PostManager(int postId)
        {
            post = new Post(postId);
        }

        #region PostSection

        public static List<Post> GetPostsByUser(int userId, int postCount = 0, int pageNumber = 1)
        {
            List<Post> postList = new List<Post>();

            int postStartCount = postCount * (pageNumber - 1);
            int postEndCount = postCount * (pageNumber);
            int forCounter = 0;
            
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                DAL.Post[] dalPosts = context.Posts.Where(p => p.PostedBy == userId && p.IsPostByPet == false).ToArray<DAL.Post>();

                foreach (DAL.Post dalPost in dalPosts)
                {
                    if (forCounter >= postStartCount && forCounter < postEndCount)
                        postList.Add(new Post(dalPost));
                    else
                        break;
                    forCounter++;
                }
            }
            return postList;
            
        }

        public static List<Post> GetPostsByPet(int petId, int postCount = 0, int pageNumber = 1)
        {
            List<Post> postList = new List<Post>();

            int postStartCount = postCount * (pageNumber - 1);
            int postEndCount = postCount * (pageNumber);
            int forCounter = 0;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                DAL.Post[] dalPosts = context.Posts.Where(p => p.PostedBy == petId && p.IsPostByPet == true).ToArray<DAL.Post>();

                foreach (DAL.Post dalPost in dalPosts)
                {
                    if (forCounter >= postStartCount && forCounter < postEndCount)
                        postList.Add(new Post(dalPost));
                    else
                        break;
                    forCounter++;
                }
            }
            return postList;
        }

        public static Post AddPost(Post post)
        {
            post.Save();
            return post;
        }

        public static Post AddPost(int postTypeId, string description, int postedById, bool isPostedByPet)
        {
            Post post = new Post(description, postedById, isPostedByPet, postTypeId);
            post.Save();
            return post;
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

        public static List<Comment> GetComments(int postId)
        {
            List<Comment> listComments = new List<Comment>();
            using(DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                DAL.PostComment[] dalComments = context.PostComments.Where(pc => pc.PostId == postId).ToArray<DAL.PostComment>();

                foreach(DAL.PostComment dalComment in dalComments)
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
