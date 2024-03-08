using Management.Domain.Models;
using Management.InfraStructure.Repository;
using Management.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace Management.Web.Controllers
{
    [Authorize]

    public class FileUploadsController : Controller
    {
        private readonly IRepository<FileUploads>  fileUploads;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUploadsController(IRepository<FileUploads> fileUploads,
            IWebHostEnvironment webHostEnvironment)
        {
            this.fileUploads = fileUploads;
            this.webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("Create")]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public ActionResult UploadFile(Upload file)
        {
            if (file != null )
            {
                var fileName = Path.GetFileName(file.fileupload.FileName);
                var fileType = Path.GetExtension(file.fileupload.ContentType);
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, $"Image/{fileName}");
                file.fileupload.CopyTo(new FileStream(filePath,FileMode.Create));

                fileUploads.Add(new FileUploads
                {
                    CreatedAt = DateTime.UtcNow,
                    Name = fileName,
                    Description = file.Description,
                    CreatedBy = file.CreatedBy,
                    Path = filePath,
                    FileType = fileType

                });
                fileUploads.SaveChanges();

            }

            return RedirectToAction("UploadFile");
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult DeleteFile(FileUploads file )
        {
            fileUploads.Delete(file);
            fileUploads.SaveChanges();
            return RedirectToAction("UploadFile");
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult UpdateFile(Upload file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.fileupload.FileName);
                var fileType = Path.GetExtension(file.fileupload.ContentType);
                var filePath = Path.Combine("~/Image/", fileName);
                file.fileupload.CopyTo(new FileStream(filePath, FileMode.Create));

                var fileUpdate = new FileUploads
                {
                    CreatedAt = DateTime.UtcNow,
                    Name = fileName,
                    Description = file.Description,
                    CreatedBy = file.CreatedBy,
                    Path = filePath,
                    FileType = fileType
                };
                fileUploads.Update(fileUpdate);
                fileUploads.SaveChanges();
            }
            return RedirectToAction("Create");

        }
    }
}

