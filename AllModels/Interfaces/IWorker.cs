

namespace  AllModels.Interfaces;

    public interface IWorker
    {
        // public DateTime createDate { get; set; }
        // public List<Worker> GetWorker();
        // public void DeleteWorker(int id);

        
        public List<Worker> GetWorkers();
        public void SetWorkers(List<Worker> value);

        public DateTime createDate { get; set; }
        public String NameOf(int id);
        public void Add(Worker worker);
        public bool Update(int id, Worker worker);
    }

