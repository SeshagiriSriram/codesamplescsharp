using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp.training.congruent.classes
{
    [Table("Foods", Schema = "training")]

    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public override string ToString()
            => $"{Name} ({Type})";  
        
    }

    public abstract class Animal
    {
        protected string _species = string.Empty;
        public Animal(string name) {
            this.Name = name;
            this._species = string.Empty;
            //this.Species = string.Empty;    
        }
        public Animal(string name, string species)
        {
            this.Name = name?? string.Empty;
            this.Species = species?? string.Empty;
        }


        public int Id { get; set; }
        public string Name { get; set; }
       public  abstract string Species { get; set; } 

        public Food? Food { get; set; }
    }

    public abstract class Pet(string name) : Animal(name)
    {
        public string? Vet { get; set; }

        public ICollection<Human> Humans { get; } = [];
    }

    [Table("FarmAnimals", Schema = "training")]

    public class FarmAnimal: Animal
   {
        public FarmAnimal(string name) : base(name)
        {
            if(string.IsNullOrEmpty(Species))
            {
                Species = "Unknown Species";
            }
            if(string.IsNullOrEmpty(name)) {
                Name= "Unnamed Farm Animal";
            }

        }
        public FarmAnimal(string  name, string species) : base(name, species)
        {
            this.Name = name??  "Unnamed Farm Animal";  
            this.Species = species?? "Unknown Species";
        }
        public override string Species
        {
            get; set; 
        }

        [Precision(18, 2)]
        public decimal Value { get; set; }

        public override string ToString()
            => $"Farm animal '{Name}' ({Species}/{Id}) worth {Value:C} eats {Food?.ToString() ?? "<Unknown>"}";
    }

    [Table("Cats", Schema = "training")]
    public class Cat(string name, string educationLevel) : Pet(name)
    {
        public string EducationLevel { get; set; } = educationLevel;
        public override string Species {
            get { return _species ;  }  
            set { _species = "Felis catus"; }    
        }

        public override string ToString()
            => $"Cat '{Name}' ({Species}/{Id}) with education '{EducationLevel}' eats {Food?.ToString() ?? "<Unknown>"}";
    }
    [Table("Dogs", Schema = "training")]
    public class Dog(string name, string favoriteToy) : Pet(name)
    {
        public string FavoriteToy { get; set; } = favoriteToy;
        public override string Species
        {
            get { return _species; }
            set { _species = "Canis familiaris"; }
        }
        public override string ToString()
            => $"Dog '{Name}' ({Species}/{Id}) with favorite toy '{FavoriteToy}' eats {Food?.ToString() ?? "<Unknown>"}";
    }
    [Table("Humans", Schema = "training")]
    public class Human(string name) : Animal(name)
    {
       
        public override string Species
        {
            get { return _species; }
            set { _species = "Homo sapiens"; }
        }
        public Animal? FavoriteAnimal { get; set; }
        public ICollection<Pet> Pets { get; } = [];

        public override string ToString()
            => $"Human '{Name}' ({Species}/{Id}) with favorite animal '{FavoriteAnimal?.Name ?? "<Unknown>"}'" +
               $" eats {Food?.ToString() ?? "<Unknown>"}";
    }
}

