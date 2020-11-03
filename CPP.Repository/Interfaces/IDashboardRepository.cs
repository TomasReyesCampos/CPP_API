using CPP.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Repository.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardDto[]> GetDashboardData();
    }
}
