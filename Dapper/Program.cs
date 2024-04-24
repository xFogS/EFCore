using Subscribers.Model;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace Subscribers
{
    public class Program
    {

        static string connectionString =
                "Data Source=DESKTOP;" +
                "Initial Catalog=Subscribers;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False";
        //static IEnumerable<Subscriber> GetSubscriberFromCountry(string country)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sql = "SELECT * FROM Subscriber WHERE CountryId = (SELECT Id FROM Country WHERE Name = @Name)";
        //        return connection.Query<Subscriber>(sql, new {Name = country});
        //    }
        //}

        //static DataTable GetSubscrFromCountry(string country)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sql = "SELECT S.Name AS SubsName, S.Email, S.Gender, C.Name " +
        //            "FROM Subscriber AS S " +
        //            "JOIN Country AS C ON C.Id = S.CountryId " +
        //            "WHERE CountryId = (SELECT Id FROM Country WHERE Name = @Name)";
        //        var reader = connection.ExecuteReader(sql, new { Name = country });
        //        DataTable table = new DataTable();
        //        table.Load(reader);
        //        return table;
        //    }
        //}

        //static DataTable GetCountSubscrFromCountry()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sql = "SELECT C.Name AS 'Country', COUNT(S.CountryId) AS 'Count' " +
        //            "FROM Subscriber AS S JOIN Country AS C ON S.CountryId = C.Id " +
        //            "GROUP BY C.Name ORDER BY 2 DESC";
        //        var reader = connection.ExecuteReader(sql);
        //        DataTable table = new DataTable();
        //        table.Load(reader);
        //        return table;
        //    }
        //}

        //static IEnumerable<Product> GetSpecialProductFromDate(string category, DateTime date)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sql = "SELECT * FROM Product AS P " +
        //            "JOIN SpecialOfer AS SO ON P.SpecialOferId = SO.Id " +
        //            "WHERE P.CategoryId = (SELECT Id FROM Category WHERE Name = @Category) " +
        //            "AND (@Date BETWEEN SO.DateStart AND SO.DateEnd)";

        //        return connection.Query<Product>(sql, new { Category = category, Date = date.ToString("yyyy-MM-dd") });
        //    }
        //}
        static IEnumerable<Subscriber> GetSubscribersFromCountry(string country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM [Subscriber] " +
                    "WHERE [CountryId] = (SELECT [Id] FROM [Country] " +
                    "WHERE [Name] = @Name)";
                return connection.Query<Subscriber>(sqlSelect, new { Name = country });
            }
        }
        static IEnumerable<SpecialOfer> GetSpecialOfferFromCountry(string country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM [SpecialOfer] " +	                               "WHERE [CountryId] = (SELECT [Id] FROM [Country] " + 	                               "WHERE [Name] = @Name)";
                return connection.Query<SpecialOfer>(sqlSelect, new { Name = country });
            }
        }
        static void Main(string[] args)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                {
                    var subscriber = sql.Query<Subscriber>("SELECT * FROM [Subscriber]").ToList();
                    var emalSubscriber = sql.Query<Subscriber>("SELECT [Email] FROM [Subscriber]").ToList();
                    var category = sql.Query<Category>("SELECT * FROM [Category]").ToList();
                    var specialOffer = sql.Query<SpecialOfer>("SELECT * FROM [SpecialOfer]").ToList();
                    var country = sql.Query<Country>("SELECT * FROM [Country]").ToList();
                    
                    //var getsSubsribersFromCountry = GetSubscribersFromCountry("Country 1").ToList();
                    //foreach (var sub in getsSubsribersFromCountry)
                    //{
                    //    Console.WriteLine(sub.ToString());
                    //}
                    var getsSpecialOfferFromCountry = GetSpecialOfferFromCountry("Country 1").ToList();
                    foreach (var specialoffer in getsSpecialOfferFromCountry)
                    {
                        Console.WriteLine(specialoffer.ToString());
                    }
                }
            }
        }
    }
}
