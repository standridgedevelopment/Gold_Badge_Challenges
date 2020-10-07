using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings
{
    public enum EventType {Golf, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public EventType EventType;
        public int Attended;
        public DateTime Date;
        public int PerPersonCost;
        public int TotalCost
        {
            get { return Attended * PerPersonCost; }
        }

        public void PrintProps()
        {
            Console.WriteLine($"1. Event Type: {EventType}");
            Console.WriteLine($"2. Amount of People: {Attended}");
            Console.WriteLine($"3. Date of Event: {Date.ToShortDateString()}");
            Console.WriteLine($"4. Cost Per Person: {PerPersonCost}");
            Console.WriteLine($"5. Total Cost: {TotalCost}");
        }
        public Outing(EventType eventType, int attended, DateTime date, int perPersonCost)
        {
            EventType = eventType;
            Attended = attended;
            Date = date;
            PerPersonCost = perPersonCost;
        }
        public Outing() { }
    }
}
    

