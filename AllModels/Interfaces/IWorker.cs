

namespace  AllModels.Interfaces;

    public interface IWorker
    {
        public DateTime createDate { get; set; }
        public List<Worker> GetWorker();
        public void DeleteWorker(int id);
    }

