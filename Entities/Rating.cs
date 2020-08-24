using System;
using System.Collections.Generic;
using System.Reflection;
using Watchdog.Persistence;

namespace Watchdog.Entities
{
    public class Rating : Persistable
    {
        private static readonly string tableName = "wdt_ratings";

        private static readonly Dictionary<string, string> tableMapping = new Dictionary<string, string>
        {
            {"rating_code", "RatingCode" },
            {"numeric_value", "RatingNumericValue" },
            {"rating_agency_index", "Agency" }
        };

        private static readonly Rating defaultValue = new Rating();
        public string RatingCode { get; set; }
        public double RatingNumericValue { get; set; }
        public double Index { get; set; }
        public double Agency { get; set; }

        public Rating()
        {
        }

        public string GetTableName()
        {
            return tableName;
        }

        public List<string> GetTableHeader()
        {
            List<string> header = new List<string>();
            header.AddRange(tableMapping.Keys);
            return header;
        }

        public double GetIndex()
        {
            return Index;
        }

        public void SetIndex(double index)
        {
            Index = index;
        }

        public static Rating GetDefaultValue()
        {
            return defaultValue;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj is Rating rating &&
                   RatingCode == rating.RatingCode &&
                   RatingNumericValue == rating.RatingNumericValue &&
                   Index == rating.Index &&
                   Agency == rating.Agency;
        }

        public override int GetHashCode()
        {
            int hashCode = 1239053354;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RatingCode);
            hashCode = hashCode * -1521134295 + RatingNumericValue.GetHashCode();
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + Agency.GetHashCode();
            return hashCode;
        }

        public Dictionary<string, string> GetTableMapping()
        {
            return tableMapping;
        }
    }
}
