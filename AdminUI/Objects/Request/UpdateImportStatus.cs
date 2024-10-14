namespace AdminUI.Objects.Request
{
    public class UpdateImportStatus
    {
        public int ImportId { get; set; }
        public int Status { get; set; }

        public UpdateImportStatus(int importId, int status)
        {
            ImportId = importId;
            Status = status;
        }
    }
}
