using Logic.Models;
using Logic.Repositories.Contracts;
using Logic.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository VacancyRepository;
        public VacancyService(IVacancyRepository VacancyRepository)
        {
            this.VacancyRepository = VacancyRepository;
        }

        public async Task AddAsync(Vacancy Vacancy)
        {
            await VacancyRepository.AddAsync(Vacancy);
        }

        public Vacancy Get(int itemId)
        {
            return VacancyRepository.Get().FirstOrDefault(x => x.VacancyId == itemId);
        }

        public async Task RemoveAsync(int VacancyId)
        {
            await VacancyRepository.RemoveAsync(VacancyId);
        }

        public async Task UpdateAsync(int VacancyId, Vacancy newVacancy)
        {
            await VacancyRepository.UpdateAsync(VacancyId, newVacancy);
        }
    }
}
