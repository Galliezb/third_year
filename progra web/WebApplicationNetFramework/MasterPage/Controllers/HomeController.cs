using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterPage.Models;

namespace MasterPage.Controllers
{

    // TODO : 
    // Créer une bannière ( ou menu ) a intégrer à chaque page
    //  Créér une page item permettant de lister les articles
    // Ajout une status barre affichant le nombre d'article affichés ( comment la page 
    // item va au parent et redescend sur l'enfant )
    // retour de script en JQuery
    //
    // méanisme d'inpersonalisation sur les droits d'accès aux sites web


    public class HomeController : Controller
    {

        List<GetAllArticlesResult> maListeArticle = new List<GetAllArticlesResult>();

        // GET: Home
        public ActionResult Index()
        {
            ArticlesDataContext mesArticles = new ArticlesDataContext();
            maListeArticle = mesArticles.GetAllArticles().ToList<GetAllArticlesResult>();
            return View( maListeArticle );
        }

        public ActionResult ArticleItem(string id) {

            ArticlesDataContext Article = new ArticlesDataContext();
            GetArticleResult articleRecu = Article.GetArticle( int.Parse(id) ).FirstOrDefault();

            return PartialView("_PartialPage1",articleRecu);
        }

    }

}