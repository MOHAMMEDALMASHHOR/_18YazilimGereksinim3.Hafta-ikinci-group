namespace StudnetApp.Models
{
   public static class StudnetRepository{

    public static List<Studnet> StudnetsList { get; set; }
    static StudnetRepository()
    {
        StudnetsList = new List<Studnet>();
        StudnetsList.Add(new Studnet(){Number = 1, FirstName = "Mohammed", LastName ="Almashhor"});
        StudnetsList.Add(new Studnet(){Number = 2, FirstName = "Mohamed", LastName ="lmashhor"});
        StudnetsList.Add(new Studnet(){Number = 3, FirstName = "Moammed", LastName ="Aashhor"});
        StudnetsList.Add(new Studnet(){Number = 4, FirstName = "Mhammed", LastName ="Alashhor"});
    }
    public static List<Studnet> GetAll(){
            return StudnetsList;
    }
    public static Studnet GetOne(int id){
        foreach (var studnet in StudnetsList)
        {
            if (studnet.Number.Equals(id))
            {
                return studnet;
            }
        }
            throw new Exception($"There is no studnet with the id: {id}");
    }
    public static Studnet CreateOne(Studnet studnet){
        StudnetsList.Add(studnet);
        return studnet;
    }
    public static void UpdateOne(int id,Studnet studnet){
        var stu = GetOne(id);
        stu.Number=studnet.Number;
        stu.FirstName=studnet.FirstName;
        stu.LastName=studnet.LastName;


    }
    public static void DeleteOne(int id){
        StudnetsList.Remove(GetOne(id));
    }
    }
}