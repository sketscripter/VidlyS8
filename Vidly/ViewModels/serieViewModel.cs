﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class serieViewModel
    {
        public Serie Serie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}