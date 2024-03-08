using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.InfraStructure.Repository
{
    public class FileUploadsRepository : GenericRepository<FileUploads>
    {
        public FileUploadsRepository(ManagementDbContext context) : base(context)
        {


        }
    }
}
