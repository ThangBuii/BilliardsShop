using System.Text.Json;

namespace Client
{
    public class CartManager
    {
        private ISession _session;
        private Dictionary<int, int> _cart;

        public CartManager(ISession session)
        {
            _session = session;
            if (session.GetString("cart") != null)
            {
                string data = _session.GetString("cart");
                _cart = JsonSerializer.Deserialize<Dictionary<int, int>>(data);
            }
            if (_cart == null)
            {
                _cart = new Dictionary<int, int>();
                _session.SetString("cart", JsonSerializer.Serialize(_cart));
            }

        }

        public void AddToCart(int productId)
        {
            if (_cart.ContainsKey(productId))
            {
                _cart[productId]++;

            }
            else
                _cart.Add(productId, 1);
            _session.SetString("cart", JsonSerializer.Serialize(_cart));
        }

        public void AddToCart(int productId, int quantity)
        {
            if (_cart.ContainsKey(productId))
            {
                _cart[productId]+=quantity;

            }
            else
                _cart.Add(productId, quantity);
            _session.SetString("cart", JsonSerializer.Serialize(_cart));
        }

        public Dictionary<int, int> GetProducts()
        {
            return _cart;
        }
    }
}
