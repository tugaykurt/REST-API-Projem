namespace KullaniciServer.Models
{
    public class Users
    {
        public int id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool? IsStudent { get; set; }
        public short? Floor { get; set; }
        public DateTime? BrithDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
