namespace Task5
{
    class Carnivore : FoodChainLink
    {
        public Carnivore(string Name)
        {
            this.Name = Name;
        }

        public bool CanEat(Herbivore herbivore)
        {
            return herbivore.IsReady;
        }
    }
}
