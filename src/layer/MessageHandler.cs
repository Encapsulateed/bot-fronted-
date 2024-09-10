using front_bot.src.common;
using front_bot.src.domain;
using front_bot.src.repository;
using Newtonsoft.Json.Linq;
using Sprache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace front_bot
{
    public partial class Program
    {
        public static async Task HandleMessage(Message msg, CancellationToken cts)
        {
            switch (msg.Type)
            {
                case MessageType.Text:
                    {
                        if (msg.Text.StartsWith('/')) await HandleCommand(msg.Text, msg.From.Id, cts);
                        else await HandleUserCmd(msg.From.Id, msg.Text);
                        return;
                    }
                case MessageType.Document: 
                    {
                        await HandleUserFile(msg.From.Id, msg.Document);
                        return;
                    }
            }
           
        }

        private static async Task HandleCommand(string cmd,long userId, CancellationToken cts) 
        {
            switch (cmd)
            {
                case "/start":
                    {
                        await _bot.SendTextMessageAsync(chatId: userId, text: BotMessages.Start, cancellationToken: cts);
                        await src.repository.User.Add(userId);
                        return;
                    }
                case "/mybots":
                    {

                        return;
                    }
                case "/newbot":
                    {
                        await _bot.SendTextMessageAsync(chatId: userId, text: BotMessages.SendBotScheme, cancellationToken: cts);


                        var usr = src.repository.User.Get(userId);

                        usr.Command = "SEND_BOT";
                        usr.Update();

                        return;
                    }
                case "/registration":
                    {
                        await _bot.SendTextMessageAsync(chatId: userId, text: BotMessages.EnterEmail, cancellationToken: cts);
                        var usr = src.repository.User.Get(userId);

                        usr.Command = "ENTER_EMAIL reg";
                        usr.Update();

                        return;
                    }
                case "/auth":
                    {
                 
                        await _bot.SendTextMessageAsync(chatId: userId, text: BotMessages.EnterEmail, cancellationToken: cts);
                        var usr = src.repository.User.Get(userId);

                        usr.Command = "ENTER_EMAIL auth";
                        usr.Update();
               
                        return;
                    }
            }
        }
        private static async Task HandleUserCmd(long userId, string text) 
        { 
            var usr = src.repository.User.Get(userId);
            var commands = usr.Command?.Split(' ');

            switch (commands[0])
            {
                case "ENTER_EMAIL":
                    {
                        await _bot.SendTextMessageAsync(chatId: userId, text: BotMessages.EnterPass);

                        usr.Email = text;

                        var second_part = commands[1];

                        usr.Command = $"ENTER_PASSWORD {second_part}";
                        await usr.Update();
                        
                        return;
                    }
                case "ENTER_PASSWORD": {
                        usr.Password = text;
                        usr.Command = "";
                        await usr.Update();
                        
                        switch (commands[1])
                        {
                            case "reg":
                                {
                                    var result = await RequestSender.SendRegisterRequest(usr);

                                    ShowRequestData(result, userId);
                                    return;
                                }
                            case "auth":
                                {
                                    var result = await RequestSender.SendLoginRequest(usr);

                                    ShowRequestData(result, userId);

                                    if (result.Item1 == 200)
                                    {
                                        JObject resp = JObject.Parse(result.Item2);

                                        string? jwt = resp["accessToken"]?.ToString();

                                        usr.Jwt = jwt;
                                        await usr.Update();
                                       
                                    }

                                    return;
                                }
                        }
                        

                        return;
                    }
            }
        }

        private static async Task HandleUserFile(long userId, Document doc)
        {
            var usr = src.repository.User.Get(userId);
            var commands = usr.Command?.Split(' ');


            switch (commands[0])
            {
                case "SEND_BOT":
                    {
                        if (doc.FileName.EndsWith(".json"))
                        {
                            var file = await _bot.GetFileAsync(doc.FileId);

                            using var memStream = new MemoryStream();

                            await _bot.DownloadFileAsync(file.FilePath, memStream);
                            memStream.Position = 0;

                            using (var reader = new StreamReader(memStream))
                            {
                                string jsonContent = await reader.ReadToEndAsync();
                                Console.WriteLine(jsonContent);

                               var data = await RequestSender.SendCreateBotRequest(usr,jsonContent);
                                await ShowRequestData(data, userId);
                            }
                        }
                        else
                        {
                            await _bot.SendTextMessageAsync(chatId: userId, "Send a json file!");
                        }
                        return;
                    }

            }
        }

        private static async Task ShowRequestData((int,string?) data,long user_id) 
        {
            int code = data.Item1;
            string? reason = data.Item2; 
            switch (code) 
            {
                case 200:
                    {
                       await _bot.SendTextMessageAsync(chatId: user_id, text: "Успешно!");
                        return;
                    }
                case 201:
                    {
                        await _bot.SendTextMessageAsync(chatId: user_id, text: "Успешно создано!");
                        return;
                    }
                case 400:
                    {
                        await _bot.SendTextMessageAsync(chatId: user_id, text: $"Ошибка {reason}");
                        return;
                    }
                case 404:
                    {
                        await _bot.SendTextMessageAsync(chatId: user_id, text: $"Ошибка {reason}");
                        return;
                    }
            }
        }
    }
}
