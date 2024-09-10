using System;
using System.Collections.Generic;

namespace front_bot.src.repository;

public partial class User
{
    public long ChatId { get; set; }

    public string? Uuid { get; set; }

    public string? Jwt { get; set; }

    public string? Command { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
