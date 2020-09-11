using System.ComponentModel;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyTestBot_NetCore.Models;

namespace MyTestBot_NetCore.Models.Commands.ServiceCommands
{
    public class StartNotificationCommand : Command
    {
        public override string Name => "StartNotificationCommand";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var ChatId = message.Chat.Id;
            var User = message.From;
            var UserName = User.FirstName;

            await client.SendTextMessageAsync(ChatId, "Привет, " + UserName + "\nЯ тебе должен " + );
        }
    }
}
