namespace FilmClub.Entity.Films.ValiuOBject
{
    public class Amount
    {
        public Amount(decimal price, decimal delayPenaltyPersantage, decimal rentPrice)
        {
            Price = price;
            DelayPenaltyPersantage = delayPenaltyPersantage;
            RentPrice = rentPrice;
        }

        public decimal Price { get; private set; }
        public decimal DelayPenaltyPersantage { get; private set; }
        public decimal RentPrice { get; private set; }
    }
}
