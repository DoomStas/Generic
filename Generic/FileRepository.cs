using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generic
{
    public class FileRepository<T> where T : IFileEntity, new()
    {
        private string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        //Get all objeckt from file

        public List<T> GetAll()
        {
            var items = new List<T>();

            if (!File.Exists(_filePath))
            {
                return items;
            }

            string[] lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string[] rawFields = line.Split('|');
                // Trim whitespace from each field
                string[] trimmedFields = new string[rawFields.Length];
                for (int i = 0; i < rawFields.Length; i++)
                {
                    trimmedFields[i] = rawFields[i].Trim();
                }
                T item = new T();
                item.FromFileFields(trimmedFields);
                items.Add(item);
            }
            return items;
        }
        public void Add(T item)
        {
            // Open the file in append mode and write the new item
            using (StreamWriter sw = File.AppendText(_filePath))
            { 
                sw.WriteLine(item.ToFileString());
            }
        }
    }
}
