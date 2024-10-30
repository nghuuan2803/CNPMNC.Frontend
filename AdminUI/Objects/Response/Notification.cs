
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace AdminUI.Objects.Response
{
    public class Notification
    {
        public int Id { get; set; }

        public NotifyType Type { get; set; }

        public string? SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public string? Link { get; set; }

        public bool IsChecked { get; set; }

        public DateTime CreatedOn { get; set; }

        public string GetIcon()
        {
            switch (Type)
            {
                case NotifyType.InventoryCheck: return Icons.Material.Filled.Check;
                case NotifyType.Merge: return Icons.Material.Filled.Api;
                case NotifyType.NewOrder: return Icons.Material.Filled.BorderAll;
                case NotifyType.CheckDone: return Icons.Material.Filled.CheckCircle;
                default: return Icons.Material.Filled.CheckCircle;
            }
        }
    }

    public enum NotifyType
    {
        InventoryCheck,
        Merge,
        NewOrder,
        CheckDone
    }
}
