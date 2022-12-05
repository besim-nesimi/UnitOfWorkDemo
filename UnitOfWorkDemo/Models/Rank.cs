using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Models;

internal class Rank
{
    public int RankId { get; set; }
    public string Title { get; set; } = null!;
    public int Grade { get; set; }

    public List<Crew> Crew { get; set; } = new(); // Samma rank kan innehas av många olika i crew.
}
