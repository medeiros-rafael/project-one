using System;
using System.Collections.Generic;

namespace project_one_api.Models;

public partial class UserModel
{
    public decimal Id { get; set; }

    public string? UserLogin { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
