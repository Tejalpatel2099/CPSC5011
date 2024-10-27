// AUTHOR:- TEJAL PATEL 
// FILE:- FormulaTest.cs
// Date:- 10/09/2024

using NUnit.Framework;
using System;
using P1;

namespace P1App.Test
{
    [TestFixture]
    public class FormulaTest
    {
        [Test]
        public void Constructor_InitializePropertiesCorrectly()
        {
            string inputM = "iron ore";
            string outputM = "iron bar";
            int inputN = 2;
            int outputN = 1;
            Formula formulaTest = new Formula(inputM, inputN, outputM, outputN);
           

           // Assert that all properties are initialized correctly using the provided inputs. 
            Assert.That(formulaTest.QueryInputMaterial(), Is.EqualTo(inputM));
            Assert.That(formulaTest.QueryInputNumber(), Is.EqualTo(inputN));
            Assert.That(formulaTest.QueryOutputMaterial(), Is.EqualTo(outputM));
            Assert.That(formulaTest.QueryOutputNumber(), Is.EqualTo(outputN));

        }

        [Test]
        public void Constructor_InvalidEmptyInputM()
        {
            string inputM = " ";
            string outputM = "iron bar";
            int inputN = 2;
            int outputN = 1;

        // Should throw an exception for invalid empty input material. 
            Assert.Throws<ArgumentException>(() => new Formula(inputM, inputN, outputM, outputN));
        }


        
        [Test]
         public void Constructor_InvalidNullInputM()
        {
            string outputM = "iron bar";
            // string inputM = "iron bar";

            int inputN = 2;
            int outputN = 1;
        // Should throw an exception when input material is an empty string. 
            Assert.Throws<ArgumentException>(() => new Formula(string.Empty, inputN,outputM, outputN));
        }

         [Test]
         public void Constructor_InvalidNullOutputM()
        {
            string inputM = "iron ore";
            int inputN = 2;
            int outputN = 1;

        // Should throw an exception when output material is an empty string. 
            Assert.Throws<ArgumentException>(() => new Formula(inputM, inputN,string.Empty, outputN));
        }

        [Test]
        public void Constructor_InvalidEmptyOutputM()
        {
            string inputM = "iron ore";
            string outputM = " ";
            int inputN = 2;
            int outputN = 1;

        // Should throw an exception for invalid empty output material 
            Assert.Throws<ArgumentException>(() => new Formula(inputM, inputN, outputM, outputN));
        }

        [Test]
        public void Constructor_InvalidNegativeInputNumber()
        {
            string inputM = "iron ore";
            string outputM = "iron bar";
            int inputN = -2;
            int outputN = 1;
        
        // Should throw an exception for invalid negative inputNumber 
            Assert.Throws<ArgumentException>(() => new Formula(inputM, inputN, outputM, outputN));
        }

         [Test]
        public void Constructor_InvalidZeroInputNumber()
        {
            string inputM = "iron ore";
            string outputM = "iron bar";
            int inputN = 0;
            int outputN = 1; 

        // Should throw an exception for invalid zero inputNumber s
            Assert.Throws<ArgumentException>(() => new Formula(inputM, inputN, outputM, outputN));
        }

        [Test]
        public void QueryInputMaterial_ReturnCorrectly()
        {
            Formula formulaTest = new Formula("iron ore",2, "iron bar", 1);
            string result = formulaTest.QueryInputMaterial();
            // Should return "iron ore" as the input material.
            Assert.That(result, Is.EqualTo("iron ore")); 
        }
        
         [Test]
        public void QueryOutputMaterial_returnCorrectly()
        {
            Formula formulaTest = new Formula("iron ore",2,"iron bar",1);
            string result = formulaTest.QueryOutputMaterial();
            // Should return "iron bar" as output material 
            Assert.That(result, Is.EqualTo("iron bar"));
        }

         [Test]
        public void QueryInputNumber_returnCorrectly()
        {
            Formula formulaTest = new Formula("iron ore",2, "iron bar",1);
            int result = formulaTest.QueryInputNumber();
            Assert.That(result, Is.EqualTo(2));
        }

         [Test]
        public void QueryOutputNumber_returnCorrectly()
        {
            Formula formulaTest = new Formula("iron ore",2,"iron bar",1);
            int result = formulaTest.QueryOutputNumber();
            Assert.That(result, Is.EqualTo(1));
        }


        [Test]
        public void Apply_ValidOutput()
        {
            Formula formulaTest = new Formula("iron ore", 2, "iron bar", 1);
            int result = formulaTest.Apply(6);
            Assert.That(result, Is.GreaterThanOrEqualTo(0));
            Assert.That(result, Is.LessThanOrEqualTo(4));  // 6/ 2 + 1
        }
         [Test]
        public void Apply_InvalidInput()
        {
            Formula formulaTest = new Formula("iron ore", 2, "iron bar", 1);
            Assert.Throws<ArgumentException>(() => formulaTest.Apply(5)); // Not divisible by input number
        }
    }
}



// FormulaTest.cs 
// This file contains unit test for the formula class using NUnit. It validates Constructor Tests ensures that valid input/output materials and numbers are initialize correctly 
// and also invalid inputs throw the correct exceptions. Query Method Tests verify that the query methods return the correct values for input output materials and quantities. 
// Apply Method tests check that the apply method produces correct outputs based on probabilities and throws an exception for invalid inputs . 