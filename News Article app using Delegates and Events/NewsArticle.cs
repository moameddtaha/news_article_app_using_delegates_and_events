using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Article_app_using_Delegates_and_Events
{
    public class NewsArticle
    {
        private string _title;
        private string _category;

        public NewsArticle(string title, string category)
        {
            _title = title;
            _category = category;
        }

        public string Title
        {
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Category
        {
            get => _category;
            set => _category = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
