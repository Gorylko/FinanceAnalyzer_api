namespace FinanceAnalyzer.UI.Interfaces
{
    using FinanceAnalyzer.Shared.Enums;

    internal interface IDataReceiver
    {
        bool TryGetInt(out int number, bool isOnFreePlace = false);

        bool TryGetDecimal(out decimal number, bool isOnFreePlace = false);

        string GetString(bool isOnFreePlace = false);

        ActionType GetAction();
    }
}
