using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IProblemSolver
    {
        Task<string> Start();
    }
}
