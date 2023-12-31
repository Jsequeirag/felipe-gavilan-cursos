﻿using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace WebApiAutores.Utilidades
{
    public class CabeceraEstaPresenteAtributte:Attribute,IActionConstraint
    {
        private readonly string cabecera;
        private readonly string valor;

        public CabeceraEstaPresenteAtributte(string cabecera,string valor)
        {
            this.cabecera = cabecera;
            this.valor = valor;
        }
        public int Order => 0;
        public bool Accept(ActionConstraintContext Context)
        {
            var cabeceras = Context.RouteContext.HttpContext.Request.Headers;
            if(!cabeceras.ContainsKey(cabecera))
            {
                return false; 
            }
            return string.Equals(cabeceras[cabecera],valor,StringComparison.OrdinalIgnoreCase);
        }
    }
}
