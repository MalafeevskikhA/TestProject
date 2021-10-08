using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

namespace MyNewProject
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            FilteredElementCollector newWallFilter = new FilteredElementCollector(doc);
            ICollection<Element> allWalls = newWallFilter.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().ToElements();
            List<string> ListOfWallsForView = new List<string>();
            List<string> ListOfWallsForDoc = new List<string>();
            foreach (Element wallEl in allWalls)
            {
                Wall wall = wallEl as Wall;
                ListOfWallsForView.Add("Имя типа: " + wall.Name.ToString() + " Id:" + wall.Id.ToString());
                ListOfWallsForDoc.Add(wall.Name.ToString() + " " + wall.Id.ToString());
            }
            UserWindWall userWind = new UserWindWall(ListOfWallsForView, ListOfWallsForDoc);
            userWind.ShowDialog();
            return Result.Succeeded;
        }
    }
}
