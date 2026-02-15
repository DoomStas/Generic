using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generic
{
    public class FileRepository<T> : IRepository<T> where T : IIdentity, IFileEntity, new()
    {
        private string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        //Get all objeckt from file
        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            string[] lines = File.ReadAllLines(_filePath);
            int currentId = 1;
            foreach (string line in lines)
            { 
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                string[] fields = line.Split('|');
                T item = new T();
                item.FromFileFields(fields);
                item.Id = currentId++;
                list.Add(item);
            }
            return list;
        }

        public void Remove(T item)
        {
            List<T> items = GetAll();
            items.RemoveAll(i => i.Id == item.Id);
            SaveAll(items);
        }

        public T GetById(int id)
        {
            List<T> items = GetAll();
            return items.FirstOrDefault(i => i.Id == id);
        }

        public void Add(T item)
        {
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(item.ToFileString());
            }
        }

        public void Update(T item)
        {
            List<T> items = GetAll();
            int index = items.FindIndex(i => i.Id == item.Id);
            if(index != -1)
            {
                items[index] = item;
                SaveAll(items);
            }
        }
        public void SaveAll(List<T> items)
        {
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                foreach (T item in items)
                {
                    sw.WriteLine(item.ToFileString());
                }
            }
        }
    }
}
