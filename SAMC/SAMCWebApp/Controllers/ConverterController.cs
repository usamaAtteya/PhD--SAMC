using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAMCWebApp.Controllers
{
    public class ConverterController : Controller
    {
        private readonly IModelReader _modelReader;
        private readonly DocumentWriter _modelWriter;
        private const string UploadedFilePath = "/UplodedFiles/";
        public ConverterController(IModelReader modelReader, DocumentWriter modelWriter)
        {
            _modelReader = modelReader;
            _modelWriter = modelWriter;
        }
        // GET: Converter
        public ActionResult Index()
        {
           // return View("UnderMaintenance");
           return View();
        }
        [HttpPost]
        public ActionResult Convert(HttpPostedFileBase filePosted ,string writer)
        {
           
            if (filePosted == null) 
                return Content("Please upload file first");
            var fileExtension = Path.GetExtension(filePosted.FileName).ToUpper();
            if (!fileExtension.Equals(".IFC") && !fileExtension.Equals(".$2K") && !fileExtension.Equals(".STD"))
                return Content("Only .ifc ,.$2k & .std files are supported");

            var guid = Guid.NewGuid().ToString();
            var postedFileName = filePosted.FileName.Split('\\').Last();
            var postedFileRelPath = UploadedFilePath + guid + postedFileName;
            string postedFileAbsPath = Server.MapPath(postedFileRelPath);
           filePosted.SaveAs(postedFileAbsPath);
            var model = _modelReader.GetModel(postedFileAbsPath);

            var writtenModel = _modelWriter.WriteContent(model);
            var writtenModelName = Path.ChangeExtension(postedFileName, writer);
            var writtenModelRelPath = UploadedFilePath +guid + writtenModelName;
            var writtenFileAbsPath = Server.MapPath(writtenModelRelPath);
            System.IO.File.WriteAllText(writtenFileAbsPath, writtenModel);
            return File(writtenModelRelPath, "Usama/Atteya", writtenModelName);
        }

        void SaveContent(string content, string fileName)
        {
            System.IO.File.WriteAllText(fileName, content);

        }
    }
}