using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab4_AmitAmit.Models;
using lab4_AmitAmit.Data;
using Microsoft.EntityFrameworkCore;

namespace lab4_AmitAmit.Controllers;

/***
*@Author : Amit Amit
*@Date : 3/26/2024
* SID : 8941429
* Created apis for Home  webapp
*/


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ApplicationDbContext _context;

    //modified controller to get Database Context while initialized

    public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    //pass it the list of Blogs

    public async Task<IActionResult> Index()
    {
            return View(await _context.Blogs.ToListAsync());
    }

    //to display all the content inside a particular blog

    public async Task<IActionResult> BlogsPost(int? id)
    {
            if (id == null)
            {
                return NotFound();
            }
             var blogPosts = await _context.Posts
                            .Where(b => b.BlogId == id)
                            .ToListAsync();

            if (blogPosts == null || !blogPosts.Any())
            {
                return NotFound();
            }
            
            return View(blogPosts);
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
