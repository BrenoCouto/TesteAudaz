using System;
using System.Collections.Generic;
using System.Linq;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class FareService
    {
        private Repository<Fare> _repository = new Repository<Fare>();

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public List<Fare> GetAllByOperatorId(Guid operatorGuid)
        {
            var fares = _repository.GetAll<Fare>();
            var selectedFares = fares.Where(o => o.OperatorId == operatorGuid).ToList();
            return selectedFares;
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }
    }
}