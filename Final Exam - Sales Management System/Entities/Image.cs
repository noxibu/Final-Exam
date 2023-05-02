namespace Final_Exam___Sales_Management_System.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ContentType { get; set; }
        public UserInformation UserInformation { get; set; }
        public Guid UserInformationId { get; set; }

    }
}
