using System;

namespace EngineerApp.API.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string CardNumber1 { get; set; }
        public string CardNumber2 { get; set; }
        public string CardNumber3 { get; set; }
        public string CardNumber4 { get; set; }
        public DateTime Add_Date { get; set; }
        public DateTime LastUse_Date { get; set; }
        public bool Blocked { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}