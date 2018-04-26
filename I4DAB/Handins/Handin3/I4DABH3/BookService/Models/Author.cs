using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookService.Models
{
    /// <summary>
    /// Author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Author Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Author name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /*
        // Circular object graph
        public ICollection<Book> Books { get; set; }
        */
    }
}