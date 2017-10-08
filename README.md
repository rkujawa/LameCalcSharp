LameCalcSharp
=============

This is a rewrite of a simple project I did in college circa 2006. The original source was lost, so here I am trying to implement a calculator exactly the same way I did back then (I more or less remember that lol). So this is not trying to be a correct implementation, merely nostalgic.

To build using Mono C# compiler, use:
```
mcs -pkg:glade-sharp-2.0 -resource:calc.glade calc.cs
```

Then, resulting binary can be run with Mono using:
```
mono calc.exe
```

