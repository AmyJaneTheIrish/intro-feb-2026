


namespace Banking.Domain;

public class Account
{
    private decimal _currentBalance = 5000M;

    public void Deposit(TransactionAmount amountToDeposit)
    {
        // if the amountToDeposit is 0 or less, throw an exception - abnormal end.

        _currentBalance += amountToDeposit;
    }

    public decimal GetBalance()
    {

        return _currentBalance;
    }

    // Primitive Obsession 
    // You can call this with any decimal value and it will work. 
    public void Withdraw(TransactionAmount amountToWithdraw)
    {

        if (WouldCauseOverdraft(amountToWithdraw))
        {
            // exit with an exception - abnormal end.
            throw new OverdraftNotAllowedException();
        }
        _currentBalance -= amountToWithdraw;


    }

    private bool WouldCauseOverdraft(decimal amountToWithdraw)
    {
        return amountToWithdraw > _currentBalance;
    }

}

public class OverdraftNotAllowedException : ArgumentOutOfRangeException { }