using System;

namespace _01.PrototypePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();
            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Paenut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Letuce, Onion, Tomato");

            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Letuce, TOmato, Onion, Olives");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Letuce, Onion");
            sandwichMenu["Vegetarian"] = new Sandwich("Wheat", "", "", "Letuce, Onion, Tomato, Olive, Spanach");
        
        Sandwich s1=sandwichMenu["BLT"].Clone() as Sandwich;
        Sandwich s2=sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
        Sandwich s3=sandwichMenu["Vegetarian"].Clone() as Sandwich;



        }
    }
}
