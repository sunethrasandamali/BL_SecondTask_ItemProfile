using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.MastrerData
{
    public class Project
    {
        public long ProjectKey { get; set; }
        public string? ProjectNumber { get; set; }
        public string? ProjectID { get; set; }
        public string? ProjectName { get; set; }
        public CodeBaseResponse ProjectType { get; set; } = new CodeBaseResponse();//PrjTypKy/PrjTypNm
        public int ParentKey { get; set; }
        public string? ParentProjectID { get; set; }
        public string? ParentProjectName { get; set; }
        public CodeBaseResponse ProjectStatus { get; set; } = new CodeBaseResponse();//PrjStsKy/PrjStsNm
        public int IsActive { get; set; }
        public int IsApproved { get; set; }
        public int IsAllowTransaction { get; set; }
        public int IsParent { get; set; }
        public int IsDefault { get; set; }
        public DateTime ProjectStartDate { get; set; } = DateTime.Now;
        public DateTime ProjectEndDate { get; set; } = DateTime.Now;
        public ItemResponse Item { get; set; } = new ItemResponse();
        public string? Alias { get; set; }
        public AddressResponse Address { get; set; } = new AddressResponse();
        public AccountResponse Account { get; set; } = new AccountResponse();
        public CodeBaseResponse BusinessUnit { get; set; } = new CodeBaseResponse();
        public CodeBaseResponse Location { get; set; } = new CodeBaseResponse();

        public string? YourReference { get; set; }  


    }

    public class ProjectResponse : BaseComboResponse
    {
        public long ProjectKey { get; set; } = 1;

        public string? ProjectName { get; set; } = "";
        public string? ProjectId { get; set; } = "";

        public DateTime ExpiryDate { get; set; }

    }
}
