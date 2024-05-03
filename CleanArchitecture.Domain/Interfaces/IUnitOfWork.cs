﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    internal interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken)
    }
}
