using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Article_app_using_Delegates_and_Events
{
    public class NewsArticleCollection
    {
        private List<NewsArticle> _articles = new List<NewsArticle>();

        public event Action<NewsArticle> articleAddedHandler;
        public event Action<NewsArticle> articleRemovedHandler;
        public event Action<string> articleFilteredHandler;

        public void RegisterArticleFilteredHandler(Action<string> handler)
        {
            articleFilteredHandler += handler;
        }

        public void AddArticle(NewsArticle article)
        {
            _articles.Add(article);

            articleAddedHandler?.Invoke(article);

            articleFilteredHandler?.Invoke(article.Category);
        }

        public void RemoveArticle(NewsArticle article)
        {
            if (_articles.Contains(article))
            {
                _articles.Remove(article);

                articleRemovedHandler?.Invoke(article);

                articleFilteredHandler?.Invoke(article.Category);
            }
            
        }

        public List<NewsArticle> FilterArticlesByCategory(string category)
        {
            List<NewsArticle> filteredArticles = new List<NewsArticle>();


            //return _articles.FindAll(x => x.Category == category);

            foreach (NewsArticle article in _articles)
            {
                if (article.Category == category)
                {
                    filteredArticles.Add(article);
                }
            }

            articleFilteredHandler?.Invoke(category);

            return filteredArticles;
        }

    }
}
