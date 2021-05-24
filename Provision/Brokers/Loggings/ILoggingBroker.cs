namespace Provision.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogActivity(string message);
    }
}
