using System.Threading.Tasks;

namespace QAToolKit.Core.Interfaces
{
    /// <summary>
    /// Generator interface, which takes a source and produces a result
    /// </summary>
    /// <typeparam name="ISource"></typeparam>
    /// <typeparam name="IResult"></typeparam>
    public interface IGenerator<ISource, IResult>
    {
        Task<IResult> Generate(ISource source);
    }
}
