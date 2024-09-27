# AsisteUNC

AsisteUNC es una aplicación web desarrollada en ASP.NET Core con Razor Pages. Su objetivo principal es gestionar la asistencia de eventos en la Universidad Nacional de Cajamarca (UNC). La aplicación permite a los usuarios crear eventos, registrar asistencias y gestionar la información relacionada con los registros de entrada a los eventos.

## Características

- **Gestión de Asistencias**: Registra la asistencia de los participantes de un evento con datos como la hora de entrada y el evento al que asistieron.
- **Gestión de Eventos**: Los usuarios pueden crear, visualizar y eliminar eventos, además de ver los detalles específicos de cada evento.
- **Diseño Moderno**: La interfaz utiliza **Tailwind CSS** para crear una apariencia moderna, minimalista y agradable al usuario.
- **Soporte de CRUD**: La aplicación permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para los eventos y asistencias.
- **Autenticación de Usuarios**: El sistema incluye autenticación para proteger las funcionalidades sensibles como la creación y eliminación de eventos.
- **Responsividad**: La interfaz está diseñada para adaptarse a diferentes tamaños de pantalla, brindando una experiencia óptima en dispositivos móviles y de escritorio.

## Tecnologías Utilizadas

- **ASP.NET Core**: Para el backend y la gestión de Razor Pages.
- **Razor Pages**: Utilizado para la creación de vistas dinámicas.
- **Entity Framework Core**: (si lo utilizas) Para la manipulación y persistencia de datos.
- **Tailwind CSS**: Para el diseño de la interfaz de usuario.
- **Git**: Para el control de versiones y la colaboración en el proyecto.

## Funcionalidades

### 1. Gestión de Eventos
- **Crear evento**: Los usuarios pueden crear nuevos eventos indicando el título, la fecha de inicio y otros detalles relevantes.
- **Ver eventos**: Los eventos creados se muestran en una página organizada con un diseño de cuadrícula.
- **Detalles del evento**: Al hacer clic en un evento, se pueden ver detalles adicionales, como la lista de asistentes y las opciones de administración.
- **Eliminar evento**: Los usuarios pueden eliminar eventos que ya no sean necesarios.

### 2. Gestión de Asistencias
- **Registro de asistencia**: Los usuarios pueden registrar la asistencia de los participantes en los eventos creados.
- **Hora de entrada**: Se registra automáticamente la hora de entrada al momento de la asistencia.
- **Relación con eventos**: Cada registro de asistencia está vinculado a un evento específico.

## Requisitos

Para ejecutar este proyecto de manera local, se requiere:

- **.NET SDK**: Versión 6.0 o superior.
- **Visual Studio** o **VS Code** con las extensiones para ASP.NET Core.
- **SQL Server** o SQLite (si usas Entity Framework Core para la base de datos).

## Instalación

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

4. **Ejecuta la aplicación**:
    ```bash
    dotnet run
    ```

5. Accede a la aplicación en tu navegador en `http://localhost:5000`.

## Capturas de Pantalla

### Página Principal
![Página Principal](ruta/a/tu/captura1.png)

### Gestión de Eventos
![Gestión de Eventos](ruta/a/tu/captura2.png)

## Contribuciones

Si deseas contribuir al desarrollo de AsisteUNC, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu funcionalidad (`git checkout -b nueva-funcionalidad`).
3. Realiza tus cambios y haz commits descriptivos (`git commit -m "Añadida nueva funcionalidad X"`).
4. Empuja tus cambios al repositorio remoto (`git push origin nueva-funcionalidad`).
5. Abre un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - consulta el archivo [LICENSE](LICENSE) para obtener más detalles.

