using System.ComponentModel.DataAnnotations;
using Business.Interfaces;
using Business.Factories;
using Business.Dtos;
using Business.Models;

namespace PresentationApp;
public class MenuDialogs(IProjectsService projectsService, ICustomerService customerService, ICustomerContactsService customerContactsService, IUserService userService, IRoleService roleService) : IMenuDialogs
{
    private readonly IProjectsService _projectsService = projectsService;
    private readonly ICustomerService _customerService = customerService;
    private readonly IUserService _userService = userService;
    private readonly IRoleService _roleService = roleService;   
    private readonly ICustomerContactsService _customerContactsService = customerContactsService;



    public void ShowMainMenu()
    {
        while (true)
        {
            var option = MainMenu();
            if (!string.IsNullOrEmpty(option))
            {
                MenuOptionSelector(option);
            }
            else
            {
                Console.WriteLine("Du måste ange ett giltigt alternativ!");
                Console.ReadKey();
            }
        }
    }
    public static string MainMenu()
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

    public void MenuOptionSelector(string option)
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
                CreateUsers();
                break;
            case "4":
                WiewAllUsers();
                break;
            case "5":
                //CreateProject();
                break;
            case "6":
                //WiewAllProject();
                break;
            case "7":
                //ViewProject();
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

    customerRegistrationForm.CustomerName = PromptAndValidate("Skriv in kundnamn: ", nameof(CustomerRegistrationForm.CustomerName));
    customerContactsRegistrationForm.FirstName = PromptAndValidate("Skriv in kontaktpersonens förnamn: ", nameof(CustomerContactsRegistrationForm.FirstName));
    customerContactsRegistrationForm.LastName = PromptAndValidate("Skriv in kontaktpersonens efternamn: ", nameof(CustomerContactsRegistrationForm.LastName));


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

public void CreateUsers()
    {
        Console.Clear();

        var userRegistrationForm = UserFactory.Create();
        var roleRegistrationForm = RoleFactory.Create();

        userRegistrationForm.FirstName = PromptAndValidate("Förnamn: ", nameof(UserRegistrationForm.FirstName));
        userRegistrationForm.LastName = PromptAndValidate("Efternamn: ", nameof(UserRegistrationForm.LastName));
        userRegistrationForm.Email = PromptAndValidate("Email: ", nameof(UserRegistrationForm.Email));
        roleRegistrationForm.RoleName = PromptAndValidate("Roll: ", nameof(RoleRegistrationForm.RoleName));

       
        var roleResult = _roleService.GetRoleByIdAsync(2).Result;
        if (roleResult.Success)
        {
            
        }
        else
        {
            OutputDialog("Kunde inte hämta rollinformation.");
            return;
        }

        var result = _userService.CreateUserAsync(userRegistrationForm);
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

    public string PromptAndValidate(string prompt, string propertyName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(prompt);
            var input = Console.ReadLine() ?? string.Empty;

            var result = new List<ValidationResult>();
            var context = new ValidationContext(new CustomerRegistrationForm()) { MemberName = propertyName };

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
