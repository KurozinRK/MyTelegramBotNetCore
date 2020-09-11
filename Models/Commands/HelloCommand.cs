using System.ComponentModel;
using Telegram.Bot;
using Telegram.Bot.Types;
using MyTestBot_NetCore.Models;

namespace MyTestBot_NetCore.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var ChatId = message.Chat.Id;
            var User = message.From;
            var UserName = User.FirstName;

            await client.SendTextMessageAsync(ChatId, "Привет, " + UserName + "\nЧего желаешь?");
        }
    }
}
