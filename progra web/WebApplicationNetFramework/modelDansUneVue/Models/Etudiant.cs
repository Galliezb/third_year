using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace modelDansUneVue.Models {
    public class Etudiant {

        [Required]
        [StringLength( 100, MinimumLength = 5, ErrorMessage = "Le Nom doit avoir entre 5 et 100 caractères" )]
        public string Nom { get; set; }
        [Required]
        [StringLength( 100, MinimumLength = 5, ErrorMessage = "Le Prénom doit avoir entre 5 et 100 caractères" )]
        public string Prenom { get; set; }
        [Required]
        [StringLength(100, MinimumLength=5, ErrorMessage = "Le Matricule doit avoir entre 5 et 100 caractères" )]
        public string Matricule { get; set; }
        [Required]
        [RegularExpression( @"^[.*]+\@[.*]+\.[.*]+$", ErrorMessage ="Le champ mail est requis" )]
        [Remote("CheckUnicity","Home", ErrorMessage ="Ok ?")]
        public string Email { get; set; }
        [Required]
        public DateTime DateDeNaissance { get; set; }
    }
}