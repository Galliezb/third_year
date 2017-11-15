using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lesFiltres.Models {

    // la surcharge de l'Authorize permettra de personnaliser la page d'erreur de retour
    // On pourra le récuprer via le viewData.Error
    // Le viewname par défaut étant Error, il faudra créer cette page en gérant le viewData.Error

    public class MyAuthorize:AuthorizeAttribute {

        public virtual string MasterName { get; set; }
        public virtual string ViewName { get; set; } = "Error";


        // permet de gérer les redirection lors d'accès autorisé
        //public override void OnAuthorization(AuthorizationContext filterContext) {
        //    base.OnAuthorization( filterContext );
        //}

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            
            if ( !filterContext.HttpContext.User.Identity.IsAuthenticated) {
                filterContext.Result = new HttpUnauthorizedResult(); // pas encore authentifié
            } else {

                ViewDataDictionary viewData = new ViewDataDictionary();
                viewData.Add("Error","Vous n'avez pas les droits pour accéder à cette ressource.");
                filterContext.Result = new ViewResult { MasterName = this.MasterName, ViewName = "Index", ViewData = viewData };
                
            }

        }

    }
}