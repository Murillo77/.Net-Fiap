using System.ComponentModel.DataAnnotations;
using TDSPM.API.Domain.Enums;

namespace TDSPM.API.Application.DTOs
{
    public class CreateCarRequest
    {      
        public string Plate { get; set; }
        public string Motorization { get; set; }
        public MarchType March { get; set; }      
        public Guid BrandId { get; set; }
    }
}
