using Microsoft.EntityFrameworkCore;
using AspNetCoreMVCPractice.Models;
namespace AspNetCoreMVCPractice.Data;

public class PracticeContext: DbContext
{
    public PracticeContext(DbContextOptions<PracticeContext> options): base(options){}
    
    public DbSet<Items> Items { get; set; }
    
}