using System.Text.RegularExpressions;
using TDSPM.API.Domain.Enums;
using TDSPM.API.Domain.Exceptions;

namespace TDSPM.API.Domain.Entity
{
    public class Car
    {
        public Guid Id { get; private set; } /* EX: 550e8400-e29b-41d4-a716-446655440000*/
   
        public string Plate { get; private set; }

        //Relacionamento 1..1
        public Guid BrandId { get; private set; }
        public virtual Brand Brand { get; set; }

        //Relacionamento N..N
        public virtual ICollection<Accessory> Accessories { get; set; }

        public string Motorization { get; private set; }

        public MarchType March { get; private set; }

        public Car(string plate, Guid brandId, string motorization, MarchType marchType)
        {
            VerifyPlate(plate);

            Id = Guid.NewGuid();
            Plate = plate;
            BrandId = brandId;
            Motorization = motorization ?? throw new DomainException($"Motorizacao é obrigatoria");
            March = marchType; 
        }

        private void VerifyPlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate))
                throw new DomainException($"Placa é obrigatoria");

            if (plate.Length < 7)      
                throw new DomainException($"Placa incorreta {plate}, verifique antes de criar");

            var regex = new Regex(@"^[A-Z]{3}\d{4}$|^[A-Z]{3}[0-9][A-Z][0-9]{2}$", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(plate))
                throw new DomainException($"Placa invalida {plate}");
        }

        internal static Car Create(string plate, string motorization, MarchType marchType, Guid brandId)
        {
            return new Car(plate, brandId, motorization, marchType);
        }

        public Car()
        {
            
        }
    }    
}
