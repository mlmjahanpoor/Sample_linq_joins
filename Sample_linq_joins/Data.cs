namespace Sample_linq_joins;

public static class Data
{
    public static ICollection<User> Users { get; set; } = new List<User>
    {
        new User
        {
            Id=1,
            Name = "moslem"
        },
        new User
        {
            Id = 2,
            Name ="mohammad"
        },
        new User
        {
            Id =3,
            Name = "test"
        }
    };

    public static ICollection<Car> Cars { get; set; } = new List<Car>
    {
        new Car
        {
            Id=1,
            Name = "pride",
            UserId =1
        },
        new Car
        {
            Id=3,
            Name="samand",
            UserId =1
        },
        new Car
        {
            Id=2,
            Name ="pejout",
            UserId =2
        },
        new Car
        {
            UserId=3,
            Name="testCar",
            Id=4
        }
    };
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}