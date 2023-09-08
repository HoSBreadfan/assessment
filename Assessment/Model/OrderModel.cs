using System.ComponentModel.DataAnnotations;

namespace Assessment.Model
{
    public class OrderModel
    {
        [Range(0, int.MaxValue)]
        public int AppleQuantity { get; set; }
        [Range(0, int.MaxValue)]
        public int OrangeQuantity { get; set; }
    }
}
