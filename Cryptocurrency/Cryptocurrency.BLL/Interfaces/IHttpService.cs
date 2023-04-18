namespace Cryptocurrency.BLL.Interfaces
{
    public interface IHttpService
    {
        Task<T> Get<T>(string path);
        Task<string> Get(string path);
        Task Put(string path, object content);
        Task<T> Post<T>(string path, object content);
        Task<T> Delete<T>(string path);
    }
}
