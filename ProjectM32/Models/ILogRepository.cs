using Microsoft.AspNetCore.Http;
using ProjectM32.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectM32.Models
{
  public  interface ILogRepository
    {
        Task AddLog(Request request);
        Task<Request[]> GetRequests();
    }
}
