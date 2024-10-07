using front_bot.src.domain;
using front_bot.src.repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace front_bot
{
    public partial class Program
    {
        public static async Task HandleCallBack(CallbackQuery clq)
        {
            if (clq.Data.StartsWith("bot"))
            {
                var bot_uuid = clq.Data.Split(' ')[1];
                var usr = src.repository.User.Get(clq.From.Id);

                var data = await RequestSender.GetBot(usr, bot_uuid);

                if (data.Item1 == 200)
                {
                    var bot_json = JObject.Parse(data.Item2);
                    var msg = MessageGenerator.GenerateBotInfo(bot_json);
                    var kb = MessageGenerator.GenerateBotInfoKeyBoard(bot_json);

                    await _bot.SendTextMessageAsync(chatId: usr.ChatId, text: msg, replyMarkup: kb);
                }
                else
                {
                    await ShowRequestData(data, usr.ChatId);
                }
            }
            else if (clq.Data == "back_to_bots")
            {
                var usr = src.repository.User.Get(clq.From.Id);

                var data = await RequestSender.GetUserBots(usr);

                if (data.Item1 == 200)
                {
                    if (data.Item2 == string.Empty || data.Item2 == "")
                    {
                        await _bot.SendTextMessageAsync(usr.ChatId, "У вас нет ещё ни одного бота");
                    }
                    else
                    {
                        var keyborard = MessageGenerator.GenerateBotsKeyBoard(data.Item2!);
                        await _bot.SendTextMessageAsync(usr.ChatId, "Выберите бота", replyMarkup: keyborard);
                    }
                }
                else
                {
                    await ShowRequestData(data, usr.ChatId);
                }
            }
            else if (clq.Data.StartsWith("start") || clq.Data.StartsWith("stop"))
            {
                var cmd = clq.Data.Split(' ')[0];
                var bot_uuid = clq.Data.Split(' ')[1];
                var usr = src.repository.User.Get(clq.From.Id);

                switch (cmd)
                {
                    case "start":
                        {
                            var data = await RequestSender.TurnON(usr, bot_uuid);
                            await ShowRequestData(data, usr.ChatId);

                            return;
                        }
                    case "stop":
                        {
                            var data = await RequestSender.TurnOFF(usr, bot_uuid);
                            await ShowRequestData(data, usr.ChatId);

                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Erorr!");
                            return;
                        }
                        
                }
            }
            else if (clq.Data.StartsWith("get_csv"))
            {
                var bot_uuid = clq.Data.Split(' ')[1];
                var usr = src.repository.User.Get(clq.From.Id);

                var data = await RequestSender.GET_CSV(usr, bot_uuid);
                
                if(data.Item1 == 200)
                {
                    var csv_str = data.Item2;   
                    byte[] csvBytes = Encoding.UTF8.GetBytes(csv_str);

                    using MemoryStream stream = new MemoryStream(csvBytes);


                    InputFile file = new InputFileStream(stream, "answers.csv");
                    await _bot.SendDocumentAsync(chatId: usr.ChatId, document: file, caption: "Ответы участников");
                }
                else
                { 
                    await ShowRequestData(data,usr.ChatId);
                }
            }
        }
    }
}
