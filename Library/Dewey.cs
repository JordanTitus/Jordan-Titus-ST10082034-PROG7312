using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Dewey
    {
        //Variables
        private double CallNumbers;
        private string DescriptionString;

        public Dewey()
        {
            //Default constructor
        }

        #region Constructor
        //constructor that passes values
        public Dewey(double callNumber, string Description)
        {
            this.DescriptionString = Description;
            this.CallNumbers = callNumber;
        }
        #endregion

        #region GetAndSetMethods
        /// <summary>
        /// Get/Set Methods
        /// </summary>
        //Get and set methods
        public double CallNumbers1 { get => CallNumbers; set => CallNumbers = value; }
        public string DescriptionString1 { get => DescriptionString; set => DescriptionString = value; }
        #endregion

        #region CallNumberCreationString
        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        //To String for callnumber with numerical and string value
        public override string ToString()
        {
            string TotalNum = this.CallNumbers.ToString() + " " + this.DescriptionString;
            return TotalNum;
        }
        #endregion

    }
}

