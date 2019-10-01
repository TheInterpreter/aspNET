using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace ElvisAppAzure.Models
{
    public class Storage
    {

        CloudStorageAccount CloudStorageAccount;
        CloudBlobClient blobClient;
        public Storage(String ConnectionString) {
            CloudStorageAccount = CloudStorageAccount.Parse(ConnectionString);
            CloudBlobClient  blobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        public CloudBlobContainer getContenedor(String ContenedorName) {
            CloudBlobContainer Container = blobClient.GetContainerReference(ContenedorName);
            Container.CreateIfNotExists();
            return Container;

        }

        public String UploadFile(Stream file, string container, string NameFile) {

            try
            {

                getContenedor(container);
                CloudBlobContainer cont = getContenedor(container);
                CloudBlockBlob blockBlob = cont.GetBlockBlobReference(container);
                blockBlob.UploadFromStream(file);
            }
            catch (Exception ex) {

                return "";
            }


            return string.Format("https://advertureproducts.blob.core.windows.net/{0}/{1}", container, NameFile);
        }
    }
}