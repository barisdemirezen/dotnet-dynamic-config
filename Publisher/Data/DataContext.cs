using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Publisher.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Parameter> Parameters { get; set; }
    }

    [Table("Parameter")]
    public class Parameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Environment { get; set; }
        public string ApplicationName { get; set; }
    }
}
