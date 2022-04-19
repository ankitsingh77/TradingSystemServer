using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TradingSystemServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITradingService
    {

        [OperationContract]
        User GetUser(Guid id);

        [OperationContract]
        Guid CreateUser(User userDto);

        [OperationContract]
        User ValidateUser(string userName, string password);

        [OperationContract]
        PortFolio GetPortFolio(Guid userId);

        [OperationContract]
        List<Stock> GetAllStocks();

        [OperationContract]
        Guid CreateStock(string name, string symbol, double price, int volume);

        [OperationContract]
        double AddBalance(Guid userId, double amountToAdd);

        [OperationContract]
        bool PurchaseStock(Guid stockId, Guid userId, int quantity);


        [OperationContract]
        bool SellStock(Guid stockId, Guid userId, int quantity);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class User
    {
        Guid id;
        string userName;
        string fullName;
        string emailId;
        int type;
        string pwd;

        [DataMember]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [DataMember]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        [DataMember]
        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }

        [DataMember]
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        [DataMember]
        public string Password
        {
            get { return pwd; }
            set { pwd = value; }
        }
    }

    [DataContract]
    public class PortFolio
    {
        [DataMember]
        public Guid PortfolioId { get; set; }
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public double Balance { get; set; }
        [DataMember]
        public IList<Stock> Stocks { get; set; }
    }

    [DataContract]
    public class Stock
    {
        [DataMember]
        public Guid StockId { get; set; }
        [DataMember]
        public string StockName { get; set; }
        [DataMember]
        public string StockSymbol { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Volume { get; set; }
        [DataMember]
        public double HighPrice { get; set; }
        [DataMember]
        public double LowPrice { get; set; }
        [DataMember]
        public double OpeningPrice { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
