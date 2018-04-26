using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookService.Models
{
    /// <summary>
    /// Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Book Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Book title
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Book publish year
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Book price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Book genre
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// Author Id for the book
        /// </summary>
        // Foreign Key
        public int AuthorId { get; set; }
        /// <summary>
        /// Author of the book
        /// </summary>
        // Navigation Property
        public Author Author { get; set; }
        /*
        // For Lazy loading make the 
        // navigation property virtual
        public virtual Author Author { get; set; }
         */
    }
}