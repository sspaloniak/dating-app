using System;

namespace EngineerApp.API.Models
{
    public class Localization
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}