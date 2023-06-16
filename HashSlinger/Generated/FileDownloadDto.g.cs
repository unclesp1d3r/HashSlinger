namespace HashSlinger.Api.Generated
{
    public partial class FileDownloadDto
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int FileId { get; set; }
        public int Status { get; set; }
        public FileDto File { get; set; }
    }
}