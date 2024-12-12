using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class PaymentService
    {
        private readonly PaymentRepository _repository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _repository = paymentRepository;
        }


        public void AddPayment(Payment payment)
        {
            _repository.AddPayment(payment);
        }

        public List<Payment> GetAllPayments()
        {
            return _repository.GetAllPayments();
        }

        //public Payment GetPaymentById(string paymentId)
        //{
        //    _repository.GetPaymentById( paymentId);
        //}

        public void UpdatePayment(Payment payment)
        {
            _repository.UpdatePayment( payment);
        } 
        public  void DeletePayment(int paymentId)
        {
            _repository.DeletePayment(paymentId);
        }
    }
}