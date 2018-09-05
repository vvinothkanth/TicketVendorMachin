//
//
//

namespace DataCollection
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class Show
    {
        private string _showTime;
        private Theater _theater;
        private Movie _movie;

        public Show()
        {

        }

        public void SetShowTime(string showTime)
        {
            _showTime = showTime;
        }

        public void SetTheater(Theater theater)
        {
            _theater = theater;
        }

        public void SetMovie(Movie movie)
        {
            _movie = movie;
        }

        public string GetShowTime()
        {
            return _showTime;
        }

        public Theater GetTheater()
        {
           return _theater;
        }

        public Movie GetMovie()
        {
            return _movie;
        }
    }
}
