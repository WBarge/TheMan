namespace OrderInvoice_DL
{
    internal class QueueItem
    {
        public object ItemToWorkOn { get; set; }
        public TypeOfWork WorkType { get; set; }
    }
}
