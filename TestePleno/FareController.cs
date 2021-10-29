using System;
using System.Linq;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService _fareService;

        public FareController()
        {
            _operatorService = new OperatorService();
            _fareService = new FareService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var @operator = _operatorService.GetOperatorByCode(operatorCode);
            var operatorFares = _fareService.GetAllByOperatorId(@operator.Id);

            if (operatorFares.Any(i => i.Status == 1))
            {
                Console.WriteLine("Não é possível cadastrar tarifa em uma operadora inexistente!");
                Environment.Exit(0);
            }
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            fare.OperatorId = selectedOperator.Id;

            _fareService.Create(fare);
        }
    }
}