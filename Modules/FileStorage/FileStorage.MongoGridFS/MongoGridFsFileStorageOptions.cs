using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.MongoGridFS
{
    public class MongoGridFsFileStorageOptions
    {
        [Required]
        public string ConnectionStringName { get; init; } = default!;
        [Required]
        public string DatabaseName { get; init; } = default!;
        
        // we can have this bucket inside the database, in this case is not need it
        public string BucketName { get; init; } = "files";


        // is to split all the files in chunks of this size and store it in the database.
        //files are going to have an average between 3 to 5MB.
        // So a chunk size of one megabyte sounds good, but you can also increase it or decrease it depending
        // on the average of your system.
        public int ChunkSizeBytes { get; init; } = 1048576; // 1MB

        public long FileSizeLimitInMB { get; init; } = 50;
        public long FileSizeLimitInBytes => FileSizeLimitInMB * 1024 * 1024;
    }
}
