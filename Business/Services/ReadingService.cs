using Business.Models;
using DataAccess.Results;
using DataAccess.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Business.Services.Bases;
using System;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;


namespace Business.Services
{
    public interface IReadingService
    {
        IQueryable<ReadingModel> Query();
        Result Add(ReadingModel model);
        Result Update(ReadingModel model);
        Result Delete(int id);
        List<ReadingModel> GetList();
        ReadingModel GetItem(int id);
    }

    public class ReadingService : ServiceBase, IReadingService
    {
 
        public ReadingService(Db db) : base(db)
        {
        }

        public IQueryable<ReadingModel> Query()
        {
            return _db.Reading.Include(r => r.UserReadings).Select(r => new ReadingModel()
            {
                Explanation = r.Explanation,
                Id = r.Id,
                CreatedAt = r.CreatedAt,
                Price = r.Price,
                TotalSalesPriceOutput = (r.Price).ToString("C2"),
                CreatedAtOutput = r.CreatedAt.ToString("MM/dd/yyyy"),
                TarotCards = r.TarotCard.Select(ug => new TarotCardModel()
                {
                    CardName = " "+ ug.CardName,
                }).ToList(),
            });
        }

        public Result Add(ReadingModel model)
        {
            Reading entity = new Reading()
            {
                Explanation= model.Explanation,
                CreatedAt = (DateTime)model.CreatedAt,
                Price = (decimal)model.Price,

            };
            _db.Reading.Add(entity);
            _db.SaveChanges();

            TarotCard tempCard = new TarotCard();
            for (int i = 0; i < 5; i++)
            {
                tempCard = new TarotCard()
                {
                    ReadingId = entity.Id,
                    CardName = RandomString(6)
                };
                _db.TarotCard.Add(tempCard);
                _db.SaveChanges(true);
            }
            return new SuccessResult("Reading added successfully.");
        }

        public Result Update(ReadingModel model)
        {
            Reading entity = _db.Reading.Include(r => r.UserReadings).SingleOrDefault(r => r.Id == model.Id);
            if (entity is null)
                return new ErrorResult("Fal not found!");

            entity.Explanation = model.Explanation;
            entity.Price = (decimal)model.Price;
            entity.CreatedAt = (DateTime)model.CreatedAt;
            _db.Reading.Update(entity);
            _db.SaveChanges();
            return new SuccessResult("Reading updated successfully.");
        }

        public Result Delete(int id)
        {
            var entity = _db.Reading.Include(r => r.UserReadings).SingleOrDefault(r => r.Id == id);
            if (entity is null)
                return new ErrorResult("Reading not found!");

            _db.UserReading.RemoveRange(entity.UserReadings);

            _db.Reading.Remove(entity);

            _db.SaveChanges();

            return new SuccessResult("Reading deleted successfully.");
        }

        public List<ReadingModel> GetList()
        {
            return Query().ToList();
        }
        public ReadingModel GetItem(int id) => Query().SingleOrDefault(r => r.Id == id);

    }

}