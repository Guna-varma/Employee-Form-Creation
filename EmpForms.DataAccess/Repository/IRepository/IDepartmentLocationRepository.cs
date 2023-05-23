﻿using Emp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository.IRepository
{
    public interface IDepartmentLocationRepository : IRepository<DepatmentLocation> 
    {
        void Update(DepatmentLocation depatmentLocation);
    }
}
