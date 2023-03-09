public class Person
{
    string firstName;
    string lastName;
    int age;
    JobTypes? job; //Nullable

    public static void Main(string[] args)
    {
        
    }
    public Person(string firstName, string lastName, int age, JobTypes? job)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        if (this.age < 0)
            this.age = 0;
        this.job = job;
    }
    public void AssignNewJob(string job)
    {
        try
        {
            this.job = (JobTypes)Enum.Parse(typeof(JobTypes), job);
        }
        catch (ArgumentException)
        {
            this.job = null;
        }
    }
    public string GetFullName()
    {
        return firstName + " " + lastName;
    }
    public int GetAge()
    {
        return age;
    }
    public JobTypes? GetJob()
    {
        return job;
    }
    public void HappyBirthday()
    {
        age += 1;
    }
}
public enum JobTypes
{
    Teacher,
    Fireman,
    Policeman,
    Politician,
    Comedian,
    Mechanic,
    Programmer
}