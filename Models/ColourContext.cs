using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ColourAPI.Models
{

  public class ColourContext : DbContext
  {

    ILogger<ColourContext> _logger;

    public ColourContext(DbContextOptions<ColourContext> options, ILogger<ColourContext> logger)
      : base(options)
    {
      _logger = logger;
    }

    public DbSet<Colour> ColourItems { get; set; }
  }
}