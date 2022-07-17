using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class MethodsandParameters
    {
            public virtual string ReturnMethodName(string name)
            {
                return $"{name} Sreenadh";
            }
    }
    class Child : MethodsandParameters
    {
        public string ReturnName(string name)
        {
            return $"{name} Chinna";
        }
        public static int ReturnAge(ref int age, int ageHike = 2, int increment = 0)
        {
            age = age + increment + ageHike;
            return age;
        }
        public override string ReturnMethodName(string name)
        {
            return $"{name} Overridden Lakshmi";
        }
        public Family ReturnAgeAndName(Family family)
        {
            family.Name = $"{family.Name} chinna";
            return family;
        }

        public (string Name, int Age) ReturnAgeAndNameWithTupple(Family family)
        {
            family.Name = $"{family.Name} Lakshmi";
            family.Age = 30;
            return (family.Name, family.Age);
        }

        public string ReturnFamilyTree(params string[] name)
        {
            return $"{name[0]}, {name[1]} Lakshmi";
        }
    }
    public class Family
    {
        public int Age; // Field
        public string Name { get; set; } // Prop
    }
}
    class Parent
    {
        internal virtual string ReturnParentName(string name)
        {
            return $"{name} Lakshmi";
        }
    }

