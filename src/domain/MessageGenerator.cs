using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace front_bot.src.domain
{
    internal static class MessageGenerator
    {

        public static InlineKeyboardMarkup GenerateBotsKeyBoard(string user_bots_json)
        {
            JArray jsonArray = JArray.Parse(user_bots_json);

            var keyboardButtons = jsonArray
                .Select(item =>  new List<InlineKeyboardButton>() { 
                    InlineKeyboardButton.WithCallbackData((string)item["name"], "bot " + (string)item["botUUID"])
                }).ToList();
        
        
        
            return new InlineKeyboardMarkup(keyboardButtons );
        }
            
        public static string GenerateBotInfo(JObject bot_json)
        {
            return $"Название: {(string)bot_json["name"]}\n" +
                   $"Дата создания: {(string)bot_json["createdAt"]}\n" +
                   $"Состояние: {(string)bot_json["status"]}";
        }

        public static InlineKeyboardMarkup GenerateBotInfoKeyBoard(JObject bot_json)
        {
            var state = (string)bot_json["status"];

            var bot_uuid = (string)bot_json["botUUID"];

            var key_board_state = state == "stopped" ? "Включить" : "Выключить";
            var key_board_clq = state == "stopped" ? "start" : "stop";

            List<List<InlineKeyboardButton>> kb = new List<List<InlineKeyboardButton>>() 
            { 
                new List<InlineKeyboardButton>() { InlineKeyboardButton.WithCallbackData(key_board_state,key_board_clq + " " + bot_uuid) },
                new List<InlineKeyboardButton>() {InlineKeyboardButton.WithCallbackData("Загрузить ответы","get_csv "+ bot_uuid) },
                new List<InlineKeyboardButton>() {InlineKeyboardButton.WithCallbackData("Назад", "back_to_bots") },
            };

            return new InlineKeyboardMarkup(kb);
        }
    }
}
