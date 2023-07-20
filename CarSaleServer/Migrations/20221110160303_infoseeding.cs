using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSale.Migrations
{
    public partial class infoseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "toyota" },
                    { 2, "mitsubishi" },
                    { 3, "ford" },
                    { 4, "audi" },
                    { 5, "volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("aa8cbb73-653c-43cf-ae03-125a91ae59b9"), "admin", new byte[] { 81, 5, 11, 52, 232, 214, 92, 204, 53, 255, 104, 50, 134, 137, 131, 182, 20, 176, 127, 149, 163, 3, 182, 52, 122, 212, 128, 98, 107, 112, 90, 57, 148, 73, 63, 239, 217, 81, 244, 82, 126, 97, 13, 212, 71, 200, 13, 194, 173, 133, 70, 161, 188, 55, 241, 244, 81, 199, 214, 179, 126, 245, 151, 79 }, new byte[] { 109, 241, 202, 38, 78, 77, 164, 63, 197, 152, 39, 200, 243, 32, 195, 21, 231, 238, 6, 139, 91, 135, 187, 159, 239, 3, 34, 38, 224, 73, 127, 80, 130, 34, 114, 32, 149, 84, 106, 187, 213, 251, 192, 63, 116, 39, 133, 94, 36, 251, 154, 208, 208, 179, 190, 129, 122, 40, 165, 107, 101, 152, 156, 238, 175, 34, 153, 14, 121, 127, 123, 68, 142, 46, 65, 221, 242, 156, 223, 135, 26, 220, 159, 124, 36, 54, 156, 8, 217, 47, 177, 176, 4, 198, 124, 241, 82, 64, 22, 9, 29, 184, 123, 158, 18, 138, 159, 4, 226, 4, 176, 149, 163, 43, 77, 181, 120, 48, 172, 185, 12, 133, 42, 17, 57, 214, 105, 249 } });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Kilometers", "MakeId", "Model", "Name", "Price", "Year" },
                values: new object[,]
                {
                    { 9, "silver", 6231, 4, "tt", "fsi tronic turbo", 200000, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "white", 100, 5, "t-cross", "200 tsi total", 55000, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "yellow", 6000, 3, "ecosport", "xlt", 25000, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132, "dark blue", 1223, 4, "q3", "ambiente quattro", 160000, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 312, "red", 3000, 2, "mirage", "g4", 49000, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1254, "white", 500, 4, "rs4", "avant quattro", 290000, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1928, "orange", 12938, 3, "ranger", "xl 2.8", 70000, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2000, "white", 1000, 1, "corolla", "xei", 40000, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2429, "brown", 59210, 1, "hilux", "sw4", 12144, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4236, "purple", 82191, 5, "santana", "gli 2.0", 27000, new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5912, "black", 71293, 2, "montero", "pajero", 36000, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12198, "grey", 1235, 5, "gol", "msi total trendline", 35000, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12568, "green", 192102, 3, "f-100", "3.6 super gasolina", 10000, new DateTime(1982, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59182, "blue", 0, 4, "a5", "sportback ambiente", 250000, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123566, "black", 1000, 2, "outlander", "gt v6", 65000, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1254);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1928);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2429);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4236);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5912);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12198);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12568);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 59182);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 123566);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa8cbb73-653c-43cf-ae03-125a91ae59b9"));

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
