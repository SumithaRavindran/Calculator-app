using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Controls;

namespace Calculator.UT
{
    [TestClass]
    public class CalculatorOrchestratorTests
    {
        [TestMethod]
        public void UpdateNumberToSystem_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "1");
                Assert.AreEqual("1", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        [TestMethod]
        public void UpdateNumberToSystem_ExceptionsTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                try
                {
                    calculatorOrchestrator.UpdateNumberToSystem(textbox, "1");
                    Assert.Fail("Expected exception not thrown");
                }
                catch (Exception)
                {
                    Assert.IsTrue(true);
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        
        [TestMethod]
        public void ChangeSign_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.input = "10";
                calculatorOrchestrator.ChangeSign(textbox);
                Assert.AreEqual("-10", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}
