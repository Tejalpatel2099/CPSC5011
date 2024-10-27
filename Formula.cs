// AUTHOR:- TEJAL PATEL 
// FILE :- Formula.cs
// Date:- 10/09/2024
// Purpose:- This class stimulaes a formula that takes input materials and returns output materials.
// Each time formula is applied successfully, the user experience increases.
// When the experience reaches a certain specific value the proficiency level increments.
// The proficiency level affects the probilities of diffrent output results, such as failure, partial success, normal success and bonus success.



using System;
namespace P1 {
    public class Formula
{
        

        // class Invariants
        // 1) InputNumber and outnumber should be positive integers , they represnt quantities for formula input and output and also negative values are not logical. 
        // 2) Inputmaterial and outputmaterial should not be empty string , this ensure that the formula always has valid values of input and output material.
        // 3) The sum of failure, partial, normal and bonus probabilitites must always add uo to 100 ensuring valid outcome probabilitites.
        // 4) ExperienceNum must be non- negative and should not exceed maxExperience, ensuring experiemce remains within valid bonus.
        // 5) ProficiencyLevel and experienceNum are private and affect the outcome probabilities.
        // 6) maxExpereince and maxProficiency set the  upper limits for experience and proficiency.
        // 7) All class attributes are encapsulated, meaning they are private and can only be accessed through public methods. This protects the internal state from being modified directly.  

    private string inputMaterial;
    private int inputNumber;
    private string outputMaterial;
    private int outputNumber;

    private int proficiencyLevel;  // tracks the proficieny level of user 
    private int experienceNum;     // tracks current experience of user 
    private int failure;
    private int partial;
    private int normal;
    private int bonus;


    private static int maxExperience = 6;
    private static int maxProficiency = 2;
    // Random generator for simulating outcomes.
    private Random getRandomNumber = new Random(); 
    
    // Constructor
    // Initialize a formula object with valid input and output materials and quantities.
    // PreCondition :- inputMaterial and outputMaterial must not be empty, inputNumbewr and outputNumber must be positive integers.
    // PostCondition:- A valid formula object is created inputNumber, outputNumber, inputMaterial, outputMaterial and default probabilities.
    public Formula(string inputMaterial, int inputNumber, string outputMaterial, int outputNumber)
    {
        if (string.IsNullOrWhiteSpace(inputMaterial) || string.IsNullOrWhiteSpace(outputMaterial) ||
            inputNumber <= 0 || outputNumber <= 0)
        {
            throw new ArgumentException("Invalid input or output values.");
        }
        this.inputMaterial = inputMaterial;
        this.inputNumber = inputNumber;
        this.outputMaterial = outputMaterial;
        this.outputNumber = outputNumber;

        this.proficiencyLevel = 0;     // Starting proficiency level
        this.experienceNum = 0;       // Starting experience level
        this.failure = 30;           // 30% chance of failure 
        this.partial = 25;          // 25% chance of partial success
        this.normal =42;           // 42% chance of normal success
        this.bonus = 3;           // 3% chance of bonus success
    }

    // Query methods
    // Get inputMaterial 
    // precondition :- None 
    // postcondition :- returns inputMaterial value.
    public string QueryInputMaterial() => inputMaterial;

    // Get inputNumber
    // precondition:- None
    // postcondition:- returns inputMaterial value.
    public int QueryInputNumber() => inputNumber;

    // Get outputMaterial
    //precondition:- None
    // postcondition:- returns outputMaterial value.
    public string QueryOutputMaterial() => outputMaterial;

    //Get outputNumber
    //precondition:- None
    //postcondition:- returns outputNumber value.
    public int QueryOutputNumber() => outputNumber;

    


    // Method to increase user experience (experienceNum)
    //precondition:- None
    //postcondition:- experienceNum may be incremented 
    private void IncreaseExp()
    {
        if (experienceNum < maxExperience) 
        {
            experienceNum++;
            if (experienceNum == (int)(maxExperience / 3) || experienceNum == maxExperience)  
            {
                IncreaseLevel();
            }
        }
    }


    // method to increase proficiency level and adjust probailities 
    //precondition :- None
    // postcondition:- probabilities could be adjusted, proficiency level increases the chnace of success and reduce failure rates. 
    private void IncreaseLevel()
    {
        if (proficiencyLevel < maxProficiency) 
        {
            proficiencyLevel++;  // increase proficiency level 

            if (failure > 5) failure -= 5;
            else failure = 0;

            if (partial > 5) partial -= 5;
            else partial = 0;

            if (normal < 92) normal += 8;
            else normal = 100 - failure - partial - bonus;

            if (bonus < 10) bonus += 2;
            else bonus = 10;

            // ensure total probalities do not exceed 100% 
            if (failure + partial + normal + bonus > 100) 
            {
                bonus = 100 - (failure + partial + normal);
            }

        }
    }

    // Method to Simulate applying the formula 
    //precondition:- materialNum should be divisible by inputNumber and materialNum is non-negative integer 
    //postcondition:- Returns the number of output materials based on result 
    public int Apply(int materialNum)
    {
        // Validate the input material number
        if (materialNum % inputNumber != 0)
        {
            throw new ArgumentException("Your input is not valid.");
        }

        // Simulate proficiency using random percentage between 1 and 100
        int proficiency = getRandomNumber.Next(1, 101);

        // Case: Failure
        if (proficiency <= failure)
        {
            return 0;
        }

        // Case: Partial Output
        if (proficiency <= failure + partial)
        {
            IncreaseExp();
            return outputNumber * (materialNum / inputNumber) - 1;
        }

        // Case: Normal Output
        if (proficiency <= failure + partial + normal)
        {
            IncreaseExp();
            return outputNumber * (materialNum / inputNumber);
        }

        // Case: Bonus Output
        IncreaseExp();
        return outputNumber * (materialNum / inputNumber) + 1;
    }
}
}



// Implementation Invariants:-  
// Invariants:- a set of conditions that must be true for any object of a class,
// at any point in time. In object-oriented programming (OOP), class invariants are used to define the valid states of an object and to ensure that the object always remains in a valid state.

// 1) The increaseExperience method is responsible for incrementing experienceNum based on the use of formula.So it ensures that experience Num increases consistenly and remains within its defined bounds
// 2) The increseLevel method chnages the proficiency level and adjusts the probabilities failure, partial, normal, bonus. It ensures that the probabilities are updated while maintaining their total sum at 100%.
// 3) The apply method ensures that its argument which is materialNum is a multiple of inputNumber. If this condition is violtaed the method throws an Argumentexception to enforce this  
// 4) ExperienceNum is only increased when the formula successfully returns an output. The Apply method only calls inc
// 5) Increase Exp and IncreaseLevel are private methods to protect experienceNum and proficiency Level.
//    The client can influence these values by calling Apply, but cannot directly modify them.  
//     The client is not explicitly aware of existence of these attributes, but if needed public getter methods could be introduced in the future to provide access to these values.  




