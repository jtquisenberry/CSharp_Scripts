using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


        public static void Main(string[] args)
        {

            var meetings = new List<Meeting>()
            {
                new Meeting(2, 5), new Meeting(1, 8)
            };
            
            Console.WriteLine("Meetings Original Order");
            PrintMeetings(meetings);

            // (2,5)
            // (1,8)

            Console.WriteLine("Sort Meetings In Place");
            meetings.Sort((x,y) => x.StartTime.CompareTo(y.StartTime));
            PrintMeetings(meetings);

            // (1, 8)
            // (2, 5)

            Console.WriteLine("Create a New Sorted List, Sorted in Reverse");
            var sorted_meetings = meetings.OrderBy(x => x.StartTime).Reverse().ToList();
            PrintMeetings(sorted_meetings);

            // (2, 5)
            // (1, 8)

            Console.WriteLine("Create a new list containing a single property of the olde one.");
            Console.WriteLine("Sort the new list.");
            var transformed_meetings = meetings.Select(z => z.StartTime).OrderBy(x => x).ToList();
            PrintInts(transformed_meetings);

            // 1
            // 2

            Console.WriteLine("Create a new list containing only the elements of the old one");
            Console.WriteLine("that meet specified criteria");
            var selected_meetings = meetings.Where(x => x.StartTime < 2).ToList();
            PrintMeetings(selected_meetings);

            // (1, 8)

            //Console.ReadKey();

        }

        public static void PrintMeetings(List<Meeting> meetings)
        {
            foreach (Meeting meeting in meetings)
            {
                Console.WriteLine(meeting.ToString());
            }

            return;
        }

        public static void PrintInts(List<int> ints)
        {
            foreach(int i in ints)
            {
                Console.WriteLine(i);
            }
        }

    


    public class Meeting
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public Meeting(int startTime, int endTime)
        {
            // Number of 30 min blocks past 9:00 am
            StartTime = startTime;
            EndTime = endTime;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            var meeting = (Meeting)obj;
            return StartTime == meeting.StartTime && EndTime == meeting.EndTime;
        }

        public override int GetHashCode()
        {
            var result = 17;
            result = result * 31 + StartTime;
            result = result * 31 + EndTime;
            return result;
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }
    }
