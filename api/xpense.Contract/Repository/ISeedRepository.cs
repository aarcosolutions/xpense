using System.Threading.Tasks;

namespace xpense.Contract.Repository
{
    public interface ISeedRepository
    {
        /// <summary>
        /// This method will create test data
        /// </summary>
        Task Seed();
    }
}
