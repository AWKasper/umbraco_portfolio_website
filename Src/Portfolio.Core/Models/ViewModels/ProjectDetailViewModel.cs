﻿using Microsoft.AspNetCore.Html;

namespace Portfolio.Core.Models.ViewModels
{
    public class ProjectDetailViewModel : MainViewModel
    {
        public HtmlString BodyText { get; set; }
    }
}