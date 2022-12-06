using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Interfaces;

internal interface IRepository
{
    void Add(IRepository repository);
}
