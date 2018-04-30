using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure;
using DD.Models;


namespace DD.Controllers
{
    public class PersonController : Controller
    {
		// GET: Person
		
	    [ActionName("Create")]
	    public async Task<ActionResult> CreateAsync()
	    {
		    return View();
	    }

		[HttpPost]
		[ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync([Bind(Include = "Id,FirstName,MiddleName,LastName, Email, Addresses")] Person person)
		{
			if (ModelState.IsValid)
			{
				await DocumentDBRepository<Person>.CreateItemAsync(person);
				return RedirectToAction("Index");
			}

			return View(person);
		}

	    [HttpPost]
	    [ActionName("Edit")]
	    [ValidateAntiForgeryToken]
	    public async Task<ActionResult> EditAsync([Bind(Include = "Id,FirstName, MiddleName,LastName,Email")] Person person)
	    {
		    if (ModelState.IsValid)
		    {
			    await DocumentDBRepository<Person>.UpdateItemAsync(person.Id, person);
			    return RedirectToAction("Index");
		    }

		    return View(person);
	    }

	    [ActionName("Edit")]
	    public async Task<ActionResult> EditAsync(string id)
	    {
		    if (id == null)
		    {
			    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		    }

		    Person person = await DocumentDBRepository<Person>.GetItemAsync(id);
		    if (person == null)
		    {
			    return HttpNotFound();
		    }

		    return View(person);
	    }
	}
}