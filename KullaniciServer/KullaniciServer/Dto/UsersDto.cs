namespace KullaniciServer.Dto
{
    public class UsersDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool? IsStudent { get; set; }
        public short? Floor { get; set; }
        public DateTime? BrithDate { get; set; }
    }
}
