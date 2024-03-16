using System;
using System.Collections.Generic;

namespace QuizApiJWT.Models;

public partial class RateCard
{
    public int No { get; set; }

    public int DaysBegin { get; set; }

    public int DaysEnd { get; set; }

    public decimal Interest { get; set; }

    public decimal SrInterest { get; set; }
}
