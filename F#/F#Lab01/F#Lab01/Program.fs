//warunek (z if)
let x = 13
let wynik = 20 + if x > 12 then 10 else 0
printfn "Wynik = %d" wynik;;

//funkcja dodaj
let dodaj = fun a b -> a+b
let wynik2 = dodaj 2 3
printfn "wynik2 = %d" wynik2;;

//obwod kola
let promien = 12.0
let obwod = 2.0*System.Math.PI*promien
printfn "obwod = %f" obwod;;

//Pole kola
let PoleKola r = System.Math.PI*r*r
let wynik3 = PoleKola 1.0
printfn "pole = %f" wynik3;;

//silnia rekurencyjnie
let rec factorial n = if n<= 1 then 1 else n * factorial (n-1);;
let wynik4 = factorial 7;
printfn "silnia rekurencyjne = %d" wynik4;;

//suma liczb naturalnych
let rec naturalsum n = if n<=1 then 1 else n + naturalsum (n-1);;
let wynik5 = naturalsum 10;;
printfn "suma liczb naturalnych = %d" wynik5;;

//obliczenia x^n
let rec powOfN(x:int,n:int) = if n <= 1 then x else x * powOfN(x,n-1);
let wynik6 = powOfN(2,8);;
printfn "x^n = %d" wynik6;;

//n-ty ciąg fibbonaciego
let rec fibon(n:int) = 
    if n = 0 then 0 
        else if n=1 then 1 else
            fibon(n-1)+fibon(n-2);;
let wynik7 = fibon(19)
printfn "fibonacci = %d" wynik7;;