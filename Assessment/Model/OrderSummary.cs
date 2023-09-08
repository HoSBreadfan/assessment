namespace Assessment.Model
{
    public class OrderSummaryModel : OrderModel
    {
        private readonly double ApplePrice = .6;
        private readonly double OrangePrice = .25;

        public double TotalCost
        {
            get
            {
                var total = (AppleQuantity * ApplePrice) + (OrangeQuantity * OrangePrice);

                return Math.Round(total, 2);
            }
        }

        public string TotalDollarCost { get => $"${TotalCost.ToString("0.00") }"; }
    }
}
