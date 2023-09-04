namespace POCOnStateDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ATMMachine atmMachine = new ATMMachine();

            // Simulate ATM interactions
            atmMachine.InsertDebitCard();
            atmMachine.EnterPin();
            atmMachine.WithdrawMoney();
            atmMachine.EjectDebitCard();
        }
    }
}
        
    
