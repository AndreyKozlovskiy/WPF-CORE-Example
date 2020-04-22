using Logic.Contexts;
using Logic.Models;
using Logic.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        public SkillRepository(IDataContext dataContext)
        {
            SkillSet = dataContext.Set<Skill>();
        }

        protected DbSet<Skill> SkillSet { get; private set; }

        public IQueryable<Skill> Get() => SkillSet;

        public async Task AddAsync(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentException();
            }

            SkillSet.Attach(skill);
            await SkillSet.AddAsync(skill);
        }

        public async Task RemoveAsync(int skillId)
        {
            var skillToRemove = await SkillSet.FindAsync(skillId);

            SkillSet.Attach(skillToRemove);
            SkillSet.Remove(skillToRemove);
        }

        public async Task UpdateAsync(int skillId, Skill newSkill)
        {
            var SkillToChange = await SkillSet.FindAsync(skillId);

            SkillSet.Attach(SkillToChange);

            SkillToChange.SkillName = newSkill.SkillName;
        }
    }
}
