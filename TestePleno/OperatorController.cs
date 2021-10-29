using System;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class OperatorController
    {
        private OperatorService _operatorService;

        public OperatorController()
        {
            _operatorService = new OperatorService();
        }

        public void GenerateOperators(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var @operator = new Operator();

                @operator.Id = Guid.NewGuid();
                @operator.Code = "OP" + i.ToString("00");

                _operatorService.Create(@operator);
            }
        }
    }
}