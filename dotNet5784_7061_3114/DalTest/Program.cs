﻿namespace DalTest;

using Dal;
using DalApi;
using DO;
using System.Xml.Linq;

internal class Program
{
    // Variables for the Interfaces .
    //static readonly IDal? e_dal = new DalList(); // Stage 2
    // static readonly IDal? e_dal = new DalXml(); // Stage 3

    //The field will be initialized to work with the class that supports the Factory design template
    //that initializes the appropriate class according to the configuration file
    static readonly IDal e_dal = Factory.Get; //stage 4                                         

    //private static IDependency? e_dalDependency = new DependencyImplementation();
    //private static ITask? e_dalTask = new TaskImplementation();
    //private static IEngineer? e_dalEngineer = new EngineerImplementation();

    // Global to go out from all menus .

    static bool _exit = false;
    static void Main(string[] args)
    {
        try
        {
            //Initialization.Do(e_dal);


            while (!_exit)
            {
                //Console.WriteLine();
                DisplayMainMenu();
                // Input char and convert to char type .
                char? userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (userInput)
                {
                    case '0':
                        _exit = true;
                        break;
                    case '1':
                        EngineerSubMenu("Engineer"); // Entity 1

                        break;
                    case '2':
                        TaskSubMenu("Task"); // Entity 2
                        break;
                    case '3':
                        DependencySubMenu("Dependency"); // Entity 3
                        break;
                    case '4':
                        // If we want to initialization the data base .
                        Console.Write("Would you like to create Initial data? (Y/N)"); //stage 3
                        string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3

                        if (ans == "Y")
                        {
                            //Initialization.Do(e_dal); // stage 2
                            Initialization.Do(); // stage 4
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }

        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur during initialization or subsequent code execution
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }

    static void EngineerSubMenu(string menuEntityName)
    {
        bool returnMainMenu = false;
        while (!returnMainMenu)
        {
            Console.WriteLine();
            // Call to the sub menu of the entity .
            DisplaySubEntityMenu(menuEntityName);

            // Input char and convert to char type .
            char? userInput = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (userInput)
            {
                case '0':
                    // We go out from all menus , and finish the running .
                    _exit = true;
                    returnMainMenu = true;
                    break;
                case '1':
                    // Perform Create operation                       
                    //Console.WriteLine($"Enter the {menuEntityName} ditals: id, cost, level, email, name");

                    Engineer newEngineer = InputValueEngineer();
                    // Send the item to methods of create and insert to list of engineer
                    try
                    {
                        e_dal!.Engineer.Create(newEngineer);
                    }
                    // If the engineer is exist
                    catch (DalDoesExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case '2':
                    // Perform Read operation       
                    Console.Write($"Enter the {menuEntityName} id: ");
                    int searchId = int.Parse(Console.ReadLine()!);
                    // Search the engineer inside detebase and bring him
                    Engineer? engineer = e_dal!.Engineer.Read(searchId);
                    // If is exist
                    if (engineer != null)
                    {
                        Console.WriteLine("The engineer is ");
                        Console.WriteLine(engineer);
                        break;
                    }
                    Console.WriteLine("The engineer is not exist");
                    break;

                case '3':
                    // Perform ReadAll operation
                    Console.WriteLine("Perform ReadAll operation for Entity " + menuEntityName);
                    IEnumerable<DO.Engineer?> engineers = e_dal!.Engineer.ReadAll();
                    if (engineers != null)
                    {
                        foreach (var i_engineer in engineers)
                        {
                            // Print the name of all engineer
                            Console.WriteLine(i_engineer);
                        }
                        break;
                    }
                    Console.WriteLine("The DataBase is empty");
                    break;

                case '4':
                    // Perform Update operation
                   
                    try
                    {
                        Console.WriteLine($"Enter the {menuEntityName} id: ");
                        int readId = int.Parse(Console.ReadLine()!);

                        Engineer? previousEngineer = e_dal!.Engineer.Read(readId);
                        if (previousEngineer != null)
                        {
                            // Print the previous engineer .
                            Console.WriteLine(previousEngineer);                           
                        }
                        Console.WriteLine();

                        Engineer updateEngineer = InputValueEngineer();
                        // Send the item to methods of create and insert to list of engineer
                        e_dal!.Engineer.Update(updateEngineer);
                    }
                    // If the engineer is exist
                    catch (DalDoesNotExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case '5':
                    // Perform Delete operation
                    Console.WriteLine("Enter Id to remove frome the DataBase ");
                    int id = int.Parse(Console.ReadLine()!);
                    try
                    {
                        e_dal!.Engineer.Delete(id);
                    }
                    // If the engineer is exist
                    catch (DalDoesNotExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (DalCannotDeleted ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case '6':
                    returnMainMenu = true;
                    break;
                // Add more cases for additional operations if needed
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
    /// <summary>
    /// Input the task values for case (create, uptade)
    /// </summary>
    /// <summary>
    /// Sub Menu for each entity .
    /// </summary>
    /// <param name="entityName"></param>

    static void TaskSubMenu(string menuEntityName)
    {
        bool returnMainMenu = false;
        while (!returnMainMenu)
        {
            Console.WriteLine();
            // Call to the sub menu of the entity .
            DisplaySubEntityMenu(menuEntityName);
            Console.WriteLine();
            // Input char and convert to char type .
            char? userInput = Console.ReadKey().KeyChar;

            Console.WriteLine();

            switch (userInput)
            {
                case '0':
                    // We go out from all menus , and finish the running .
                    _exit = true;
                    returnMainMenu = true;
                    break;

                case '1':
                    // Perform Create operation                       
                    //Console.WriteLine($"Enter the {menuEntityName} ditals: engineer id, level, alias, description, remarks");

                    DO.Task newTask = InputValueTask();
                    // Send the item to methods of create and insert to list of task
                    try
                    {
                        e_dal!.Task.Create(newTask);
                    }
                    // If the engineer is not exist
                    catch (DalDoesExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case '2':
                    // Perform Read operation       
                    Console.Write($"Enter the {menuEntityName} id: ");
                    int searchId = int.Parse(Console.ReadLine()!);

                    // Search the task inside detebase and bring him
                    DO.Task? searchTask = e_dal!.Task.Read(searchId);
                    // If is exist
                    if (searchTask != null)
                    {
                        Console.WriteLine("The Task is " + searchTask);
                        break;
                    }
                    Console.WriteLine("The Task is not exist");
                    break;

                case '3':
                    // Perform ReadAll operation
                    Console.WriteLine("Perform ReadAll operation for Entity " + menuEntityName);
                    IEnumerable<DO.Task?> tasks = e_dal!.Task.ReadAll();

                    if (tasks != null)
                    {
                        foreach (var e_task in tasks)
                        {
                            // Print the name of all task
                            Console.WriteLine(e_task);
                        }
                        break;
                    }
                    Console.WriteLine("The DataBase is empty");
                    break;

                case '4':
                    // Perform Update operation
                    
                    try
                    {
                        Console.WriteLine($"Enter the {menuEntityName} id: ");
                        int readId = int.Parse(Console.ReadLine()!);

                        DO.Task? previousTask = e_dal!.Task.Read(readId);

                        if (previousTask != null)
                        {
                            // Print the previous Task .
                            Console.WriteLine(previousTask);
                        }
                        Console.WriteLine();
                        DO.Task updateTask = InputValueTask();
                        // Send the item to methods of create and insert to list of task
                        e_dal!.Task.Update(updateTask);

                    }
                    // If the engineer is exist
                    catch (DalDoesNotExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case '5':
                    // Perform Delete operation
                    Console.WriteLine("Enter Id to remove frome the DataBase ");
                    int id = int.Parse(Console.ReadLine()!);
                    try
                    {
                        e_dal!.Task.Delete(id);
                    }
                    // If the engineer is not exist
                    catch (DalDoesExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    catch (DalCannotDeleted ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case '6':
                    returnMainMenu = true;
                    break;

                // Add more cases for additional operations if needed
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }




        }

    }



    static void DependencySubMenu(string menuEntityName)
    {
        bool returnMainMenu = false;
        while (!returnMainMenu)
        {
            Console.WriteLine();
            // Call to the sub menu of the entity .
            DisplaySubEntityMenu(menuEntityName);
            Console.WriteLine();
            // Input char and convert to char type .
            char? userInput = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (userInput)
            {
                case '0':
                    // We go out from all menus , and finish the running .
                    _exit = true;
                    returnMainMenu = true;
                    break;

                case '1':
                    // Perform Create operation                       
                   // Console.WriteLine($"Enter the {menuEntityName} ditals: DependentTask , DependsOnTas");

                    Dependency newDependency = InputValueDependency();
                    // Send the item to methods of create and insert to list of task
                    try
                    {
                       e_dal!.Dependency.Create(newDependency);
                    }
                    // If the engineer is exist
                    catch (DalDoesExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case '2':
                    // Perform Read operation       
                    Console.Write($"Enter the {menuEntityName} id: ");
                    int searchId = int.Parse(Console.ReadLine()!);

                    // Search the dependency inside detebase and bring him
                    Dependency? searchDependency = e_dal!.Dependency.Read(searchId);

                    // If is exist
                    if (searchDependency != null)
                    {
                        Console.WriteLine($"The Dependency is :{ searchDependency}");
                        break;
                    }
                    Console.WriteLine("The Dependency is not exist");
                    break;


                case '3':
                    // Perform ReadAll operation
                    Console.WriteLine("Perform ReadAll operation for Entity " + menuEntityName);

                    IEnumerable<DO.Dependency?> dependency = e_dal!.Dependency.ReadAll();
                    if (dependency != null)
                    {
                        foreach (var e_dependency in dependency)
                        {
                            // Print the name of all dependency .
                            Console.WriteLine(e_dependency);
                        }
                        break;
                    }
                    Console.WriteLine("The DataBase is empty");
                    break;

                case '4':
                    // Perform Update operation                   
                    try
                    {
                        Console.WriteLine($"Enter the {menuEntityName} id:");
                        int dependencyId = int.Parse(Console.ReadLine()!);
                        Dependency? previousDependency = e_dal!.Dependency.Read(dependencyId);
                        if (previousDependency != null)
                        {
                            Console.WriteLine(previousDependency);
                        }

                        // Send the item to methods of create and insert to list of dependcy
                        Dependency updateDependecy = InputValueDependency();

                        e_dal!.Dependency.Update(updateDependecy);
                    }
                    // If the engineer is exist
                    catch (DalDoesNotExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case '5':
                    // Perform Delete operation
                    Console.WriteLine("Enter Id to remove frome the DataBase ");
                    int id = int.Parse(Console.ReadLine()!);
                    try
                    {
                        e_dal!.Dependency.Delete(id);
                    }
                    // If the dependency is not exist
                    catch (DalDoesNotExistException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    // If can not to delete the depedncy
                    catch (DalCannotDeleted ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    // If the root is not exist
                    catch (XmlRootException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case '6':
                    returnMainMenu = true;
                    break;

                // Add more cases for additional operations if needed
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }




        }

    }

    static void DisplaySubEntityMenu(string entityName)
    {
        Console.WriteLine("Entity " + entityName + " Menu:");
        Console.WriteLine("0. Exit Main Menu");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. ReadAll");
        Console.WriteLine("4. Update");
        Console.WriteLine("5. Delete");
        Console.WriteLine("6. Back to Main Menu");
        // Add more options specific to the entity if needed
        Console.Write("Enter your choice: ");
    }

    static Engineer InputValueEngineer()
    {
        Console.WriteLine($"Enter the Engineer ditals:  UPDATE - same id / CREATE - id, cost, level, email, name");

        int id = int.Parse(Console.ReadLine()!);
        double cost = double.Parse(Console.ReadLine()!);
        DO.EngineerExperience level = (DO.EngineerExperience)int.Parse(Console.ReadLine()!);
        string? email = Console.ReadLine();
        string name = Console.ReadLine()!;

        //To save all paramers in item
        Engineer item = new(id, cost, level, email, name);
        return item;
    }


    static DO.Task InputValueTask()
    {
        Console.WriteLine($"Enter the Task ditals: engineer id,  UPDATE - same id / CREATE - id, level, alias, description, remarks");
        int engineerId = int.Parse(Console.ReadLine()!);
        int id = int.Parse(Console.ReadLine()!);
        DO.EngineerExperience? taskLevel = (DO.EngineerExperience)int.Parse(Console.ReadLine()!);
        string? alias = Console.ReadLine();
        string? description = Console.ReadLine();
        string? remarks = Console.ReadLine();

        DO.Task task = new(null, null, taskLevel, null, null, null, null, alias, description, null, remarks,id,engineerId);
        return task;
    }


    static Dependency InputValueDependency()
    {
        Console.WriteLine($"Enter the Dependency ditals: DependentTask , DependsOnTas, UPDATE - same id / CREATE - id");
        int dependentTask = int.Parse(Console.ReadLine()!);
        int dependsOnTask = int.Parse(Console.ReadLine()!);
        int id = int.Parse(Console.ReadLine()!);
        Dependency item = new(dependentTask, dependsOnTask, id);
        return item;

    }

    /// <summary>
    /// Main menu .
    /// </summary>
    static void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Entity Engineer");
        Console.WriteLine("2. Entity Task");
        Console.WriteLine("3. Entity Dependency");
        Console.WriteLine("4. Initialization");

        // Add more entities or options as needed
        Console.Write("Enter your choice: ");
    }

}
