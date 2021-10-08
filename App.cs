using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Reflection;
using System.Windows.Media.Imaging;


namespace MyNewProject
{
    class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }

        public Result OnStartup(UIControlledApplication a)
        {
            string tabName = "Plugin";
            string panelName = "Plugin";
            a.CreateRibbonTab(tabName);
            var panel = a.CreateRibbonPanel(tabName, panelName);
            var NewButton = new PushButtonData("Выгрузка стен", "Выгрузка стен", Assembly.GetExecutingAssembly().Location, "MyNewProject.Command");
            var NewBtn = panel.AddItem(NewButton) as PushButton;
            var globePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Wall.png");
            Uri uriImage = new Uri(globePath);
            BitmapImage largeImage = new BitmapImage(uriImage);
            NewBtn.LargeImage = largeImage;
            return Result.Succeeded;
        }
    }
}
