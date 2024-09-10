using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using DotNetEnv;

namespace front_bot
{
   public partial class Program
    {
        private static ITelegramBotClient _bot;

        private static ReceiverOptions _receiverOptions;

        static async Task Main()
        {
            Env.Load("..//..//..//.env");

            _bot = new TelegramBotClient(Environment.GetEnvironmentVariable("TOKEN")!);

            _receiverOptions = new ReceiverOptions 
            {
                AllowedUpdates = new[]
                {
                    UpdateType.Message, UpdateType.CallbackQuery
                },

                ThrowPendingUpdates = true,
            };

            using var cts = new CancellationTokenSource();

            _bot.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token); 

            var me = await _bot.GetMeAsync(); 
            Console.WriteLine($"{me.FirstName} запущен!");

            await Task.Delay(-1);
        }
        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cts)
        {
            try
            {
                Logger(update);
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            await HandleMessage(update.Message,cts);
                            return;
                        }
                    case UpdateType.CallbackQuery: 
                        {
                            await HandleCallBack(update.CallbackQuery);
                            await _bot.DeleteMessageAsync(update.CallbackQuery.From.Id, update.CallbackQuery.Message.MessageId);


                            return;

                        }
                    
                    default:
                        throw new Exception("Unsupported update type!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }


        private static void Logger(Update update)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            Console.WriteLine($"{update.Type}\n");
            if (update.Type == UpdateType.Message)
            {
                if (string.IsNullOrEmpty(update.Message.Text) == false)
                    Console.WriteLine($"Message: {update.Message.Text}\nFrom: {update.Message.From.Id}\nLink @{update.Message.From.Username}");

            }
            else
            {
                Console.WriteLine($"Querry: {update.CallbackQuery.Data}\nText: {update.CallbackQuery.Message.Text}\nFrom: {update.CallbackQuery.From.Id}\n" +
                    $"Link @{update.CallbackQuery.From.Username}");
            }
            Console.WriteLine();
        }
    }
}
