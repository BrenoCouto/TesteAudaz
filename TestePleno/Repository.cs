using System;
using System.Collections.Generic;
using System.Linq;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class Repository<T> where T : Model
    {
        private static List<T> _fakeDatabase = new List<T>();

        public void Insert(T model)
        {
            if (model.Id == Guid.Empty)
                throw new Exception("Não é possível salver um registro com Id não preenchido");

            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == model.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name}' com o Id '{model.Id}'");

            _fakeDatabase.Add(model);
        }

        public void Update(T model)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Id}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }

        public T GetById<TModel>(Guid id)
        {
            var model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
            return model as T;
        }

        public List<T> GetAll<TModel>()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T)));
            var convertedModels = allModels.Select(genericModel => genericModel as T).ToList();
            return convertedModels;
        }
    }
}