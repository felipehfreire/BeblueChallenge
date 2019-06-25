using Beblue.Data.Context;
using Beblue.Domain.Discs;
using Beblue.Domain.Discs.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beblue.Data.Repositorys
{
    public class DiscRepository : Repository<Disc>, IDiscRepository
    {
        public DiscRepository(BeblueContext context) : base(context)
        {
        }
    }
}
