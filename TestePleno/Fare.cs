using System;

namespace TestePleno.Models
{
    public class Fare : Model
    {
        public Guid OperatorId { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
    }
}