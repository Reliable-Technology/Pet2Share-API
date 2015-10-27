using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;
using Pet2Share_API.Utility;

namespace Pet2Share_API.Service
{
    /// <summary>
    /// The connection class either has small pets or small users
    /// </summary>
    public class Connection
    {
        public bool IsPet { get; set; }
        public object Requester { get; set; }
        public object Accepter { get; set; }
    }

    public class ConnectionManager
    {
        public static SmallPet[] GetMyConnections(Pet pet)
        {
            List<SmallPet> sPetList = new List<SmallPet>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetMyPetConnection_Result> connectionList = context.GetMyPetConnection(pet.Id).ToList<DAL.GetMyPetConnection_Result>();
                foreach (DAL.GetMyPetConnection_Result result in connectionList)
                {
                    SmallPet sPet = new SmallPet();
                    sPet.Id = result.Id;
                    sPet.Name = result.Name;
                    sPet.FamilyName = result.FamilyName;
                    sPet.ProfilePictureURL = result.ProfilePicture;

                    sPetList.Add(sPet);
                }
            }
            return sPetList.ToArray();
        }

        public static int GetMyConnectionCount(User user)
        {
            int result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                //TODO: Correct it so that you dont return the complete set of object
                result = (from dalConnection in context.Connections
                          where dalConnection.IUserId == user.Id || dalConnection.AUserId == user.Id
                          select dalConnection.Id).Count();
                //result = context.GetMyConnection(user.Id).ToList().Count;
            }
            return result;
        }

        public static int GetMyConnectionCount(Pet pet)
        {
            int result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                //TODO: Correct it so that you dont return the complete set of object
                result = (from dalConnection in context.PetConnections
                          where dalConnection.IPetId == pet.Id || dalConnection.APetId == pet.Id
                          select dalConnection.Id).Count();
                //result = context.GetMyConnection(user.Id).ToList().Count;
            }
            return result;
        }

        public static SmallUser[] GetMyConnection(User user)
        {
            List<SmallUser> sUserList = new List<SmallUser>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetMyConnection_Result> connectionList = context.GetMyConnection(user.Id).ToList<DAL.GetMyConnection_Result>();
                foreach (DAL.GetMyConnection_Result result in connectionList)
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

        public static SmallPet[] GetMyPetConnection(Pet pet)
        {
            List<SmallPet> sPetList = new List<SmallPet>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetMyPetConnection_Result> connectionList = context.GetMyPetConnection(pet.Id).ToList<DAL.GetMyPetConnection_Result>();
                foreach (DAL.GetMyPetConnection_Result result in connectionList)
                {
                    SmallPet sPet = new SmallPet();
                    sPet.Id = result.Id;
                    sPet.Name = result.Name;
                    sPet.FamilyName = result.FamilyName;
                    sPet.ProfilePictureURL = result.ProfilePicture;

                    sPetList.Add(sPet);
                }
            }
            return sPetList.ToArray();
        }

        public static SmallPet[] GetConnectionSuggestion(Pet pet)
        {
            List<SmallPet> sPetList = new List<SmallPet>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetAvailablePetConnection_Result> connectionList = context.GetAvailablePetConnection(pet.Id).ToList<DAL.GetAvailablePetConnection_Result>();
                foreach (DAL.GetAvailablePetConnection_Result result in connectionList)
                {
                    SmallPet sPet = new SmallPet();
                    sPet.Id = result.Id;
                    sPet.Name = result.Name;
                    sPet.FamilyName = result.FamilyName;
                    sPet.ProfilePictureURL = result.ProfilePicture;

                    sPetList.Add(sPet);
                }
            }
            return sPetList.ToArray();
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

        /// <summary>Method to send friend request</summary>
        /// <param name="requester">The person sending request</param>
        /// <param name="accepter">The person who has to accept this request</param>
        public static BoolExt AskToConnect(Pet requester, Pet accepter)
        {
            int? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.InsertUpdatePetConnection(0, requester.Id, accepter.Id).FirstOrDefault();
            }
            if (result.HasValue && result > 0)
                return new BoolExt(true, "");
            return new BoolExt(false, "");
        }

        public static BoolExt ApproveConnection(User accepter, User requester)
        {
            bool? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.ApproveConnection(accepter.Id, requester.Id, false).FirstOrDefault();
            }
            if (result.HasValue && result == true)
                return new BoolExt(true, "");
            return new BoolExt(false, "");
        }

        public static BoolExt ApproveConnection(Pet accepter, Pet requester)
        {
            bool? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.ApproveConnection(accepter.Id, requester.Id, true).FirstOrDefault();
            }
            if (result.HasValue && result == true)
                return new BoolExt(true, "");
            return new BoolExt(false, "");
        }

        public static BoolExt DeleteConnection(User accepter, User requester)
        {
            bool? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeleteConnection(accepter.Id, requester.Id, false).FirstOrDefault();
            }
            if (result.HasValue && result == true)
                return new BoolExt(true, "");
            return new BoolExt(false, "");
        }

        public static BoolExt DeleteConnection(Pet accepter, Pet requester)
        {
            bool? result;
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeleteConnection(accepter.Id, requester.Id, true).FirstOrDefault();
            }
            if (result.HasValue && result == true)
                return new BoolExt(true, "");
            return new BoolExt(false, "");
        }

        public static SmallUser[] SearchUser(string searchString, int userCount = 0, int pageNumber = 1)
        {
            List<SmallUser> sUserList = new List<SmallUser>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.SearchUser_Result> connectionList = context.SearchUser(searchString).ToList<DAL.SearchUser_Result>();
                foreach (DAL.SearchUser_Result result in connectionList)
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

        public static SmallPet[] SearchPet(string searchString, int petCount = 0, int pageNumber = 1)
        {
            List<SmallPet> sPetList = new List<SmallPet>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.SearchPet_Result> connectionList = context.SearchPet(searchString).ToList<DAL.SearchPet_Result>();
                foreach (DAL.SearchPet_Result result in connectionList)
                {
                    SmallPet sPet = new SmallPet();
                    sPet.Id = result.Id;
                    sPet.Name = result.Name;
                    sPet.FamilyName = result.FamilyName;
                    sPet.ProfilePictureURL = result.ProfilePicture;

                    sPetList.Add(sPet);
                }
            }
            return sPetList.ToArray();
        }

        public static SmallUser[] GetConnectRequests(int myUserId)
        {
            List<SmallUser> sUserList = new List<SmallUser>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetConnectRequests_Result> connectionList = context.GetConnectRequests(myUserId).ToList<DAL.GetConnectRequests_Result>();
                foreach (DAL.GetConnectRequests_Result result in connectionList)
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

        public static SmallPet[] GetPetConnectRequests(int myId, bool amIPet)
        {
            List<SmallPet> sPetList = new List<SmallPet>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                List<DAL.GetPetConnectRequests_Result> connectionList = context.GetPetConnectRequests(myId, amIPet).ToList<DAL.GetPetConnectRequests_Result>();
                foreach (DAL.GetPetConnectRequests_Result result in connectionList)
                {
                    SmallPet sPet = new SmallPet();
                    sPet.Id = result.Id;
                    sPet.Name = result.Name;
                    sPet.FamilyName = result.FamilyName;
                    sPet.ProfilePictureURL = result.ProfilePicture;

                    sPetList.Add(sPet);
                }
            }
            return sPetList.ToArray();
        }

        public static Connection[] GetConnectRequestsGeneralised(int myId, bool amIPet)
        {
            List<Connection> connList = new List<Connection>();
            List<DAL.Connection> userConnList = new List<DAL.Connection>();
            List<DAL.PetConnection> petConnList = new List<DAL.PetConnection>();

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {

                if (!amIPet)
                {
                    userConnList = context.Connections.Where(uc => uc.AUserId == myId && !uc.IsApproved && uc.IsActive && !uc.IsDeleted).ToList();

                    foreach (DAL.Connection userConn in userConnList)
                    {
                        SmallUser initUser = new SmallUser(userConn.IUserId);
                        SmallUser acptUser = new SmallUser(userConn.AUserId);

                        Connection conn = new Connection();
                        conn.Requester = initUser;
                        conn.Accepter = acptUser;
                        conn.IsPet = false;
                        connList.Add(conn);
                    }

                    List<DAL.GetPetProfileByUserId_Result> petResults = context.GetPetProfileByUserId(myId, 1).ToList();

                    foreach (DAL.GetPetProfileByUserId_Result petResult in petResults)
                    {
                        petConnList = context.PetConnections.Where(pc => pc.APetId == petResult.Id && !pc.IsApproved && pc.IsActive && !pc.IsDeleted).ToList();

                        foreach (DAL.PetConnection petConn in petConnList)
                        {
                            SmallPet initPet = new SmallPet(petConn.IPetId);
                            SmallPet acptPet = new SmallPet(petConn.APetId);

                            Connection conn = new Connection();
                            conn.Requester = initPet;
                            conn.Accepter = acptPet;
                            conn.IsPet = true;
                            connList.Add(conn);
                        }
                    }
                }
                else
                {
                    petConnList = context.PetConnections.Where(pc => pc.APetId == myId && !pc.IsApproved && pc.IsActive && !pc.IsDeleted).ToList();

                    foreach (DAL.PetConnection petConn in petConnList)
                    {
                        SmallPet initPet = new SmallPet(petConn.IPetId);
                        SmallPet acptPet = new SmallPet(petConn.APetId);

                        Connection conn = new Connection();
                        conn.Requester = initPet;
                        conn.Accepter = acptPet;
                        conn.IsPet = true;
                        connList.Add(conn);
                    }
                }

                
            }
            return connList.ToArray();
        }
    }
}
