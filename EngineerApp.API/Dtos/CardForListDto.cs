namespace EngineerApp.API.Dtos
{
    public class CardForListDto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string CardNumber1 { get; set; }
        public string CardNumber2 { get; set; }
        public string CardNumber3 { get; set; }
        public string CardNumber4 { get; set; }
        public bool Blocked { get; set; }
    }
}