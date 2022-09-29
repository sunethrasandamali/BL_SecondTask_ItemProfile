using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class UIObject:BaseEntity
    {
        public long ObjectKey { get; set; } = 1;
        public string ObjectName { get; set; }
        public string ObjectCaption { get; set; }
        public string OurCode { get; set; }
        public string OurCode2 { get; set; }
        public int ParentKey { get; set; } = 1;
        public int ParentKey2 { get; set; } = 1;
        public int Level1ObjectKey { get; set; } = 1;
        public string Level1ObjectName { get; set; } 
        public string ToolTip { get; set; } 
        public int UserObjectKey { get; set; } = 1;
        public string DefaultValue { get; set; }
        public string DefaultPath { get; set; }
        public bool IsFreeze { get; set; }
        public bool IsEnable { get; set; }
        public string Alignment { get; set; }
        public long DefaultKey { get; set; } = 1;
        public DateTime DefaultDate { get; set; }
        public bool IsVisible { get; set; } 
        public int Width { get; set; }
        public string DataType { get; set; }
        public string Format { get; set; }
        public string Arggreates { get; set; }
        public string Template { get; set; }
        public string FooterTemplate { get; set; }
        public string GroupFooterTemplate { get; set; }
        public string ObjectType { get; set; }
        public string URLController { get; set; }
        public string URLAction { get; set; }
        public string ReportServerURL { get; set; }
        public string ReportPath { get; set; }
        public string ReportName { get; set; }
        public double SO { get; set; }
        public int NextObjectKey { get; set; } = 1;
        public string NextObjectName { get; set; }
        public string NextObjectType { get; set; }
        public bool IsMust { get; set; }
        public string ValidationMessae { get; set; }
        public short ValidationOrder { get; set; }
        public string CssClass { get; set; }
        public string OnClickAction { get; set; }
        public string IsFirstFocusObject { get; set; }
        public bool IsCode73 { get; set; }
        public bool ReportType { get; set; }
        public bool DuplicateFill { get; set; }
        public bool ContraAutoFill { get; set; }
        public int ObjectTypeKey { get; set; } = 1;
        public bool FilterCriteria { get; set; } 
        public string ObjectID { get; set; } 
        public string UIDomId { get; set; } 
        public string UIDomName { get; set; } 
        public string MapId { get; set; } 
        public string MapName { get; set; } 
        public string CollectionName { get; set; } 
        public bool  IsAjax { get; set; }
        public int DetailObjectKey { get; set; } = 1;
        public string ParentCssClass { get; set; }
        public string IconCssClass { get; set; }
        public bool IsAllowAccess { get; set; }
        public bool IsAllowAdd { get; set; }
        public bool IsAllowUpdate{ get; set; }
        public string SPName { get; set; }
        public byte GridEditMode { get; set; }
        public byte HierachhyType { get; set; }
        public string CreateURLAction { get; set; }
        public string CreateURLController { get; set; }
        public string UpdateURLAction { get; set; }
        public string UpdateURLController { get; set; }
        public string DeleteURLAction { get; set; }
        public string DeleteURLController { get; set; }
        public bool IsCreateToolBar { get; set; }
        public bool IsEnableRowFilter { get; set; }
        public short NumberOfRows { get; set; }
        public int ReferenceObjectKey  { get; set; }=1;
        public string EnterKeyAction { get; set; }  


    }



}

