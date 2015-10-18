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
            return null;
        }

        public static SmallPet[] GetConnectionSuggestion(User user)
        {
            return null;
        }

        public static SmallUser[] GetConnectionSuggestion(Pet pet)
        {
            return null;
        }

        public static BoolExt AskToConnect(User requester, User accepter)
        {
            int? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.InsertUpdateConnection(0, requestor.Id, acceptor.Id).FirstOrDefault();              
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
