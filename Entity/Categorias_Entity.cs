﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Categorias_Entity
    {
        //public Categorias_Entity()
        //{
        //}

        public Guid CatIntIdValue { get; set; }

        [Required(ErrorMessage = "Favor Ingresar Nombre")]
        [Display(Name ="Nombre")]
        public string CatNombreValue { get; set; }
        [Required(ErrorMessage = "Favor Ingresar Codigo")]
        [Display(Name = "Codigo")]
        public string CatCodigoValue { get; set; }
        [Display(Name = "Estado")]
        public bool CatStatusValue { get; set; }
    }
}
