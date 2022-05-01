namespace CardGame.API.Models
{
    public class Card
    {
        public int Order
        {
            get;
            set;
        }

        private string NamedValue(int Value)
        {
                string name = string.Empty;
                switch (Value)
                {
                    case (14):
                        name = "A";
                        break;
                    case (13):
                        name = "K";
                        break;
                    case (12):
                        name = "Q";
                        break;
                    case (11):
                        name = "J";
                        break;
                    default:
                        name = Convert.ToString(Value);
                        break;
                }

                return name;
        }

        public string Name
        {
            get;
            set;
        }

        public Card(int Order, int Value, string Suite)
        {
            this.Order = Order;
            this.Name = NamedValue(Value) + Suite;
        }

        public Card(int Order, string Value)
        {
            this.Order = Order;
            this.Name = Value;
        }
    }
}
