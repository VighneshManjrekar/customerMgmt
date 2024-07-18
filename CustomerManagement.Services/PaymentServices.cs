using AutoMapper;
using CustomerManagement.DTO;
using CustomerManagement.IRepositories;
using CustomerManagement.IServices;
using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Services
{
    public class PaymentServices:IPaymentServices
    {
        private readonly IMapper mapper;
        private readonly IPaymentRepository paymentRepository;

        public PaymentServices(IMapper _mapper, IPaymentRepository _paymentRepository)
        {
            mapper = _mapper;
            paymentRepository = _paymentRepository;
        }

        public async Task<PaymentDTO> CreatePaymentAsync(PaymentDTO paymentDTO)
        {
            try
            {
                var payment = mapper.Map<Payment>(paymentDTO);
                payment.CreatedDate = DateTimeOffset.Now;
                payment.UpdatedDate = DateTimeOffset.Now;
                payment.CreatedBy = paymentDTO.CreatedBy;
                payment.UpdatedBy = paymentDTO.CreatedBy;

                var newPayment = await paymentRepository.CreateAsync(payment);
                var mappedPayment = mapper.Map<PaymentDTO>(newPayment);
                return mappedPayment;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            try
            {
                var oldPayment = await paymentRepository.FindByIdAsync(id);
                if (oldPayment != null)
                {
                    var isDeleted = await paymentRepository.DeleteAsync(oldPayment);
                    return isDeleted;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            try
            {
                var payments = await paymentRepository.FindAllAsync();
                var mappedPayments = mapper.Map<IEnumerable<PaymentDTO>>(payments);
                return mappedPayments;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<PaymentDTO> GetPaymentByIdAsync(int id)
        {
            try
            {
                var payment = await paymentRepository.FindByIdAsync(id);
                var mappedPayment = mapper.Map<PaymentDTO>(payment);
                return mappedPayment;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<PaymentDTO> UpdatePaymentAsync(int id, UpdatePaymentDTO updatePaymentDTO)
        {
            var oldPayment = await paymentRepository.FindByIdAsync(id);
            var myRequest = mapper.Map<Payment>(updatePaymentDTO);
            if (oldPayment != null)
            {
                myRequest.UpdatedDate = DateTimeOffset.Now;

                var oldPaymentDTO = mapper.Map<UpdatePaymentDTO>(oldPayment);
                var myRequestDTO = mapper.Map<UpdatePaymentDTO>(myRequest);

                var updateRequestDTO = mapper.Map(myRequestDTO, oldPaymentDTO);
                var updateRequest = mapper.Map<Payment>(updateRequestDTO);

                updateRequest.CreatedDate = oldPayment.CreatedDate;
                updateRequest.CreatedBy = oldPayment.CreatedBy;

                var updatedPayment = await paymentRepository.UpdateAsync(updateRequest);
                var mappedPayment = mapper.Map<PaymentDTO>(updatedPayment);
                return mappedPayment;
            }
            else
            {
                throw new InvalidOperationException($"Payment with ID {id} not found.");
            }
        }
    }
}
