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

        public static Post AddPost(Post post)
        {
            return post;
        }

        public static Post AddPost(int postTypeId, string description, int postedById, bool isPostedByPet)
        {
            return null;
        }

        public static Post UpdatePost(Post post)
        {
            return null;
        }

        public static Post UpdatePost(int postId, string description)
        {
            return null;
        }

        public static BoolExt DeletePost(int postId)
        {
            return new BoolExt(false);
        }

        #endregion

        #region LikeSection

        public static void ToggleLike(int postId, int userId)
        {
            Post post = new Post(postId);
            if (post.PostLikedBy.Contains(userId))
            {
                post.PostLikeCount--;
                post.PostLikedBy.Remove(userId);
            }
            else
            {
                post.PostLikeCount++;
                post.PostLikedBy.Add(userId);
            }
        }

        #endregion

        #region commentsSection

        public static Comment[] GetComments(int postId)
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
            return listComments.ToArray();
        }

        public static Comment AddComment(Comment comment)
        {
            return null;
        }

        public static Comment AddComment(int postId, int commentedById, bool isCommenterPet, string comment)
        {
            return null;
        }

        public static BoolExt DeleteComment(int commentId)
        {
            return new BoolExt(false);
        }

        public static Comment UpdateComment(int commentId, string comment)
        {
            return null;
        }

        #endregion
    }
}
