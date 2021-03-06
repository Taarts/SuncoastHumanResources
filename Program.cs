using System;


namespace SuncoastHumanResources
{

    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Our Employee Database    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            // Our list of employees
            var database = new EmployeeDatabase();
            database.LoadEmployees();

            // Should we keep showing the menu?

            var keepGoing = true;

            DisplayGreeting();

            // While the user hasn't said QUIT yet
            while (keepGoing)
            {
                // Insert a blank line then prompt them and get their answer (force uppercase)
                Console.WriteLine();
                Console.Write("What do you want to do?\n (A)dd an employee\n (U)pdate an employee\n (D)elete an employee\n or (S)how all the employees\n or (F)ind an employee\n or (Q)uit: ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "D":
                        DeleteEmployee(database);
                        break;
                    case "F":
                        ShowEmployee(database);
                        break;
                    case "S":
                        showAllEmployees(database);
                        break;
                    case "U":
                        UpdateEmployee(database);
                        break;
                    case "A":
                        AddEmployees(database);
                        break;

                    default:
                        Console.WriteLine("?????? ?????? ?????? ?????? ?????? NOPE! ?????? ?????? ?????? ?????? ??????");
                        break;

                }
                // end of the `while` statement
            }
        }

        private static void DeleteEmployee(EmployeeDatabase database)
        {
            var name = PromptForString("What name are you looking for? ");
            // search to see if the employee exists
            Employee foundEmployee = database.FindOneEmployee(name);
            // if employee not found 
            if (foundEmployee == null)
            {
                Console.WriteLine("Employee doesn't exist.");
            }
            // employee found, Delete?
            else
            {
                // We did find the employee
                // show details
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                // ask to confirm "Are you sure you want to delete?"
                var confirm = PromptForString("Are you sure? [Y/N] ").ToUpper();

                // no
                if (confirm == "Y")
                {
                    database.DeleteEmployee(foundEmployee);
                }
            }
        }

        private static void ShowEmployee(EmployeeDatabase database)
        {
            // Ask for the name of an employee
            var name = PromptForString("What name are you looking for? ");

            // Make a new variable to store the found employee, initializing
            // to null which will indicate no match found
            Employee foundEmployee = database.FindOneEmployee(name);

            // If the foundEmployee is still null, nothing was found
            if (foundEmployee == null)
            {
                Console.WriteLine("No match found");
            }
            else
            {
                // Otherwise print details of the found employee
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
            }
        }

        private static void UpdateEmployee(EmployeeDatabase database)
        {
            // Update - CREATE,  READ, UPDATE, DELETE
            var name = PromptForString("What name are you looking for? ");
            // search to see if the employee exists
            Employee foundEmployee = database.FindOneEmployee(name);
            // if employee not found 
            if (foundEmployee == null)
            {
                Console.WriteLine("Employee doesn't exist.");
            }
            else
            {
                // confirm
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                var changeChoice = PromptForString("What do you want to change [Name/Dept/Salary]? ");

                // what do you want to change
                //    - if name
                if (changeChoice == "Name")
                {
                    //      - prompt for name
                    foundEmployee.Name = PromptForString("What is the new name? ");
                }
                //    - if dept
                //      - prompt for dept
                if (changeChoice == "Department")
                {
                    foundEmployee.Department = PromptForInteger("What is the new department? ");
                }
                //    - if Salary
                //      - prompt for salary
                if (changeChoice == "Salary")
                {
                    foundEmployee.Salary = PromptForInteger("What is the new Salary? ");
                }
                // if not found 
                // show message
            }
        }

        private static void AddEmployees(EmployeeDatabase database)
        {
            // Make a new employee object
            var employee = new Employee();

            // Prompt for values and save them in the employee's properties
            employee.Name = PromptForString("What is your name? ");
            employee.Department = PromptForInteger("What is your department number? ");
            employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

            // Add it to the list
            database.AddEmployee(employee);
        }

        private static void showAllEmployees(EmployeeDatabase database)
        {
            // Loop through each employee
            foreach (var employee in database.GetAllEmployees())
            {
                // And print details
                Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
            }
        }
    }
}