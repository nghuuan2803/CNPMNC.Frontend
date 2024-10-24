namespace AdminUI.Objects.Request
{
    public class UpdateImportStatus
    {
        public string ImportId { get; set; }
        public int Status { get; set; }

        public UpdateImportStatus(string importId, int status)
        {
            ImportId = importId;
            Status = status;
        }
    }
}
