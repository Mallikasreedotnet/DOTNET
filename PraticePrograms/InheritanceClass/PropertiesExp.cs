namespace InheritanceClass
{
    public class PropertiesExp
    {
        //private int _StdId;
        //private string _Name;

        //public void SetStdId(int stdId)
        //{
        //    if (stdId <= 0)
        //    {
        //        //throw new ArgumentOutOfRangeException();
        //        Console.WriteLine("Std id can't be negative or empty!");
        //    }
        //    else
        //    {
        //        _StdId = stdId;
        //        Console.WriteLine(GetStdId());
        //    }

        //}
        //public int GetStdId()
        //{
        //    return _StdId;
        //}
        //public void SetName(String Name)
        //{
        //    if (string.IsNullOrWhiteSpace(Name))
        //    {
        //        //throw new ArgumentNullException("name");
        //        Console.WriteLine("enter your name");
        //    }
        //    else
        //    {
        //        _Name = Name;
        //        Console.WriteLine(GetName());
        //    }
        //}
        //public string GetName()
        //{
        //    return _Name;
        //}

        //public string FirstName { get; private set; }
        //public string LastName { get; private set; }
        //public PropertiesExp(string firstName, string lastName)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //}

        public double _length { get; private set; }
        public double breadth { get; set; }
        public double height { get; set; }
      public void SetLength(double length)
        {
            _length = length;
        }
        //public PropertiesExp(double len,double bre,double hei)
        //{
        //    length = len;
        //    breadth = bre;
        //    height = hei;

        //}
    }
    public class University
    {
       private static string UniversityName;
       private static string DepartmentName;
        public static string _UniversityName 
        {
            set
           {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("you cannot enter null or empty value!");
                }
                else
                {
                    UniversityName = value;
                }
               
            }
            get
            {
                return UniversityName;
            }
            
        }
        
    }
}
