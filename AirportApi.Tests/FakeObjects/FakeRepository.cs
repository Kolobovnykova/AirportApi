using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using Shared.Exceptions;

namespace AirportApi.Tests.FakeObjects
{
//    public class FakeRepository<T> : IRepository<T> where T : Entity
//    {
//        public List<T> Data;
//
//        public FakeRepository()
//        {
//        }
//
//        public FakeRepository(List<T> data)
//        {
//            Data = data;
//        }
//
//        public List<T> GetAll()
//        {
//            return Data;
//        }
//
//        public T Get(int id)
//        {
//            return Data.FirstOrDefault(x => x.Id == id);
//        }
//
//        public void Create(T entity)
//        {
//            Data.Add(entity);
//        }
//
//        public void Update(T entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity));
//            }
//
//            var oldEntity = Data.Find(x => x.Id == entity.Id);
//            if (oldEntity == null)
//            {
//                throw new NotFoundException(nameof(oldEntity));
//            }
//
//            Data[oldEntity.Id] = entity;
//        }
//
//        public void Delete(int id)
//        {
//            var entity = Data.Find(i => i.Id == id);
//            if (entity == null)
//            {
//                throw new NotFoundException(nameof(entity));
//            }
//
//            Data.Remove(entity);
//        }
//    }
}