namespace Utility
{
    public interface ILog
    {
        void WriteErrorToDB(string info);
        void WriteErrorToFile(string info);
    }
}
