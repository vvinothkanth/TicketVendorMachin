//
//
//

namespace DataCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Reflection;

    public class TicketVendor 
    {
        public List<Theater> theaterList = new List<Theater>();

        public List<Movie> movieList = new List<Movie>();

        public List<Show> showList = new List<Show>();

        public List<Ticket> ticketList = new List<Ticket>();

        public TicketVendor()
        {
            Theater nS = new Theater();
            Theater kasi = new Theater();
            Theater jothi = new Theater();
            nS.SetName("NS");
            nS.SetCapacity(2);
            nS.SetLoaction("Attur");

            kasi.SetName("Kasi");
            kasi.SetCapacity(2);
            kasi.SetLoaction("Attur");

            jothi.SetName("Jothi");
            jothi.SetCapacity(2);
            jothi.SetLoaction("Parangimalai");

            AddToList(nS);
            AddToList(kasi);
            AddToList(jothi);

            Movie coCo = new Movie();
            Movie billa = new Movie();
            Movie kaththi = new Movie();

            coCo.SetId(1);
            coCo.SetName("Kolamavu Kokila");
            coCo.SetCasting("Nayanthara");
            coCo.SetDirector("Ezhil");

            billa.SetId(2);
            billa.SetName("Billa");
            billa.SetCasting("Ajith");
            billa.SetDirector("Sid");

            kaththi.SetId(3);
            kaththi.SetCasting("Vijay");
            kaththi.SetName("Kathi");
            kaththi.SetDirector("A.R. Murugadhas");

            AddToList(coCo);
            AddToList(billa);
            AddToList(kaththi);

            Show s1 = new Show();

            s1.SetShowTime("9:30 AM");
            s1.SetMovie(coCo);
            s1.SetTheater(nS);

            Show s2 = new Show();
            s2.SetShowTime("6:30 PM");
            s2.SetMovie(coCo);
            s2.SetTheater(nS);

            Show s3 = new Show();
            s3.SetTheater(kasi);
            s3.SetMovie(billa);
            s3.SetShowTime("1:30 PM");

            Show s4 = new Show();
            s4.SetTheater(kasi);
            s4.SetMovie(kaththi);
            s4.SetShowTime("9:30 PM");

            Show s5 = new Show();
            s5.SetTheater(jothi);
            s5.SetMovie(kaththi);
            s5.SetShowTime("6:30 PM");

            Show s6 = new Show();
            s6.SetTheater(jothi);
            s6.SetMovie(billa);
            s6.SetShowTime("9:30 AM");

            AddToList(s1);
            AddToList(s2);
            AddToList(s3);
            AddToList(s4);
            AddToList(s5);
            AddToList(s6);

        }

        public bool AddToList(Theater theater)
        {
            theaterList.Add(theater);
            return true;
        }

        public bool AddToList(Movie movie)
        {
            movieList.Add(movie);
            return true;
        }

        public bool AddToList(Show show)
        {
            showList.Add(show);
            return true;
        }

        public bool AddToList(Ticket ticket)
        {
            ticketList.Add(ticket);
            return true;
        }

        public List<Movie> GetAllMovies()
        {
            return movieList;
        }

        public List<Theater> GetAllTheaters()
        {
            return theaterList;
        }

        public List<Show> GetAllShows()
        {
            return showList;
        }

        public List<Show> GetMoviesRunningOnTheater(string theaterName)
        {
            var getMovies = showList.Where( movieList => movieList.GetTheater().GetName().ToString() == theaterName );

            return getMovies.ToList<Show>();
        }

        public List<Show> GetTheatersUsingMovie(string movieName)
        {
            var getTheaters = showList.Where( theaterList => theaterList.GetMovie().GetName().ToString() == movieName );

            return getTheaters.ToList<Show>();
        }

        public List<Ticket> GetTheatersDailyReport(Show show)
        {
            var getTickets = ticketList.Where(ticket => ticket.Show == show);

            return getTickets.ToList<Ticket>();
        }

        private void DailyReportPattern(string theaterName, string showTime, double totalAmount, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0},{1},{2} ", theaterName, showTime, totalAmount );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void WriteDailyReport(string theaterName, string showTime, double totalAmount)
        {
            try
            {

                string fileName = @"Daily Report On " + DateTime.Now.ToString(" dd MMMM yyyy HH-mm-ss") + ".csv";
                string filePath = @"E:\vinothkanth\Assesment\TicketVendingMachine\DailyReport" + "\\" + fileName;
                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    DailyReportPattern(theaterName, showTime, totalAmount, streamWriter);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}

