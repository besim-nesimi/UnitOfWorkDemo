using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models;

internal class Crew
{
    public int CrewId { get; set; }
    public string FirstName { get; set; } = null!; // Kan ej vara null
    public string? LastName { get; set; } // Kan vara null
    public int RankId { get; set; }
    public Rank Rank { get; set; } = null!; // Kan ej vara null
}
