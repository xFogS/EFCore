namespace EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ChampionshipDB db = new ChampionshipDB())
            {
                //Display ours teams from sql server
                foreach (var item in db.Teams)
                    Console.WriteLine(item);
            }
        }
    }
}
