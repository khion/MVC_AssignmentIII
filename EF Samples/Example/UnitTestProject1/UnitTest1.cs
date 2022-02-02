using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Example;
using Example.Controllers;
using Example.Models;
using System.Web.Mvc;
using System.IO;
//https://stackoverflow.com/questions/1166883/connection-string-in-unit-test-project-to-reference-database-in-app-data-folder?rq=1

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var appDataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../App_Data");

            AppDomain.CurrentDomain.SetData("DataDirectory", appDataDir);
            Renter renter = new Renter();
            renter.name = "Boris";
            RentersController rc = new RentersController();
            //ActionResult ac = rc.Create(renter);
            //string vbData = ((ViewResult)ac).ViewData["Name"].ToString();
            //ActionResult ac = rc.Details(1);
            ViewResult vr = rc.Index() as ViewResult;
            vr.ViewData.Model
            Assert.IsNotNull(vr);
        }
    }
}
