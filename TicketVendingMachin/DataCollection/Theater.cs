//
//
//

namespace DataCollection
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class Theater
    {
        private string _name;
        private int _capacity;
        private string _location;

        public Theater()
        {

        }

        public void SetName(string theaterName)
        {
            _name = theaterName;
        }

        public void SetCapacity(int theaterCapacity)
        {
            _capacity = theaterCapacity;
        }

        public void SetLoaction(string theaterLocation)
        {
            _location = theaterLocation;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetCapacity()
        {
            return _capacity;
        }

        public string GetLocation()
        {
            return _location;
        }
    }
}
