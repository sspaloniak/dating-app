using System;

namespace EngineerApp.API.Models
{
    public class Presence
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public int PlannedPresence { get; set; }
        public int RealPresence { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}