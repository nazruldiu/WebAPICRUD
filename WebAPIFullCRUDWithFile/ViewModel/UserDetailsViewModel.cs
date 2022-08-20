namespace WebAPIFullCRUDWithFile.ViewModel
{
    public class UserDetailsViewModel
    {
        public int? UserId { get; set; }
        public string? Address { get; set; }
        public string? NationalId { get; set; }
        public string? ImageFile { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}
