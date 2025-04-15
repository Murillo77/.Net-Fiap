using TDSPM.API.Application.DTOs;
using TDSPM.API.Domain.Entity;
using TDSPM.API.Infrastructure.Persistence.Repositories;

namespace TDSPM.API.Application.UseCases
{
    public class CarUserCase
    {
        private readonly IRepository<Car> _repositoryCar;

        private readonly IRepository<Brand> _repositoryBrand;

        public CarUserCase(IRepository<Car> repositoryCar, IRepository<Brand> repositoryBrand)
        {
            _repositoryCar = repositoryCar;
            _repositoryBrand = repositoryBrand;
        }

        public async Task<Car> CreateCar(CreateCarRequest createCarRequest)
        {
            var brand = await _repositoryBrand.GetByIdAsync(createCarRequest.BrandId) ?? throw new Exception("Brand invalid");

            brand.AddCar(createCarRequest.Plate, createCarRequest.Motorization, createCarRequest.March);

            //var car = await _repositoryCar.AddAsync();

            return null;
        }
    }
}
