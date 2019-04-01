using System;
using System.Threading.Tasks;
using System.Threading;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Plant carrot = new Plant("carrot");
            carrot.GrowUp += Growing;//growing
            carrot.GrowUp += Living; //lifespan
            //let's start with the carrot
            carrot.Grow(1500);



            Herbivore rabbit = new Herbivore("rabbit");
            rabbit.GrowUp += (sender, growthTime) => { Console.WriteLine($"{rabbit.Name} ate {carrot.Name}"); }; //nutrition
            rabbit.GrowUp += Growing; //growing
            rabbit.GrowUp += Living; //lifespan
            //the rabbit eats carrots, grows up, lives, dies
            Task.Run(() =>
            {
                while (true)
                {
                    if (rabbit.CanEat(carrot))
                    {
                        rabbit.Grow(3000);
                        carrot.IsReady = false;
                    }
                }
            });



            Carnivore person = new Carnivore("person");
            person.GrowUp += (sender, growthTime) => { Console.WriteLine($"{person.Name} ate {rabbit.Name}"); }; //nutrition
            person.GrowUp += Growing; //growing
            person.GrowUp += (sender, growthTime) => { Console.WriteLine("The person planted a carrot."); }; //Sadim plants thus closes the circuit.
            person.GrowUp += Living; //lifespan
            //the person eats rabbit, grows up, plants carrot, lives, dies
            Task.Run(() =>
            {
                while (true)
                {
                    if (person.CanEat(rabbit))
                    {
                        person.Grow(4000);
                        rabbit.IsReady = false;
                    }
                }
            });



            //carrots planted by man grows up, lives, dies
            Task.Run(() =>
            {
                while (true)
                {
                    if (person.IsReady)
                    {
                        carrot.Grow(1500);
                        person.IsReady = false;
                    }
                }
            });



            Console.ReadKey();
        }

        public static void Growing(object sender, int growthTime)
        {
            Thread.Sleep(growthTime);
            Console.WriteLine($"{((FoodChainLink)sender).Name} grew."); //FoodChainLink suitable for everyone
        }

        public static void Living(object sender, int growthTime)
        {
            Thread.Sleep(growthTime / 5);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}



