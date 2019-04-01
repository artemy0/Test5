namespace Task5
{
    class Herbivore : FoodChainLink
    {
        public Herbivore(string Name)
        {
            this.Name = Name;
        }

        public bool CanEat(Plant plant)
        {
            return plant.IsReady;
        }
    }
}
