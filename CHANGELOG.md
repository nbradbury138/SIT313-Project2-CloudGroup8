# Changelog
All notable changes to this project will be documented in this file.

**Commits on 20/09/18** (Glenn Prince)

Added the connectivity plugin to check for internet connectivity from the client side and changed the way the client adds, reads and updates items from the server to synchronise when connectivity is restablished. Also reworked the application start to hide the login screen if the user has a valid bear token.

**Commits on 18/09/18** (Glenn Prince)

Created all the required task API's on the server to make the Wed API a full CRUD service. Added the settings plugin to the project and created the structures to allow us to save the username / password and bearer tokens to the local device to prevent the user from having to log in all the time. Enabled all the client side work to save and retrieve tasks from the server while the user is connected.

**Commits on 16/09/18** (Glenn Prince)

Hooked up the registration and login service to the proper view created by John. Tested out to make sure the access token was recieved and the user didn't get getting prompted to login or register.

**Commits on 15/09/18** (Nathan Bradbury)

Removed User Model as no need for local database side. Changed the usernames in the default data to be email addresses, added in last modified date field for tasks.
Made changes to allow returning task lists for specific user. Added in application wide property for username. Tested functionality

**Commits on 15/09/18** (John Bulauan)

Register button on login screen working. Transitions to the register xaml page once clicked. New register page pushed to github due to xamarin ide problems "Data is invalid at the root level" Line 1 position 1. Thus a creation of a new register page was made.

**Commits on 13/09/18** (Glenn Prince)

Tested out the login process and the use of the OAuth bearer token and created the Task API services to get and set task details.

**Commits on 12/09/18** (Nathan Bradbury)

Worked on getting the views to talk to the local database using the MVVM methodology. Worked with the Create Task page, the home page which shows a list of tasks and the Task Screen which shows the task details. I added a delete button to be able to delete the task from within the task itself. I also added in a create button for creating tasks from the home/list page. Completed moderate testing to ensure the functionality worked.

**Commits on 07/09/18** (John Bulauan)

Create In-App user interfaces for all screens. This includes; Home, Login, Registration, Task and Create Task Views.

**Commits on 06/09/18** (Nathan Bradbury)

Added in and worked on code for the following classes UserDataRepository.cs, AddTaskViewModel.cs, AddUserViewModel.cs, BaseTaskViewModel.cs, BaseUserViewModel.cs, TaskDetailViewModel.cs, TaskListViewModel.cs.

Tested functionality of the TaskList with a sample view.

**Commits on 05/09/18** (Glenn Prince)

Cleaned up all the unrelated functions to the web server that we wouldn't be using and tried to implement email confirmations to the registration and sign up process but couldn't get this to work.

**Commits on 30/08/18** (Glenn Prince)

Creation of the Web API Server project to handle the registration and login for the user. Initialy used the standard .NET 4.5 Identity Web API with some cleanups delpoyed onto a personal Azure tenancy. Created a user services class within the application to handle the regitsration events as well as the view models that will feed data to that service.

**Commits on 30/08/18** (Nathan Bradbury)

Added in TaskDataRepository, DBHelper, iOS and Android Database files worked further on database models, added in default data and checks to see if database exists and if tables/data exist

**Commits on 29/08/18** (John Bulauan)

No github commits, wireframe of UI's were created by myself.

**Commits on 25/08/18** (Nathan Bradbury)

Create database/table structures and place in the Model Folder. This includes tables for TaskData, UserData, LUStatus and LUPriority.cs. I also included an interface to be used with the database.