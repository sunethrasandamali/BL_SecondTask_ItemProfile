using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Document
{
    public class Document : BaseEntity
    {
        private long documentKey;
        private int companyKey;
        private string? description;
        private string? keyword;
        private string? path;
        private string? filename;
        private string? versionNumber;
        private DateTime nextActionDate;
        private int projectKey;
        private CodeBaseResponse? documentType;
        private CodeBaseResponse category;
        private long projectStatusKey;

        private int transactionKey;
        private string? extention;
        private int employeeCodeKey;
        private int employeeCodeDtKey;

        private int buKey;

        public long DocumentKey { get => documentKey; set => documentKey = value; }
        public int CompanyKey { get => companyKey; set => companyKey = value; }
        public string? Description { get => description; set => description = value; }
        public string? Keyword { get => keyword; set => keyword = value; }
        public string? Path { get => path; set => path = value; }
        public string? Filename { get => filename; set => filename = value; }
        public string? VersionNumber { get => versionNumber; set => versionNumber = value; }
        public DateTime NextActionDate { get => nextActionDate; set => nextActionDate = value; }

        public CodeBaseResponse? Category { get => category; set => category = value; }
        public long ProjectStatusKey { get => projectStatusKey; set => projectStatusKey = value; }
        public CodeBaseResponse? DocumentType { get => documentType; set => documentType = value; }
        public int TransactionKey { get => transactionKey; set => transactionKey = value; }
        public int OrderKey { get; set; }
        public int ItemKey { get; set; }
        public int ProjectKey { get => projectKey; set => projectKey = value; }
        public int AddressKey { get; set; }
        public int ItemTranKey { get; set; }
        public int ProcessDetKey { get; set; }
        public int OrderDetailKey { get; set; }
        public string? Extention { get => extention; set => extention = value; }
        public int CdKey { get; set; }
        public string? GetCreatedDate
        {
            get
            {
                return CreatedDate.ToString("dd-MMM-yyyy");
            }
        }
        public long FileSize { get; set; }

        public string? Size
        {
            get
            {
                return FileSize.SizeSuffix(2);
            }
        }

        public int EmployeeCodeKey { get => employeeCodeKey; set => employeeCodeKey = value; }
        public int EmployeeCodeDtKey { get => employeeCodeDtKey; set => employeeCodeDtKey = value; }
        public int BuKey { get => buKey; set => buKey = value; }
    }
    public class BinaryDocument : Document
    {
        public byte[]? DocumentArray { get; set; }
    }
    public class Base64Document : Document
    {
        public string? Base64Source { get; set; }

    }
    public class DocumentRetrivaltDTO : BaseDTO
    {
        public int TransactionKey { get; set; } = 1;
        public long ItemKey { get; set; } = 1;
        public int OrderKey { get; set; } = 1;
        public int ProjectKey { get; set; } = 1;
        public int DocumentTypeKey { get; set; } = 1;
        public int EmployeeCodeKey { get; set; } = 1;
        public int EmployeeCodeDtKey { get; set; } = 1;
        public int ItemTransactionKey { get; set; } = 1;
        public int OrderDetailKey { get; set; } = 1;
        public int DocCategory1Key { get; set; } = 1;
        public int DocCategory2Key { get; set; } = 1;
        public int DocCategory3Key { get; set; } = 1;
        public int BUKey { get; set; } = 1;
        public int ProcessDetKey { get; set; } = 1;
        public int AdrKy { get; set; } = 1;
        public int CdKey { get; set; } = 1;
        public int ProjectStatusKey { get; set; } = 1;
        public DateTime NextActionDate { get; set; } = DateTime.Now;
        public string? KeyWord { get; set; } = "";

        public int DocumentKey { get; set; } = 1;

        public DocumentRetrivaltDTO()
        {
            TransactionKey = 1;
            ItemKey = 1;
            OrderKey = 1;
            DocumentTypeKey = 1;
            ProjectKey = 1;
            EmployeeCodeDtKey = 1;
            EmployeeCodeKey = 1;
            ItemTransactionKey = 1;
            OrderDetailKey = 1;
            DocCategory1Key = 1;
            DocCategory2Key = 1;
            DocCategory3Key = 1;
            ProcessDetKey = 1;
            AdrKy = 1;
            CdKey = 1;
            NextActionDate = DateTime.Now;
            KeyWord = "";
            DocumentKey = 1;

        }
    }
    public class FileUpload : DocumentRetrivaltDTO
    {
        public FileType UploadedFile { get; set; } = new FileType();
        public string? Description { get; set; } = "";
        public byte[] Buffer { get; set; } = new byte[] { };
    }
    public class FileType
    {
        public long Size { get; set; }
        public string? FileName { get; set; } = "";
        public string? Extension { get; set; } = "";
        public bool HasAcceptedExtension { get; set; }

    }
}
