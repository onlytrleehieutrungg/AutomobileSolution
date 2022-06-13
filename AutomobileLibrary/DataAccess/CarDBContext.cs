using System;
using System.Collections.Generic;
using System.Linq;
using AutomobileLibrary.BussinessObject;

namespace AutomobileLibrary.DataAccess
{
	public class CarDBContext
	{

		private static List<Car> CarList = new List<Car>()
		{
			new Car{ CarId=1,Carname="CRV",Manufacturer="Honda",Price=3000,ReleaseYear=2021}
		};
		private CarDBContext() { }
		private static CarDBContext instance = null;
		private static readonly object instanceLock = new object();

		public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }

        public List<Car> GetCars => CarList;

        public Car GetCarByID(int carID)
        {
            Car car = CarList.SingleOrDefault(pro => pro.CarId == carID);
            return car;
        }

        public void AddNewCar(Car car)
        {
            Car pro = GetCarByID(car.CarId);
            if(pro == null)
            {
                CarList.Add(pro);
            }
            else
            {
                throw new Exception("Car already exists.");

            }
        }
        public void UpdateCar(Car car)
        {
            Car pro = GetCarByID(car.CarId);
            if (pro != null)
            {
                var index = CarList.IndexOf(pro);
                CarList[index] = pro;
            }
            else
            {
                throw new Exception("Car dose not already exists.");

            }
        }

        public void Remove(int CarID)
        {
            Car p = GetCarByID(CarID);
            if (p != null)
            {
                CarList.Remove(p);
            }
            else{
                throw new Exception("Car dose not already exists.");
            }
        }

    }
}

