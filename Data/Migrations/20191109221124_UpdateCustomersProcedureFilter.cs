using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Example.Data.Migrations
{
    public partial class UpdateCustomersProcedureFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER Procedure [dbo].[GetCustomers]

    @filter varchar(100) = NULL,
    @page int = 1,
    @pageCount int = 10,
    @column varchar(100) = 'LastName',
    @order varchar(10) = 'ASC'
AS
BEGIN


    SET @filter = LTRIM(RTRIM(@filter));

            ; WITH CTE_Results AS
            (
                SELECT Id, FirstName, LastName from Customers
                WHERE @filter IS NULL OR CHARINDEX(@filter, FirstName + ' ' + LastName) > 0

                 ORDER BY

            CASE WHEN(@column = 'FirstName' AND @order = 'ASC')

                        THEN FirstName

            END ASC,
            CASE WHEN(@column = 'FirstName' AND @order = 'DESC')

                       THEN FirstName

            END DESC,
         CASE WHEN(@column = 'LastName' AND @order = 'ASC')

                        THEN LastName

            END ASC,
            CASE WHEN(@column = 'LastName' AND @order = 'DESC')

                       THEN LastName

            END DESC

          OFFSET @pageCount *(@page - 1) ROWS
         FETCH NEXT @pageCount ROWS ONLY
		),
	CTE_TotalRows AS
    (
        select count(Id) as MaxRows from Customers WHERE @filter IS NULL OR CHARINDEX(@filter, FirstName + ' ' + LastName) > 0
	)
	   Select MaxRows, t.Id, t.FirstName, t.LastName from Customers as t, CTE_TotalRows
       WHERE EXISTS(SELECT 1 FROM CTE_Results WHERE CTE_Results.FirstName = t.FirstName)

       OPTION(RECOMPILE)

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
