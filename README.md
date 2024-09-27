# AsisteUNC

AsisteUNC es una aplicaci�n web desarrollada en ASP.NET Core con Razor Pages. Su objetivo principal es gestionar la asistencia de eventos en la Universidad Nacional de Cajamarca (UNC). La aplicaci�n permite a los usuarios crear eventos, registrar asistencias y gestionar la informaci�n relacionada con los registros de entrada a los eventos.

## Caracter�sticas

- **Gesti�n de Asistencias**: Registra la asistencia de los participantes de un evento con datos como la hora de entrada y el evento al que asistieron.
- **Gesti�n de Eventos**: Los usuarios pueden crear, visualizar y eliminar eventos, adem�s de ver los detalles espec�ficos de cada evento.
- **Dise�o Moderno**: La interfaz utiliza **Tailwind CSS** para crear una apariencia moderna, minimalista y agradable al usuario.
- **Soporte de CRUD**: La aplicaci�n permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para los eventos y asistencias.
- **Autenticaci�n de Usuarios**: El sistema incluye autenticaci�n para proteger las funcionalidades sensibles como la creaci�n y eliminaci�n de eventos.
- **Responsividad**: La interfaz est� dise�ada para adaptarse a diferentes tama�os de pantalla, brindando una experiencia �ptima en dispositivos m�viles y de escritorio.

## Tecnolog�as Utilizadas

- **ASP.NET Core**: Para el backend y la gesti�n de Razor Pages.
- **Razor Pages**: Utilizado para la creaci�n de vistas din�micas.
- **Entity Framework Core**: (si lo utilizas) Para la manipulaci�n y persistencia de datos.
- **Tailwind CSS**: Para el dise�o de la interfaz de usuario.
- **Git**: Para el control de versiones y la colaboraci�n en el proyecto.

## Funcionalidades

### 1. Gesti�n de Eventos
- **Crear evento**: Los usuarios pueden crear nuevos eventos indicando el t�tulo, la fecha de inicio y otros detalles relevantes.
- **Ver eventos**: Los eventos creados se muestran en una p�gina organizada con un dise�o de cuadr�cula.
- **Detalles del evento**: Al hacer clic en un evento, se pueden ver detalles adicionales, como la lista de asistentes y las opciones de administraci�n.
- **Eliminar evento**: Los usuarios pueden eliminar eventos que ya no sean necesarios.

### 2. Gesti�n de Asistencias
- **Registro de asistencia**: Los usuarios pueden registrar la asistencia de los participantes en los eventos creados.
- **Hora de entrada**: Se registra autom�ticamente la hora de entrada al momento de la asistencia.
- **Relaci�n con eventos**: Cada registro de asistencia est� vinculado a un evento espec�fico.

## Requisitos

Para ejecutar este proyecto de manera local, se requiere:

- **.NET SDK**: Versi�n 6.0 o superior.
- **Visual Studio** o **VS Code** con las extensiones para ASP.NET Core.
- **SQL Server** o SQLite (si usas Entity Framework Core para la base de datos).

## Instalaci�n

1. **Clona el repositorio**:
    ```bash
    git clone https://github.com/Davs07/AsisteUNC.git
    cd AsisteUNC
    ```

2. **Restaura los paquetes**:
    ```bash
    dotnet restore
    ```

3. **Compila el proyecto**:
    ```bash
    dotnet build
    ```

4. **Ejecuta la aplicaci�n**:
    ```bash
    dotnet run
    ```

5. Accede a la aplicaci�n en tu navegador en `http://localhost:5000`.

## Capturas de Pantalla

### P�gina Principal
![P�gina Principal](ruta/a/tu/captura1.png)

### Gesti�n de Eventos
![Gesti�n de Eventos](ruta/a/tu/captura2.png)

## Contribuciones

Si deseas contribuir al desarrollo de AsisteUNC, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu funcionalidad (`git checkout -b nueva-funcionalidad`).
3. Realiza tus cambios y haz commits descriptivos (`git commit -m "A�adida nueva funcionalidad X"`).
4. Empuja tus cambios al repositorio remoto (`git push origin nueva-funcionalidad`).
5. Abre un Pull Request.

## Licencia

Este proyecto est� licenciado bajo la Licencia MIT - consulta el archivo [LICENSE](LICENSE) para obtener m�s detalles.

