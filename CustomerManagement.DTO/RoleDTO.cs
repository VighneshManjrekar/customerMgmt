using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DTO
{
    public record RoleDTO(
        string RoleName,
        bool IsActive,
        DateTimeOffset? CreatedDate,
        int? CreatedBy,
        DateTimeOffset? UpdatedDate,
        int? UpdatedBy
    );
    public record UpdateRoleDTO(
            int RoleId,
            string RoleName,
            bool IsActive,
            DateTimeOffset? UpdatedDate,
            int? UpdatedBy
    );

/*
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
        int CreatedBy,
        DateTimeOffset UpdatedDate,
        int UpdatedBy,
        int ProductId,
        int DurationInDays = 0
    );
    */
}