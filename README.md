# YappaDevChallenge API y Cliente Web

Este proyecto consiste en una API de .NET 6 que permite realizar operaciones CRUD para la gestión de clientes y un cliente web que interactúa con dicha API utilizando HTML, CSS, JavaScript y Chart.js para visualizar datos.

## Características

- **API RESTful**: Construida con .NET 6.
- **Cliente Web**: Interfaz sencilla y moderna para interactuar con la API.
- **CRUD Completo**: Operaciones de crear, leer, actualizar clientes.
- **Filtrado de Clientes**: Búsqueda por nombre o apellido.
- **Visualización de Datos**: Gráfico de clientes por año usando Chart.js.

## Instrucciones de Uso

### Pre-requisitos

- .NET 6 SDK
- Node.js (opcional, si se quiere usar un servidor HTTP para el front-end)
- SQL Server (o cualquier otro proveedor de base de datos soportado por Entity Framework Core)

### Documentación de la API
La API de Clientes ofrece las siguientes funcionalidades:

- GET /api/Client/documentation: Documentación de la API.
- GET /api/Client/GetAll: Obtiene todos los clientes.
- GET /api/Client/{id}: Obtiene un cliente por su ID.
- GET /api/Client/Search?name=value: Busca clientes por nombre o apellido.
- POST /api/Client/Insert: Crea un nuevo cliente.
- PUT /api/Client/{id}: Actualiza los datos de un cliente existente.


### Instalación

1. Clona el repositorio a tu máquina local:

```bash
git clone https://github.com/yourusername/YappaDevChallenge.git
cd YappaDevChallenge
dotnet ef database update
dotnet run
add-migration .
update-database
cd ViewApiClients
npx http-server (o usar Go Live)




