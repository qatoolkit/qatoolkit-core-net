using System.Threading.Tasks;

namespace QAToolKit.Core.Interfaces
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Get JWT access token
        /// </summary>
        /// <returns></returns>
        Task<string> GetAccessToken();
    }
}
