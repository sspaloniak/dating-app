using System;
using EngineerApp.API.Controllers;

namespace EngineerApp.API.Dtos
{
    public class Event
    {
        public int IdUser { get; set; }
        public string User { get; set; }
        public int IdCardReader { get; set; }
        public string CardReader { get; set; }
        public int IdIncidentType { get; set; }
        public string IncidentType { get; set; }
        public string Date { get; set; }
    }
}