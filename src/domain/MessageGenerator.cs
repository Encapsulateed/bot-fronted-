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

        public static InlineKeyboardMarkup GenerateBotsKeyBoard(string user_bots)
        {
            JArray jsonArray = JArray.Parse(user_bots);

            // Формирование клавиатуры
            var keyboardButtons = jsonArray
                .Select(item =>  InlineKeyboardButton.WithCallbackData((string)item["name"], "bot " + (string)item["uuid"])).ToList();

            return new InlineKeyboardMarkup(new[] { keyboardButtons });

        }

    }
}
