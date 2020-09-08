using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
//using MyTestBot_NetCore.Models.Commands;
using Telegram.Bot.Args;

//namespace MyTestBot_NetCore.Models
//{
//    public static class Bot
//    {
//        private static TelegramBotClient client;

//        private static List<Command> commandList;

//        public static IReadOnlyList<Command> Commands { get => commandList.AsReadOnly(); }

//        public static async Task<TelegramBotClient> Get()
//        {
//            if (client != null)
//            {
//                return client;
//            }

//            commandList = new List<Command>();
//            commandList.Add(new HelloCommand());
//            // Инициализация команд

//            client = new TelegramBotClient(AppSettings.Key);
//            var me = client.GetMeAsync().Result;
//            var ID = me.Id;
//            var FirstName = me.FirstName;

//            // For WebHooks
//            //var hook = string.Format(AppSettings.Url, "api/message/update");
//            //await client.SetWebhookAsync(hook);
//            //var WebhookInfo = await client.GetWebhookInfoAsync();

//            client.OnMessage += Bot_OnMessage;
//            client.StartReceiving();

//            return client;

//            static async void Bot_OnMessage(object sender, MessageEventArgs e)
//            {
//                if (e.Message.Text != null)
//                {
//                    //Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

//                    await client.SendTextMessageAsync(
//                      chatId: e.Message.Chat,
//                      text: "You said:\n" + e.Message.Text
//                    );
//                }
//            }
//        }
//    }
//}
