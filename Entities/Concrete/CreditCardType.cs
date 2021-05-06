using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    
    public class CreditCardType : IEntity
    {
        
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}