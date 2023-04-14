using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Dtos.Product
{
    public class GetReviewDto
    {
        public int Id { get; set; }  //Review ID
        public string? Title { get; set; } = "Titulo";
        public int Rating { get; set; } = 0;
        public string? ReviewText { get; set; } = "Review del producto";
        public string? Author { get; set; }
        public DateTime Date { get; set; } = new DateTime(2023, 4, 14, 10, 30, 0);
        public bool Verified { get; set; } = false;
    }
}