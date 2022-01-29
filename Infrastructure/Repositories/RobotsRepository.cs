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
            client = new RestClient("http://localhost:56399/api/");
        }

        public List<RobotViewModel> GetRobots()
        {
            RestRequest request = new RestRequest("Robot", Method.Get);
            var response = client.ExecuteGetAsync<List<RobotViewModel>>(request).Result; //sync call
            return response.Data;
        }

        public void CreateRobot(RobotViewModel robot)
        {
            var request = new RestRequest("Robot", Method.Post);
            request.AddJsonBody(robot);
            client.ExecutePostAsync(request).Wait(); //sync call
        }
    }
}
