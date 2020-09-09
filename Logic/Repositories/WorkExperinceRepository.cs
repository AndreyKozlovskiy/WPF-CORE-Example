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
    public class WorkExperinceRepository:IWorkExperienceRepository
    {
        public WorkExperinceRepository(IDataContext dataContext)
        {
            WorkExperienceSet = dataContext.Set<WorkExperience>();
        }

        protected DbSet<WorkExperience> WorkExperienceSet { get; private set; }

        public IQueryable<WorkExperience> Get() => WorkExperienceSet;

        public async Task AddAsync(WorkExperience workExperience)
        {
            if (workExperience == null)
            {
                throw new ArgumentException();
            }

            WorkExperienceSet.Attach(workExperience);
            await WorkExperienceSet.AddAsync(workExperience);
        }

        public async Task RemoveAsync(int workExperienceId)
        {
            var skillToRemove = await WorkExperienceSet.FindAsync(workExperienceId);

            WorkExperienceSet.Attach(skillToRemove);
            WorkExperienceSet.Remove(skillToRemove);
        }

        public async Task UpdateAsync(int workExperienceId, WorkExperience newWork)
        {
            var workToChange = await WorkExperienceSet.FindAsync(workExperienceId);

            WorkExperienceSet.Attach(workToChange);

            workToChange.OrghanizationName = newWork.OrghanizationName;
            workToChange.WorkName = newWork.WorkName;
        }
    }
}
