using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;

namespace ToDoListUnitTests
{
    [TestClass]
    public class LoginFormTests
    {
        private Application _application;

        public void SetupApplication()
        {
            if (_application != null) return;
            var applicationPath = AppDomain.CurrentDomain.BaseDirectory + "/Debug/ToDoListApp.exe";
            _application = Application.Launch(applicationPath);
        }

        [TestMethod]
        [Description("Minimize Button Click")]
        public void LoginWindowMinimizeButton()
        {
            SetupApplication();
            var window = _application.GetWindow("Login", InitializeOption.NoCache);
            var button = window.Get<Button>("ButtonMinimize");
            button.Click();
        }

        [TestMethod]
        [Description("Close Button Click")]
        public void LoginWindowCloseButton()
        {
            SetupApplication();
            var window = _application.GetWindow("Login", InitializeOption.NoCache);
            var button = window.Get<Button>("ButtonClose");
            button.Click();
        }

        [TestMethod]
        [Description("Check credentials are correct or wrong")]
        public void Login()
        {
            SetupApplication();
            var window = _application.GetWindow("Login", InitializeOption.NoCache);
            var username = window.Get<TextBox>("UserName");
            var passwordText = window.Get<TextBox>("PasswordText");
            username.Text = "taner";
            passwordText.Text = "1234";
            var button = window.Get<Button>("LoginButton");
            button.Click();
        }
    }
}