namespace Week05
{
    internal class CartItem
    {
        private string Product { get; set; }
        private int Price { get; set; }

        public CartItem(string product, int price)
        {
            Product = product;
            Price = price;
        }
        public int CalculatePrice()
        {
            return Price;
        }
    }
}
