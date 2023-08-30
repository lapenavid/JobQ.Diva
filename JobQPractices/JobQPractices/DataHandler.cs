namespace JobQPractices
{
    public class DataHandler
    {
        private IDataServices _dataServices;

        public DataHandler(IDataServices dataServices) { 
        
        _dataServices = dataServices;

        }

        public void sendData(string message)
        {
            _dataServices.SendData(message);
        }
    }
}
