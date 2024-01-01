using AllModels;
using AllModels.Interfaces;
namespace AllService;
    public class WorkerService:IWorker
    {
    private  IFile _fileservice;
    public WorkerService( IFile fileservice)
    {
        _fileservice=fileservice;
    }
    private static readonly List<Worker> workers = new List<Worker>()
    {
     new Worker() { id=1,first_name="Person1"},
     new Worker() { id=2,first_name="Person2"}
    };
        public DateTime createDate { get; set; }
        public List<Worker> GetWorker()
        {
            return workers;
        }
        public void DeleteWorker(int id)
        {
            foreach (var worker in workers)
            {
                if(worker.id == id)
                workers.Remove(worker);   
            }
        }
     }
