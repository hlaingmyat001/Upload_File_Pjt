using Microsoft.EntityFrameworkCore;
using Upload_File_Pjt.Models;

namespace Upload_File_Pjt
{
    public class UploadContext : DbContext
    {
        public UploadContext(DbContextOptions<UploadContext> options)
    : base(options)
        { }

        public DbSet<CSVUpload> cSVUploads { get; set; }
        public DbSet<XMLUpload> xmlUploads { get; set; }


    }
}
