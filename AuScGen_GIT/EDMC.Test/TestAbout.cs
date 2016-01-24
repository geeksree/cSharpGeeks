﻿using AuScGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EDMC.Pages.CustomControls;


namespace EDMC.Test
{
    public class TestAbout : TestBase
    {
        //[TestCategory(TestType.functional)]
        //[Test(Description = "Test to perform login")]

        [Test]
        public void TC01_ClickOnEDMCAbout() { 
            //Runner.DoStep("Click on EDMC About Page in Home Page".() => {
            //    Page.Login.
            //};)
            Runner.DoStep("Click on EDMC About Page in Home Page",() => {
                Page.Home.MainMenuControl.SpecificNavListItems(MainMenu.MainMenuItems.AboutEDMC);
            });

            
        }

        
        //public void TC01_Login()
        //{
        //    Runner.DoStep("Click on login link", () =>
        //    {
        //        //Page.Login.LogInPageLink.Highlight();
        //        //Page.Login.EDMCAboutLink.Click();
        //        Page.Home.
        //    });

        //    Runner.DoStep("Enter Username", () =>
        //    {
        //        Page.Login.Username.Highlight();
        //        Page.Login.Username.SendKeys("sreenivasparimi95@gmail.com");
        //    });

        //    Runner.DoStep("Enter Password", () =>
        //    {
        //        Page.Login.Password.Highlight();
        //        Page.Login.Password.SendKeys("Sreenivas007.");
        //    });

        //    Runner.DoStep("Click on login button", () =>
        //    {
        //        Page.Login.LogInButton.Highlight();
        //        Page.Login.LogInButton.Click();
        //    });

        //    Runner.DoStep("Verify Login is successfull", () =>
        //    {
        //        Page.Login.ITChoice.Highlight();
        //        if (!Page.Login.IsChoicePresent)
        //        {
        //            Assert.Fail("Login is not successful - Choice Frame is not found");
        //        }
        //    });
        //}
    }
}
