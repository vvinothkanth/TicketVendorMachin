//
//
//

namespace DataCollection
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class Movie
    {
        private int _id;
        private string _name;
        private string _casting;
        private string _director;

        public Movie()
        {

        }

        public void SetId(int movieId)
        {
            _id = movieId;
        }

        public void SetName(string movieName)
        {
            _name = movieName;
        }

        public void SetCasting(string movieCasting)
        {
            _casting = movieCasting;
        }

        public void SetDirector(string movieDirector)
        {
            _director = movieDirector;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string SetCasting()
        {
            return _casting;
        }

        public string SetDirector()
        {
            return _director;
        }
    }
}
