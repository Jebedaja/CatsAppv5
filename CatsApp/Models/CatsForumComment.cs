using System.ComponentModel.DataAnnotations;

namespace CatsForum.Models
{
    public class Comment
    {
        public int Id { get; set; }     

        [StringLength(12, ErrorMessage = "Author Name cannot exceed 12 characters.")]               // atrybuty do walidacji i jaki teskst erroru
        public string AuthorName { get; set; }

        [StringLength(100, ErrorMessage = "Comment cannot exceed 100 characters.")]         
        public string Content { get; set; }
    }
}
