using Logic.Contexts;
using Logic.Models;
using Logic.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        public ResumeRepository(IDataContext dataContext)
        {
            ResumeSet = dataContext.Set<Resume>();
        }

        protected DbSet<Resume> ResumeSet { get; private set; }

        public IQueryable<Resume> Get() => ResumeSet;

        public async Task AddAsync(Resume resume)
        {
            if (resume == null)
            {
                throw new ArgumentException();
            }

            ResumeSet.Attach(resume);
            await ResumeSet.AddAsync(resume);
        }

        public async Task RemoveAsync(int resumeId)
        {
            var resumeToRemove = await ResumeSet.FindAsync(resumeId);

            ResumeSet.Attach(resumeToRemove);
            ResumeSet.Remove(resumeToRemove);
        }

        public async Task UpdateAsync(int resumeId, Resume newResume)
        {
            var resumeToChange = await ResumeSet.FindAsync(resumeId);

            ResumeSet.Attach(resumeToChange);

            resumeToChange.ShortDescription = newResume.ShortDescription;
            resumeToChange.FullDescription = newResume.FullDescription;
        }
    }
}
