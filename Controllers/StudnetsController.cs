using Microsoft.AspNetCore.Mvc;
using StudnetApp.Models;

namespace StudnetApp.Controllers
{
    [ApiController]
    [Route("api/studnets")]
    public class StudnetsController : ControllerBase
    {
        
        private readonly ILogger<StudnetsController> _logger;

        public StudnetsController(ILogger<StudnetsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Studnet> GetAllStudnets(){
            _logger.LogInformation($"GetAllStudnets has been called!!");
            return StudnetRepository.GetAll();

        }
        [HttpGet("/{id}:int")]
        public Studnet GetOneStudnet(int id){
           _logger.LogInformation($"GetOnetudnets with the Id: {id}has been called!!");
           return StudnetRepository.GetOne(id);
        }
        [HttpPost]
        public Studnet CreateOneStudnet(Studnet studnet){
           _logger.LogInformation($"CreateOneStudnets has been called!!");
            return StudnetRepository.CreateOne(studnet);
        }

        [HttpPut("{id}:int")]
        public void UpdateOneStudnet(int id, Studnet studnet){
            _logger.LogInformation($"UpdateOneStudnets with the Id: {id}has been called!!");
            StudnetRepository.UpdateOne(id,studnet);
        }
        
        [HttpDelete("{id:int}")]
        public void DeleteOneStudnet(int id){
            _logger.LogInformation($"DeleteOneStudnets with the Id: {id}has been called!!");
            StudnetRepository.DeleteOne(id);
        }
    }


 /*  public Studnet[] StudnetList { get; set; }
            public StudnetsController()
            {   
                StudnetList = new Studnet[4];
                StudnetList[0] = new Studnet(){
                    Number = 1,
                    FirstName ="Mohammed",
                    LastName = "Almashhor"
                };
                Studnet stu2 = new Studnet();
                stu2.Number= 2;
                stu2.FirstName = "Zain";
                stu2.LastName= "BinYahya";
                StudnetList[1]=stu2;
                StudnetList[2] = new Studnet(){
                    Number = 3,
                    FirstName ="Ali",
                    LastName = "Alhadi"
                };
                StudnetList[3] = new Studnet(){
                    Number = 4,
                    FirstName ="Mohammed",
                    LastName = "Albar"
    };
} */
    
}