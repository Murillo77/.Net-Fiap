using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TDSPM.API.Application.DTOs;
using TDSPM.API.Application.UseCases;
using TDSPM.API.Application.Validators;
using TDSPM.API.Domain.Entity;
using TDSPM.API.Infrastructure.Context;
using TDSPM.API.Infrastructure.Persistence.Repositories;

namespace TDSPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("CRUD Car")]
    public class CarsController : ControllerBase
    {
        private readonly IRepository<Car> _repositoryCar;

        private readonly IRepository<Brand> _repositoryBrand;

        private readonly CarUserCase _CarUserCase;


        public CarsController(IRepository<Car> repositoryCar, IRepository<Brand> repositoryBrand, CarUserCase CarUserCase)
        {
            _repositoryCar = repositoryCar;
            _repositoryBrand = repositoryBrand;
            _CarUserCase = CarUserCase;
        }

        // GET: api/Cars
        /// <summary>
        /// Get all cars
        /// </summary>
        /// <returns>Return list of car</returns>
        /// <response code="200">Cars found</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _repositoryCar.GetAllAsync();
        }

        // GET: api/Cars/5
        /// <summary>
        /// Get car by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Car>> GetCar(Guid id)
        {
            var car = await _repositoryCar.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update car
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutCar(Guid id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _repositoryCar.Update(car);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CarExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Car>> PostCar(CreateCarRequest createCarRequest)
        {
            var createCarRequestValidator = new CreateCarRequestValidator();
            try
            {
                createCarRequestValidator.ValidateMessage(createCarRequest);
            }
            catch (ValidationException ex)
            {

                var x = ex.Message;
                throw;
            }

            Task<Car> car = _CarUserCase.CreateCar(createCarRequest);
       
            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var car = await _repositoryCar.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _repositoryCar.Delete(car);
            //await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
