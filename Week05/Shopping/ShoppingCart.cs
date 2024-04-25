namespace Week05
{
    internal class ShoppingCart
    {
        private List<CartItem> Items = new();

        public ShoppingCart() 
        {
        }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }

        public int CalculateTotal()
        {
            var total = 0;
            foreach (var item in Items)
            {
                total += item.CalculatePrice();
            }
            return total;
        }
    }
}
