using System.Collections;
using System.Collections.Generic;
using Coffee.core;
using System;
using System.Linq;
using System.Text;

namespace Coffee.Data
{
    public interface ICoffeeData
    {
        //methods
        IEnumerable<core.Coffee> GetCoffeeByLocation(string location); //method that gets all coffee data by location
        core.Coffee GetbyId(int id);
        core.Coffee Update(core.Coffee updatedCoffee); //returns updated Coffee Data

        core.Coffee Add(core.Coffee newCoffee); //method for adding new coffee data
        int Commit(); //after make a change to an entit
        
    }

    public class InMemoryCoffeeData : ICoffeeData
    {
        List<core.Coffee> _coffees;
        
        public InMemoryCoffeeData()
        {
            //in memory data currently, but will implement database soon
            _coffees = new List<core.Coffee>() //hardcoded list of data, will implement database eventually
            {
                new core.Coffee {Id = 1, BrandName = "flyingM", Age = 25, Location = "Idaho", Roast = RoastType.Light},
                new core.Coffee {Id = 2, BrandName = "starbucks", Age = 35, Location = "Oregon", Roast = RoastType.Dark},
                new core.Coffee {Id = 3, BrandName = "seattleCoffee", Age= 40, Location = "Montana", Roast = RoastType.Medium}

            };
            
        }

        public core.Coffee GetbyId(int id) //gets coffee by ID method
        {
            return _coffees.SingleOrDefault(c => c.Id == id); //returns id or a null
        }

        public core.Coffee Add(core.Coffee newCoffee) //function for adding new coffee data
        {
            _coffees.Add(newCoffee); //adds new coffee data
            newCoffee.Id = _coffees.Max(c => c.Id)+ 1; //only for testing use really, getting highest Id and adding one to it, for adding new row of coffee data
            return newCoffee; //returns new data user added

        }
        public core.Coffee Update(core.Coffee updatedCoffee) //updating method
        {
            var coffee = _coffees.SingleOrDefault(c => c.Id == updatedCoffee.Id);
            if (coffee != null)
            {
                //for the updated information
                coffee.BrandName = updatedCoffee.BrandName;
                coffee.Location = updatedCoffee.Location;
                coffee.Roast = updatedCoffee.Roast;
            }

            return coffee;
        }
        public int Commit()
        {
            return 0; //this method will be implemented once I use a real data source
        }
        public IEnumerable<core.Coffee> GetCoffeeByLocation(string location = null)
        {
            //using a query to search for coffee data by location is was bought at
            return from c in _coffees 
                where string.IsNullOrEmpty(location) || c.Location.StartsWith(location)
                orderby c.Age
                select c;
        }
        
    }
}