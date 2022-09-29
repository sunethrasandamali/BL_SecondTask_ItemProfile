using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public interface IParentChild
    {
        int ParentKey { get; set; }
        int EntityKey { get; }

    }
    public enum DependencyType { StringValue, IntegerValue, JavascriptVariable }
    public class UIObjectMinimal : BaseEntity
    {
        public int ObjectId { get; set; }
        public int ParentKey { get; set; }
        public string ObjectName { get; set; }
        public string ObjectCaption { get; set; }
        public bool IsProcessed { get; set; }

        public bool HasPermisonToAdd { get; set; }


        public sbyte GridEditMode { get; set; }


        public sbyte HierarchyType { get; set; }
    }
    public class UIObject: UIObjectMinimal, IParentChild
    {
        public bool IsLastElement { get; set; }
        public string ToolTip { get; set; }
        public int Parent2Id { get; set; }
        public string DefaultValue { get; set; }
        public bool IsFreeze { get; set; }
        public bool IsEnable { get; set; }
        public bool IsVisible { get; set; }
        public string Alignment { get; set; }
        public int DefaultKy { get; set; }
        public DateTime DefaultDate { get; set; }
        public int Width { get; set; }
        public string DataType { get; set; }
        public string Format { get; set; }
        public string Aggregates { get; set; }
        public string Template { get; set; }
        public string FooterTemplate { get; set; }
        public string GroupFooterTemplate { get; set; }
        public string ObjectType { get; set; }
        public string UrlController { get; set; }
        public string UrlAction { get; set; }

        public string UpdateController { get; set; }
        public string UpdateAction { get; set; }

        public string CreateController { get; set; }
        public string CreateAction { get; set; }

        public string DeleteController { get; set; }
        public string DeleteAction { get; set; }

        public string OurCode { get; set; }
        public string OurCode2 { get; set; }
        public string ReportServerURL { get; set; }
        public string ReportName { get; set; }
        public int NextObjectId { get; set; }
        public string NextObjectType { get; set; }
        public string EnterKeyAction { get; set; }
        public bool IsMust { get; set; }
        public string ValidationMessage { get; set; }
        public int ValidationOrder { get; set; }
        public string CssClass { get; set; }
        public string OnClickAction { get; set; }
        public string OnKeyUpAction { get; set; }
        public bool IsFirstFocusObject { get; set; }

        public string ReportType { get; set; }
        public IList<UIObject> Childrens { get; set; }
        public int ChildId { get; set; }
        public string UiSection { get; set; }
        public decimal SortingOrder { get; set; }
        public string NextObjectName { get; set; }
        public string UiDomId { get; set; }
        public string UiDomName { get; set; }
        public string MapKey { get; set; }
        public string MapName { get; set; }
        public string CollectionName { get; set; }
        public bool IsAjaxForm { get; set; }
        public UIObjectType UiObjectType { get; set; }
        public int EntityKey { get => ObjectId; }

        public bool IsOption1Active { get; set; }
        public bool IsOption2Active { get; set; }
        public bool IsOption3Active { get; set; }
        public bool IsOption4Active { get; set; }
        public bool IsOption5Active { get; set; }
        public bool IsOption6Active { get; set; }
        public bool IsOption7Active { get; set; }
        public bool IsOption8Active { get; set; }
        public bool IsOption9Active { get; set; }
        public bool IsOption10Active { get; set; }
        public bool IsOption11Active { get; set; }
        public bool IsOption12Active { get; set; }
        public bool IsOption13Active { get; set; }
        public bool IsOption14Active { get; set; }
        public bool IsOption15Active { get; set; }
        public bool IsOption16Active { get; set; }
        public bool IsOption17Active { get; set; }
        public bool IsOption18Active { get; set; }
        public bool IsOption19Active { get; set; }
        public bool IsOption20Active { get; set; }
        public bool IsOption21Active { get; set; }
        public bool IsOption22Active { get; set; }
        public bool IsOption23Active { get; set; }
        public bool IsOption24Active { get; set; }
        public bool IsOption25Active { get; set; }
        public bool IsOption26Active { get; set; }
        public bool IsOption27Active { get; set; }
        public bool IsOption28Active { get; set; }
        public bool IsOption29Active { get; set; }
        public bool IsOption30Active { get; set; }
        public bool IsOption31Active { get; set; }
        public bool IsOption32Active { get; set; }
        public bool IsOption33Active { get; set; }
        public bool IsOption34Active { get; set; }
        public bool IsOption35Active { get; set; }
        public bool IsOption36Active { get; set; }
        public bool IsOption37Active { get; set; }
        public bool IsOption38Active { get; set; }
        public bool IsOption39Active { get; set; }
        public bool IsOption40Active { get; set; }
        public bool IsOption41Active { get; set; }
        public bool IsOption42Active { get; set; }
        public bool IsOption43Active { get; set; }
        public bool IsOption44Active { get; set; }
        public bool IsOption45Active { get; set; }
        public bool IsOption46Active { get; set; }
        public bool IsOption47Active { get; set; }
        public bool IsOption48Active { get; set; }
        public bool IsOption49Active { get; set; }
        public bool IsOption50Active { get; set; }
        public bool IsOption51Active { get; set; }
        public bool IsOption52Active { get; set; }
        public bool IsOption53Active { get; set; }
        public bool IsOption54Active { get; set; }
        public bool IsOption55Active { get; set; }
        public bool IsOption56Active { get; set; }
        public bool IsOption57Active { get; set; }
        public bool IsOption58Active { get; set; }
        public bool IsOption59Active { get; set; }
        public bool IsOption60Active { get; set; }
        public bool IsOption61Active { get; set; }
        public bool IsOption62Active { get; set; }
        public bool IsOption63Active { get; set; }
        public bool IsOption64Active { get; set; }
        public bool IsOption65Active { get; set; }
        public bool IsOption66Active { get; set; }
        public bool IsOption67Active { get; set; }
        public bool IsOption68Active { get; set; }
        public bool IsOption69Active { get; set; }
        public bool IsOption70Active { get; set; }
        public bool IsOption71Active { get; set; }
        public bool IsOption72Active { get; set; }
        public bool IsOption73Active { get; set; }
        public bool IsOption74Active { get; set; }
        public bool IsOption75Active { get; set; }
        public bool IsOption76Active { get; set; }
        public bool IsOption77Active { get; set; }
        public bool IsOption78Active { get; set; }
        public bool IsOption79Active { get; set; }
        public bool IsOption80Active { get; set; }
        public bool IsOption81Active { get; set; }
        public bool IsOption82Active { get; set; }
        public bool IsOption83Active { get; set; }
        public bool IsOption84Active { get; set; }
        public bool IsOption85Active { get; set; }
        public bool IsOption86Active { get; set; }
        public bool IsOption87Active { get; set; }
        public bool IsOption88Active { get; set; }
        public bool IsOption89Active { get; set; }
        public bool IsOption90Active { get; set; }
        public bool IsOption91Active { get; set; }
        public bool IsOption92Active { get; set; }
        public bool IsOption93Active { get; set; }
        public bool IsOption94Active { get; set; }
        public bool IsOption95Active { get; set; }
        public bool IsOption96Active { get; set; }
        public bool IsOption97Active { get; set; }
        public bool IsOption98Active { get; set; }
        public bool IsOption99Active { get; set; }
        public string ReportPath { get; set; }
        public string Remarks { get; set; }
        public int CallObjectKey { get; set; }
        public int ReferenceObjectKey { get; set; }

        public string ParentCssClass { get; set; }
        public string IconCss { get; set; }

        public int ObjectTypeKey { get; set; } = 1;
        public IList<ObjectDependency> ObjectDependencies { get; set; }

        public bool IsAllowEdit { get; set; }

        public bool IsCreateToolBar { get; set; }
        public bool IsEnableRowFilter { get; set; }
        public string DefaultPath { get; set; }
        public decimal NoOfRows { get; set; }

        public string ObjectUniqueID { get; set; }


        public string ReadController { get; set; }
        public string ReadAction { get; set; }


        public override string ToString()
        {
            try
            {
                return this.ObjectId.ToString() + " - " + this.ObjectName + " - " + this.ObjectCaption + " - " + UiSection;
            }
            catch (Exception exp)
            {

            }
            return "ERR";

        }
        public UIObject(int ObjectKey)
        {
            ObjectId = ObjectKey;
        }

        public UIObject()
        {
            ObjectId = 1;
        }

        public string StoredPorcedureName { get; set; }
        public string ParameterName { get; set; }

        public string ReferenceVariableName { get; set; }
        public UIObject ReferenceObject { get; set; }


    }

    public class UIObjectID
    {
        public int ObjectIDKey { get; set; }
        public string ObjectIDName { get; set; }

    }
    public class UIObjectType : BaseEntity
    {
        public int ObjectTypeKey { get; set; }
        public int ParentKey { get; set; }
        public string ObjectType { get; set; }
        public string TypeName { get; set; }
        public bool IsWindows { get; set; }
        public bool IsWeb { get; set; }
        public bool IsUserObject { get; set; }
    }

    public class ObjectDependency : BaseEntity
    {
        public DependencyType TypeOfDependency;
        public string DependencyName { get; set; }
        public string DependencyValue { get; set; }

    }





}

