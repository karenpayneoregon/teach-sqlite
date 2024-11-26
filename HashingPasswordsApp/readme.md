# About

This project demonstrates using a third-party library [BCrypt.Net-Next](https://www.nuget.org/packages/BCrypt.Net-Next/4.0.3?_src=template) to hash a password. Note that the database is copied to the debug folder on each run of the application.

All work, insert a new record with a hashed password followed by reading the new record and verifying the password is done in a single method. Of course, in real life we have separate methods.

[Dapper](https://www.nuget.org/packages/Dapper) is used for data operations.

All work, insert an

BCrypt.Net-Next alias `BC` is setup in the project file.

```xml
<ItemGroup>
   <PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
   <Using Include="BCrypt.Net.BCrypt" Alias="BC" />
</ItemGroup>
```


