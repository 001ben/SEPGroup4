using FileManagerNs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace FileManagerNs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FileManager : IFileManager
    {
        public void UploadFiles(ApplicationFileCollection appFiles)
        {
            // Get the database context
            FileDbContext fileDb = new FileDbContext();
            
            // Check if an entry already exists for the given application id
            var applicationFileCollection = fileDb.ApplicationFiles.FirstOrDefault(f => f.ApplicationID == appFiles.ApplicationId);
            
            // create it if it doesn't exist
            if(applicationFileCollection == null)
            {
                // Add the application id to the data model
                applicationFileCollection = new ApplicationDbFiles
                {
                    ApplicationID = appFiles.ApplicationId
                };
                fileDb.ApplicationFiles.Add(applicationFileCollection);
                fileDb.SaveChanges();
            }

            // Add the appplication files to application files db object
            fileDb.Files.AddRange(appFiles.Files
                .Select(f => new ApplicationDbFile
                {
                    ApplicationDbFilesId = applicationFileCollection.ApplicationDbFilesId,
                    Data = f.Data,
                    FileName = f.FileName,
                    MimeType = f.MimeType
                }));

            fileDb.SaveChanges();
        }
    }
}
