using DataAccess.Entity;
using DataAccess.Repository;
using ITInvestVarna.Filters;
using ITInvestVarna.Models;
using ITInvestVarna.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITInvestVarna.Controllers
{
    [AuthenticationFilter]
    public class UsersController : BaseController<User, UsersRepository, FilterVM, IndexVM, EditVM, OrderBy>
    {


        [AuthorizeAdmin]
        public override ActionResult Index(IndexVM model)
        {
            return base.Index(model);
        }

        [HttpGet]
        [AuthorizeAdmin]
        public override ActionResult Edit(EditVM model, FormCollection form)
        {
            return base.Edit(model, form);
        }

        [HttpPost]
        [AuthorizeAdmin]
        public override ActionResult Edit(EditVM model)
        {
            return base.Edit(model);
        }

        [HttpGet]
        [AuthorizeAdmin]
        public override ActionResult Delete(int id)
        {
            return base.Delete(id);
        }



        [HttpGet]
        public virtual ActionResult EditProfile(EditVM model, FormCollection form)
        {
            ModelState.Clear();

            model = model ?? new EditVM();

            model.Id = AuthenticationManager.LoggedUser.Id;

            UsersRepository repo = new UsersRepository();
            User item = repo.GetById(model.Id);

            if (item == null)
            {
                ModelState.AddModelError("", "The record you attempted to Edit or not found");
                return View("Edit", model);
            }
            model.PopulateModel(item);

            return View("Edit", model);
        }

        [HttpPost]
        public virtual ActionResult EditProfile(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            UsersRepository repo = new UsersRepository();
            User item = new User();

            bool valid = true;
            if (item == null)
            {
                valid = false;
            }
            if (!valid)
            {
                ModelState.AddModelError("", "The record you attempted to Edit or not found.");
                return View("Edit", model);
            }

            model.PopulateEntity(item);

            repo.Save(item);
            Models.AuthenticationManager.Authenticate(model.Email, model.Password);

            return RedirectToAction("Index");
        }

        public virtual ActionResult Details(DetailsVM model)
        {
            UsersRepository arepo = new UsersRepository();
            User user = arepo.GetById(model.Id);
            AdressesRepository adrepo = new AdressesRepository();         
            model.addresses = adrepo.GetAll(a=>a.UserId==model.Id);
            PhoneRepository phrepo = new PhoneRepository();
            foreach (Address address in model.addresses)
            {
                address.PhoneNumbers = phrepo.GetAll(a => a.AddressId == address.Id);
                    }
            model.PopulateDetailModel(user);
            return View(model);
        }

    }
}