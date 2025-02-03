Software requerido para el desarrollo:
- Microsoft Visual Studio 2022 + Paquete de desarrollo .NET 8 con Blazor.
- Microsoft SQL Server Management Studio (opcional, pero altamente recomendado).
- Microsoft SQL Server Express (requerido tal como está el proyecto, opcional si se usa otro tipo de base de datos).

Pasos para la primera ejecución:

1) Si usa SQL Server Express con su dirección y nombre de servidor predeterminados, vaya al paso 3.
2) Cambiar el string de conexión de la base de datos en el archivo "appsettings.json", guardando los cambios.
3) Desde la consola del Administrador de paquetes, ejecutar update-database para crear una copia nueva de la base de datos.
4) Ejecutar la aplicación en HTTP o HTTPS según se requiera y probar que las operaciones CRUD funcionen correctamente.
