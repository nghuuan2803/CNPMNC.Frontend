namespace AdminUI.Objects.Request
{
    public class UpdateStatusRequest
    {
        public int Id { get; set; }
        public int NewStatus { get; set; }

        public UpdateStatusRequest(int id, int newStatus)
        {
            Id = id;
            NewStatus = newStatus;
        }

        public UpdateStatusRequest()
        {
        }
    }

}
