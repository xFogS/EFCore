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
        //Відобразити кількість покупців у кожній країні.
        static DataTable GetCountSubsctibersFromCountry()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var sql = "SELECT [C].[Name] AS 'Country', COUNT([S].[CountryId]) AS 'Count' FROM [Country] AS C " +
                    "JOIN [Subscriber] AS S ON [C].[Id] = [S].[CountryId] " +
                    "GROUP BY [C].[Name] ORDER BY COUNT([S].[CountryId]) ASC";
                DataTable table = new DataTable();
                table.Load(conn.ExecuteReader(sql));
                return table;
            }
        }
        static DataTable GetInterestingSubsctibersFromCountry(string country)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Category AS C " +
                    "WHERE [C].[Id] IN (SELECT [WL].[CategoryId] FROM [WishList] AS WL " +
                    "WHERE [WL].[SubscriberId] IN (SELECT [S].[Id] FROM [Subscriber] AS S " +
                    "WHERE [S].[CountryId] = (SELECT [Country].[Id] FROM [Country] " +
                    "WHERE [Country].[Name] = @Name)))";
                DataTable table = new DataTable();
                table.Load(conn.ExecuteReader(sql, new { Name = country }));
                return table;
            }
        }
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
        static DataTable GetSpecialProductFromDate(string category, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Product AS P " +
                    "JOIN SpecialOfer AS SO ON P.SpecialOferId = SO.Id " +
                    "WHERE P.CategoryId = (SELECT Id FROM Category WHERE Name = @Category) " +
                    "AND (@Date BETWEEN SO.DateStart AND SO.DateEnd)";
                DataTable table = new();
                table.Load(connection.ExecuteReader(sql, new { Category = category, Date = date.ToString("yyyy-MM-dd") }));
                return table;
            }
        }
        static DataTable GetSpecialProductFromSubscribe(string subscribe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM [Product] AS P " +
                    "WHERE[P].[SpecialOferId] IS NOT NULL " +
                    "AND[P].[SpecialOferId] IN(SELECT[SO].[Id] FROM[SpecialOfer] AS SO) " +
                    "AND[P].[CategoryId] IN(SELECT[C].[Id] FROM[Category] AS C " +
                    "WHERE[C].[Id] IN(SELECT[WL].[CategoryId] FROM[WishList] AS WL " +
                    "WHERE[WL].[SubscriberId] IN(SELECT[S].[Id] FROM[Subscriber] AS S " +
                    "WHERE[S].[Name] = @Name)))";
                DataTable table = new();
                table.Load(connection.ExecuteReader(sql, new { Name = subscribe }));
                return table;
            }
        }
        static DataTable GetTopCountryFromSubscribes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT TOP(3) [C].[Name] AS 'Country', COUNT([S].[CountryId]) AS 'Count' " +
                    "FROM[Country] AS C JOIN[Subscriber] AS S " +
                    "ON[S].[CountryId] = [C].[Id] " +
                    "GROUP BY[C].[Name] ORDER BY COUNT([S].[CountryId]) DESC";
                DataTable table = new();
                table.Load(connection.ExecuteReader(sql));
                return table;
            }
        }
        static DataTable GetTopCountry()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT TOP(1) [C].[Name] AS 'Country', COUNT([S].[CountryId]) AS 'Count' " +
                    "FROM[Country] AS C JOIN[Subscriber] AS S " +
                    "ON[S].[CountryId] = [C].[Id] " +
                    "GROUP BY[C].[Name] ORDER BY COUNT([S].[CountryId]) DESC";
                DataTable table = new();
                table.Load(connection.ExecuteReader(sql));
                return table;
            }
        }
        static void Main(string[] args)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                {
                    /*var subscriber = sql.Query<Subscriber>("SELECT * FROM [Subscriber]").ToList();
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
                    }*/
                }
                {
                    DataTable[] table = new[]{ GetCountSubsctibersFromCountry(),
                                                GetInterestingSubsctibersFromCountry("Country 1"),
                                                GetSpecialProductFromDate("Category 1", new DateTime(2024, 03, 27)),
                                                GetSpecialProductFromSubscribe("Serg"),
                                                GetTopCountryFromSubscribes()};
                    foreach (DataTable data in table)
                    {
                        data.Print();
                    }
                }
            }
        }
    }
}
