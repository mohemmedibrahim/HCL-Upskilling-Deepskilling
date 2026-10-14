namespace TrainingManagementSystem.Services;

public sealed class FeeCalculator
{
    public (decimal BaseFee, decimal TotalDiscount, decimal FinalFee) Calculate(decimal baseFee, decimal surcharge)
        => Calculate(baseFee, surcharge, false, false);

    public (decimal BaseFee, decimal TotalDiscount, decimal FinalFee) Calculate(
        decimal baseFee, decimal surcharge, bool earlyBird, bool groupDiscount)
    {
        if (baseFee < 0 || surcharge < 0) throw new ArgumentOutOfRangeException(nameof(baseFee), "Fees cannot be negative.");
        decimal discount = (earlyBird ? baseFee * 0.10m : 0m) + (groupDiscount ? baseFee * 0.05m : 0m);
        return (baseFee, discount, baseFee - discount + surcharge);
    }
}
