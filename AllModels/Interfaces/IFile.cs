using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AllModels.Interfaces
{
  
    public interface IFile
    {
     
    public string FilePath { get ; set ; }
     void WriteMessage(string message);
    // public void Update<T>(List<T> list);
    }
}