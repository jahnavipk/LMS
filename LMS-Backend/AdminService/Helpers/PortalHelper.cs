using MongoDB.Driver;
using AdminService.DAO;
using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Helpers
{
    public class PortalHelper : IPortalHelper
    {
        private readonly IMongoCollection<PortalDAO> _portalDAO;

        public PortalHelper(ILMSDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("LMSData");
            _portalDAO = database.GetCollection<PortalDAO>("UserDetails");
        }


        public bool Register(Register registor)
        {
            try
            {
                PortalDAO PortalDAO = new PortalDAO();
                PortalDAO.Name = registor.Name;
                PortalDAO.Email = registor.Email;
                PortalDAO.Role = "Admin";
                PortalDAO.Password = registor.Password;
                PortalDAO.bsonDateTime = registor.DateTime;
                PortalDAO.IsActive = 1;
                _portalDAO.InsertOne(PortalDAO);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PortalDAO> GetUser(Login login)
        {
            try
            {
                return _portalDAO.Find(x => x.Email == login.Email && x.Password == login.Password && x.IsActive == 1).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
