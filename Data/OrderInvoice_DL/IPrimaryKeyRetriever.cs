namespace OrderInvoice_DL
{
    public interface IPrimaryKeyRetriever
    {
        int GetNextPrimaryKey(object obj);
    }
}
