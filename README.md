# Task-Manager

Construcción de un CRUD y aplicar los conceptos básicos de DevOps



## Tecnologías utilizadas

* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* XUnit
* Swagger
* Docker
* GitHub Actions



El motivo por el cual se decidió utilizar .NET para desarrollar esta API es debido a que ya cuento experiencia laboral previa desarrollando con este Framework. Utilice a mi familiaridad con este mismo para poder realizar el proyecto de la manera más eficaz posible.



El proyecto tiene la siguiente estructura :

* TaskManager

  * TaskManager.API

    * Properties

      * launchSettings.json
    * Controllers

      * TaskItemController.cs
    * appsettings.json
    * Program.cs
  * TaskManager.Domain

    * Entities

      * TaskItem.cs
    * Interfaces

      * ITaskItemRepository.cs
  * TaskManager.DTOs

    * CreateTaskItemDto.cs
    * GetTaskItemDto.cs
    * UpdateTaskItemDto.cs
  * TaskManager.Infrastructure

    * Data

      * AppDbContext.cs
    * Migrations
    * Repositories

      * TaskItemRepository.cs
  * TaskManager.Services

    * TaskItemService.cs
  * TaskManager.UnitTest

    * TaskItemServiceTest.cs
  * .GitHub
  * Dockerfile
  * README.md



## Prerequisitos para ejecutar el proyecto :



***Se da por entendido que cualquier comando que se deba de ejecutar, se hará desde la consola apuntando a la carpeta raíz del proyecto a menos que se indique lo contrario.*** 



#### Para ejecutar de manera local :

* Tener instalado Git
* Tener instalado .NET 10 SDK



#### Para ejecutar haciendo uso de Docker :

* Tener instalado Docker Desktop



#### IDE's sugeridos:

* Visual Studio



### Base de datos:

Este proyecto utiliza SQLite y Entity Framework, **la primera vez que se ejecuta el proyecto es necesario crear la base de datos de nombre taskmanager.db en caso de que esta no exista.** La base de datos se crea ejecutando el siguiente comando:

* *dotnet tool install  dotnet-ef*
* *dotnet ef database update*



### Pasos para ejecutar desde IDE :

* Clonar el repositorio con el comando git clone <url del repositorio> / Como alternativa, Tambien se puede descomprimir el archivo comprimido en una carpeta limpia.
* Si los paquetes NuGet no se restauran de manera automática, es necesario ir a Build -> Restore Nuget Packages.
* Compilar el proyecto con *Ctrl + Shift + B* ó con *Build -> Build Solution*
* Asegurar que TaskManager.API sea el proyecto inicial.
* Presionar el botón *Run*, o *Run without debugging* o como alternativa utilizar las combinaciones de teclado equivalente, *F5 ó Ctrl + F5*.
* Asegurarse que el puerto 7280 se encuentre disponible.
* Swagger se levantará de manera automática y el proyecto ya puede utilizarse.



### Pasos para ejecutar desde consola :

Si como alternativa uno prefiere utilizar la consola de comandos (como por ejemplo Powershell) se debería utilizar los siguientes comandos :

* Restaurar dependencias : *dotnet restore*
* Realizar el build del proyecto : *dotnet build*
* Ejecutar la api : *dotnet run --project TaskManager.API*
* Abrir swagger en la url: http://localhost:<PORT>/swagger, puerto por defecto es 7280.



### Pasos para ejecutar con Docker :

Desde una consola que esté apuntando a la raíz del proyecto :

* Construir la imagen : *docker build -t taskmanager-api .*
* Verificar que se haya creado la imágen : *docker images*
* Ejecutar el contenedor : *docker run -d -p 8080:8080 --name taskmanager-api* taskmanager-api
* Abrir swagger desde el navegador : http://localhost:8080/swagger  
* Para detener el contenedor: *docker stop taskmanager-api*
* Para volver a iniciar el contenedor : *docker start taskmanager-api*



### Pruebas

Se utilizó el framework "XUnit" para realizar las pruebas unitarias del proyecto.

Para ejecutar es necesario hacer uso del siguiente comando : *dotnet test*



### Github Actions (CI)

Este proyecto hace uso de Github Actions.

De manera automatica realiza el build del proyecto y tambien ejecuta los casos de pruebas unitarias. El pipeline se ejecuta en dos situaciones :

* Cuando se realiza un push a la rama main
* Cuando se crea un pull request para la rama main



### Glosario de comandos

* Restaurar las dependecias *: dotnet restore*
* Construir la solución *: dotnet build*
* Levantar el proyecto *: dotnet run --project TaskManager.API*
* Ejecutar pruebas unitarias *: dotnet test*
* Construir la Docker image:  *docker build -t taskmanager-api .*
* Ejecutar el contenedor: *docker run -d -´p 8080:8080 --name taskmanager-api taskmanager-api* 
* Revisar el estado del contenedor : *docker ps* 
* *Ver Logs del contenedor : docker logs taskmanager-api* 
* *D*etener el contenedor : *docker stop taskmanager-api* 
* Iniciar el contenedor : *docker start taskmanager-api* 
* Remover el contenedor : *docker rm taskmanager-api*
* Remover la Docker image : *docker rmi taskmanager-api*





&#x09;

