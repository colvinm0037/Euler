# Project Euler Solutions

This project contains my solutions to the first 70 or so Project Euler problems written in C#.

Project runs a basic console application where the user can enter the number of any problem.

Upon entering the problem number the description of that problem is printed then my implementation of that problem is called and the answer is calculated and printed.

I use reflection and linq to grab all classes that implement my IEulerProblem interface (done in UserInterface.cs). This keeps things extremely simple as I don't have to maintain a list of problems or modify anything when I add new solutions to the project.

I originally wrote these all as completely separate LinqPad files. The purpose of this project is to combine them all into an 
easy to maintain and consistent framework with a user interface that displays the description of each problem and then calls 
my code to calculate the solution for the problem.

TODO:
Finish implementing remaining questions to use new interface.
Add test cases to ensure that all problems are calculating the correct answer.
Pull commonly used methods like 'FindPrimes' out of problems and put in seperate methods for useful functions.
Ensure that problems which use a .txt file for data are working.
Some questions take a long time to run the algorithm, work on making these more effecient.
