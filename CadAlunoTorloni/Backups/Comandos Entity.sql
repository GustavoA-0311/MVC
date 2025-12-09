dotnet tool list
dotnet tool install
dotnet ef dbcontext scaffold "Server=NOTE03-S19\SQLEXPRESS;User Id=sa; Password=Senai@134; Database=CadAlunoTorloni;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c CadAlunoTorloniContext --data-annotations -f