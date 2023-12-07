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
            this.FilePath = Path.Combine(Environment.CurrentDirectory, "files", "filePizza.txt");

        }
        public void WriteMessage(string message)
        {
           
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, $" {message}");// {DateTime.Now}
            }
        }
        // public void Update<T>(List<T> list)
        // {
        //    string json=JsonSerializer.Serialize(list);
        //    WriteMessage(json);
        // }
}
