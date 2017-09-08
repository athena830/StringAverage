using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringAverageTest
{
    [TestClass]
    public class StringAverageTest
    {
        [TestMethod]
        public void Input_Empty_Should_Be_na()
        {
            AssertShouldBeAverageString("n/a", "");
        }

        [TestMethod]
        public void Input_One_Should_Be_One()
        {
            AssertShouldBeAverageString("one", "one");
        }

        [TestMethod]
        public void Input_Two_Should_Be_Two()
        {
            AssertShouldBeAverageString("two", "two");
        }

        [TestMethod]
        public void Input_OneOne_Should_Be_One()
        {
            AssertShouldBeAverageString("one", "one one");
        }

        [TestMethod]
        public void Input_OverNine_Should_Be_na()
        {
            AssertShouldBeAverageString("n/a", "five ten");
        }

        [TestMethod]
        public void Input_ZeroZeroZeroZeroZero_Should_Be_Zero()
        {
            AssertShouldBeAverageString("zero", "zero zero zero zero zero");
        }

        [TestMethod]
        public void Input_OneOneEightOne_Should_Be_Two()
        {
            AssertShouldBeAverageString("two", "one one eight one");
        }

        [TestMethod]
        public void Input_FourSixTwoThree_Should_Be_Three()
        {
            AssertShouldBeAverageString("three", "four six two three");
        }

        [TestMethod]
        public void Input_OneTwoThreeFourFive_Should_Be_Three()
        {
            AssertShouldBeAverageString("three", "one two three four five");
        }

        [TestMethod]
        public void Input_ZeroNineFiveTwo_Should_Be_Four()
        {
            AssertShouldBeAverageString("four", "zero nine five two");
        }

        private void AssertShouldBeAverageString(string expect, string input)
        {
            var kata=new Kata();
            Assert.AreEqual(expect, kata.AverageString(input));
        }
    }

    public class Kata
    {
        public string AverageString(string input)
        {
            var stringNumbers = new Dictionary<string, int>()
            {
                {"zero",0},
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };

            var inputStrings = input.Split(' ');

            if (inputStrings.Any(x => string.IsNullOrEmpty(x) || !stringNumbers.ContainsKey(x)))
            {
                return "n/a";
            }


            var sum=0;

            foreach (var stringKey in inputStrings)
            {
                sum += stringNumbers[stringKey];
            }

            var average = sum / inputStrings.Length;

            return stringNumbers.SingleOrDefault(x => x.Value == average).Key;
        }
    }
}
