using System;
using NUnit.Framework;
using System.Xaml;
using System.Windows;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Media;

using WPF;
namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        CrossThreadTestRunner runner = new CrossThreadTestRunner();

        [Test]
        public void Height()
        {
            runner.RunInSTA(
          delegate
          {
              MainWindow window = new MainWindow();
              Assert.AreEqual(500, window.Height);
          });
        }

        [Test]
        public void Width()
        {
            runner.RunInSTA(
          delegate
          {
              MainWindow window = new MainWindow();
              Assert.AreEqual(500, window.Width);
          });
        }

        [Test]
        public void DataBarCreate()
        {
            runner.RunInSTA(
                    delegate
                    {
                        DataBar window = new DataBar();
                        Assert.NotNull(window);
                    });
        }

        [Test]
        public void DataBarValue()
        {
            runner.RunInSTA(
                    delegate
                    {
                        DataBar window = new DataBar();
                        window.Value = 10;
                        Assert.AreEqual(10, window.Value);
                    });
        }

        [Test]
        public void DataBarRange()
        {
            runner.RunInSTA(
                    delegate
                    {
                        DataBar window = new DataBar();
                        window.Range = 10;
                        Assert.AreEqual(10, window.Range);
                    });
        }

        [Test]
        public void DataBarWidth()
        {
            runner.RunInSTA(
                    delegate
                    {
                        DataBar window = new DataBar();
                        Assert.AreEqual(0, window.DesiredSize.Width);
                    });
        }

        [Test]
        public void DataBarHeight()
        {
            runner.RunInSTA(
                    delegate
                    {
                        DataBar window = new DataBar();
                        Assert.AreEqual(33, window.Height);
                    });
        }

        [Test]
        public void BarCreate()
        {
            runner.RunInSTA(
                    delegate
                    {
                        Bar window = new Bar();
                        Assert.NotNull(window);
                    });
        }

        [Test]
        public void BarHeight()
        {
            runner.RunInSTA(
                    delegate
                    {
                        Bar window = new Bar();
                        Assert.AreEqual(0, window.DesiredSize.Height);
                    });
        }

        [Test]
        public void BarWidth()
        {
            runner.RunInSTA(
                    delegate
                    {
                        Bar window = new Bar();
                        Assert.AreEqual(0, window.DesiredSize.Width);
                    });
        }

        [Test]
        public void CanCreateAndShowWpfWindow()
        {
            runner.RunInSTA(
                delegate
                {
                    Console.WriteLine(Thread.CurrentThread.GetApartmentState());

                    System.Windows.Window window = new System.Windows.Window();
                    window.Show();
                });
        }   
   

       
    }

    public class CrossThreadTestRunner
    {
        private Exception lastException;

        public void RunInMTA(ThreadStart userDelegate)
        {
            Run(userDelegate, ApartmentState.MTA);
        }

        public void RunInSTA(ThreadStart userDelegate)
        {
            Run(userDelegate, ApartmentState.STA);
        }

        private void Run(ThreadStart userDelegate, ApartmentState apartmentState)
        {
            lastException = null;

            Thread thread = new Thread(
              delegate()
              {
                  try
                  {
                      userDelegate.Invoke();
                  }
                  catch (Exception e)
                  {
                      lastException = e;
                  }
              });
            thread.SetApartmentState(apartmentState);

            thread.Start();
            thread.Join();

            if (ExceptionWasThrown())
                ThrowExceptionPreservingStack(lastException);
        }

        private bool ExceptionWasThrown()
        {
            return lastException != null;
        }

        [ReflectionPermission(SecurityAction.Demand)]
        private static void ThrowExceptionPreservingStack(Exception exception)
        {
            FieldInfo remoteStackTraceString = typeof(Exception).GetField(
              "_remoteStackTraceString",
              BindingFlags.Instance | BindingFlags.NonPublic);
            remoteStackTraceString.SetValue(exception, exception.StackTrace + Environment.NewLine);
            throw exception;
        }
    }  
}
