using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_Example.Data.Migrations
{
    public partial class spGetCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE Procedure GetCustomers
	@filter varchar(100) = NULL,
    @page int = 1,
    @pageCount int = 10,
    @column varchar(100) = 'Email',
	@order varchar(10) = 'ASC'
AS
BEGIN

	SET @filter = LTRIM(RTRIM(@filter));

	; WITH CTE_Results AS 
	(
		SELECT Id, UserName, Email, PhoneNumber from AspNetUsers
		WHERE (@filter IS NULL OR UserName LIKE @filter + '%') 
	 			ORDER BY
   		 CASE WHEN (@column = 'UserName' AND @order='ASC')
						THEN UserName
			END ASC,
			CASE WHEN (@column = 'UserName' AND @order='DESC')
					   THEN UserName
			END DESC,
		 CASE WHEN (@column = 'Email' AND @order='ASC')
						THEN Email
			END ASC,
			CASE WHEN (@column = 'Email' AND @order='DESC')
					   THEN Email
			END DESC 
		  OFFSET @pageCount * (@page - 1) ROWS
		  FETCH NEXT @pageCount ROWS ONLY
		),
	CTE_TotalRows AS 
	(
	 select count(Id) as MaxRows from AspNetUsers WHERE (@filter IS NULL OR UserName LIKE @filter + '%')
	)
	   Select MaxRows, t.Id, t.UserName, t.Email, t.PhoneNumber from AspNetUsers as t, CTE_TotalRows 
	   WHERE EXISTS (SELECT 1 FROM CTE_Results WHERE CTE_Results.UserName = t.UserName)
	   OPTION (RECOMPILE)

END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
