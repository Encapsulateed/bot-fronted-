using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace front_bot
{
    public partial class Program
    {
        public static async Task HandleMessage(Message msg)
        {
            if (msg.Text.StartsWith('/')) HandleCommand();
            else HandleUserMessage();
        }

        private static async Task HandleCommand() { }
        private static async Task HandleUserMessage() { }
    }
}
