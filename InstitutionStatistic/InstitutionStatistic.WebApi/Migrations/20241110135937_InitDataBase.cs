using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitutionStatistic.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlPath = Path.Combine("Migrations", "sql", "InitDataBase.sql");
            var sql = File.ReadAllText(sqlPath);
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
