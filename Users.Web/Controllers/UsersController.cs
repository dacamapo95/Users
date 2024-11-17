using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Users.Shared;
using Users.Web.Hubs;

namespace Users.Web.Controllers;
public class UsersController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly HttpClient _httpClient;
    private readonly IHubContext<NotificationHub> _hubContext;

    public UsersController(IHttpClientFactory clientFactory, IHubContext<NotificationHub> hubContext)
    {
        _clientFactory = clientFactory;
        _httpClient = _clientFactory.CreateClient("UsersApiClient");
        _hubContext = hubContext;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("/api/users");

        if (response.IsSuccessStatusCode)
        {
            var users = await response.Content.ReadFromJsonAsync<IEnumerable<UserResponse>>();
            return View(users);
        }
        else
        {
            return View(new List<UserResponse>());
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {

        var response = await _httpClient.PostAsJsonAsync("/api/users", request);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(request);
        }
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"/api/users/{id}");
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit()
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _httpClient.GetFromJsonAsync<UserDetailResponse>($"/api/users/{id}");
        var model = new UpdateUserRequest(
            user.Id,
            user.Password,
            user.UserName,
            user.Email,
            user.FirstName,
            user.SecondName,
            user.LastName,
            user.SecondLastName);

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(UpdateUserRequest updateUserRequest)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/users/{updateUserRequest.Id}", updateUserRequest);
        return RedirectToAction(nameof(Index));
    }
}
