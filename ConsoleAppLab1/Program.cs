using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;

namespace ConsoleAppVadim
{
    class Program
    {
        public static List<Detail> Details = new List<Detail>();
        public static List<Mechanism> Mechanisms = new List<Mechanism>();
        public static List<Knot> Knots = new List<Knot>();

        static void Main(string[] args)
        {
            bool active = true;

            while (active)
            {
                Console.Clear();

                Console.WriteLine("Выберите пункт меню, введя номер пункта\n" +
                    "1.Добавить элемент изделия\n" +
                    "2.Показать все элементы\n" +
                    "3.Закончить работу программы");

                switch (InputInt(1, 3))
                {
                    case 1:
                        Console.Clear();
                        AddProduct();
                        break;
                    case 2:
                        Console.Clear();
                        PrintProducts();
                        Console.ReadKey();
                        break;
                    case 3:
                        active = false;
                        break;
                }
            }
        }

        public static void AddProduct()
        {
            Console.WriteLine("Выберите товар который вы хотите добавить, введя номер пункта\n" +
                "1.Детали\n" +
                "2.Механизм\n" +
                "3.Узел\n");

            switch (InputInt(1, 3))
            {
                case 1:
                    Console.Clear();
                    AddDetail();
                    break;
                case 2:
                    Console.Clear();
                    AddMechanism();
                    break;
                case 3:
                    Console.Clear();
                    AddKnot();
                    break;
            };
        }

        public static void AddDetail()
        {
            Console.WriteLine("Введите название: ");
            string name = InputString();

            Console.WriteLine("Введите вес: ");
            int weight = InputInt(1, Product.MAX_WEIGHT);

            Console.WriteLine("Введите количество: ");
            int amount = InputInt(1, Product.MAX_AMOUNT);

            Console.WriteLine("Выберите страну производства:\n" +
                $"{Product.COUNTRY_ID_RUSSIA}.{Product.GetCountryById(Product.COUNTRY_ID_RUSSIA)}\n" +
                $"{Product.COUNTRY_ID_USA}.{Product.GetCountryById(Product.COUNTRY_ID_USA)}\n" +
                $"{Product.COUNTRY_ID_GERMANY}.{Product.GetCountryById(Product.COUNTRY_ID_GERMANY)}\n" +
                $"{Product.COUNTRY_ID_JAPAN}.{Product.GetCountryById(Product.COUNTRY_ID_JAPAN)}\n" +
                $"{Product.COUNTRY_ID_KOREA}.{Product.GetCountryById(Product.COUNTRY_ID_KOREA)}\n");
            int countryId = InputInt(1, Product.COUNT_COUNTRY);

            Console.WriteLine("Введите год производства: ");
            int yearMake = InputInt(Detail.MIN_YEAR_MAKE, DateTime.Now.Year);

            Console.WriteLine("Выберите материал:\n" +
                $"{Detail.MATERIAL_ID_IRON}.{Detail.GetMaterialById(Detail.MATERIAL_ID_IRON)}\n" +
                $"{Detail.MATERIAL_ID_STEEL}.{Detail.GetMaterialById(Detail.MATERIAL_ID_STEEL)}\n" +
                $"{Detail.MATERIAL_ID_ALUMINUM}.{Detail.GetMaterialById(Detail.MATERIAL_ID_ALUMINUM)}\n");
            int materialId = InputInt(1, Detail.COUNT_MATERIAL);

            Console.WriteLine("Введите описание детали: ");
            string description = InputLongString();

            Details.Add(new Detail(weight, amount, name, countryId, yearMake, materialId, description));
        }

        public static void AddMechanism()
        {
            Console.WriteLine("Введите название: ");
            string name = InputString();

            Console.WriteLine("Введите вес: ");
            int weight = InputInt(1, Product.MAX_WEIGHT);

            Console.WriteLine("Введите количество: ");
            int amount = InputInt(1, Product.MAX_AMOUNT);

            Console.WriteLine("Выберите страну производства:\n" +
                $"{Product.COUNTRY_ID_RUSSIA}.{Product.GetCountryById(Product.COUNTRY_ID_RUSSIA)}\n" +
                $"{Product.COUNTRY_ID_USA}.{Product.GetCountryById(Product.COUNTRY_ID_USA)}\n" +
                $"{Product.COUNTRY_ID_GERMANY}.{Product.GetCountryById(Product.COUNTRY_ID_GERMANY)}\n" +
                $"{Product.COUNTRY_ID_JAPAN}.{Product.GetCountryById(Product.COUNTRY_ID_JAPAN)}\n" +
                $"{Product.COUNTRY_ID_KOREA}.{Product.GetCountryById(Product.COUNTRY_ID_KOREA)}\n");
            int countryId = InputInt(1, Product.COUNT_COUNTRY);

            Console.WriteLine("Введите год производства: ");
            int yearMake = InputInt(Detail.MIN_YEAR_MAKE, DateTime.Now.Year);

            Console.WriteLine("Выберите тип механизма:\n" +
                $"{Mechanism.TYPE_ID_LEVER}.{Mechanism.GetTypeById(Mechanism.TYPE_ID_LEVER)}\n" +
                $"{Mechanism.TYPE_ID_SCREW}.{Mechanism.GetTypeById(Mechanism.TYPE_ID_SCREW)}\n");
            int typeId = InputInt(1, Mechanism.COUNT_TYPES);

            Console.WriteLine($"Введите сложность механизма(от 1 до {Mechanism.MAX_DIFFICULTY})");
            int difficulty = InputInt(1, Mechanism.MAX_DIFFICULTY);

            Console.WriteLine("Введите цель механизма: ");
            string purpose = InputLongString();

            Mechanisms.Add(new Mechanism(countryId, weight, amount, name, typeId, difficulty, purpose));
        }

        public static void AddKnot()
        {
            if (Details.Count() < 2)
            {
                Console.WriteLine("Деталей слишком мало для создания узла, минимальное количество 2.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите название: ");
            string name = InputString();

            Console.WriteLine("Введите вес: ");
            int weight = InputInt(1, Product.MAX_WEIGHT);

            Console.WriteLine("Введите количество: ");
            int amount = InputInt(1, Product.MAX_AMOUNT);

            Console.WriteLine("Выберите страну производства:\n" +
                $"{Product.COUNTRY_ID_RUSSIA}.{Product.GetCountryById(Product.COUNTRY_ID_RUSSIA)}\n" +
                $"{Product.COUNTRY_ID_USA}.{Product.GetCountryById(Product.COUNTRY_ID_USA)}\n" +
                $"{Product.COUNTRY_ID_GERMANY}.{Product.GetCountryById(Product.COUNTRY_ID_GERMANY)}\n" +
                $"{Product.COUNTRY_ID_JAPAN}.{Product.GetCountryById(Product.COUNTRY_ID_JAPAN)}\n" +
                $"{Product.COUNTRY_ID_KOREA}.{Product.GetCountryById(Product.COUNTRY_ID_KOREA)}\n");
            int countryId = InputInt(1, Product.COUNT_COUNTRY);

            Console.WriteLine("Введите год производства: ");
            int yearMake = InputInt(Detail.MIN_YEAR_MAKE, DateTime.Now.Year);

            List<Detail> details = new List<Detail>();

            Console.WriteLine("Выберите 1-ю деталь механизма: ");
            details.Add(ChoiceDetail());

            Console.WriteLine("Выберите 2-ю деталь механизма: ");
            details.Add(ChoiceDetail());

            Console.WriteLine("Выберите тип соеденения: \n" +
                $"{Knot.CONNECT_ID_GEAR}.{Knot.GetConnectById(Knot.CONNECT_ID_GEAR)}\n" +
                $"{Knot.CONNECT_ID_THREADED}.{Knot.GetConnectById(Knot.CONNECT_ID_THREADED)}\n");
            int connectionId = InputInt(1, Knot.COUNT_CONNECTS);

            Console.WriteLine($"Выберите сложность узла(от 1 до {Knot.MAX_DIFFICULTY})");
            int difficulty = InputInt(1, Knot.MAX_DIFFICULTY);

            Knots.Add(new Knot(countryId, weight, amount, name, details, connectionId, difficulty));
        }

        public static Detail ChoiceDetail()
        {
            for (int i = 0; i < Details.Count(); ++i)
            {
                Console.WriteLine($"{i + 1}.{Details[i].Name}\n");
            }

            return Details[InputInt(1, Details.Count() + 1) - 1];
        }

        public static void PrintProducts()
        {
            Console.WriteLine("Детали:\n");

            if (Details.Count() == 0)
            {
                Console.WriteLine("Список деталей пуст\n");
            }
            else
            {
                for (int i = 0; i < Details.Count(); ++i)
                {
                    Console.WriteLine($"{i + 1}.{Details[i].ToString()}");
                }
            }

            Console.WriteLine("Механизмы:\n");

            if (Mechanisms.Count() == 0)
            {
                Console.WriteLine("Список механизмов пуст\n");
            }
            else
            {
                for (int i = 0; i < Mechanisms.Count(); ++i)
                {
                    Console.WriteLine($"{i + 1}.{Mechanisms[i].ToString()}");
                }
            }

            Console.WriteLine("Узлы:\n");

            if (Knots.Count() == 0)
            {
                Console.WriteLine("Список узлов пуст\n");
            }
            else
            {
                for (int i = 0; i < Knots.Count(); ++i)
                {
                    Console.WriteLine($"{i + 1}.{Knots[i].ToString()}");
                }
            }
        }

        public static string InputString()
        {
            string a;
            bool active = true;
            while (active)
            {
                a = Console.ReadLine();
                if (string.IsNullOrEmpty(a) || a.Contains(" ") || IsNumberContains(a))
                {
                    Console.WriteLine("Ошибка ввода! Введите верное значение\n");
                }
                else
                {
                    return a;
                }
            }
            return "";
        }

        public static string InputLongString()
        {
            string a;
            bool active = true;
            while (active)
            {
                a = Console.ReadLine();
                if (string.IsNullOrEmpty(a) || IsNumberContains(a))
                {
                    Console.WriteLine("Ошибка ввода! Введите верное значение\n");
                }
                else
                {
                    return a;
                }
            }
            return "";
        }

        static bool IsNumberContains(string input)
        {
            foreach (char c in input)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }

        public static int InputInt(int minValue, int maxValue)
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || (a < minValue) || (a > maxValue))
            {
                Console.WriteLine($"Ошибка ввода! Введите допустимое число(от {minValue} до {maxValue})");
            }
            return a;
        }
    }
}
