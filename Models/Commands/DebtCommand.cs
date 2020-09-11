using System.ComponentModel;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyTestBot_NetCore.Models;

namespace MyTestBot_NetCore.Commands
{
    public class DebtCommand : Command
    {
        public override string Name => "debt";
        public int DebtSum { get; }

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var ChatId = message.Chat.Id;
            var User = message.From;
            var UserName = User.FirstName;

            await client.SendTextMessageAsync(ChatId, "Привет, " + UserName + "\nЯ тебе должен " + DebtSum);
        }

        // GET: Movies
        //public async Task<IActionResult> GetDebt(int DebtSum, Message message)
        //{
        //    // Use LINQ to get list of genres.
        //    //IQueryable<string> debtQuery = from m in _context.Movie
        //    //                                orderby m.Genre
        //    //                                select m.Genre;

        //    //var movies = from m in _context.Movie
        //    //             select m;

        //    //if (!string.IsNullOrEmpty(searchString))
        //    //{
        //    //    movies = movies.Where(s => s.Title.Contains(searchString));
        //    //}

        //    //if (!string.IsNullOrEmpty(movieGenre))
        //    //{
        //    //    movies = movies.Where(x => x.Genre == movieGenre);
        //    //}

        //    //var movieGenreVM = new MovieGenreViewModel
        //    //{
        //    //    Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
        //    //    Movies = await movies.ToListAsync()
        //    //};

        //    //return OkResult;
        //}


    }
}
