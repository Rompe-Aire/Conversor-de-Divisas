# Conversor de Divisas

Este es un programa de consola que permite convertir entre diferentes divisas. Ofrece una interfaz sencilla para agregar nuevas divisas, modificar sus valores y realizar conversiones de una divisa a otra. Es fácil de usar y es compatible con cualquier sistema operativo que tenga .NET instalado.

## Requisitos

- .NET Core 3.1 o superior (para compilar y ejecutar el programa).
- (Opcional) Visual Studio o cualquier IDE que soporte C#.

## Instalación

### Opción 1: Ejecutar el archivo EXE

1. Descarga el archivo ejecutable (EXE) de la última versión desde [aquí](https://github.com/Rompe-Aire/Conversor-de-Divisas/releases).
2. Coloca el archivo en la carpeta deseada.
3. Ejecuta el archivo haciendo doble clic en él.

### Opción 2: Compilar desde el código fuente

1. Clona este repositorio o descarga el código fuente:
   ```bash
   git clone https://github.com/Rompe-Aire/Conversor-de-Divisas.git
   ```
2. Navega a la carpeta del proyecto:
   ```bash
   cd Conversor-de-Divisas
   ```
3. Compila el proyecto usando .NET:
   ```bash
   dotnet build -c Release
   ```
4. Publica el proyecto para crear un archivo ejecutable independiente:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained
   ```
5. Encuentra el archivo EXE en la carpeta `bin/Release/netX.X/win-x64/publish`.

## Uso

Al iniciar el programa, se mostrará un menú con las siguientes opciones:

1. **Agregar divisa**: Permite añadir una nueva divisa y su valor.
2. **Cambiar valor de divisa**: Modifica el valor de una divisa existente.
3. **Convertir divisa**: Convierte una cantidad de una divisa a otra.
4. **Ver lista de divisas**: Muestra todas las divisas y sus valores actuales.
5. **Salir**: Cierra el programa.

### Ejemplo de Uso

- Selecciona la opción deseada introduciendo el número correspondiente.
- Sigue las instrucciones en pantalla para realizar la acción deseada.

## Guardado de Datos

Las divisas y sus valores se guardan en un archivo de texto llamado `values.txt` en la misma carpeta donde se ejecuta el programa. Esto asegura que los datos persistan entre sesiones.

## Contribuciones

Si deseas contribuir a este proyecto, puedes hacerlo de las siguientes maneras:

- Reportando errores o problemas.
- Sugerencias para nuevas características.
- Mejoras en la documentación.

Para contribuir, simplemente realiza un fork del repositorio, realiza tus cambios y envía un pull request.

## Licencia

Este proyecto está bajo la Licencia MIT.

## Contacto

Para más información, puedes contactar a [angeloleonhart01@gmail.com](mailto:angeloleonhart01@gmail.com).
