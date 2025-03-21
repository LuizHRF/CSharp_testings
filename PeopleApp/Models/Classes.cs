namespace PeopleApp.Models
{
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = -1;

        // public Person(string Name, int age) {
        //     Name = name;
        //     Age = age;
        // }
    }

    public class Pet
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
    }
    
}