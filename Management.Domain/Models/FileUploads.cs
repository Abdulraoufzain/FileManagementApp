using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    // This class represents the FileUploads table in the database
    public class FileUploads
    {
        // This is the primary key of the table
        public Guid FileUploadsId { get; set; }

        // This is the name of the file
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        // This is the path of the file
        [Required]
        public string? Path { get; set; }

        // This is the file type of the file
        [Required]
        [MaxLength(50)]
        public string? FileType { get; set; }

        // This is the description of the file
        public string? Description { get; set; }

        // This is the date and time when the file was created
        [Required]
        public DateTime CreatedAt { get; set; }

        // This is the user who created the file
        [Required]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }


        public FileUploads()
        {
                FileUploadsId = Guid.NewGuid();

        }

    }
}

