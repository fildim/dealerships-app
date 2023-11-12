using System;
using System.Collections.Generic;

namespace DEALERSHIPS_APP.Models;

public partial class Logincredential
{
    public int Id { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Created { get; set; }
}
