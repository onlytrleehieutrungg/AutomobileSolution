using System;
using System.Collections.Generic;
using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void AddCar(Car car) => CarDBContext.Instance.AddNewCar(car);


        public void DeleteCar(int carId) => CarDBContext.Instance.Remove(carId);

        public Car GetCarById(int carId) => CarDBContext.Instance.GetCarByID(carId);

        public IEnumerable<Car> GetCars() => CarDBContext.Instance.GetCars;

        public void UpdateCar(Car car) => CarDBContext.Instance.UpdateCar(car);
    }
}

