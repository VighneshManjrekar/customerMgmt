using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EnquiryId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EnquiryId",
                table: "Users",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_PaymentId",
                table: "PaymentRecords",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_EnquiryId",
                table: "Leads",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EqnuiryDetails_EnquiryId",
                table: "EqnuiryDetails",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryInterests_EnquiryId",
                table: "EnquiryInterests",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryInterests_ProductId",
                table: "EnquiryInterests",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_StatusId",
                table: "Enquiries",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquiries_Statuses_StatusId",
                table: "Enquiries",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryInterests_Enquiries_EnquiryId",
                table: "EnquiryInterests",
                column: "EnquiryId",
                principalTable: "Enquiries",
                principalColumn: "EnquiryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryInterests_Products_ProductId",
                table: "EnquiryInterests",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EqnuiryDetails_Enquiries_EnquiryId",
                table: "EqnuiryDetails",
                column: "EnquiryId",
                principalTable: "Enquiries",
                principalColumn: "EnquiryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Enquiries_EnquiryId",
                table: "Leads",
                column: "EnquiryId",
                principalTable: "Enquiries",
                principalColumn: "EnquiryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRecords_Payments_PaymentId",
                table: "PaymentRecords",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Enquiries_EnquiryId",
                table: "Users",
                column: "EnquiryId",
                principalTable: "Enquiries",
                principalColumn: "EnquiryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enquiries_Statuses_StatusId",
                table: "Enquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryInterests_Enquiries_EnquiryId",
                table: "EnquiryInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryInterests_Products_ProductId",
                table: "EnquiryInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_EqnuiryDetails_Enquiries_EnquiryId",
                table: "EqnuiryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Enquiries_EnquiryId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRecords_Payments_PaymentId",
                table: "PaymentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Enquiries_EnquiryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EnquiryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GenderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRecords_PaymentId",
                table: "PaymentRecords");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Leads_EnquiryId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_EqnuiryDetails_EnquiryId",
                table: "EqnuiryDetails");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryInterests_EnquiryId",
                table: "EnquiryInterests");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryInterests_ProductId",
                table: "EnquiryInterests");

            migrationBuilder.DropIndex(
                name: "IX_Enquiries_StatusId",
                table: "Enquiries");

            migrationBuilder.AlterColumn<int>(
                name: "EnquiryId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
