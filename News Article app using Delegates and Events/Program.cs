using System.Security.Cryptography.X509Certificates;

namespace News_Article_app_using_Delegates_and_Events
{
    internal class Program
    {
        public static void Main()
        {
            NewsArticleCollection newsArticles = new NewsArticleCollection();


            newsArticles.RegisterArticleFilteredHandler(category =>
            {
                Console.WriteLine($"Articles filtered by category '{category}'");
            });


            newsArticles.articleAddedHandler += article =>
            {
                Console.WriteLine($"Article added: {article.Title} ({article.Category})");
            };

            newsArticles.articleRemovedHandler += article =>
            {
                Console.WriteLine($"Article removed: {article.Title} ({article.Category})");
            };

            NewsArticle article1 = new NewsArticle("New Iphone release", "Technology");
            NewsArticle article2 = new NewsArticle("Record profits for Apple", "Business");
            NewsArticle article3 = new NewsArticle("New study shows benefits of exercise", "Health");

            newsArticles.AddArticle(article1);
            newsArticles.AddArticle(article2);
            newsArticles.AddArticle(article3);

            List<NewsArticle> filteredArticles = newsArticles.FilterArticlesByCategory("Technology");

            newsArticles.RemoveArticle(article2);
        }
    }



}
