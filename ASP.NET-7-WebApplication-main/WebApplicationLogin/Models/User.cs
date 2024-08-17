using System;
using System.Collections.Generic;

namespace WebApplicationLogin.Models;

public partial class User
{
    public int userid { get; set; }

    public string? username { get; set; }


    public string? password { get; set; }
}
