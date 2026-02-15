using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class User : IIdentity, IFileEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string ToFileString()
        {
            return $"{FirstName}|{LastName}|{Age}";
        }

        public void FromFileFields(string[] fields)
        {
            FirstName = fields[0];
            LastName = fields[1];
            Age = int.Parse(fields[2]);
            
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }

    }

}
