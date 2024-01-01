using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AllModels.Interfaces;

namespace FileServices;
public class FileService:IFile
{
        public string FilePath { get ; set ; }
        public FileService()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory, "File", "filePizza.json");
        }
        public void WriteMessage(string message)
        {
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, $" {message}");// {DateTime.Now}
            }
        }

           public void AddItem<T>(T item){
            string json = File.ReadAllText(FilePath);
            var TList = JsonSerializer.Deserialize<List<T>>(json);
            TList.Add(item);
            json=JsonSerializer.Serialize(TList);
           WriteMessage(json);
        }
           public List<T> Get<T>()
          {
            string json = File.ReadAllText(FilePath);
            var TList = JsonSerializer.Deserialize<List<T>>(json);
            if (TList != null)
                return TList;
            return default(List<T>);
          }
           public void Update<T>(List<T> list)
          {
           string json=JsonSerializer.Serialize(list);
           WriteMessage(json);
          }
    }


       

