using JobQPractices.Models;

namespace JobQPractices.Interface
{
    public interface ISimulationRepo
    {
        public Task<IEnumerable<jobDetails>> GetSimulationName();
    }
}
