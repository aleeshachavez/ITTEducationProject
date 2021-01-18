using System.ComponentModel.DataAnnotations;

namespace Coffee.core
{
    public class Coffee
    {
        
        //defining the properties in the Coffee Data, will add more as I think of useful marketing data
        public int Id { get; set; } //for storing coffee data in a database... eventually 
        
        [Required] //makes brandname a requirement, so user cant leave it blank when editing data
        public string BrandName { get; set; } //for storing name of coffee bag
        public int Age { get; set; } //age of the consumer
        
        [Required] //makes location of purchase required
        public string Location { get; set; } //location of product purchase
        public RoastType Roast { get; set; } //for the roast types in RoastType.cs 


    }
}