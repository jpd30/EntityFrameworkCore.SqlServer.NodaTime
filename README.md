Repository
==========

This repository is home to the following project.  This project is maintained by [Jon Davies](mailto:jpd.cantab@gmail.com) and licensed under the [Apache Licence, Version 2.0](LICENCE.txt).

* [EntityFrameworkCore.SqlServer.NodaTime]

EntityFrameworkCore.SqlServer.NodaTime
--------------------------------------

### Installation

EF Core SqlServer NodaTime will be available on [NuGet](https://www.nuget.org/packages/EntityFrameworkCore.SqlServer.NodaTime). Install the project, along with the SQL Server database provider and underlying EF Core packages.

```sh
dotnet add package EntityFrameworkCore.SqlServer.NodaTime
```

Use the `--version` option to specify a [preview version](https://www.nuget.org/packages/EntityFrameworkCore.SqlServer.NodaTime/absoluteLatest) to install.

### Usage

The following code demonstrates a simple entity and `DbContext` making use of EF Core SQL Server NodaTime.

```cs
class MyEntity
{
    public int Id { get; set; }
    public Instant Instant { get; set; }
    public LocalDate LocalDate { get; set; }
    public LocalTime LocalTime { get; set; }
    public LocalDateTime LocalDateTime { get; set; }
    public OffsetDateTime OffsetDateTime { get; set; }
}

class MyContext : DbContext
{
    public DbSet<MyEntity> MyEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=SqlServerNodaTime",
            options => options.UseNodaTime()
        );
    }
}
```
