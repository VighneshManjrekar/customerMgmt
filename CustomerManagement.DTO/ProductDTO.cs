using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DTO
{
    public record ProductDTO(
        bool IsSubscribable,
        string ProductName,
        string ProductDescription,
        decimal ProductPrice,
        bool IsActive,
        decimal IGstRate,
        decimal CGstRate,
        decimal UTGstRate,
        decimal SGstRate,
        DateTimeOffset? StartDate,
        DateTimeOffset? EndDate,
        DateTimeOffset CreatedDate,
        int CreatedBy,
        DateTimeOffset UpdatedDate,
        int UpdatedBy,
        int DurationInDays = 0
    );

    public record ProductOrderDetail(
        bool IsSubscribable,
        string ProductName,
        string ProductDescription,
        bool IsActive,
        DateTimeOffset CreatedDate
    );

    public record UpdateProductDTO(
        bool IsSubscribable,
        string ProductName,
        string ProductDescription,
        decimal ProductPrice,
        bool IsActive,
        decimal IGstRate,
        decimal CGstRate,
        decimal UTGstRate,
        decimal SGstRate,
        DateTimeOffset? StartDate,
        DateTimeOffset? EndDate,
        DateTimeOffset UpdatedDate,
        int UpdatedBy,
        int ProductId,
        int DurationInDays = 0
    );
}