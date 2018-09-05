//
//
//
//

namespace DataCollection
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class Ticket
    {
        public int Number { get; set; }

        public Show Show { get; set; }

        public int SeatNo { get; set; }

        public string SeatType { get; set; }

        public double Price { get; set; }

    }
}
