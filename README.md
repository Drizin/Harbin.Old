# Harbin Architecture
.NET Architecture - using [CodegenCS](https://github.com/Drizin/CodegenCS/) (Code Generator), EF6/EFCore, Dapper, NancyFX, Type-Safe Enums, Unit Tests

# Description

**Currently Harbin is mostly about Data Access and Business/Services Layer:**

Basically, [CodegenCS](https://github.com/Drizin/CodegenCS/) is used to read the SQL Database and generate POCOs and DbContext for Entity Framework (based on [Simon Hughes T4 templates](https://github.com/sjh37/EntityFramework-Reverse-POCO-Code-First-Generator)).  
These POCOs also work with Dapper in case you want better control over your queries and performance.  

The database model is based on AdventureWorks Database which includes [Table-per-Type](https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-2-table-per-type-tpt): BusinessEntity is defined as an abstract class and has many derived classes (Person, Employee, Vendor, etc).  

Then, we have some extensions in the "Queries" namespace which add behavior to existing DbSet<T> and IQueriable<T>, for finding objects and filtering over DbContext objects.  
Some Enums are modeled as Type-Safe-Enums (classes), while still being mapped to Entity Framework and Dapper. Expression trees allow us to apply SQL-filters based on these enums.  
  
REST endpoints are served using NancyFX.  

Currently there's no UI.  
**Would you like to contribute with REACT or VUE UI? [Get in contact](http://drizin.io/pages/Contact/).**



## Documentation

"Baby shark.. TO DO... TO DO... TO DO..."

## Contributing

If you you want to contribute, you can either:
- Fork it, optionally create a feature branch, commit your changes, push it, and submit a Pull Request.
- Drop me an email (http://drizin.io/pages/Contact/) and let me know how you can help. 



## History
- 2019-xx-xx: Initial public version. 

## License
MIT License
