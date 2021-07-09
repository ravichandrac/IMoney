namespace MoneySpace
{
    interface IMoney
    {
        decimal Amount { get; }
        string Currency { get; }
    }
}