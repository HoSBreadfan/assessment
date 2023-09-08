namespace Assessment.Model
{
    public class OrderSummaryModel : OrderModel
    {
        private readonly double ApplePrice = .6;
        private readonly double OrangePrice = .25;


        public double TotalCost { get; set; }

        public string TotalDollarCost { get => $"${TotalCost.ToString("0.00") }"; }

        public OrderSummaryModel(int orangeQuantity, int appleQuantity)
        {
            OrangeQuantity = orangeQuantity;
            AppleQuantity = appleQuantity;

            //  2 for 1 apples!
            var appleTotal = Math.Ceiling(AppleQuantity / 2.0) * ApplePrice;

            //  3 for 2 oranges!
            var orangeTotal = Math.Ceiling(orangeQuantity * (2.0 / 3.0)) * OrangePrice;

            var total = appleTotal + orangeTotal;

            TotalCost = Math.Round(total, 2);
        }
    }
}
