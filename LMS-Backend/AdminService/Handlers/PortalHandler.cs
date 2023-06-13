using AdminService.DAO;
using AdminService.Helpers;
using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Handlers
{
    public class PortalHandler : IPortalHandler
    {
        public readonly IPortalHelper _portalHelper;

        public PortalHandler(IPortalHelper adminHelper)
        {
            this._portalHelper = adminHelper;

        }

        public bool Register(Register register)
        {
            return _portalHelper.Register(register);
        }

        public List<PortalDAO> GetUser(Login login)
        {
            return _portalHelper.GetUser(login);
        }
    }
}
