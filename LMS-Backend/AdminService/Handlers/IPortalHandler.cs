using AdminService.DAO;
using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Handlers
{
    public interface IPortalHandler
    {
        bool Register(Register register);

        List<PortalDAO> GetUser(Login login);
    }
}
