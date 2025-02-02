**DM42 Calculator Compiler**

**Introduction**

This compiler translates high-level languages programs into keystrokes
for the DM42 calculator. These programs will run on unmodified DM42
calculators -- no firmware flashing required. Most programs will also
run on the Free42 emulator provided they do not use any
unsupported DM42 extensions. Compiled programs make use of the DM42\'s
extended stack mode (NSTK). "Dynamic Stack Extension" should be enabled in the 
calculator's settings. 

**Examples**

The following examples illustrate the high-level language supported.

    program gcd()
    {
      var a = 36;
      var b = 24;
      while (a != b)
        if (a > b) a = a - b;
        else       b = b – a;
      return a;
    }

Computes the greatest common divisor (gcd) of two numbers using
Euclid\'s algorithm. The result is returned on the calculator's stack.

    program gcd_as_function()
    {
      var a = 36;
      var b = 24;
      func gcd()
      {
        while (a != b)
          if (a > b) a = a - b; 
          else       b = b - a;
        return a;
      }
      return gcd();
    }

Here gcd is defined as a function, which is then called by the main
program.

    program lcm_with_parameters(a, b)
    {
      func gcd(x, y)
      {
        while (x != y)
          if (x > y) x = x - y; 
          else       y = y - x;
        return x;
      }
      func lcm(x, y)
      {
        return x * (y / gcd(x, y));
      }
      return lcm(a, b);
    }

In this example gcd is defined as a function with two parameters, which
is then used by another function computing the lowest common multiple
(lcm) of two values. Here the main program itself has parameters which
are taken from the calculator's stack when the program is executed.

Programs can consume and return complex numbers\...

    program complex_test(a, b)
    {
      return complex(a^2, sin(b));
    }

\...and provide an easy way to define and manipulate matrices.

    program matrix_test(a, b, c)
    {
      var m1 = matrix(
                      [a^2, 1,   1  ], 
                      [1,   b^2, 1  ], 
                      [1,   1,   c^2]
                     );
      var m2 = matrix(
                      [1,  1,    c^3], 
                      [1,   b^3, 1  ], 
                      [a^3, 1,   1  ]
                     );
      return determinant(transpose(m1 * m2));
    }

Finally, here is a program to plot a graph of a function on the
calculator's screen.

    program plotter()
    {
      var x_max = recall("ResX") - 1;
      var y_max = recall("ResY") - 1;
      
      func f(x)
      {
       return (y_max / 2) * sin(8 * x);
      }
      
      func void plot()
      {
        var x0 = x_max / 2;
        var y0 = y_max / 2;
        v_line(x0);
        h_line(y0);
        for x = 0 to x_max do
        {
          var y = f(x - x0) + y0;
          if (y <= y_max) pixel(y_max - y, x);
        }
      } 
      degrees();
      plot();
    }
    
**System Requirements**

The executables require .Net Framework 3.5 to be installed. Your system
should prompt you and offer to do this if it is not present.

The sources are backwards compatible with VS 2008 and later versions should
be able to convert them. 