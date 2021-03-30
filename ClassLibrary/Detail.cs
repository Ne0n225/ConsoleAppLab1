using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Detail : Product
    {
        public const int MATERIAL_ID_IRON = 1;
        public const int MATERIAL_ID_STEEL = 2;
        public const int MATERIAL_ID_ALUMINUM = 3;

        public const int COUNT_MATERIAL = 3;

        public const int MIN_YEAR_MAKE = 2007;

        private int YearMake { get; set; }
        private int MaterialId { get; set; }
        public string Description { get; set; }

        public Detail(
            int weight,
            int amount,
            string name,
            int countryId,
            int yearMake,
            int materialId,
            string description)
            : base(
                  countryId,
                  weight,
                  amount,
                  name)
        {
            this.YearMake = yearMake;
            this.MaterialId = materialId;
            this.Description = description;
        }

        public int GetYearMake()
        {
            return this.YearMake;
        }

        public void SetYearMake(int year)
        {
            if (year < MIN_YEAR_MAKE || year > DateTime.Now.Year)
            {
                return;
            }
            else
            {
                this.YearMake = year;
            }
        }

        public string GetMaterial()
        {
            return GetMaterialById(this.MaterialId);
        }

        public void SetMaterialId(int materialId)
        {
            this.MaterialId = materialId;
        }

        public static string GetMaterialById(int materialId)
        {
            switch (materialId)
            {
                case MATERIAL_ID_ALUMINUM:
                    return "Алюминий";
                case MATERIAL_ID_IRON:
                    return "Железо";
                case MATERIAL_ID_STEEL:
                    return "Сталь";
                default:
                    return "Ошибка: ненайден материал детали";
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $"Дата производства: {this.YearMake}\n" +
                $"Материал: {this.GetMaterial()}\n" +
                $"Описание: {this.Description}\n" ;
        }
    }
}
