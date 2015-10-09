using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.Serialization;



namespace Pet2Share_Service
{
    /// <summary>
    /// Class to help get around the craziness of WCF DateTime formats (Use this class instead of DateTime for WebService Models)
    /// </summary>
    [Serializable]
    [DataContract]
    public class WCFDate
    {

        public static string DateTimeFormat = "yyyy-MM-dd hh:mm:ss zz";

        /// <summary>
        /// The Date as a formatted string (Format set by the Format helper class)
        /// </summary>
        [DataMember]
        public string Data { get; set; }

        /// <summary>
        /// Basic constructor (with no value)
        /// </summary>
        public WCFDate() { }
        /// <summary>
        /// String constructor setting a Formatted string for the DateTime
        /// </summary>
        /// <param name="data"></param>
        public WCFDate(string data)
        {
            Data = data;
        }
        /// <summary>
        /// DateTime constructor, sets the Data to the formatted String from the DateTime
        /// </summary>
        /// <param name="date"></param>
        public WCFDate(DateTime date)
        {
            Data = date.ToString(DateTimeFormat);
        }

        /// <summary>
        /// DateTime constructor, sets the Data to the formatted String from the DateTime
        /// </summary>
        /// <param name="date"></param>
        public WCFDate(DateTime? date)
        {
            if (date.HasValue)
            {
                Data = date.Value.ToString(DateTimeFormat);
            }
        }

        /// <summary>
        /// Check if the class is holding a Date or not
        /// </summary>
        public bool HasDate
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Data);
            }
        }

        /// <summary>
        /// Gets the DateTime the class represents
        /// </summary>
        /// <returns></returns>
        public DateTime? GetDate()
        {

            try
            {
                return DateTime.ParseExact(Data, DateTimeFormat, CultureInfo.CurrentCulture);
            }
            catch
            {
                return null;
            }
        }
    }

}