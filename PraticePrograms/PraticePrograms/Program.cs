// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using InheritanceClass;

//var emp = new SalesEmployee("mallika", 30000, 1500);
//Console.WriteLine($"Employee {emp.Name} earned:{emp.Calculatepay()}");
//Console.WriteLine("--------------------------");


//var arr = new Examplesprgm();
//Console.WriteLine("how many number of item u want");
//arr.arraynumbers();
//Console.WriteLine("--------------------------");


//Example1 ex = new Example1(12, "sreenadh", 50000);
//Example1 exm = new Example1(15, "vishnu", 70000);
//Console.WriteLine($"CompanyName:{Example1.CompanyName}");
//Console.WriteLine($"Employee Id: {ex.EmpId} \nEmployee Name: {ex.EmpName}\nEmployee Salary: {ex.EmpSalary}");
//Console.WriteLine("--------------------------");
//Console.WriteLine($"Employee Id: {exm.EmpId} \nEmployee Name: {exm.EmpName}\nEmployee Salary: {exm.EmpSalary}");
////Console.WriteLine($"CompanyName:{Example1.CompanyName}");
//Example1 ex1 = new Example1(ex);
//Console.WriteLine("Copy Constructor");
//Console.WriteLine($"Employee Id: {ex1.EmpId} \nEmployee Name: {ex1.EmpName}\nEmployee Salary: {ex1.EmpSalary}");

//Console.WriteLine("--------------------------");
//VisitingEmp ve = new VisitingEmp();
//ve.EmpId = 23;
//Console.WriteLine($"visitingemp Id:{ve.EmpId}");
//ve.show();
//PermanentEmp pe=new PermanentEmp();
//pe.EmpId = 15;
//Console.WriteLine($"permanentemp Id:{pe.EmpId}");

//PropertiesExp properties = new PropertiesExp("dft","gy");
//properties.StdId = 12;
//properties.Name = "";
//properties.SetStdId(10);
//properties.SetName("");
//Console.WriteLine(properties.GetStdId());

//Console.ReadLine(); 
//PropertiesExp p = new PropertiesExp("mallika","kuntumalla");
//p.FirstName = "sreenadh";
//p.LastName = "Kambum";
//Console.WriteLine($"FirstName:{p.FirstName}\nLastName:{p.LastName}");

//PropertiesExp p = new PropertiesExp(6.0, 7.0, 5.0);
//Console.WriteLine($"{p.volume}");



//static void some()
//{
//    DestructorExp de = new DestructorExp("abc", 12);
//    Console.WriteLine($"Name:{de.getName()}, Age:{de.getAge()}");
//    DestructorExp de1 = new DestructorExp("abcd", 15);
//    Console.WriteLine($"Name:{de1.getName()}, Age:{de1.getAge()}");
//}
//some();
//GC.Collect();
//Console.ReadLine();

//Console.WriteLine("-------------------------");



//PropertiesExp pe = new PropertiesExp();
//pe.SetLength(22.3);
//Console.WriteLine(pe._length);
//University._UniversityName = null;
//Console.WriteLine($"{University._UniversityName}");

//Polymorphism pm = new Polymorphism();
child c = new child();
//((Polymorphism)c).some();
c.some();

//static void some()
//{
//    Chlid c = new Chlid();
//      Console.WriteLine(c.Test);
//    //Console.WriteLine($"Name{c.name}\nAge{c..Age}");
//    //Console.WriteLine(c.some);
//}
//some();
//GC.Collect();
//Console.ReadLine();

Test t = new Test();
ITest2 t1 = t;
//ITest t2 = t;
t.sub(4, 2);
t.Add(1,2);
t.Ad1();
t.some();
//t.sub(3, 5);