namespace CardGame.API.Models
{
    public class Deck
    {
        public enum Suites
        {
            D = 0,
            S,
            C,
            H
        }

        public List<Card> FillDeck()
        {
            List<string> SpecialCards = new List<string>() { "4T", "2T", "ST", "PT", "RT" };
            List<Card> Cards = new List<Card>();
            {
                var order = 0;
                for (int i = 0; i < SpecialCards.Count; i++, order++)
                {
                    Cards.Add(new Card(order, SpecialCards[i]));
                }
                for (int i = 0; i < 52; i++, order++)
                {
                    Suites suite = (Suites)(Math.Floor((decimal)i / 13));
                    int val = i % 13 + 2;
                    Cards.Add(new Card(order, val, suite.ToString()));
                }
            }
            return Cards;
        }

        public List<string> SortDeck(List<string> cards)
        {
            return this.FillDeck().Where(x => cards.Contains(x.Name)).OrderBy(x => x.Order).Select(x => x.Name).ToList();
        }
    }
}
