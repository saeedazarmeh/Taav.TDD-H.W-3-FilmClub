namespace FilmClub.Service.Films.Contracts.DTO
{
    public class UpdateAmountFilmeDTO
    {
        public UpdateAmountFilmeDTO(decimal price, decimal delayPenaltyPersantage, decimal rentPrice)
        {
            Guard(price, delayPenaltyPersantage, rentPrice);

            Price = price;
            DelayPenaltyPersantage = delayPenaltyPersantage;
            RentPrice = rentPrice;
        }
        public decimal Price { get; set; }
        public decimal DelayPenaltyPersantage { get; set; }
        public decimal RentPrice { get; set; }

        public void Guard( decimal price, decimal delayPenaltyPersantage, decimal rentPrice)
        {
            if (price < 0 || delayPenaltyPersantage < 0 || rentPrice < 0)
            {
                throw new InvalidDataException();
            }
        }
    }
}
