using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllModels.Interfaces
{
    public interface ILog
    {
         public string FilePath { get; set; }
       
         public void WriteMessage<T>(T message);
    }
}