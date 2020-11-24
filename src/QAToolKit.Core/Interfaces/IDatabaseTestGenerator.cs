using System.Collections.Generic;
using System.Threading.Tasks;

namespace QAToolKit.Core.Interfaces
{
    /// <summary>
    /// Database script generator interface
    /// </summary>
    public interface IDatabaseTestGenerator<T>
    {
        /// <summary>
        /// Generate a script
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> Generate();
    }
}
