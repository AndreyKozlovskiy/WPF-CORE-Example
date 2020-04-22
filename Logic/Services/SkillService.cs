using Logic.Models;
using Logic.Repositories.Contracts;
using Logic.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task AddAsync(Skill Skill)
        {
            await skillRepository.AddAsync(Skill);
        }

        public Skill Get(int itemId)
        {
            return skillRepository.Get().FirstOrDefault(x => x.SkillId == itemId);
        }

        public async Task RemoveAsync(int SkillId)
        {
            await skillRepository.RemoveAsync(SkillId);
        }

        public async Task UpdateAsync(int SkillId, Skill newSkill)
        {
            await skillRepository.UpdateAsync(SkillId, newSkill);
        }
    }
}
