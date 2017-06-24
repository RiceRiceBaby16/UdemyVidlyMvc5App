namespace CourseByMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthDateForExistingCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '12Jan1998' WHERE Name LIKE 'Josh%';");
            Sql("UPDATE Customers SET BirthDate = '26Feb1988' WHERE Name LIKE 'Clare%';");
            Sql("UPDATE Customers SET BirthDate = '11Mar1978' WHERE Name LIKE 'Andy%';");
        }
        
        public override void Down()
        {
        }
    }
}
