using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSelectedViews
{
    internal static class Utils
    {

        #region Categories

        internal static List<Element> GetCategoryByName(Document curDoc, BuiltInCategory bicTags)
        {
            List<Element> m_returnCat = new List<Element>();

            FilteredElementCollector m_colCat = new FilteredElementCollector(curDoc)
                .OfCategory(bicTags)
                .WhereElementIsElementType();

            foreach (Element curCat in m_colCat)
            {
                m_returnCat.Add(curCat);
            }

            return m_returnCat;
        }

        #endregion

        #region Ribbon
        internal static RibbonPanel CreateRibbonPanel(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel currentPanel = GetRibbonPanelByName(app, tabName, panelName);

            if (currentPanel == null)
                currentPanel = app.CreateRibbonPanel(tabName, panelName);

            return currentPanel;
        }        

        internal static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tmpPanel in app.GetRibbonPanels(tabName))
            {
                if (tmpPanel.Name == panelName)
                    return tmpPanel;
            }

            return null;
        }

        #endregion

        #region Views

        public static ICollection<View> GetSelectedViews(Document doc)
        {
            UIDocument uidoc = new UIDocument(doc);

            // Get the selected elements from the UIDocument
            ICollection<ElementId> selectedElementIds = uidoc.Selection.GetElementIds();

            // Filter out the views from the selected elements
            ICollection<View> selectedViews = new List<View>();
            foreach (ElementId elementId in selectedElementIds)
            {
                Element element = doc.GetElement(elementId);
                if (element is View view)
                {
                    selectedViews.Add(view);
                }
            }

            return selectedViews;
        }

        #endregion
    }
}
