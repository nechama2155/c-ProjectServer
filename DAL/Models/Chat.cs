using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Chat
{
    public int ChatId { get; set; }

    public int? ApplicationId { get; set; }

    public string From { get; set; } = null!;

    public string Information { get; set; } = null!;

    public bool? Read { get; set; }

    public DateTime SendDate { get; set; }

    public string To { get; set; } = null!;

    public virtual Application? Application { get; set; }
}
