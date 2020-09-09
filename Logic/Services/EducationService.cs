using Domain.Models;
using Domain.Repositories.Contracts;
using Domain.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository EducationRepository;
        public EducationService(IEducationRepository educationRepository)
        {
            EducationRepository = educationRepository;
        }

        public async Task AddAsync(Education Education)
        {
            await EducationRepository.AddAsync(Education);
        }

        public Education Get(int itemId)
        {
            return EducationRepository.Get().FirstOrDefault(x => x.Id == itemId);
        }

        public async Task RemoveAsync(int educationId)
        {
            await EducationRepository.RemoveAsync(educationId);
        }

        public async Task UpdateAsync(int educationId, Education newEducation)
        {
            await EducationRepository.UpdateAsync(educationId, newEducation);
        }
    }
}