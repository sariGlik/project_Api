using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AllModels.Interfaces
{
  
    public interface IFile
    {
    public string FileName { get; set; }
    // public string FilePath { get ; set ; }
    void WriteMessage(string message);
    public void AddItem<T>(T item);
    public List<T> Get<T>();
    public void Update<T>(List<T> list);

    }
}