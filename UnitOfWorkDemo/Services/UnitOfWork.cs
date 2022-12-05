using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Data;

namespace UnitOfWorkDemo.Services;

internal class UnitOfWork
{
    private readonly AppDbContext _context;
    private CrewRepository _crewRepo;
    private RankRepository _rankRepo;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public CrewRepository CrewRepo 
    {
        get
        {
            if(_crewRepo == null )
            {
                _crewRepo = new CrewRepository(_context);
                return _crewRepo;
            }
            else 
            {    
                return _crewRepo;
            }
        }

    }

    public RankRepository RankRepo
    {
        get
        {
            if(_rankRepo == null )
            {
                _rankRepo = new RankRepository(_context);
                return _rankRepo;
            }
            else
            {
                return _rankRepo;
            }
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async void SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
