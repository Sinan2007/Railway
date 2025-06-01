using System;
using System.Collections.Generic;

namespace Rail.Data.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string? PassengerName { get; set; }

    public int? TrainId { get; set; }

    public int? RounteId { get; set; }

    public string? SeatNumber { get; set; }

    public decimal? Price { get; set; }

    public virtual Route? Rounte { get; set; }

    public virtual Train? Train { get; set; }
}
