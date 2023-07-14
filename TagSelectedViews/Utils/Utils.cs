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

        internal static List<Category> GetCategoryByName(Document curDoc, BuiltInCategory bicTags)
        {
            List<Category> m_returnCat = new List<Category>();

            FilteredElementCollector m_colCat = new FilteredElementCollector(curDoc)
                .OfCategory(bicTags);


            foreach (Category c in m_colCat)
            {
                m_returnCat.Add(c);
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
    }
}
