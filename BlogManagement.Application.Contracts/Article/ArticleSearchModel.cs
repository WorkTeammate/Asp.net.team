﻿namespace BlogManagement.Application.Contracts.Article
{
    public class ArticleSearchModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public long CategoryId { get; set; }
    }
}
