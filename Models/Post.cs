using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        
        public Guid Id {get;set;}

        public String title {get; set;}

        public String content {get; set;}

        public ICollection<Tag> Tags {get; set;}
    }
}