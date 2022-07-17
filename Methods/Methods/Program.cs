// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Methods;
    var instanceClass = new Child();
    var name = instanceClass.ReturnName("Ramana");
    Console.WriteLine($"Name: {name}");
    var age = 28;
    var increment = 5;
    Console.WriteLine($"Age: {Child.ReturnAge(age: ref age, increment: increment)}");
    Console.WriteLine($"Age: {age}");
    var Name = instanceClass.ReturnMethodName("Mallika");
    Console.WriteLine($"Parent Name:{Name}");
    Console.WriteLine($"Family Tree: {instanceClass.ReturnFamilyTree("Father", "Gandfather")}");

    var family = new Family { Age = 29, Name = "Sreenadh Family" };
    Console.WriteLine($"Passed Name: {family.Name},{age}");

    var familyReturned = instanceClass.ReturnAgeAndName(family);
    Console.WriteLine($"Name: {familyReturned.Name}, Age: {familyReturned.Age}");

    var familyReturnedAsTupple = instanceClass.ReturnAgeAndNameWithTupple(family);
    Console.WriteLine($"Name: {familyReturnedAsTupple.Name}, Age: {familyReturnedAsTupple.Age}");

    Console.WriteLine($"Passed Name: {family.Name}");

