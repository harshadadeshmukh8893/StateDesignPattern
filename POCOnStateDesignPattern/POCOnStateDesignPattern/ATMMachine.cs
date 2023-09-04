using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCOnStateDesignPattern
{
    
    internal class ATMMachine:IATMState
    {

        // A reference to the current state of the Context.
        public IATMState AtmMachineState = null;
        public ATMMachine()
        {
            //Initially the AtmMachineState will be DebitCardNotInsertedState
            AtmMachineState = new DebitCardNotInsertedState();
           
        }
        // The Context Object allows changing the State of the object at runtime.
        public void InsertDebitCard()
        {
            //Inserting Debit card
            AtmMachineState.InsertDebitCard();

            if (AtmMachineState is DebitCardNotInsertedState)
            {
                // Debit Card has been inserted so the internal state of the ATM Machine
                // has been changed to DebitCardInsertedState
                AtmMachineState = new DebitCardInsertedState();
                Console.WriteLine($"ATM Machine internal state has been changed to : {AtmMachineState.GetType().Name}");
            }
        }
        // The Context Object allows changing the State of the object at runtime.
        public void EjectDebitCard()
        {
            //Ejecting the Debit Card
            AtmMachineState.EjectDebitCard();

            if (AtmMachineState is DebitCardInsertedState)
            {
                // Debit Card has been ejected so the internal state of the ATM Machine
                // has been changed to 'DebitCardNotInsertedState'
                AtmMachineState = new DebitCardNotInsertedState();
                Console.WriteLine($"ATM Machine internal state has been Changed to : {AtmMachineState.GetType().Name}");
            }
        }
        public void EnterPin()
        {
            //No need to Change the State, only perform the Operation
            AtmMachineState.EnterPin();
        }
        public void WithdrawMoney()
        {
            //No need to Change the State, only perform the Operation
            AtmMachineState.WithdrawMoney();
        }
        // Function to automatically update the state based on conditions
        private void UpdateState()
        {
            if (AtmMachineState is DebitCardNotInsertedState)
            {
                // Check conditions and change state if needed
                if (AtmMachineState is DebitCardNotInsertedState) // Example: Check if a PIN has been entered
                {
                    AtmMachineState = new DebitCardInsertedState();
                    Console.WriteLine($"ATM Machine internal state has been changed to : {AtmMachineState.GetType().Name}");
                }
            }
            else if (AtmMachineState is DebitCardInsertedState)
            {
                // Check conditions and change state if needed
                if (AtmMachineState is DebitCardInsertedState) // Example: Check if money has been withdrawn
                {
                    AtmMachineState = new DebitCardNotInsertedState();
                    Console.WriteLine($"ATM Machine internal state has been changed to : {AtmMachineState.GetType().Name}");
                }
            }
        }
    }
}

    

