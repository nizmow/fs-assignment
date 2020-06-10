using System;

namespace DataAccess.Entities
{
    /// <summary>
    /// A "number to english" call we have processed.
    /// </summary>
    public class NumberToEnglishProcessed
    {
        public long NumberToEnglishHistoryId { get; set; }

        public decimal InputNumber { get; set; }

        public string OutputText { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
