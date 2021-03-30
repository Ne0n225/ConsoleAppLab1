using System.Collections.Generic;

namespace ClassLibrary
{
    public class Knot : Product
    {
        public const int CONNECT_ID_GEAR = 1;
        public const int CONNECT_ID_THREADED = 2;

        public const int COUNT_CONNECTS = 2;

        public const int MAX_DIFFICULTY = 5;

        public List<Detail> Details { get; set; }
        private int ConnectionId { get; set; }
        public int Difficulty { get; set; }


        public Knot(
            int countryId,
            int weight,
            int amount,
            string name,
            List<Detail> details,
            int connectionId,
            int difficulty)
            : base(
                  countryId,
                  weight,
                  amount,
                  name)
        {
            this.Details = details;
            this.Difficulty = difficulty;
            this.ConnectionId = connectionId;
        }

        public void SetConnect(int connectId)
        {
            if (connectId < 1 || connectId > COUNT_CONNECTS)
            {
                return;
            }
            else
            {
                this.ConnectionId = connectId;
            }
        }

        public string GetConnect()
        {
            return GetConnectById(this.ConnectionId);
        }

        public static string GetConnectById(int connectId)
        {
            switch (connectId)
            {
                case CONNECT_ID_GEAR:
                    return "Зубчатое";
                case CONNECT_ID_THREADED:
                    return "Резьбовое";
                default:
                    return "Ошибка: ненайден тип соедения";
            }
        }

        public override string ToString()
        {
            return base.ToString()
                + $"Детали находящиеся в узле: {this.Details[0].Name}, {this.Details[1].Name}\n" +
                $"Тип соеденения: {this.GetConnect()}\n" +
                $"Сложность: {this.Difficulty}\n";
        }
    }
}
