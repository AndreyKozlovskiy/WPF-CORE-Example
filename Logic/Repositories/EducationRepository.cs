using Domain.Contexts;
using Domain.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class EducationRepository :IEducationRepository
    {
        public EducationRepository(IDataContext dataContext)
        {
            EducationSet = dataContext.Set<Education>();
        }

        protected DbSet<Education> EducationSet { get; private set; }

        public IQueryable<Education> Get() => EducationSet;

        public async Task AddAsync(Education Education)
        {
            if (Education == null)
            {
                throw new ArgumentException();
            }

            EducationSet.Attach(Education);
            await EducationSet.AddAsync(Education);
        }

        public async Task RemoveAsync(int EducationId)
        {
            var skillToRemove = await EducationSet.FindAsync(EducationId);

            EducationSet.Attach(skillToRemove);
            EducationSet.Remove(skillToRemove);
        }

        public async Task UpdateAsync(int EducationId, Education newEducation)
        {
            var educationToChange = await EducationSet.FindAsync(EducationId);

            EducationSet.Attach(educationToChange);

            educationToChange.EducationName = newEducation.EducationName;
            educationToChange.OrghanisationName = newEducation.OrghanisationName;
        }
    }
}
