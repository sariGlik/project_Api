using AllModels;
using AllModels.Interfaces;
using FileServices;

namespace AllService;
    public class WorkerService:IWorker
    {
    // private  IFile _fileservice;
    // private List<Worker> workers{ get; set; }
    // public WorkerService(IFile fileservice)
    // {
    //     _fileservice=fileservice;
    //     workers=_fileservice.Get<Worker>();
    // }
    // public List<Worker> Workers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    // private static readonly List<Worker> workers = new List<Worker>()
    // {
    //  new Worker() { id=1,first_name="Person1"},
    //  new Worker() { id=2,first_name="Person2"}
    // };
                   // public DateTime createDate { get; set; }
        // public List<Worker> GetWorker()
        // {
        //     return workers;
        // }
        // public void DeleteWorker(int id)
        // {
        //     foreach (var worker in workers)
        //     {
        //         if(worker.id == id)
        //         workers.Remove(worker);   
        //     }
        //         _fileservice.Update(workers);
        // }
        //    public List<Worker> workers;
        //{ get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime createDate { get; set; }
        public List<Worker> Workers;
         private IFile  _fileService;
        public List<Worker> GetWorkers()
        {
            return Workers;
        }
        public void SetWorkers(List<Worker> value)
        {
            Workers = value;
        }
        public WorkerService(IFile fileService)
        {
            _fileService = fileService;
            _fileService.FileName = "fileWorker.json";
            SetWorkers(_fileService.Get<Worker>());
        }
        public string NameOf(int id)
        {
            var exsitworker = GetWorkers().FirstOrDefault(worker => worker.id == id);
            return exsitworker != null ? exsitworker.first_name : string.Empty;
        }
        public void Add(Worker worker){
            _fileService.AddItem<Worker>(worker);
            SetWorkers(_fileService.Get<Worker>());
        }
        public bool Update(int id,Worker worker)
        {
            var existWorker = GetWorkers().FirstOrDefault(worker => worker.id == id);
            if (existWorker != null)
            {
                existWorker.id = worker.id;
                existWorker.first_name = worker.first_name;
                _fileService.Update(GetWorkers());
                SetWorkers(_fileService.Get<Worker>());
                return true;
            }
            return false;
        }
    }

     
