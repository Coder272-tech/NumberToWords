# NumberToWords

This is solution for Spinutech coding assessment.

Problem statement:

Pick one of the exercises below and build a Visual Studio solution
using ASP.NET MVC on .NET Core with a web front-end to solve it.

------------
-Exercise 1-
------------
Write some code that will accept an amount and convert it to the
appropriate string representation.
Example:
Convert 2523.04
to "Two thousand five hundred twenty-three and 04/100
dollars"


## Project Overview

**NumberToWords** is a .NET application that converts numeric values into their corresponding word representations. This solution is designed to provide an easy-to-use and extendable library for handling number-to-word conversions, ideal for a variety of applications like check printing, automated invoicing, or similar systems that require human-readable number outputs.

## Features

- **Converts numbers to words**: Supports conversion of numeric values to their word equivalents.
- **Modular library**: The conversion logic is contained in a separate library (`NumberToWordsLib`) to allow for easy integration into other applications.
- **Unit tests included**: Comprehensive unit tests for the conversion logic are included in the `NumberToWordsLibTests` project.
- **Logging**: Nlog for logging. 

## Prerequisites

- .NET 8 SDK or later
- Visual Studio 2022 for development and debugging

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/NumberToWords.git
   ```
   
NumberToWords is the MVC application