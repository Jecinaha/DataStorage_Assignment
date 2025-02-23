using System.ComponentModel.DataAnnotations;
using Business.Interfaces;
using Business.Factories;
using Business.Dtos;
using Business.Models;
using Business.Services;

namespace PresentationApp;
public class MenuDialogs(IProjectsService projectsService, IStatusService StatusService, IProductService ProductService, ICustomerService customerService, ICustomerContactsService customerContactsService, IUserService userService, IRoleService roleService) : IMenuDialogs
{
    private readonly IProjectsService _projectsService = projectsService;
    private readonly IStatusService _statusService = StatusService;
    private readonly IProductService _productService = ProductService;
    private readonly ICustomerService _customerService = customerService;
    private readonly IUserService _userService = userService;
    private readonly IRoleService _roleService = roleService;
    private readonly ICustomerContactsService _customerContactsService = customerContactsService;

    public void Run()
    {
        _ = _roleService.CreateDefaultRoles().Result;
        _ = _statusService.CreateDefaultStatuses().Result;
        _ = _productService.CreateDefaultProducts().Result;


        while (true)
        {

            var option = ShowMenu();
            if (!string.IsNullOrEmpty(option))
            {
                RunMenuOption(option);
            }
            else
            {
                Console.WriteLine("Du måste ange ett giltigt alternativ!");
                Console.ReadKey();
            }
        }
    }
    public static string ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("................MENY.................\n");
        Console.WriteLine($"{"  1",-3} Lägg till kund");
        Console.WriteLine($"{"  2",-3} Visa alla kunder\n");

        Console.WriteLine($"{"  3",-3} Lägg till anställd");
        Console.WriteLine($"{"  4",-3} Visa alla anställda\n");

        Console.WriteLine($"{"  5",-3} Lägg till projekt");
        Console.WriteLine($"{"  6",-3} Visa alla projekt");
        Console.WriteLine($"{"  7",-3} Visa ett projekt\n");

        Console.WriteLine($"{"  8",-3} Avsluta\n");
        Console.WriteLine(".....................................\n");
        Console.Write("  Välj ditt alternativ: ");
        var option = Console.ReadLine()!;

        return option;
    }

    public void RunMenuOption(string option)
    {
        switch (option)
        {
            case "1":
                CreateCustomers();
                break;
            case "2":
                WiewAllCustomers();
                break;
            case "3":
                CreateUser();
                break;
            case "4":
                WiewAllUsers();
                break;
            case "5":
                CreateProjects();
                break;
            case "6":
                WiewAllProject();
                break;
            case "7":
                ViewProject();
                break;
            case "8":
                QuitOption();
                break;
            default:
                InvalidOption();
                break;
        }
    }
    public void CreateCustomers()
    {
        Console.Clear();

        var customerRegistrationForm = CustomerFactory.Create();
        var customerContactsRegistrationForm = CustomerContactsFactory.Create(2);

        customerRegistrationForm.CustomerName = PromptAndValidate(customerRegistrationForm, prompt: "Skriv in kundnamn: ", nameof(CustomerRegistrationForm.CustomerName));
        customerContactsRegistrationForm.FirstName = PromptAndValidate(customerContactsRegistrationForm, prompt: "Skriv in kontaktpersonens förnamn: ", nameof(CustomerContactsRegistrationForm.FirstName));
        customerContactsRegistrationForm.LastName = PromptAndValidate(customerContactsRegistrationForm, prompt: "Skriv in kontaktpersonens efternamn: ", nameof(CustomerContactsRegistrationForm.LastName));

        var customerContactsResult = _customerContactsService.GetAllCustomerContactsAsync().Result;
        if (customerContactsResult.Success)
        {

        }
        else
        {
            OutputDialog("Kunde inte hämta rollinformation.");
            return;
        }

        var result = _customerService.CreateCustomerAsync(customerRegistrationForm);

        if (result != null)
        {
            OutputDialog("Kunden har nu lagts till i din kundlista");
        }
        else
        {
            OutputDialog("Kunden gick inte att lägga till i din kundlista");
        }

    }

    public void WiewAllCustomers()
    {
        var AllCustomersResponse = _customerService.GetAllCustomerAsync().Result;

        if (!AllCustomersResponse.Success)
        {
            Console.WriteLine("Det finns inga kunder i denna listan.");
            return;
        }

        var customers = AllCustomersResponse.Data;

        Console.Clear();
        Console.WriteLine("...........KUNDLISTA...........");

        foreach (var customer in customers)
        {
            Console.WriteLine($"{"\nKundnummer: ",-5}{customer.Id}");
            Console.WriteLine($"{"\nKund: ",-5}{customer.CustomerName}");
            Console.WriteLine($"{"\nKontaktperson: ",-5}{customer.Contacts}");



            Console.WriteLine("\n.....................................");
        }
        Console.ReadKey();
    }

    public void CreateUser()
    {
        Console.Clear();

        var userRegistrationForm = UserFactory.Create();

        userRegistrationForm.FirstName = PromptAndValidate(userRegistrationForm, prompt: "Förnamn", nameof(UserRegistrationForm.FirstName));
        userRegistrationForm.LastName = PromptAndValidate(userRegistrationForm, prompt: "Efternamn", nameof(UserRegistrationForm.LastName));
        userRegistrationForm.Email = PromptAndValidate(userRegistrationForm, prompt: "Email", nameof(UserRegistrationForm.Email));

        var roleResult = _roleService.GetAllRoleAsync().Result;
        if (roleResult.Success)
        {
            var roles = roleResult.Data;
            Console.WriteLine(".....................................");
            foreach (var role in roles)
            {
                Console.WriteLine($"{"Rollnummer: ",-5}{role.Id}");
                Console.WriteLine($"{"Roll: ",-5}{role.RoleName}");
                Console.WriteLine(".................");
            }
            Console.WriteLine(".....................................");

            Console.WriteLine("Välj rollnummer: ");
            var input = Console.ReadLine() ?? string.Empty;
            var roleId = int.Parse(input);
            var selectedRole = roles.FirstOrDefault(x => x.Id == roleId);

            userRegistrationForm.Role = selectedRole;

            _userService.CreateUserAsync(userRegistrationForm);
        }
        else
        {
            OutputDialog("Kunde inte hämta rollinformation.");
            return;
        }
    }
    public void WiewAllUsers()
    {
        var allUsersResponse = _userService.GetAllUsersAsync().Result;
        if (!allUsersResponse.Success)
        {
            Console.WriteLine("Det finns inga anställda i denna listan.");
            return;
        }

        var users = allUsersResponse.Data;

        Console.Clear();
        Console.WriteLine("...........ANSTÄLLDA...........");

        foreach (var user in users)
        {
            Console.WriteLine($"{"\nNamn: ",-5}{user.FirstName} {user.LastName}");
            Console.WriteLine($"{"\nEmail: ",-5}{user.Email}");
            Console.WriteLine($"{"\nRoll: ",-5}{user.Role.RoleName}");
            Console.WriteLine("\n.....................................");
        }
        Console.ReadKey();
    }

    public void CreateProjects()
    {
        Console.Clear();

        var form = GetProjectInfo();
        var result = _projectsService.CreateProjectsAsync(form).Result;
        if (result.Success)
        {
            OutputDialog("Projektet har nu lagts till i din projektlista");
        }
        else
        {
            OutputDialog("Projektet gick inte att lägga till i din projektlista");
        }
    }

    private ProjectsForm? GetProjectInfo()
    {
        var projectRegistrationForm = ProjectsFactory.Create();

        projectRegistrationForm.Title = PromptAndValidate(projectRegistrationForm, prompt: "Projektnamn: ", nameof(ProjectsForm.Title));
        projectRegistrationForm.Description = PromptAndValidate(projectRegistrationForm, prompt: "Beskrivning: ", nameof(ProjectsForm.Description));

        Console.WriteLine("Startdatum (format yyyy-mm-dd hh:mm): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var start))
        {
            OutputDialog("Felaktigt datumformat. Försök igen.");
            return null;
        }
        projectRegistrationForm.StartDate = start;


        Console.WriteLine("Slutdatum (format yyyy-mm-dd hh:mm): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var end))
        {
            OutputDialog("Felaktigt datumformat. Försök igen.");
            return null;
        }
        projectRegistrationForm.EndDate = end;


        var projectStatusResult = _statusService.GetAllStatusAsync().Result;
        if (projectStatusResult.Success)
        {
            var statuses = projectStatusResult.Data;
            Console.WriteLine(".....................................");
            foreach (var status in statuses)
            {
                Console.WriteLine($"{"Statusnummer: ",-5}{status.Id}");
                Console.WriteLine($"{"Status: ",-5}{status.StatusName}");
                Console.WriteLine(".................");
            }
            Console.WriteLine(".....................................");

            Console.WriteLine("Välj status: ");
            var input = Console.ReadLine() ?? string.Empty;
            var statusId = int.Parse(input);
            var selectedStatus = statuses.FirstOrDefault(x => x.Id == statusId);

            projectRegistrationForm.Status = selectedStatus;
        }
        else
        {
            OutputDialog("Kunde inte hämta status.");
            return null;
        }

        var projectProductResult = _productService.GetAllProductAsync().Result;
        if (projectProductResult.Success)
        {
            var products = projectProductResult.Data;
            Console.WriteLine(".....................................");
            foreach (var product in products)
            {
                Console.WriteLine($"{"Nummer: ",-5}{product.Id}");
                Console.WriteLine($"{"Tjänst: ",-5}{product.ProductName}");
                Console.WriteLine(".................");
            }
            Console.WriteLine(".....................................");

            Console.WriteLine("Välj tjänst: ");
            var input = Console.ReadLine() ?? string.Empty;
            var productId = int.Parse(input);
            var selectedProduct = products.FirstOrDefault(x => x.Id == productId);

            projectRegistrationForm.Product = selectedProduct;
        }
        else
        {
            OutputDialog("Kunde inte hämta tjänster.");
            return null;
        }

        var projectCustomerResult = _customerService.GetAllCustomerAsync().Result;
        if (projectCustomerResult.Success)
        {
            var customers = projectCustomerResult.Data;
            Console.WriteLine(".....................................");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{"Kundnummer: ",-5}{customer.Id}");
                Console.WriteLine($"{"Kundnamn: ",-5}{customer.CustomerName}");
                Console.WriteLine($"{"Kontaktperson: ",-5} {customer.Contacts}");
                Console.WriteLine(".................");
            }
            Console.WriteLine(".....................................");

            Console.WriteLine("Välj kund: ");
            var input = Console.ReadLine() ?? string.Empty;
            var customerId = int.Parse(input);
            var selectedCustomer = customers.FirstOrDefault(x => x.Id == customerId);

            projectRegistrationForm.Customer = selectedCustomer;
        }
        else
        {
            OutputDialog("Kunde inte hämta kunden.");
            return null;
        }

        var projectUserResult = _userService.GetAllUsersAsync().Result;
        if (projectUserResult.Success)
        {
            var users = projectUserResult.Data;
            Console.WriteLine(".....................................");
            foreach (var user in users)
            {
                Console.WriteLine($"{"Anställningsnummer: ",-5}{user.Id}");
                Console.WriteLine($"{"Förnamn: ",-5}{user.FirstName}");
                Console.WriteLine($"{"EfterNamn: ",-5} {user.LastName}");
                Console.WriteLine(".................");
            }
            Console.WriteLine(".....................................");

            Console.WriteLine("Välj projektledare: ");
            var input = Console.ReadLine() ?? string.Empty;
            var userId = int.Parse(input);
            var selectedUser = users.FirstOrDefault(x => x.Id == userId);

            projectRegistrationForm.User = selectedUser;
        }
        else
        {
            OutputDialog("Kunde inte hämta kunden.");
            return null;
        }

        return projectRegistrationForm;
    }

    public void WiewAllProject()
    {
        var allProjectsResponse = _projectsService.GetAllProjectsAsync().Result;
        if (!allProjectsResponse.Success)
        {
            Console.WriteLine("Det finns inget projekt i denna listan.");
            return;
        }

        var projects = allProjectsResponse.Data;

        Console.Clear();
        Console.WriteLine("...........Projekt...........");

        foreach (var project in projects)
        {
            Console.WriteLine($"{"\nProjektnamn: ",-5}{project.Title}");
            Console.WriteLine($"{"\nKund: ",-5}{project.Customer.CustomerName}");
            Console.WriteLine("\n.....................................");
        }
        Console.ReadKey();
    }

    public void ViewProject()
    {
        Console.Clear();

        var allProjectsResponse = _projectsService.GetAllProjectsAsync().Result;
        if (!allProjectsResponse.Success)
        {
            Console.WriteLine("Det finns inget projekt i denna listan.");
            return;
        }

        var projects = allProjectsResponse.Data;
        Console.WriteLine(".....................................");
        foreach (var project in projects)
        {
            Console.WriteLine($"{"\nProjektnummer: ",-5}{project.Id}");
            Console.WriteLine($"{"\nProjektnamn: ",-5}{project.Title}");
            Console.WriteLine($"{"\nKund: ",-5}{project.Customer?.CustomerName ?? "Ej satt"}");
            Console.WriteLine(".................");
        }
        Console.WriteLine(".....................................");

        Console.WriteLine("Välj projekt att visa: ");
        var input = Console.ReadLine() ?? string.Empty;
        var projectId = int.Parse(input);
        var selectedProject = projects.FirstOrDefault(x => x.Id == projectId);

        Console.Clear();
        Console.WriteLine("...........DETALJERAD INFORMATION OM PROJEKT...........");
        Console.WriteLine($"{"\nProjektnamn: ",-5}{selectedProject.Title}");
        Console.WriteLine($"{"\nBeskrivning: ",-5}{selectedProject.Description}");
        Console.WriteLine($"{"\nStarttid: ",-5}{selectedProject.StartDate}");
        Console.WriteLine($"{"\nSluttid: ",-5}{selectedProject.EndDate}");
        Console.WriteLine($"{"\nStatus: ",-5}{selectedProject.Status?.StatusName ?? "Ej satt"}");
        Console.WriteLine($"{"\nKund: ",-5}{selectedProject.Customer?.CustomerName ?? "Ej satt"}");
        Console.WriteLine($"{"\nTjänst: ",-5}{selectedProject.Product?.ProductName ?? "Ej satt"}");
        Console.WriteLine($"{"\nProjektansvarig: ",-5}{selectedProject.User?.FirstName} {selectedProject.User?.LastName}");
        Console.WriteLine("\n.....................................");

        Console.WriteLine("Vill du uppdatera? (Y/N)");

        var shouldUpdate = Console.ReadLine();
        if (shouldUpdate.ToUpper() == "Y")
        {
            var form = GetProjectInfo();
            if (form == null)
            {
                return;
            }

            var result = _projectsService.UpdateProjectsAsync(selectedProject.Id, form).Result;
            if (!result.Success)
            {
                OutputDialog("Misslyckades att uppdatera projekt");
                return;
            }
        }
    }

    public string PromptAndValidate<T>(T toValidate, string prompt, string propertyName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(prompt);
            var input = Console.ReadLine() ?? string.Empty;

            var result = new List<ValidationResult>();
            var context = new ValidationContext(toValidate) { MemberName = propertyName };

            if (Validator.TryValidateProperty(input, context, result))
                return input;
            Console.WriteLine($"{result[0].ErrorMessage}. Försök igen");
        }
    }
    public static void QuitOption()
    {
        Environment.Exit(0);
    }

    public static void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("Du måste ange ett giltigt alternativ!");
        Console.ReadKey();
    }

    public static void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
