#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace TagSelectedViews
{
    [Transaction(TransactionMode.Manual)]
    public class cmdTagSelectedViews : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document curDoc = uidoc.Document;

            // put any code needed for the form here

            // create a list of the categories
            List<string> cats = new List<string>{ "Casework", "Detail Items", "Doors", "Electrical Fixtures",
                "Generic Models", "Lighting Fixtures", "Mechanical Equipment", "Multi-Category",
                "Plumbing Fixtures", "Property Line Segments", "Rooms", "Specialty Equipment",
                "Stairs", "Structrual Columns", "Structural Framing", "Walls", "Windows" };

            // get all the tags for the categories
            List<Element> caseworkTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_CaseworkTags);
            List<Element> detailTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_DetailComponentTags);
            List<Element> doorTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_DoorTags);
            List<Element> electricalTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_ElectricalFixtures);
            List<Element> genericTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_GenericModelTags);
            List<Element> lightingTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_LightingFixtureTags);
            List<Element> mechanicalTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_MechanicalEquipmentTags);
            List<Element> multiTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_MultiCategoryTags);
            List<Element> plumbingTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_PlumbingFixtureTags);
            List<Element> propertyTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_SitePropertyLineSegmentTags);
            List<Element> roomTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_RoomTags);
            List<Element> specialtyTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_SpecialityEquipmentTags);
            List<Element> stairTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_StairsTags);
            List<Element> columnTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_StructuralColumnTags);
            List<Element> framingTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_StructuralFramingTags);
            List<Element> wallTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_WallTags);
            List<Element> windowTags = Utils.GetCategoryByName(curDoc, BuiltInCategory.OST_WindowTags);

            // open form
            frmTagSelectedViews curForm = new frmTagSelectedViews()
            {
                Width = 800,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            // get form data and do something

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
