using System.Threading.Tasks;

namespace QAToolKit.Core.Interfaces
{
    /// <summary>
    /// Test interface, which takes a source and produces a result
    /// </summary>
    /// <typeparam name="ISource"></typeparam>
    /// <typeparam name="IResult"></typeparam>
    public interface ITestSource<ISource, IResult>
    {
        Task<IResult> Load(ISource source);
    }
}
