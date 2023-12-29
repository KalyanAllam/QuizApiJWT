using System;
using System.Collections.Generic;

namespace QuizApiJWT.Models;

public partial class Userdatum
{
    public int No { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
