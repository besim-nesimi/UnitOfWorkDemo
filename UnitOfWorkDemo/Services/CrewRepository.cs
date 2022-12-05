using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Services;

internal class CrewRepository
{
    private readonly AppDbContext _context;

    public CrewRepository(AppDbContext context)
	{
        _context = context;
    }

    // Get all

    public List<Crew> GetCrew()
    {
        return _context.Crew.ToList();
    } 

    // Get one by id

    public Crew? GetCrewMember(int id)
    {
        return _context.Crew.FirstOrDefault(c => c.CrewId == id);
    }

    // Create

    public void AddCrew(Crew crewToAdd)
    {
        _context.Crew.Add(crewToAdd);
    }

    // Update

    public void UpdateCrew(Crew updatedCrew)
    {
        _context.Crew.Update(updatedCrew);
    }

    // Remove

    public void RemoveCrew(Crew crewToRemove)
    {
        _context.Crew.Remove(crewToRemove);
    }
}
