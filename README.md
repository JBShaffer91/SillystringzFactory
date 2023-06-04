# Factory Management Application

This is a .NET 5 MVC application that allows factory managers to track engineers and machines. 

## Functionality

This application supports full CRUD (Create, Read, Update, Delete) operations for both engineers and machines:

- **Create:** Add a new engineer or machine.
- **Read:** View a list of all engineers or machines, or view details for a single engineer or machine, including their associated machines or engineers, respectively.
- **Update:** Edit the details of an existing engineer or machine.
- **Delete:** Delete an engineer or machine.

## Setup

Here are the steps to get the application running on your local machine:

1. **Clone the Repository:** Use the following command in your terminal to clone the repository:
```bash
git clone https://github.com/JBShaffer91/SillystringzFactory.git
```
2. Navigate into the directory:
```bash
cd Factory
```
3. Update the Database Connection: Update the "DefaultConnection" string in appsettings.json to match your local database server configuration.

4. Install the Dependencies:

```bash
dotnet restore
```
Update the Database: Apply the database migrations using Entity Framework Core:
```bash
dotnet ef database update
```
Run the Application: Use the .NET CLI to run the application:
```bash
dotnet run
```
The application should now be running on https://localhost:5001/.

## Troubleshooting
If you encounter issues when running the application, please check the console for any error messages. These messages can often provide clues about what's going wrong. If you continue to have issues, feel free to submit an issue on this repository.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
Copyright 2023 Justin Shaffer

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.