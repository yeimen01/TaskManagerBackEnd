# 📌 Task Management API (.NET Core)

API RESTful construida con ASP.NET Core para gestionar tareas. Soporta operaciones CRUD, validaciones básicas y persistencia con Entity Framework Core usando SQLite o SQL Server.

---

## 🛠️ Tecnologías utilizadas

- ASP.NET Core 8+
- Entity Framework Core
- SQL Server
- Swagger (documentación interactiva)

---

## 📋 Modelo de Datos

```csharp
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }           // Obligatorio
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public DateTime DueDate { get; set; }       // No puede ser anterior a hoy
}

📦 Requisitos
- .NET 8 SDK
- SQL Server
- Visual Studio / VS Code
```
## 🛠️ Ejemplos de uso con curl

📌 Crear una tarea
curl -X POST https://localhost:5001/api/tasks \
  -H "Content-Type: application/json" \
  -d '{"title":"Estudiar .NET","description":"Leer documentación","dueDate":"2025-05-30"}'

📌 Listar tareas
curl https://localhost:5001/api/tasks

📌 Actualizar una tarea
curl -X PUT https://localhost:5001/api/tasks/1 \
  -H "Content-Type: application/json" \
  -d '{"id":1,"title":"Estudiar EF Core","description":"Revisar migraciones","isDone":false,"dueDate":"2025-06-01"}'

📌 Eliminar una tarea
curl -X DELETE https://localhost:5001/api/tasks/1
