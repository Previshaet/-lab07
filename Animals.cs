namespace library;

public enum eClassificationAnimal
{
    Herbivores,
    Carnivores,
    Omnivores
}

public enum eFavouriteFood
{
    Meat,
    Plants,
    Everything
}

[MyAttribute("Base class for every animals. Eto Baza.")]
public class Animal
{
    public string Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string Name { get; set; }
    public string WhatAnimal { get; set; }

    public Animal(string country = "", bool hideFromOtherAnimals = true, string name = "", string whatAnimal = "")
    {
        Country = country;
        HideFromOtherAnimals = hideFromOtherAnimals;
        Name = name;
        WhatAnimal = whatAnimal;
    }

    public void Deconstruct()
    {

    }
    public eClassificationAnimal GetClassificationAnimal()
    {
        return eClassificationAnimal.Omnivores;
    }
    public virtual eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Everything;
    }
    public virtual string SayHello()
    {
        return "----";
    }
}

[MyAttribute("Cow is herbivorous animal. Grass do hrum hrum")]
public class Cow : Animal
{
    public Cow(string country, string name, bool hideFromOtherAnimals) : base(country, hideFromOtherAnimals, name, "Cow") { }

    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Plants;
    }

    public override string SayHello()
    {
        return "Mooooo (Hellow Good sir. Isn't its a good weather outside?)";
    }
}

[MyAttribute("Lion is carnivore animal. Ya ne kotic, Ya Zveri!")]
public class Lion : Animal
{
    public Lion(string country, string name, bool hideFromOtherAnimals) : base(country, hideFromOtherAnimals, name, "Lion") { }

    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Meat;
    }

    public override string SayHello()
    {
        return "Growl (Meow)";
    }
}

[MyAttribute("pig is omniverse animal. A:This guy just like Pig! B:Dont offend pigs.")]
public class Pig : Animal
{
    public Pig(string country, string name, bool hideFromOtherAnimals) : base(country, hideFromOtherAnimals, name, "Pig") { }

    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Everything;
    }

    public override string SayHello()
    {
        return "Oink (I'm hungry. Let's steal some eggs.)";
    }
}
