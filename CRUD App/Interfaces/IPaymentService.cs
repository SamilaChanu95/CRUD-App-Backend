using CRUD_App.Models;

namespace CRUD_App.Interfaces
{
    public interface IPaymentService
    {
        public List<PaymentDetail> GetAll();
        public PaymentDetail GetPaymentDetail(int id);
        public bool AddPayment(PaymentDetail paymentDetail);
        public bool UpdatePayment(int id, PaymentDetail paymentDetail);
        public bool DeletePayment(int id);
        public bool PaymentExists(int id);

    }
}
