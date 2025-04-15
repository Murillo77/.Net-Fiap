using TDSPM.API.Domain.Enums;
using TDSPM.API.Domain.Exceptions;

namespace TDSPM.API.Domain.Entity
{
    public class Brand /*Marca ou Montadora*/
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        //Relacionamento 1..N
        private readonly List<Car> _cars = new();

        public IReadOnlyCollection<Car> Cars => _cars.AsReadOnly();

        public void AddCar(string plate, string motorization, MarchType march)
        {
            var car = Car.Create(plate, motorization, march, Id);
            _cars.Add(car);
        }

        public Brand(string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new DomainException($"Nome da brand é obrigatoria");
        }

        private Brand()
        {          
        }
    }
}
