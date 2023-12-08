using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly List<ICocktail> coctails;

        //ctor
        public CocktailRepository()
        {
              this.coctails = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => this.coctails;

        public void AddModel(ICocktail model)
        {
            coctails.Add(model);
        }
    }
}
