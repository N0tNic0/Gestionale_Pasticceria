# Gestionale_Pasticceria

.Net Core Web API per gestione Pasticceria.
Pattern utilizzato: Repository And Unit Of Work Pattern.
L'applicazione espone 3 controller:
-DolciController (CRUD Dolci)
-IngredientiController (CRUD Ingredienti)
-IngredientiOfDolceController (CRUD Ingredienti utilizzati per un dolce).

Per l'esecuzione del progetto è necessario installare il DBMS Sql Server e SQL Server Management Studio.
Dopo aver installato correttamente quanto sopra indicato ottenere il nome dell'istanza di database al quale connettersi dall'applicazione attraverso l'SSMS.
Installare Visual Studio(preferibilmente Visual Studio 2019 o Visual Studio Code) e aprire la Solution Pasticceria.sln -> espandere il progetto Pasticceria.Api
-> Aprire il file appsettings.json e modificare:

"ConnectionStrings": {
    "Default": "Server=SERVER_NAME;Database=Pasticceria_Interlogica;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
  
  con il nome dell'istanza del database al posto di SERVER_NAME.
  
  Dal terminale di visual studio eseguire il seguente comando per riflettere la migrazione presente all'interno del progetto Pasticceria.Data.Migrations all'interno del nostro database:
  
 dotnet ef --startup-project Pasticceria.Api/Pasticceria.Api.csproj database update
 
 Dopo aver eseguito correttamente il comando soprastante, avviare la soluzione che esponerà su https://localhost:44307 i servizi da consumare.
