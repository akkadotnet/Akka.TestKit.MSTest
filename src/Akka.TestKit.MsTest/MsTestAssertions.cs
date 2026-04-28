//-----------------------------------------------------------------------
// <copyright file="MsTestAssertions.cs" company="Akka.NET Project">
//     Copyright (C) 2013-2022 Akka.NET project <https://github.com/akkadotnet/akka.net>
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akka.TestKit.MsTest
{
    /// <summary>
    /// Assertions for Visual Studio Unit Testing Framework
    /// </summary>
    public class MsTestAssertions : ITestKitAssertions
    {
        public void Fail(string format = "", params object[] args)
        {
            Assert.Fail(string.Format(format, args));
        }

        public void AssertTrue(bool condition, string format = "", params object[] args)
        {
            Assert.IsTrue(condition, string.Format(format, args));
        }

        public void AssertFalse(bool condition, string format = "", params object[] args)
        {
            Assert.IsFalse(condition, string.Format(format, args));
        }

        public void AssertEqual<T>(T expected, T actual, string format = "", params object[] args)
        {
            Assert.AreEqual(expected, actual, string.Format(format, args));
        }

        public void AssertEqual<T>(T expected, T actual, Func<T, T, bool> comparer, string format = "", params object[] args)
        {
            if(!comparer(expected, actual))
                throw new AssertFailedException($"Assert.AreEqual failed. Expected [{FormatValue(expected)}]. Actual [{FormatValue(actual)}]. {string.Format(format, args)}");
        }

        private static string FormatValue<T>(T expected)
        {
            return ReferenceEquals(expected, null) ? "null" : expected.ToString();
        }

        public Exception AssertThrows(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                return ex;
            }
            throw new AssertFailedException("Expected an exception to be thrown, but no exception was thrown.");
        }

        public TException AssertThrows<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                throw new AssertFailedException($"Expected exception of type {typeof(TException)} but got {ex.GetType()}: {ex.Message}");
            }
            throw new AssertFailedException($"Expected exception of type {typeof(TException)}, but no exception was thrown.");
        }

        public async Task<Exception> AssertThrowsAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                return ex;
            }
            throw new AssertFailedException("Expected an exception to be thrown, but no exception was thrown.");
        }

        public async Task<TException> AssertThrowsAsync<TException>(Func<Task> action) where TException : Exception
        {
            try
            {
                await action();
            }
            catch (TException ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                throw new AssertFailedException($"Expected exception of type {typeof(TException)} but got {ex.GetType()}: {ex.Message}");
            }
            throw new AssertFailedException($"Expected exception of type {typeof(TException)}, but no exception was thrown.");
        }
    }
}

