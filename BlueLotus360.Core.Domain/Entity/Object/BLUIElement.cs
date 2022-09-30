using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Object
{
    public class BLUIElement
    {
        public string _internalElementName { get; set; }
        public string ElementCaption { get; set; }
        public string ElementName { get; set; }
        public string ElementID { get; set; }
        public string OurCode { get; set; }
        public string OurCode2 { get; set; }
        public string ElementType { get; set; }
        public string DefaultAccessPath { get; set; }
        public string DefaultValue { get; set; }
        public bool IsServerFiltering { get; set; }
        public string MapName { get; set; }
        public string MapKey { get; set; }
        public string CollectionName { get; set; }
        public string OnClickAction { get; set; }
        public long ElementKey { get; set; } = 1;
        public long ParentKey { get; set; } = 1;
        public long Width { get; set; } = 1;
        public long ObjectTypeKey { get; set; } = 1;
        public long ReferenceElementKey { get; set; } = 1;
        public bool IsVisible { get; set; }
        public bool IsMust { get; set; }

        public bool IsReadOnly { get; set; }
        public bool IsFreeze { get; set; }
        public bool IsEnable { get; set; }
        public bool IsAllowEdit { get; set; }

        public IList<BLUIElement> Children { get; set; }


        public string CssClass { get; set; }
        public string ValidationMessage { get; set; }
        public string ParentCssClass { get; set; }
        public string UiSection { get; set; }
        public string UrlAction { get; set; }
        public string UrlController { get; set; }
        public string IconCss { get; set; }
        public string ToolTip { get; set; }
        public string DataType { get; set; }
        public string EnterKeyAction { get; set; }
        public string Format { get; set; }

        public string ReadController { get; set; }
        public string ReadAction { get; set; }
        public string CreateController { get; set; }
        public string CreateAction { get; set; }
        public string UpdateController { get; set; }
        public string UpdateAction { get; set; }
        public string DeleteController { get; set; }
        public string DeleteAction { get; set; }


        public string OnBeforeComboLoad
        {
            get
            {
                if (this._internalElementName != null)
                {
                    return this._internalElementName + "_OnBeforeDataFetch";
                }
                return "";

            }
        }

        public string OnAfterComboLoad
        {
            get
            {
                if (this._internalElementName != null)
                {
                    return this._internalElementName + "_OnAfterDataFetch";
                }
                return "";

            }
        }

        public BLUIElement()
        {
            Children = new List<BLUIElement>();
        }




    }

    public class UserConfigObjectsBlLite
    {
        public string _internalElementName { get; set; }
        public string ElementCaption { get; set; }
        public string ElementName { get; set; }
        public string ElementID { get; set; }
        public string OurCode { get; set; }
        public string OurCode2 { get; set; }
        public string ElementType { get; set; }
        public string DefaultAccessPath { get; set; }
        public string DefaultValue { get; set; }
        public string NextObjectName { get; set; }
        public long ElementKey { get; set; } = 1;
        public long ParentKey { get; set; } = 1;
        public bool IsVisible { get; set; }
        public bool IsMust { get; set; }
        public bool IsEnable { get; set; }

        public int DefaultsApr { get; set; }
        public long NextObjectKey { get; set; }
        public bool IsVisibleByDefault { get; set; }
        public bool IsChkAcsLvl { get; set; }
        public bool IsChkAlwTrn { get; set; }
        public bool IsChkPreKy { get; set; }
        public bool IsChkObjMasCd { get; set; }
        public bool AlwPrint { get; set; }
        public bool IsChkPrint { get; set; }
        public string ReportPath { get; set; }
        public bool IsCd01 { get; set; }
        public bool IsCd02 { get; set; }
        public bool IsCd03 { get; set; }
        public bool IsCd04 { get; set; }
        public bool IsCd05 { get; set; }
        public bool IsCd06 { get; set; }
        public bool IsCd07 { get; set; }
        public bool IsCd08 { get; set; }
        public bool IsCd09 { get; set; }
        public bool IsCd10 { get; set; }
        public bool IsCd11 { get; set; }
        public bool IsCd12 { get; set; }
        public bool IsCd13 { get; set; }
        public bool IsCd14 { get; set; }
        public bool IsCd15 { get; set; }
        public bool IsCd16 { get; set; }
        public bool IsCd17 { get; set; }
        public bool IsSysRec { get; set; }
        public string SpName { get; set; }
        public int ContraAutoFill { get; set; }
        public int DuplicateFill { get; set; }
        public string UrlAction { get; set; }
        public string UrlController { get; set; }
        public string CssClass { get; set; }
        public string IconCssClass { get; set; }
        public string OnClickAction { get; set; }
        public IList<UserConfigObjectsBlLite> Children { get; set; }

        public UserConfigObjectsBlLite()
        {
            Children = new List<UserConfigObjectsBlLite>();
        }

    }
}
