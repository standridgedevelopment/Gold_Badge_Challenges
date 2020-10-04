using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings
{
    public enum EventType {Golf, Bowling, Amusement_Park, Concert }
    public class Outing
    {
        public EventType EventType;
        public int Attended;
        public DateTime Date;
        public int PerPersonCost;
        public int TotalCost;

        public Outing(EventType eventType, int attended, DateTime date, int perPersonCost, int totalCost)
        {
            EventType = eventType;
            Attended = attended;
            Date = date;
            PerPersonCost = perPersonCost;
            TotalCost = totalCost;
        }
        public Outing() { }
    }
}
    

