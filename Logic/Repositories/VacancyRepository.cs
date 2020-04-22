using Logic.Contexts;
using Logic.Models;
using Logic.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        public VacancyRepository(IDataContext dataContext)
        {
            VacancySet = dataContext.Set<Vacancy>();
        }

        protected DbSet<Vacancy> VacancySet { get; private set; }

        public IQueryable<Vacancy> Get() => VacancySet;

        public async Task AddAsync(Vacancy vacancy)
        {
            if (vacancy == null)
            {
                throw new ArgumentException();
            }

            VacancySet.Attach(vacancy);
            await VacancySet.AddAsync(vacancy);
        }

        public async Task RemoveAsync(int vacancyId)
        {
            var vacancyToRemove = await VacancySet.FindAsync(vacancyId);

            VacancySet.Attach(vacancyToRemove);
            VacancySet.Remove(vacancyToRemove);
        }

        public async Task UpdateAsync(int vacancyId, Vacancy newVacancy)
        {
            var vacancyToChange = await VacancySet.FindAsync(vacancyId);

            VacancySet.Attach(vacancyToChange);

            vacancyToChange.ShortDescription = newVacancy.ShortDescription;
            vacancyToChange.FullDescription = newVacancy.FullDescription;
        }
    }
}
