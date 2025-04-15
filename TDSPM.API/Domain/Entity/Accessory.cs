using TDSPM.API.Domain.Exceptions;

namespace TDSPM.API.Domain.Entity
{
    public class Accessory
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }


        //Relacionamento N..N
        public virtual ICollection<Car> Cars { get; set; }

        public Accessory(string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new DomainException($"Nome do acessorio é obrigatoria");
        }

        public Accessory()
        {
            
        }
    }
}
