# Project Euler Solutions

This project contains my solutions to the first 70 or so Project Euler problems written in C#.

Project runs a basic console application where the user can enter the number of any problem.

Upon entering the problem number the description of that problem is printed then my implementation of that problem is called and the answer is calculated and printed.

I use reflection and linq to grab all classes that implement my IEulerProblem interface (done in UserInterface.cs). This keeps things extremely simple as I don't have to maintain a list of problems or modify anything when I add new solutions to the project.
