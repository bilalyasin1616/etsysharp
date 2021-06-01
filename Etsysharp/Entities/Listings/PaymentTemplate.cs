namespace Etsysharp.Entities
{

    public class PaymentTemplate : EtsyEntity
    {
        public long? shipping_template_id { get; set; }
        public long? user_id { get; set; }
    }
}
