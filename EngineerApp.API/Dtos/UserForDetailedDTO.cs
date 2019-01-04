using System;

namespace EngineerApp.API.Dtos
{
    public class UserForDetailedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TypePermission { get; set; }
        public string Login { get; set; }
        public int IdSuperior { get; set; }
        public string Superior { get; set; }
        public int IdDepartment { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}