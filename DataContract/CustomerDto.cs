namespace DataContract
{
    public class CustomerDto
    {
        public Guid? CustomerId { get; set; }
        public string? FullName { get; set; }
        public DateTime DOB { get; set; }
        //public DateTime DateAdded { get; set; }
        //public DateTime? DateModified { get; set; }
        //public int AddedBy { get; set; }
        //public int? ModifiedBy { get; set; }

    }
}