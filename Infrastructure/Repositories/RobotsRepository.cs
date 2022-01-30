using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RodriBus.MartianRobots.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RobotsRepository
    {
        private RestClient client;
        public RobotsRepository()
        {
            
          // client = new RestClient("http://localhost:61586/api/"); //Use for local debug
          client = new RestClient("http://localhost:8080/api/"); //Use for docker
        }

        public List<RobotViewModel> GetRobots()
        {
            RestRequest request = new RestRequest("Robot", Method.Get);
            RestResponse response = client.ExecuteGetAsync(request).Result; //sync call
            List<RobotViewModel> robots = JsonConvert.DeserializeObject<List<RobotViewModel>>(response.Content);
            return robots;
        }

        public void CreateRobot(RobotViewModel robot)
        {
            try
            {
                var request = new RestRequest("Robot", Method.Post);
                request.AddJsonBody(robot);
                client.ExecutePostAsync(request).Wait(); //sync call
            }catch(Exception e)
            {
                Console.Write(e.Message);
            }
        }


        public void UpdateRobot(RobotViewModel robot)
        {
            try
            {
                var request = new RestRequest("Robot/UpdateRobots", Method.Put);
                request.AddJsonBody(robot);
                client.ExecutePutAsync(request).Wait(); //sync call
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }


        public void DeleteAll()
        {
            try
            {
                var request = new RestRequest("Robot", Method.Delete);
                client.DeleteAsync(request).Wait(); //sync call
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
