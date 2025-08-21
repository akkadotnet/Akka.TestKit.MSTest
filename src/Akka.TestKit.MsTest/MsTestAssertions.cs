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
            Assert.Fail(format, args);
        }

        public void AssertTrue(bool condition, string format = "", params object[] args)
        {
            Assert.IsTrue(condition,format, args);
        }

        public void AssertFalse(bool condition, string format = "", params object[] args)
        {

            Assert.IsFalse(condition,format, args);
        }

        public void AssertEqual<T>(T expected, T actual, string format = "", params object[] args)
        {
            Assert.AreEqual(expected,actual,format,args);
        }

        public void AssertEqual<T>(T expected, T actual, Func<T, T, bool> comparer, string format = "", params object[] args)
        {
            if(!comparer(expected, actual))
                throw new AssertFailedException(string.Format("Assert.AreEqual failed. Expected [{0}]. Actual [{1}]. {2}", FormatValue(expected), FormatValue(actual), string.Format(format,args)));
        }

        public Exception AssertThrows(Action action)
        {
            return Assert.Throws<Exception>(action);
        }

        public TException AssertThrows<TException>(Action action) where TException : Exception
        {
            return Assert.ThrowsExactly<TException>(action);
        }

        public Task<Exception> AssertThrowsAsync(Func<Task> action)
        {
            return Assert.ThrowsAsync<Exception>(action);
        }

        public Task<TException> AssertThrowsAsync<TException>(Func<Task> action) where TException : Exception
        {
            return Assert.ThrowsExactlyAsync<TException>(action);
        }

        private static string FormatValue<T>(T expected)
        {
            return ReferenceEquals(expected, null) ? "null" : expected.ToString();
        }

    }
}

