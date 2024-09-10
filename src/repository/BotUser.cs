using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace front_bot.src.repository
{
    public partial class User
    {
        public static User Get(long userId)
        {
            using (var db = new FrontDbContext())
            {
                var usr = db.Users.Where(u => u.ChatId == userId).FirstOrDefault();
                if (usr is null)
                    throw new Exception("No such user !");
                return usr;
            }

           

           

           
        }

        public static async Task<User> Add(long userId)
        {
            using var db = new FrontDbContext();

            var usr = db.Users.Where(u => u.ChatId == userId).FirstOrDefault();

            if (usr is not null) return usr;


            var new_user = new User() { ChatId = userId, Uuid = GenerateUUID() };

            db.Users.Add(new_user);
            await db.SaveChangesAsync();

            return new_user;
        }

        public async Task Update()
        {
            using var db = new FrontDbContext();

            db.Update(this).CurrentValues.SetValues(this);

            await db.SaveChangesAsync();    
        }

        private static string GenerateUUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
