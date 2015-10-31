using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;
using Pet2Share_API.Service;
using Pet2Share_API.Utility;
using System.IO;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {

            Connection[] testConn = ConnectionManager.GetConnectRequestsGeneralised(9, false);

            List<Post> postList = PostManager.GetPostsByUser(9, 2, 2);

            AccountManagement.Login("nish@gmail.com", "test");
            //Post post = new Post("This is a test post", 1, true, 1);

            //PostManager.AddPost(post);
            //PostManager.AddComment(post.Id, 9, false, "Test comment");

            //post.Comments = PostManager.GetComments(post.Id);

            FileStream fs = File.Open(@"C:\Users\PS\Desktop\test\banner.jpg", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            
            byte[] imageArr = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));

            BoolExt result = PetProfileManager.UpdateProfilePicture(imageArr, "newTest.jpg", ImageType.jpg, 1);

            Uri imageURi = new Uri("http://192.168.0.7:80");

            string path = new Uri(imageURi, "/9/9/iosdf.jpg").ToString();

            Console.WriteLine(result.Message);    
        }
    }
}
