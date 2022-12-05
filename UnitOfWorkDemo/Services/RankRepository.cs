using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Services;

internal class RankRepository
{
    private readonly AppDbContext _context;

    public RankRepository(AppDbContext context)
    {
        _context = context;
    }

    // Get all

    public List<Rank> GetRank()
    {
        return _context.Rank.ToList();
    }

    // Get one by id

    public Rank? GetRank(int id)
    {
        return _context.Rank.FirstOrDefault(c => c.RankId == id);
    }

    // Create

    public void AddRank(Rank rankToAdd)
    {
        _context.Rank.Add(rankToAdd);
    }

    // Update

    public void UpdateRank(Rank updatedRank)
    {
        _context.Rank.Update(updatedRank);
    }

    // Remove

    public void RemoveRank(Rank rankToRemove)
    {
        _context.Rank.Remove(rankToRemove);
    }

}
