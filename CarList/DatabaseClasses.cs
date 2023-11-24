using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarList
{


    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int Mileage { get; set; }
        public int EngineCapacity { get; set; }
        public int EnginePower { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public string Gearbox { get; set; }
        public string BodyType { get; set; }
        public string CountryOfOrigin { get; set; }

        public string VIN { get; set; }

        //its in cents/grosze
        public int Price { get; set; }

    }
    public class Database
    {
        static SQLiteConnection getDB()
        {
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CarList.db");

            SQLiteConnection db = new SQLiteConnection(databasePath);
            db.CreateTable<Car>();
     /*       Car car = new Car()
            {
                Make = "Toyota",
                Model = "Gruz",
                YearOfProduction = 2005,
                Mileage = 200000,
                EngineCapacity = 2000,
                EnginePower = 140,
                Color = "Biały",
                FuelType = "Benzyna",
                Gearbox = "Automatyczna",
                BodyType = "SUV",
                CountryOfOrigin = "Rosja",
                VIN = "12345678901234567",
                Price = 125
            };
            db.Insert(car);*/
            return db;
        }
        static public List<Car> getCars()
        {
            SQLiteConnection db = getDB();
            List<Car> cars = db.Table<Car>().ToList();
            return cars;
        }

        static public void removeCar(int id)
        {
            SQLiteConnection db = getDB();
            var car = db.Table<Car>().Where(v => v.Id == id).First();
            db.Delete(car);
        }

        static public void addCar(Car car)
        {
            SQLiteConnection db = getDB();
            db.Insert(car);
        }
        static public Car getCar(int id)
        {
            SQLiteConnection db = getDB();
            var car = db.Table<Car>().Where(v => v.Id == id).First();
            return car;
        }
    }
}
