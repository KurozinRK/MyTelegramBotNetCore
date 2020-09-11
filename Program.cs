using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyTestBot_NetCore.Models;
using MyTestBot_NetCore.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Microsoft.AspNetCore.Components;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using MyTestBot_NetCore.Models.Commands.ServiceCommands;

namespace MyTestBot_NetCore
{
    public class Program
    {
        static ITelegramBotClient botClient;
        static TelegramBotClient client;

        static KeyboardButton button;

        public static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }


        static void Main()
        {
            botClient = new TelegramBotClient(AppSettings.Key);
            client = (TelegramBotClient)botClient;

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            //var startcommand = new StartNotificationCommand();
            //startcommand.

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            commandsList.Add(new DebtCommand());
            //
            //foreach (var command in commandsList)
            //{
            //    button = new KeyboardButton(command.Name);
            //}
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllersWithViews();

        //    services.AddDbContext<MvcMovieContext>(options =>
        //            options.UseSqlServer(Configuration.GetConnectionString("MvcMovieContext")));
        //}

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var commands = Program.Commands;
            var message = e.Message;
            var user = message.From.FirstName;

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
                else
                {
                    await botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat,
                      text: user + "\nВ данный момент функционал бота активно разрабатывается. \nСпасибо за участие в тестировании! ",
                      parseMode: 0,
                      disableNotification: true,
                      replyToMessageId: 0,
                      replyMarkup: new InlineKeyboardMarkup("Круто!")
                    );
                }
            }
        }
    }
}
