//dopasowanie do wzorca
let x = 2
let wynik = match x with
                | 1 -> "jeden"
                | 2 | 3 -> "dwa lub trzy"
                | _ -> "inna wartosc"

printfn "wynik = %s" wynik;;

let y = 106
let wynik1 = match y with
                | _ when y >= 100 -> 100
                | _ when y < 0  -> 0
                | _ -> y
printfn "wynik1 = %d" wynik1;;

//para
let para = (1, 'a');;
//zwracanie poprzez pary
let funkcja = 
    let a = 9
    let b = 3
    (a,b)
let wynik_a, wynik_b = funkcja
printfn "wynik2 = %d, %d" wynik_a wynik_b;;

let para1 = funkcja
let c = fst (para1)
let d = snd (para1)
printfn "wynik3 = %d, %d" c d

let dzielenie k l =
    let xx = k/l
    let yy = k%l
    (xx,yy);;
let wynik4_a, wynik4_b=dzielenie 5 2;;
printfn "dzielenie = %d, reszta = %d" wynik4_a wynik4_b;;