namespace CommonLayer
{
    public static class InvoiceNumberHelper
    {
        public static string GetNextNumber(int year, int currentNumber)
        {
            currentNumber++;
            return $"{year}-{currentNumber.ToString().PadLeft(6, '0')}";
        }
    }
}