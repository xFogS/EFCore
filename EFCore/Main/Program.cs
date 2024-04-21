using EFCore._1_Work;
using EFCore.Main;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ChampionshipDB db = new ChampionshipDB())
            {
                Random rnd = new Random();
                #region addplayers
                /*for (int i = 0; i < 10; ++i) //our base has two teams
                {
                    db.Players.Add(new Player()
                    {
                        Name = $"Player - Team {i / 5 + 1}",
                        Number = i + 1,
                        Position = "Forward",
                        TeamId = i / 5 + 3,
                    });
                }*/
                #endregion
                #region addgames
                /*for (int i = 0; i < 4; ++i)
                {
                    db.Games.Add(new Game()
                    {
                        Date = DateOnly.FromDateTime(new DateTime(rnd.Next(2000, 2024), rnd.Next(1, 12), rnd.Next(1, 27))),
                        TeamId1 = rnd.Next(3, 5),
                        TeamId2 = rnd.Next(3, 5)
                    });
                }*/
                #endregion
                #region addgoals
                /*for (int i = 0; i < 4; ++i)
                {
                    db.Goals.Add(new Goal()
                    {
                        PlayerId = rnd.Next(3, 12),
                        TeamId = rnd.Next(3, 5),
                        GameId = rnd.Next(1, 5),
                        Minutes = rnd.Next(1, 61)
                    });
                }*/
                #endregion
                //db.SaveChanges();
                #region onlypractical
                /*var player = db.Players
                    .Include(t => t.Team)
                    .ToList();
                foreach (Player p in db.Players)
                {
                    Console.WriteLine(p);
                }

                var games = db.Games
                    .Include(t => t.Team1)
                    .Include(t => t.Team2)
                    .Include(g => g.Goals)
                    .Where(t => t.Team1!.Name == "Ukraine national football team"
                    || t.Team2!.Name == "Joma");

                var gg = db.Games
                    .Include(g => g.Team1)
                    .Include(g => g.Team2)
                    .Include(g => g.Goals)
                    .ToList();

                foreach (var game in gg)
                {
                    int g1 = game.Goals.Count(g => game.TeamId1 == g.TeamId);
                    int g2 = game.Goals.Count(g => game.TeamId2 == g.TeamId);
                    Console.WriteLine($"{game} {g1} {g2}");
                }

                var teams = db.Teams.ToList();
                foreach (var team in teams)
                {
                    var gameTeams = db.Games
                        .Include(g => g.Team1)
                        .Include(g => g.Team2)
                        .Include(g => g.Goals)
                        .Where(t => t.Team1 == team || t.Team2 == team);

                    int winGoals = 0, loseGoals = 0, win = 0, lose = 0, draw = 0;

                    Console.WriteLine(team.Name);
                    foreach (var game in gameTeams)
                    {
                        int g1 = game.Goals.Count(g => game.TeamId1 == g.TeamId);
                        int g2 = game.Goals.Count(g => game.TeamId2 == g.TeamId);
                        Console.WriteLine($"{game}");

                        if (team.Id == game.TeamId1)
                        {
                            winGoals += g1;
                            loseGoals += g2;
                            if (g1 > g2)
                            {
                                win++;
                            }
                            else if (g1 < g2)
                            {
                                lose++;
                            }
                            else
                            {
                                draw++;
                            }
                        }
                        else
                        {
                            winGoals += g2;
                            loseGoals += g1;
                            if (g1 < g2)
                            {
                                win++;
                            }
                            else if (g1 > g2)
                            {
                                lose++;
                            }
                            else
                            {
                                draw++;
                            }
                        }
                    }

                    db.TournamentTables.Add(new TournamentTable()
                    {
                        Name = team.Name!,
                        WinGoal = winGoals,
                        LoseGoal = loseGoals,
                        Wins = win,
                        Lose = lose,
                        Draw = draw,
                        Score = win * 3 + draw
                    });
                }
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"{"Name".PadRight(10)} |  WG |  LG |  W  |  D  |  L  |  S  ");
                Console.WriteLine("---------------------------------------------");
                db.TournamentTables.Sort((t1, t2) => t2.Score.CompareTo(t1.Score));
                foreach (var item in db.TournamentTables)
                {
                    Console.WriteLine(item);
                }

                var st = db.GetTeams("Kyiv").ToList(); // my db.id stars from three number
                foreach (Team t in st)
                    Console.WriteLine(t.Name);*/
                #endregion

                #region task
                /*
                     Покажіть різницю забитих та пропущених голів для кожної команди.
                     Покажіть повну інформацію про матч.
                     Покажіть інформацію про матчі у конкретну дату.
                     Покажіть усі матчі конкретної команди.
                     Покажіть усіх гравців, які забили голи у конкретну дату
                 */
                #endregion
                /*1var teams = db.Teams.ToList();
                foreach (var team in teams)
                {
                    var gameTeams = db.Games
                        .Include(g => g.Team1)
                        .Include(g => g.Team2)
                        .Include(g => g.Goals)
                        .Where(t => t.Team1 == team || t.Team2 == team);

                    int win = 0, lose = 0;

                    Console.WriteLine(team.Name);
                    foreach (var game in gameTeams)
                    {
                        int g1 = game.Goals.Count(g => game.TeamId1 == g.TeamId);
                        int g2 = game.Goals.Count(g => game.TeamId2 == g.TeamId);
                        Console.WriteLine($"{game}");

                        if (team.Id == game.TeamId1)
                            _ = g1 < g2 ? ++win : ++lose;
                        else
                            _ = g1 < g2 ? ++win : ++lose;
                    }
                    Console.WriteLine($"{team.Name} {win} {lose}");
                }*/
                /*2
                var teams = db.Teams.ToList();
                foreach (var team in teams)
                {
                    var gameTeams = db.Games
                        .Include(g => g.Team1)
                        .Include(g => g.Team2)
                        .Include(t => t.Goals)
                        .Where(t => t.Team1 == team || t.Team2 == team)
                        .ToList();
                    foreach (var game in gameTeams)
                    {
                        var playerGame = db.Players
                            .Where(p => p.Team == team)
                            .ToList();
                        foreach (var players in playerGame)
                        {
                            Console.Write($"Team: {team}\nGame: {game}\nPlayer: {players}\n");
                            var goal = db.Goals
                                .Where(g => g.Team == team &&
                                g.Game == game &&
                                g.Player == players).ToList();
                            foreach (var goals in goal)
                                Console.WriteLine($"Min Gols: {goals}\n");
                        }
                    }
                }*/
                /*3
                var teams = db.Teams.ToList();
                foreach (var team in teams)
                {
                    var games = db.Games
                        .Where(g => g.Date == new DateOnly(2005, 08, 25))
                        .Include(g => g.Team1)
                        .Include(g => g.Team2)
                        .Where(g => g.Team1 == team || g.Team2 == team)
                        .ToList();
                    foreach (var game in games)
                        Console.WriteLine($"Games: {game.Id} Fight {game.Team1} VS {game.Team2} Date: {game.Date}\n");
                }*/
                /*4
                var teams = db.Teams.ToList();
                foreach (var team in teams)
                {
                    var games = db.Games
                       .Where(t => team.Name == "Ukraine national football team")
                       .Include(g => g.Team1)
                       .Include(g => g.Team2)
                       .Where(g => g.Team1 == team || g.Team2 == team)
                       .ToList();
                    games.ForEach(game => Console.WriteLine($"Game: {game}"));
                }*/


                /*//1 - Teams, 2 - Games, 3 - Goals, 4 - Players   
                var teams = db.Teams.ToList();
                foreach (var team in teams)
                {
                    var games = db.Games
                        .Where(g => g.Date == new DateOnly(2005, 08, 25))
                        .Include(g => g.Team1)
                        .Include(g => g.Team2)
                        .Where(g => g.Team1 == team || g.Team2 == team)
                        .Include(g => g.Goals).ToList();
                    foreach (var game in games)
                    {
                        var goals = db.Goals
                            .Include(g => g.Game)
                            .Where(g => g.Game == game)
                            .ToList();
                        foreach (var goal in goals)
                        {
                            var players = db.Players
                                .Include(p => p.Team)
                                .Where(p => goal.PlayerId == p.Id 
                                && p.Team == team)
                                .ToList();
                            players.ForEach(pp => Console.WriteLine(pp));
                        }
                    }
                }*/
                /*1
                 * Додати інформацію про матч. Перед додаванням потрібно
                перевірити таку інформацію на наявність у додатку.
                
                Game game = new Game()
                {
                    Date = new DateOnly(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day),
                    TeamId1 = rnd.Next(3, 5), //aw... sorry for my rand ^D
                    TeamId2 = rnd.Next(3, 5),
                };
                foreach (Game games in db.Games)
                {
                    if (games.Date == game.Date
                        && games.Team1 == game.Team1
                        && games.Team2 == game.Team2) //+checked && game.Team1 != game.Team2
                    { Console.WriteLine("this object is already in the database"); return; }
                }
                Console.WriteLine("object is append"); db.Add(game); db.SaveChanges();*/

                /*2
                 * Зміна даних існуючого матчу. Користувач може змінити
                будь - який параметр матчу.
                Console.Write("Id: "); int idInput = Convert.ToInt32(Console.ReadLine()!);
                foreach (Game game in db.Games) 
                {
                    Console.WriteLine(game);
                    if (game.Id == idInput)
                    {
                        game.Date = new DateOnly(2017, 05, 05);
                        game.TeamId1 = 4;
                        game.TeamId2 = 3;
                        db.Update(game);
                    }
                }
                db.SaveChanges();*/
                /*3
                 * Cкрипт працював би, якщо я поставив
                          onDelete: ReferentialAction.NoAction);, цього не зробив, маю конфлікти
                          з видаленням
                 * Видалити матч. Пошук матчу для видалення проводиться за
                назвою команд і дати. Перед видаленням, додаток має
                запитати користувача, чи потрібно видаляти матч.
                
                 **Можливо сама побудова була інша, бо зараз не розумію якy участь приймає сама команда(Name). 
                 Типу в матчі приймає дві команди матч*/
                Console.Write("Date: "); DateOnly dateEvent = DateOnly.FromDateTime
                                         (Convert.ToDateTime(Console.ReadLine()));
                Console.Write("Team: "); string gameName = Console.ReadLine()!;
                var games = db.Games
                    .ToList();
                foreach (var game in games)
                {
                    var teams = db.Teams
                        .Where(t => game.Date == dateEvent
                        && t.Name == gameName)
                        .ToList();
                    foreach (var deltem in teams)
                        db.Remove(deltem);
                }
                db.SaveChanges();
            }
        }
    }
}
