using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Product
    {
        public const int COUNTRY_ID_RUSSIA = 1;
        public const int COUNTRY_ID_USA = 2;
        public const int COUNTRY_ID_GERMANY = 3;
        public const int COUNTRY_ID_JAPAN = 4;
        public const int COUNTRY_ID_KOREA = 5;

        public const int MAX_WEIGHT = 100;
        public const int MAX_AMOUNT = 100;

        public const int COUNT_COUNTRY = 5;
        
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Amount { get; set; }
        private int CountryId { get; set; }

        public Product(int countryId, int weight, int amount, string name)
        {
            this.CountryId = countryId;
            this.Weight = weight;
            this.Amount = amount;
            this.Name = name;
        }

        protected void SetWeight(int weigth)
        {
            if (weigth < 0 || weigth > 100)
            {
                return;
            }
            else
            {
                this.Weight = weigth;
            }
        }


        protected void SetAmount(int amount)
        {
            if (amount < 0 || amount > 100)
            {
                return;
            }
            else
            {
                this.Amount = amount;
            }
        }

        protected void SetCountryId(int id)
        {
            this.CountryId = id;
        }

        protected string GetCountry()
        {
            return GetCountryById(this.CountryId);
        }

        public static string GetCountryById(int countryId)
        {
            switch (countryId)
            {
                case COUNTRY_ID_RUSSIA:
                    return "Россия";
                case COUNTRY_ID_USA:
                    return "США";
                case COUNTRY_ID_GERMANY:
                    return "Германия";
                case COUNTRY_ID_KOREA:
                    return "Корея";
                case COUNTRY_ID_JAPAN:
                    return "Япония";
                default:
                    return "Ошибка: ненайдена страна производства";
            }
        }

        public override string ToString()
        {
            return $"Название: {this.Name}\n" +
                $"Вес: {this.Weight}\n" +
                $"Количество: {this.Amount}\n" +
                $"Страна производства: {this.GetCountry()}\n";
        }
    }
}
