using FilmClub.Contracts.Utilities;
using FilmClub.Entity.Films.ValiuOBject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Films.Contracts.DTO
{
    public class AddFilmeDTO
    {
        public AddFilmeDTO(string title, int durationPerMinuts, int createdYear, int limitatedAge, int genreId,
            decimal price, decimal delayPenaltyPersantage, decimal rentPrice)
        {
            Guard(title, durationPerMinuts, createdYear, limitatedAge, genreId, price, delayPenaltyPersantage, rentPrice);

            Title = title;
            DurationPerMinuts = durationPerMinuts;
            CreatedYear = createdYear;
            LimitatedAge = limitatedAge;
            GenreId = genreId;
            Price = price;
            DelayPenaltyPersantage = delayPenaltyPersantage;
            RentPrice = rentPrice;
        }

        public string Title { get; set; }
        public int DurationPerMinuts { get; set; }
        public int CreatedYear { get; set; }
        public int LimitatedAge { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public decimal DelayPenaltyPersantage { get; set; }
        public decimal RentPrice { get; set; }

        public void Guard(string title, int durationPerMinuts, int createdYear, int limitatedAge, int genreId,
            decimal price, decimal delayPenaltyPersantage, decimal rentPrice)
        {
            if (!Utility.IsCheckLength(title, 60))
            {
                throw new InvalidDataException();
            }
            else if (durationPerMinuts < 10 || durationPerMinuts > 400)
            {
                throw new InvalidDataException();
            }
            else if (createdYear > 2024 || createdYear < 1500)
            {
                throw new InvalidDataException();
            }
            else if (limitatedAge < 0 || limitatedAge > 22)
            {
                throw new InvalidDataException();
            }
            else if (price < 0 || delayPenaltyPersantage <0 || rentPrice<0)
            {
                throw new InvalidDataException();
            }
        }
    }
}
