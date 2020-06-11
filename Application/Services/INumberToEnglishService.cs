using System.Threading.Tasks;

namespace Application.Services
{
    public interface INumberToEnglishService
    {
        /// <summary>
        /// Calculates English text for the given number, and log the call as required by specs.
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>English representation of number, eg: seventy four</returns>
        Task<string> CalculateEnglishAndLog(decimal number);
    }
}