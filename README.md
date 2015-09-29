# Project Euler Solutions

This project contains my solutions to the first 70 or so Project Euler problems written in C#.

Project runs a basic console application where the user can enter the number of any problem.

Upon entering the problem number the description of that problem is printed then my implementation of that problem is called and the answer is calculated and printed.

I use reflection and linq to grab all classes that implement my IEulerProblem interface (done in UserInterface.cs). This keeps things extremely simple as I don't have to maintain a list of problems or modify anything when I add new solutions to the project.

I originally wrote these all as completely separate LinqPad files. The purpose of this project is to combine them all into an 
easy to maintain and consistent framework with a user interface that displays the description of each problem and then calls 
my code to calculate the solution for the problem.

######TODO:
1. Finish implementing remaining questions to use new interface.
2. Add test cases to ensure that all problems are calculating the correct answer.
3. Pull commonly used methods like 'FindPrimes' out of problems and put in seperate methods for useful functions.
4. Ensure that problems which use a .txt file for data are working.
4. Some questions take a long time to run the algorithm, work on making these more effecient.

######Notes on Project Euler:
Project Euler is a list of usually math related questions that are meant to be solved by writing a program in any language. 
The first few questions are easy and involve things like prime numbers and fibonacci series. Beyond there the questions become more complex and interesting. Typically there is a niave approach to the problem that will take a long time to run, 
the real trick is coming up with an effecient solution that will run quickly.

https://projecteuler.net/
