using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class ArticlesRepository:BaseRepository<Article>
    {
        public Article GetArticleWithAllKeyWords(int Id)
        {
            var ArticleWithAllKeyWords = Items.Include("KeyWords")
                            .Where(s => s.Id == Id).FirstOrDefault();


              return ArticleWithAllKeyWords;
        }
    }
}
