# ToDoTask
# Proyecto Full Stack: Angular + AWS Lambda (.NET Core)
Este proyecto es una aplicación simple de gestión de tareas que permite a los usuarios realizar las siguientes operaciones:

1. **Crear**: una tarea nueva.
2. **Listar Tareas**: Mostrar todas las tareas existentes.
3. **Visualizar una Tarea**: Ver los detalles de una tarea específica.
4. **Eliminar una Tarea**: Borrar una tarea seleccionada.

Cada tarea contiene los siguientes campos:
- **ID**: Un identificador único de la tarea.
- **Nombre**: El nombre de la tarea.
- **Descripción**: Una breve descripción de la tarea.

El backend de la aplicación está implementado usando funciones **AWS Lambda** en **.NET Core** que se integran con **API Gateway** para gestionar las solicitudes HTTP (GET, DELETE, POST). El frontend está desarrollado en **Angular**, proporcionando una interfaz de usuario para interactuar con estas operaciones.
## Requisitos Previos

### Frontend (Angular)
- Node.js (v16 o superior) y npm (Node Package Manager)
  - Descarga desde: https://nodejs.org/
- Angular CLI
  - Instala usando npm: npm install -g @angular/cli

### Backend (AWS Lambda con .NET Core)
- .NET Core SDK (v3.1 o superior)
  - Descarga desde: https://dotnet.microsoft.com/download
- AWS Tools for Visual Studio
  - Instrucciones de instalación: https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/setup-install.html

## Estructura del Proyecto

El repositorio está organizado de la siguiente manera:

- **/ToDoTask.Lambda(ClassLibrary)**: Esta carpeta contiene una librería compartida que incluye las entidades, repositorios y clases relacionadas que pueden ser usadas por las funciones Lambda.
-   - **/Entity**: Contiene las clases que representan las entidades del dominio.
    - **TaskEntity.cs**: Define la estructura de las entidades de negocio (por ejemplo, usuarios, productos, etc.).
      
  - **/Repository**: Aquí está la lógica de acceso a datos.
    - **IRepository.cs**: Interfaz que define los métodos del repositorio (por ejemplo, para añadir, obtener o eliminar registros).
    - **Repository.cs**: Implementación de los métodos de acceso a datos definidos en IRepository.cs.

  - **/RequestModel**: Contiene las clases usadas para gestionar las solicitudes (request) y las respuestas (response) de las funciones Lambda.
    - **TaskRequest.cs**: Clase que define los datos de entrada para las operaciones de las funciones Lambda.
    - **TaskResponse.cs**: Clase que encapsula los datos de respuesta de las funciones Lambda.
    - 
- **/Function**: Esta carpeta contiene la función Lambda que se encarga de añadir un registro a la base de datos o al servicio correspondiente.
- **/FunctionDelete**: Contiene la función Lambda que se encarga de obtener registros desde el backend o base de datos.
- **/FunctionGet**: Función Lambda que se encarga de eliminar registros en el sistema.

## Pasos para Descargar y Ejecutar el Proyecto

### 1. Clonar el Repositorio

Clona este repositorio en tu máquina local utilizando la siguiente Url:

git clone https://github.com/Estremor/ToDoTask
## Ejecutar angular
Navegar a la carpeta angular y ejecutar: 
cd angular-app
npm install
ng serve

## .Net App
### Despliegue de las Lambdas

El despliegue de las funciones Lambda puede realizarse directamente desde Visual Studio utilizando el AWS Toolkit. Sigue los pasos a continuación:

#### 1. Abrir la solución en Visual Studio

1. Abre Visual Studio.
2. Navega a la carpeta raíz de tu proyecto y abre el archivo de solución (.sln).

#### 3. Instalar los paquetes NuGet necesarios

1. En el Explorador de Soluciones, haz clic derecho en el proyecto ToDoTask.Lambda.
2. Selecciona Administrar paquetes NuGet.
3. En la pestaña Examinar, busca e instala los paquetes, como:
   - APIGatewayEvents
   - AWSSDK.DynamoDBv2
   - Lambda.Core.

#### 4. Desplegar las Lambdas en AWS
1. En el Explorador de Soluciones, haz clic derecho en el proyecto de la función Lambda que deseas desplegar.
2. Selecciona Publish to AWS Lambda.
3. Se abrirá el asistente de publicación de AWS Lambda. En esta ventana, sigue los pasos:
   - Elige la región de AWS donde quieres desplegar la función Lambda.
   - Selecciona si deseas crear una nueva función Lambda o actualizar una existente.
4. Configura el role adecuado:

5. Haz clic en Publish.
Nota las api estan en aws para ralizar las pruebas

## Diagrama de la Arquitectura

![Diagrama de arquitectura](TodoTask/Todo%20task%20Diagram.drawio.png)
