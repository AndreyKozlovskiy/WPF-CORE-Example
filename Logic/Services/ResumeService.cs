using Domain.Models;
using Domain.Repositories.Contracts;
using Domain.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository resumeRepository;
        public ResumeService(IResumeRepository resumeRepository)
        {
            this.resumeRepository = resumeRepository;
        }

        public async Task AddAsync(Resume resume)
        {
            await resumeRepository.AddAsync(resume);
        }

        public Resume Get(int itemId)
        {
            return resumeRepository.Get().FirstOrDefault(x => x.ResumeId == itemId);
        }

        public async Task RemoveAsync(int resumeId)
        {
            await resumeRepository.RemoveAsync(resumeId);
        }

        public async Task UpdateAsync(int resumeId, Resume newResume)
        {
            await resumeRepository.UpdateAsync(resumeId, newResume);
        }
    }
}
