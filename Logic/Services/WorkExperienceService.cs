using Domain.Models;
using Domain.Repositories.Contracts;
using Domain.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IWorkExperienceRepository WorkExperienceRepository;
        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository)
        {
            WorkExperienceRepository = workExperienceRepository;
        }

        public async Task AddAsync(WorkExperience workExperience)
        {
            await WorkExperienceRepository.AddAsync(workExperience);
        }

        public WorkExperience Get(int itemId)
        {
            return WorkExperienceRepository.Get().FirstOrDefault(x => x.Id == itemId);
        }

        public async Task RemoveAsync(int workExperienceId)
        {
            await WorkExperienceRepository.RemoveAsync(workExperienceId);
        }

        public async Task UpdateAsync(int workExperienceId, WorkExperience newWorkExperience)
        {
            await WorkExperienceRepository.UpdateAsync(workExperienceId, newWorkExperience);
        }
    }
}
