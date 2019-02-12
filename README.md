# Spring-Thing

A mechanical spring calculator and design tool written in C#.

Intended for design of: Compression springs, Extension springs, Torsion springs

I've found most websites offering spring calculators to be extremely rudimentary and basically require you to know all the dimensions of the part beforehand.
  
This is a personal project to continue developing my C# coding skills and to use them to develop a commerically acceptable product suitable for use in an engineering environment. This code is offered as-is and I make no guarantees about the calculations accuracy or precision. If you're using this, at this stage, to design parts, shame on you. 

All equations and material properties are available from publically-available websites or textbooks. I have tried to cite the sources of material properties. 

Current features:
* compression springs
* US Customary and Metric units
* import/export from/to XML file

Features to come:
* Stress calculations
* Stress graph
* Rate window graph
* Drawing of spring
* Extension springs
* Torsion springs

Things I'm not adding right now:
* rectangular wire - the stress correction factors are just way too complicated and dull to digitize at the moment, with so many other features to add
