using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;
using Pet2Share_API.Utility;

namespace Pet2Share_API.Service
{
    public class ConnectionManager
    {
        public static SmallPet[] GetMyConnections(Pet pet)
        {
            return null;
        }

        public static SmallUser[] GetMyConnection(User user)
        {
            List<SmallUser> sUserList = new List<SmallUser>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetMyConnection_Result> connectionList = context.GetMyConnection(user.Id).ToList<DAL.GetMyConnection_Result>();
                foreach (DAL.GetAvailableConnection_Result result in connectionList)
                {
                    Person p = new Person(result.PrimaryPersonId);
                    SmallUser sUser = new SmallUser();
                    sUser.Id = result.Id;
                    sUser.Name = p.FirstName + " " + p.LastName;
                    sUser.Username = result.Username;
                    sUser.ProfilePictureURL = p.ProfilePictureURL;

                    sUserList.Add(sUser);
                }
            }
            return sUserList.ToArray();
        }

        public static SmallPet[] GetConnectionSuggestion(Pet pet)
        {
            return null;
        }

        public static SmallUser[] GetConnectionSuggestion(User user)
        {
            List<SmallUser> sUserList = new List<SmallUser>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetAvailableConnection_Result> connectionList = context.GetAvailableConnection(user.Id).ToList<DAL.GetAvailableConnection_Result>();
                foreach(DAL.GetAvailableConnection_Result result in connectionList)
                {
                    Person p = new Person(result.PrimaryPersonId);
                    SmallUser sUser = new SmallUser();
                    sUser.Id = result.Id;
                    sUser.Name = p.FirstName + " " + p.LastName;
                    sUser.Username = result.Username;
                    sUser.ProfilePictureURL = p.ProfilePictureURL;

                    sUserList.Add(sUser);
                }
            }
            return sUserList.ToArray();
        }

        /// <summary>Method to send friend request</summary>
        /// <param name="requester">The person sending request</param>
        /// <param name="accepter">The person who has to accept this request</param>
        public static BoolExt AskToConnect(User requester, User accepter)
        {
            int? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.InsertUpdateConnection(0, requester.Id, accepter.Id).FirstOrDefault();              
            }
            if (result.HasValue && result > 0)
                return new BoolExt(true, "");
            return new BoolExt(false, "");
        }

        public static BoolExt ApproveConnect(int connectionId, User accepter)
        {
            bool? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.ApproveConnection(connectionId, accepter.Id).FirstOrDefault();
            }
            if (result.HasValue && result == true)
                return new BoolExt(true, "");
            return new BoolExt(false, "");            
        }


    }
}
