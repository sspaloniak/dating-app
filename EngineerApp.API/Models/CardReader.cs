using System;

namespace EngineerApp.API.Models
{
    public class CardReader
    {
        public int Id { get; set; }
        public int IdLocalization { get; set; }
        public string ReaderName { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}