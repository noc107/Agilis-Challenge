using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgilisTestAnibalDominguez.Utils
{
    public class My_Controller_Factory : DefaultControllerFactory
    {
        public override IController CreateController
        (System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            string controllername = requestContext.RouteData.Values
            ["controller"].ToString();
            Type controllerType = Type.GetType(string.Format
            ("AgilisTestAnibalDominguez.Controllers.{0}", controllername));
            IController controller = Activator.CreateInstance(controllerType) as IController;
            return controller;
        }
        public override void ReleaseController(IController controller)
        {
            IDisposable dispose = controller as IDisposable; if (dispose != null)
            {
                dispose.Dispose();
            }
        }
    }
}