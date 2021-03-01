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

        [TestMethod]
        public void UpdateOperation_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.input = "10";
                calculatorOrchestrator.UpdateOperation(textbox, Operator.Add);
                Assert.AreEqual("", textbox.Text);

            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        [TestMethod]
        public void ExecuteCE_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.ExecuteCE(textbox);
                Assert.AreEqual(string.Empty, textbox.Text);
                Assert.AreEqual(string.Empty, calculatorOrchestrator.input);

            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        [TestMethod]
        public void ExecuteC_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.ExecuteC(textbox);
                Assert.AreEqual(string.Empty, textbox.Text);
                Assert.AreEqual(string.Empty, calculatorOrchestrator.input);

            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        [TestMethod]
        public void ExecutePeriod_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.input = "10";
                calculatorOrchestrator.ExecutePeriod(textbox);
                Assert.AreEqual("10.", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        [TestMethod]
        public void ComputeResultAdd_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "10");
                calculatorOrchestrator.UpdateOperation(textbox, Operator.Add);
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "20");

                calculatorOrchestrator.ComputeResult(textbox);
                Assert.AreEqual("30", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
       
        [TestMethod]
        public void ComputeResultSubtract_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "10");
                calculatorOrchestrator.UpdateOperation(textbox, Operator.Subtract);
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "50");

                calculatorOrchestrator.ComputeResult(textbox);
                Assert.AreEqual("-40", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        [TestMethod]
        public void ComputeResultMultiply_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "10");
                calculatorOrchestrator.UpdateOperation(textbox, Operator.Multiply);
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "2");

                calculatorOrchestrator.ComputeResult(textbox);
                Assert.AreEqual("20", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        [TestMethod]
        public void ComputeResultDivide_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "10");
                calculatorOrchestrator.UpdateOperation(textbox, Operator.Divide);
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "2");

                calculatorOrchestrator.ComputeResult(textbox);
                Assert.AreEqual("5", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        [TestMethod]
        public void ComputeResultPeriodAdd_HappyPathTest()
        {
            CalculatorOrchestrator calculatorOrchestrator = new CalculatorOrchestrator();
            TextBox textbox = null;
            Thread t = new Thread(() =>
            {
                textbox = new TextBox();
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "10");
                calculatorOrchestrator.ExecutePeriod(textbox);
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "20");
                calculatorOrchestrator.UpdateOperation(textbox, Operator.Divide);
                calculatorOrchestrator.UpdateNumberToSystem(textbox, "2");

                calculatorOrchestrator.ComputeResult(textbox);
                Assert.AreEqual("5.100", textbox.Text);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
    }
}
