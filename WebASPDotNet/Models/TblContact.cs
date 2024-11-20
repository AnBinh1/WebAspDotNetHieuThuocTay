﻿using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblContact
{
    public int ContactId { get; set; }

    public string? Name { get; set; }

    public string? Alias { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Message { get; set; }

    public bool? IsRead { get; set; }
}