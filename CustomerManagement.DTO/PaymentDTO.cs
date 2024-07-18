using CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DTO
{
    public record PaymentDTO(
       int OrderId,
       decimal Price,
       DateTimeOffset? CreatedDate,
       int CreatedBy
   );
    public record UpdatePaymentDTO(
        int PaymentId,
        int OrderId,
        decimal Price
    );
}