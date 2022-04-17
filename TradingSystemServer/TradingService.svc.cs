using System;
using BusinessLayer.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TradingSystemServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ITradingService
    {
        private readonly UserController userController;
        private readonly PortfolioController portfolioController;
        public Service1()
        {
            userController = new UserController();
            portfolioController = new PortfolioController();
        }
        public Guid CreateUser(User userDto)
        {
            return userController.CreateUser(userDto.UserName, userDto.FullName, userDto.EmailId, userDto.Type, userDto.Password);
        }

        public User GetUser(Guid id)
        {
            var user = userController.GetUser(id);
            return new User()
            {
                Id = id,
                UserName = user.UserName,
                EmailId = user.EmailId,
                FullName = user.FullName,
                Type = (int)user.Type,
            };
        }

        public User ValidateUser(string userName, string password)
        {
            var user = userController.ValidateUser(userName, password);
            if(user == null)
            {
                return null;
            }

            return new User()
            {
                Id = user.UserId,
                UserName = user.UserName,
                EmailId = user.EmailId,
                FullName = user.FullName,
                Type = (int)user.Type,
            };
        }

        public PortFolio GetPortFolio(Guid userId)
        {
            var portfolio = portfolioController.GetPortfolio(userId);
            var dto = new PortFolio()
            {
                PortfolioId = portfolio.PortfolioId,

            };

            dto.Stocks = new List<Stock>();
            foreach (var stock in portfolio.Stocks)
            {
                dto.Stocks.Add(ConvertStock(stock));
            }

            return dto;
        }

        private Stock ConvertStock(BusinessLayer.Model.Stock stock1)
        {
            var stock = new Stock();
            return stock;
        }
    }
}
