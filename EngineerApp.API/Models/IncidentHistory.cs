using System;

namespace EngineerApp.API.Models
{
    public class IncidentHistory
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdCardReader { get; set; }
        public int IncidentType { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
    }
}