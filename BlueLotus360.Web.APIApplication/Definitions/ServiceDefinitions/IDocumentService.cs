using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface IDocumentService
    {
        void UploadImages(Company company, User user, FileUpload document);
        IList<Base64Document> GetBase64Documents(Company company, User user, DocumentRetrivaltDTO document);
    }
}
