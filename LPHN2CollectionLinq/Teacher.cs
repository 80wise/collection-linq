using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPHN2CollectionLinq
{
    public class Teacher : IComparable<Teacher>
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public int[] chargedHours { get; set; }
        public Teacher(string name,string faculty,params int[] chargedHours)
        {
            this.Name = name;
            this.Faculty = faculty;
            this.chargedHours = new int[chargedHours.Length];
            for (int i = 0; i < chargedHours.Length; i++)
                this.chargedHours[i] = chargedHours[i];
        }
        public double averageChargedHours { get => chargedHours.Average(); }

        public int CompareTo(Teacher? teacher)
        {
            if(teacher != null)
            {
                return teacher.Name.CompareTo(this.Name);
            }
            else
                throw new NotImplementedException();
            
        }
    }
}
