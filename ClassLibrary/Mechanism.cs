using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Mechanism : Product
    {
        public const int TYPE_ID_LEVER = 1;
        public const int TYPE_ID_SCREW = 2;

        public const int COUNT_TYPES = 2;

        public const int MAX_DIFFICULTY = 5;

        private int TypeId { get; set; }
        public int Difficulty { get; set; }
        public string Purpose { get; set; }

        public Mechanism(
            int countryId,
            int weight,
            int amount,
            string name,
            int typeId,
            int difficulty,
            string purpose)
            : base (
                  countryId,
                  weight,
                  amount,
                  name)
        {
            this.TypeId = typeId;
            this.Difficulty = difficulty;
            this.Purpose = purpose;
        }

        public void SetType(int typeId)
        {
            if (typeId < 1 || typeId > COUNT_TYPES)
            {
                return;
            }
            else
            {
                this.TypeId = typeId;
            }
        }

        public string GetType()
        {
            return GetTypeById(this.TypeId);
        }

        public static string GetTypeById(int typeId)
        {
            switch (typeId)
            {
                case TYPE_ID_LEVER:
                    return "Рычажный";
                case TYPE_ID_SCREW:
                    return "Винтовой";
                default:
                    return "Ошибка: ненайден тип механизма";
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $"Тип механизма: {this.GetType()}\n" +
                $"Сложность: {this.Difficulty}\n" +
                $"Цель: {this.Purpose}\n";
        }
    }
}
