using MegaMinds_CrudTask.Models;

namespace MegaMinds_CrudTask.Service.IDetailsInterface
{
    public interface IDetailsService
    {
        Task<List<Details>> GetDetailsList();
        Task<Details> GetDetailsById(int Id, Details details);
        Task<int> AddDetails(Details details);
        Task<int> UpdateDetails(Details details);
        Task<int> DeleteDetails(int Id);
    }
}
