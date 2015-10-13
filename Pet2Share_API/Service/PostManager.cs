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

        public static void Like(int postId, int userId)
        {
            
        }

        public static BoolExt AddComment()
        {
            return new BoolExt(false);
        }

        public static BoolExt DeleteComment()
        {
            return new BoolExt(false);
        }
    }
}
