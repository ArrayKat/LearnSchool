﻿using System;
using System.Collections.Generic;

namespace LernSchool.Models;

public partial class ClientService
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? ServiceId { get; set; }

    public DateTime StartTime { get; set; }

    public string Comment { get; set; } = null!;

    public virtual Client? Client { get; set; }

    public virtual Service? Service { get; set; }
}
