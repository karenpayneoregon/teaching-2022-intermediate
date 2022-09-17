namespace Models;

public class Person
{
    public Person(string firstName, string middleName, string lastName) =>
        (FirstName, MiddleName, LastName) = (firstName, middleName, lastName);

    public void Deconstruct(out string firstName, out string middleName, out string lastName)
    {
        firstName = FirstName;
        middleName = MiddleName;
        lastName = LastName;
    }

    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }

    public override string ToString() =>
        $"{FirstName} {MiddleName} {LastName}";

}