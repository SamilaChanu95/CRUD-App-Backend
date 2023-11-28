using CRUD_App.Interfaces;
using CRUD_App.Models;

namespace CRUD_App.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DBContextPaymentDetail _dBContextPaymentDetail;
        public PaymentService(DBContextPaymentDetail dBContextPaymentDetail)
        {
            _dBContextPaymentDetail = dBContextPaymentDetail;
        }
        public bool AddPayment(PaymentDetail paymentDetail)
        {
            var result = _dBContextPaymentDetail.PaymentDetails.Add(paymentDetail);
            return true;
        }

        public bool DeletePayment(int id)
        {
            PaymentDetail paymentDetailExist = _dBContextPaymentDetail.PaymentDetails.Where(p => p.PaymentDetailId == id).FirstOrDefault() ?? new PaymentDetail { PaymentDetailId = 0 };
            if (paymentDetailExist.PaymentDetailId == 0) 
            {
                return false;
            }
            var result = _dBContextPaymentDetail.PaymentDetails.Remove(paymentDetailExist);
            return true;
        }

        public PaymentDetail GetPaymentDetail(int id)
        {
            PaymentDetail result = _dBContextPaymentDetail.PaymentDetails.Where(p => p.PaymentDetailId == id).FirstOrDefault() ?? new PaymentDetail () { PaymentDetailId = 0 };
            return result;
        }

        public List<PaymentDetail> GetAll()
        {
            var result = _dBContextPaymentDetail.PaymentDetails.OrderBy(p => p.PaymentDetailId).ToList();
            return result;
        }

        public bool PaymentExists(int id)
        {
            return _dBContextPaymentDetail.PaymentDetails.Find(id) != null ? true : false;
        }

        public bool UpdatePayment(int id, PaymentDetail paymentDetail)
        {
            PaymentDetail paymentDetailExist = _dBContextPaymentDetail.PaymentDetails.Where(p => p.PaymentDetailId == id).FirstOrDefault() ?? new PaymentDetail() { PaymentDetailId = 0 };
            if (paymentDetailExist.PaymentDetailId != 0) { 
                var result = _dBContextPaymentDetail.PaymentDetails.Update(paymentDetail);
                return true;
            }
            return false;
        }
    }
}
