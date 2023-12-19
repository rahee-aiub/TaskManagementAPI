Table of Contents
Controller Overview
Endpoints
GetTasks
GetTaskModel
PutTaskModel
PostTaskModel
DeleteTaskModel
Controller Overview
Dependencies
ITaskService: The controller relies on an implementation of the ITaskService interface, injected through the constructor. This service provides the necessary business logic for task management.
Authorization (Optional)
Uncomment the [Authorize] attribute to enforce authentication based on the specified policy ("BasicAuthentication" in this case).
Endpoints
GetTasks
Endpoint: GET /api/Task
Description: Retrieves a list of all tasks.
Response:
200 OK: Returns a list of TaskModel objects.
404 Not Found: If no tasks are found.
GetTaskModel
Endpoint: GET /api/Task/{id}
Description: Retrieves a specific task by its ID.
Parameters:
id (integer): ID of the task.
Response:
200 OK: Returns the specified TaskModel.
404 Not Found: If the task with the given ID is not found.
PutTaskModel
Endpoint: PUT /api/Task/{id}
Description: Updates an existing task.
Parameters:
id (integer): ID of the task to be updated.
Request Body: Updated TaskModel object.
Response:
200 OK: Returns the updated TaskModel.
400 Bad Request: If the provided ID in the URL does not match the ID in the request body.
PostTaskModel
Endpoint: POST /api/Task
Description: Creates a new task.
Request Body: TaskModel object representing the new task.
Response:
201 Created: Returns the newly created TaskModel with a location header pointing to the new resource.
DeleteTaskModel
Endpoint: DELETE /api/Task/{id}
Description: Deletes a task by its ID.
Parameters:
id (integer): ID of the task to be deleted.
Response:
200 OK: Returns a success message after deleting the task.
404 Not Found: If the task with the given ID is not found.
