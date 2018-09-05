//
//
//

namespace DataFunction
{
    using System;
    using System.Collections.Generic;
    using DataCollection;

    public class TicketVendorMachin
    {
        enum MainMenu
        {
            AddTicket = 1,
            ShowMovie,
            ShowRunningMoviesOnTheater,
            ShowTheaterAsMovie,
            GenerateReport,
            AddNewTheaterMovieOrShow
        }

        enum SeatType
        {
            I,
            II,
            III
        }

        enum SubMenu
        {
         
            AddNewTheater = 1,
            AddNewMovie,
            AddShow
        }

        TicketVendor tvm = new TicketVendor();

        public void GetTheaterList()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Movies");
            foreach (var movie in tvm.GetAllMovies())
            {
                Console.WriteLine(movie.GetName());
            }
            Console.WriteLine("------------------");

        }

        public void GetShow()
        {
            Console.Write("Enter Theater Name : ");
            string theater = Convert.ToString(Console.ReadLine());
            var movieDetail = tvm.GetMoviesRunningOnTheater(theater);
            foreach (var show in movieDetail)
            {

                Console.WriteLine("Show Time :{0} => Movie : {1}", show.GetShowTime(), show.GetMovie().GetName());
            }

        }

        public void GetTheater()
        {
            Console.Write("Enter Movie Name : ");
            string movie = Convert.ToString(Console.ReadLine());
            var theaterDetail = tvm.GetTheatersUsingMovie(movie);
            foreach (var theaters in theaterDetail)
            {
                Console.WriteLine("Theater Name : {0}", theaters.GetTheater().GetName().ToString());
                Console.WriteLine("Location     : {0}", theaters.GetTheater().GetLocation().ToString());
                Console.WriteLine("Timing       : {0}", theaters.GetShowTime().ToString());
                Console.WriteLine("---------------");
                //Console.WriteLine("Press {3} For => Theater Name :{0} => Location{1} , Timing {2}", theaters.GetTheater().GetName(), theaters.GetTheater().GetLocation(), theaters.GetShowTime());

            }

        }

        public void AddTicket()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Movies running in theater\n");
            int movieCount = 1;

            foreach (var movie in tvm.GetAllMovies())
            {
                Console.WriteLine("Press {0} For => {1} ", movieCount, movie.GetName());
                movieCount++;
            }

            Console.Write("Enter Your Choice : ");

            int movieIndex = Convert.ToInt16(Console.ReadLine());

            List<Show> theaterSet = tvm.GetTheatersUsingMovie(tvm.movieList[movieIndex - 1].GetName());

            int theaterCount = 1;

            Console.WriteLine("--------------------------------");
            foreach (var theater in theaterSet)
            {
                Console.WriteLine("Press {3} For => Theater Name :{0} => Location{1} , Timing {2}", theater.GetTheater().GetName(), theater.GetTheater().GetLocation(), theater.GetShowTime(), theaterCount);
                theaterCount++;
            }

            Console.Write("Enter Your Choice : ");
            int theaterIndex = Convert.ToInt16(Console.ReadLine());

            int availableTickets = theaterSet[theaterIndex - 1].GetTheater().GetCapacity() - tvm.GetTheatersDailyReport(theaterSet[theaterIndex - 1]).Count;
            if (availableTickets != 0)
            {
                Console.WriteLine("Only {0} tickets are available:", availableTickets);

                Ticket ticket = new Ticket();
                ticket.Number = tvm.ticketList.Count + 1;
                ticket.Show = theaterSet[theaterIndex - 1];

                ticket.SeatNo = tvm.GetTheatersDailyReport(ticket.Show).Count + 1;

                Console.WriteLine("Enter Ticket Type eg, I/II/III");
                ticket.SeatType = Convert.ToString(Console.ReadLine());

                if (ticket.SeatType == SeatType.I.ToString())
                {
                    ticket.Price = 350;
                }
                else if (ticket.SeatType == SeatType.II.ToString())
                {
                    ticket.Price = 250;
                }
                else
                {
                    ticket.Price = 150;
                }

                tvm.AddToList(ticket);

                Console.WriteLine("----------------------");
                Console.WriteLine("TicketNumber : {0}", ticket.Number);
                Console.WriteLine("SeatNo       : {0}", ticket.SeatNo);
                Console.WriteLine("Theater Name : {0}", ticket.Show.GetTheater().GetName());
                Console.WriteLine("Movie        : {0}", ticket.Show.GetMovie().GetName());
                Console.WriteLine("Seat Type    : {0}", ticket.SeatType);
                Console.WriteLine("Amount       : {0}", ticket.Price);
                Console.WriteLine("----------------------");

            }
            else
            {
                Console.WriteLine("Seat are not available....");
            }

        }

        public void GetReport()
        {
            foreach (var show in tvm.showList)
            {
                string theater = show.GetTheater().GetName();
                string showTime = show.GetShowTime();
                double totalTicketAmount = 0.0;
                foreach (var item in tvm.GetTheatersDailyReport(show))
                {
                    totalTicketAmount += item.Price;
                }

                tvm.WriteDailyReport(theater, showTime, totalTicketAmount);
            }

            Console.WriteLine(@"View report On :E:\vinothkanth\Assesment\TicketVendingMachine\DailyReport\");
        }

        public void AddNewTheaterMovieOrShow()
        {
            Console.WriteLine("Press {0} : => Add Theater", (int)SubMenu.AddNewTheater );
            Console.WriteLine("Press {0} : => Add Movie", (int)SubMenu.AddNewMovie);
            Console.WriteLine("Press {0} : => Add Show", (int)SubMenu.AddShow);
            Console.Write("Enter Your Choice");
            int option = Convert.ToInt16(Console.ReadLine());
            switch (option)
            {
                case (int)SubMenu.AddNewTheater:
                    Theater theater = new Theater();
                    Console.Write("Enter Theater Name :");
                    theater.SetName(Convert.ToString(Console.ReadLine()));
                    Console.Write("Enter Theater Capacity :");
                    theater.SetCapacity(Convert.ToInt32(Console.ReadLine()));
                    Console.Write("Enter Theater Location :");
                    theater.SetLoaction(Convert.ToString(Console.ReadLine()));

                    tvm.AddToList(theater);
                    Console.WriteLine("Theater Details has been added successfully");
                    break;

                case (int)SubMenu.AddNewMovie:
                    Movie movie = new Movie();
                    Console.Write("Enter Movie Id :");
                    movie.SetId(Convert.ToInt32(Console.ReadLine()));
                    Console.Write("Enter Movie Name :");
                    movie.SetName(Convert.ToString(Console.ReadLine()));
                    Console.Write("Enter Movie Casting :");
                    movie.SetCasting(Convert.ToString(Console.ReadLine()));
                    Console.Write("Enter Movie Director :");
                    movie.SetDirector(Convert.ToString(Console.ReadLine()));
                    tvm.AddToList(movie);

                    Console.WriteLine("Movie Details has been added successfully");
                    break;

                case (int)SubMenu.AddShow:
                    Show show = new Show();
                    Console.Write("Enter Show Time :");

                    Console.WriteLine("------------------");
                    Console.WriteLine("Movies running in theater\n");
                    int movieCount = 1;

                    foreach (var movies in tvm.GetAllMovies())
                    {
                        Console.WriteLine("Press {0} For => {1} ", movieCount, movies.GetName());
                        movieCount++;
                    }
                    Console.Write("Enter Your Choice : ");
                    int movieIndex = Convert.ToInt16(Console.ReadLine());


                    int theaterCount = 1;

                    Console.WriteLine("--------------------------------");
                    foreach (var theaters in tvm.GetAllTheaters())
                    {
                        Console.WriteLine("Press {0} to select => Theater :{1} Location : {2}", theaterCount, theaters.GetName(), theaters.GetLocation());
                        theaterCount++;
                    }
                    Console.Write("Enter Your Choice : ");
                    int theaterIndex = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Enter Show Time / eg. 9:30 AM/1:30 PM/6:30 PM");
                    show.SetShowTime(Convert.ToString(Console.ReadLine()));
                    show.SetMovie(tvm.movieList[movieIndex - 1]);
                    show.SetTheater(tvm.theaterList[theaterIndex - 1]);
                    tvm.AddToList(show);
                    Console.WriteLine("Show details has been added succesfully");
                    break;

                default:
                    Console.WriteLine("Wrong Option");
                    break;
            }
        }
        static void Main(string[] args)
        {
            TicketVendorMachin p = new TicketVendorMachin();

            while (true)
            {

                Console.WriteLine("------------");
                Console.WriteLine("Press  {0} : => Add ticket", (int)MainMenu.AddTicket);
                Console.WriteLine("Press  {0} : => Show Movie", (int)MainMenu.ShowMovie);
                Console.WriteLine("Press  {0} : => Search movies running on theater", (int)MainMenu.ShowRunningMoviesOnTheater);
                Console.WriteLine("Press  {0} : => Search theaters using movie name", (int)MainMenu.ShowTheaterAsMovie);
                Console.WriteLine("Press  {0} : => Get daily report", (int)MainMenu.GenerateReport);
                Console.WriteLine("Press  {0} : => Add new theater, movie or show", (int)MainMenu.AddNewTheaterMovieOrShow);

                Console.Write("Enter Your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)MainMenu.ShowMovie:
                        p.GetTheaterList();
                        break;

                    case (int)MainMenu.ShowRunningMoviesOnTheater:
                        p.GetShow();
                        break;

                    case (int)MainMenu.ShowTheaterAsMovie:
                        p.GetTheater();
                        break;

                    case (int)MainMenu.AddTicket:
                        p.AddTicket();
                        break;
                    case (int)MainMenu.GenerateReport:
                        p.GetReport();
                        break;
                    case (int)MainMenu.AddNewTheaterMovieOrShow:
                        p.AddNewTheaterMovieOrShow();
                        break;
                    default:
                        Console.Write("Wrong Entry");
                        break;
                }
            }

            //Console.ReadKey();
        }
    }
}
