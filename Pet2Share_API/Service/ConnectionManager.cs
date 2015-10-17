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

        public static BoolExt AskToConnect(Pet requestor, Pet acceptor)
        {
            return null;
        }

        public static BoolExt ApproveConnect()
        {
            return null;
        }
    }
}
