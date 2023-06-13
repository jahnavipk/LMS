using AdminService.DAO;
using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Helpers
{
    public interface IPortalHelper
    {
        bool Register(Register register);

        List<PortalDAO> GetUser(Login login);

    }
}
