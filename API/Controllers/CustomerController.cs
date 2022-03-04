using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController
{

    public CustomerController()
    {

    }

    [HttpGet(Name = "GetCustomerList")]
    public string Get()
    {
        return "jignesh patel";
    }
}
