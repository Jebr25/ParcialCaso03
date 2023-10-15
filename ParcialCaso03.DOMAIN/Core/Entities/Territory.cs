using System;
using System.Collections.Generic;

namespace ParcialCaso03.DOMAIN.Core.Entities;

public partial class Territory
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Area { get; set; }

    public string? Population { get; set; }
}
