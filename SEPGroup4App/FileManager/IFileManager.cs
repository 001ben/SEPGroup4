using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace FileManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFileManager
    {
        // TODO: Add your service operations here
        [OperationContract]
        string UploadFiles(ApplicationFileCollection appFiles);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ApplicationFileCollection
    {
        int applicationId;
        ICollection<ApplicationFile> files;

        [DataMember]
        public int ApplicationId
        {
            get { return applicationId; }
            set { applicationId = value; }
        }

        [DataMember]
        public ICollection<ApplicationFile> Files
        {
            get { return files; }
            set { files = value; }
        }
    }

    [DataContract]
    public class ApplicationFile
    {
        byte[] data;
        string fileName;
        string mimeType;

        [DataMember]
        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }

        [DataMember]
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        [DataMember]
        public string MimeType
        {
            get { return mimeType; }
            set { mimeType = value; }
        }
    }
}
