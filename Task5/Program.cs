using System;
using System.Threading;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Plant carrot = new Plant("carrot");
            carrot.GrowUp += Growing;//growing
            carrot.GrowUp += (sender, growthTime) => { Thread.Sleep(growthTime / 5); }; //lifespan
            //the method of causing the life cycle of a carrot
            carrot.Grow(800);

            Console.WriteLine();



            Herbivore rabbit = new Herbivore("rabbit");
            rabbit.GrowUp += (sender, growthTime) => { Console.WriteLine($"{rabbit.Name} ate {carrot.Name}"); }; //nutrition
            rabbit.GrowUp += Growing; //growing
            rabbit.GrowUp += (sender, growthTime) => { Thread.Sleep(growthTime / 5); }; //lifespan
            //the method of causing the life cycle of a rabbit
            if (rabbit.CanEat(carrot))
                rabbit.Grow(1500);

            Console.WriteLine();



            Carnivore wolf = new Carnivore("wolf");
            wolf.GrowUp += (sender, growthTime) => { Console.WriteLine($"{wolf.Name} ate {rabbit.Name}"); }; //nutrition
            wolf.GrowUp += Growing; //growing
            wolf.GrowUp += (sender, growthTime) => { Thread.Sleep(growthTime / 5); }; //lifespan
            //the method of causing the life cycle of a wolf
            if (wolf.CanEat(rabbit))
                wolf.Grow(2000);

            Console.ReadKey();
        }

        public static void Growing(object sender, int growthTime)
        {
            Thread.Sleep(growthTime);
            Console.WriteLine($"{((FoodChainLink)sender).Name} grew."); //FoodChainLink suitable for everyone
        }
    }
}



