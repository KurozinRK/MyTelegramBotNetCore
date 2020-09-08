using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyTestBot_NetCore.Models;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace MyTestBot_NetCore
{
    public class Program
    {
        static ITelegramBotClient botClient;

        static void Main()
        {
            botClient = new TelegramBotClient(AppSettings.Key);
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }
        
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var user = e.Message.From;
            if (e.Message.Text != null)
            {
                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text:  user.FirstName + "\nВ данный момент функционал бота активно разрабатывается. \nСпасибо за участие в тестировании! "
                );
            }
        }
    }
}
