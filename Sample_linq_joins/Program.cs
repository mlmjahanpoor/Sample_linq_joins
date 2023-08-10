//1) inner
using Sample_linq_joins;

var inners = from u in Data.Users
             join c in Data.Cars on u.Id equals c.UserId
             select new
             {
                 userId = u.Id,
                 carName = c.Name
             };

//2) left
var lefts = (from u in Data.Users
             join c in Data.Cars on u.Id equals c.UserId into x
             from d in x.DefaultIfEmpty()
             select new
             {
                 userId = u.Id,
                 carName = d.Name
             }).ToList();

//3) right ⚠ linq dos'nt support but we can swap tables in left join
//4) Full outer(logical union of a left outer join and a right outer join) ⚠  LINQ does not support full outer joins directly, the same as right outer joins
var leftOuterJoin = from u in Data.Users
                    join c in Data.Cars on u.Id equals c.UserId into cars
                    from car in cars.DefaultIfEmpty()
                    select new
                    {
                        userId = u.Id,
                        carName = car.Name
                    };
var rightOuterJoin = from c in Data.Cars
                     join u in Data.Users on c.UserId equals u.Id into users
                     from user in users.DefaultIfEmpty()
                     select new
                     {
                         userId = user.Id,
                         carName = c.Name
                     };
leftOuterJoin = leftOuterJoin.Union(rightOuterJoin);

//5) Cross Join ⚠ This join does not require any condition in the join but LINQ does not allow using the "join"
//keyword without any condition. Using two from clauses we can do a cross join.

var crossJoin = from u in Data.Users
                from c in Data.Cars
                select new
                {
                    userId = u.Id,
                    carName = c.Name
                };

//6) Group join : ⚠ a group join can be done using a "Group by" clause. There are two ways to do a group join in LINQ.
//1.Using INTO keyword
var groupJoin = from u in Data.Users
                join c in Data.Cars on u.Id equals c.UserId into cars
                select new
                {
                    userId = u.Id,
                    userCars = cars
                };
//2. Using sub query
var groupJoin2 = from u in Data.Users
                 select new
                 {
                     userName = u.Name,
                     cars = (from c in Data.Cars
                             where u.Id == c.UserId
                             select c)
                 };

Console.ReadKey();