using DataAccess.Entity;
using DataAccess.Repository;
using ITInvestVarna.Filters;
using ITInvestVarna.Models;
using ITInvestVarna.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITInvestVarna.Controllers
{
   
    public class ArticlesController : BaseController<Article, ArticlesRepository, FilterVM, IndexVM, EditVM, OrderBy>
    {
        protected override void PopulateModel(IndexVM model)
        {
            UsersRepository uRepo = new UsersRepository();

            
            
            ArticlesRepository aRepo = new ArticlesRepository();
            List<Article> dbArticles = aRepo.GetAll(a => true);

            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem()
            {
                Text = "",
                Value = null

            });

            foreach (Article article in dbArticles)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = article.Title,
                    Value = article.Id.ToString()

                });

            }

            model.Filter.NameList = new SelectList(listItems, "Value", "Text",model.Filter.Title??null);


            List<User> dbUsers = uRepo.GetAll(a => true);
            List<SelectListItem> userList = new List<SelectListItem>();
            userList.Add(new SelectListItem()
            {
                Text = "",
                Value = null

            });

            foreach (User user in dbUsers)
            {
                userList.Add(new SelectListItem()
                {
                    Text = user.Name,
                    Value = user.Id.ToString()

                });

            }

            model.Filter.UsersesList = new SelectList(userList, "Value", "Text", model.Filter.UserId ?? null);


            CategoriesRepository cRepo = new CategoriesRepository();
            List<Category> dbCategories = cRepo.GetAll(a => true);

            List<SelectListItem> listItems2 = new List<SelectListItem>();

            listItems2.Add(new SelectListItem()
            {
                Text = "",
                Value = null

            });

            foreach (Category category in dbCategories)
            {
                listItems2.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()

                });

            }

            model.Filter.CategoryList = new SelectList(listItems2, "Value", "Text", model.Filter.CategoryId);



        }

        public virtual ActionResult Details(DetailsVM model)
        {
            ArticlesRepository arepo = new ArticlesRepository();
            Article article = arepo.GetArticleWithAllKeyWords(model.Id);
            model.PopulateDetailModel(article);

            UsersRepository urepo = new UsersRepository();
            model.User = urepo.GetById(model.UserId);

            CommentsRepository crepo = new CommentsRepository();
            model.Comments = crepo.GetAll(c => c.ArticleId == model.Id);

            GalleriesRepository grepo = new GalleriesRepository();
            model.Galleries = grepo.GetAll(g => g.ArticleId == model.Id);

           

            return View(model);
        }

        [HttpGet]       
        public override ActionResult Edit(EditVM model, FormCollection form)
        {
            if (AuthenticationManager.LoggedUser.Id == model.UserId||AuthenticationManager.LoggedUser.IsAdmin)
            {
                return base.Edit(model, form);
            }
            return RedirectToAction("Index", "Articles");

        }

        protected override void PopulateEditModel(EditVM model, ref bool valid)
        {
            model.Type = "Service";
            model.UserId = AuthenticationManager.LoggedUser.Id;


          CategoriesRepository cRepo = new CategoriesRepository();
            List<Category> dbCategories = cRepo.GetAll(a => true);

            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem()
            {
                Text = "",
                Value = null

            });

            foreach (Category category in dbCategories)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString()

                });

            }

            model.CategoriesList = new SelectList(listItems, "Value", "Text", model.CategoryId );

        }
    }


    }
