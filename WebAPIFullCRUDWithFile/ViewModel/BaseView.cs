namespace WebAPIFullCRUDWithFile.ViewModel
{
    public class BaseView
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
