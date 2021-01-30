using System;
using Data.Form;
using Data.Models;

namespace Pizzeria.Mappers
{
    public static class RetourMapper
    {
        public static RetourForm RetourToRetourForm(this Retour retour)
        {
            return new RetourForm
            {
                AvisId=retour.AvisId,
                LastName=retour.LastName,
                FirstName=retour.FirstName,
                Avis=retour.Avis
            };
        }

        public static Retour RetourFormToRetour(this RetourForm retour)
        {
            return new Retour
            {
                AvisId = retour.AvisId,
                LastName = retour.LastName,
                FirstName = retour.FirstName,
                Avis = retour.Avis
            };
        }
    }
}
