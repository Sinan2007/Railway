using System;
using System.Collections.Generic;

namespace Rail.Data.Models;

public partial class Route
{
    public int Id { get; set; }

    public int? TrainId { get; set; }

    public string? DepartureStation { get; set; }

    public string? ArrivalStation { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Train? Train { get; set; }
}
