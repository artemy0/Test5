using System;

namespace Task5
{
    class FoodChainLink
    {
        public event EventHandler<int> GrowUp = delegate { };

        public string Name { get; set; }
        public bool IsReady { get; set; } = false;

        public void Grow(int growthTime)
        {
            lock(GrowUp)
            {
                GrowUp(this, growthTime);
                IsReady = true;
            }
        }
    }
}
