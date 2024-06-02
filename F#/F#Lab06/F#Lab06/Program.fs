//Mapy w F#
let stanFloty = Map.ofList [ ("Mazda",2);("VW",7);("Audi",3)]
printfn "firma posiada %d sztuk pojazdów marki mazda" stanFloty.["Mazda"]
printfn "%A" stanFloty

//Dodawanie
let nowyStanFloty = Map.add "Ford" 4 stanFloty
printfn "%A" nowyStanFloty

let nowyStanFloty_2 = nowyStanFloty.Remove "Mazda"
printfn "%A" nowyStanFloty_2

let nowyStanFloty_3 = Map.remove "Audi" nowyStanFloty_2
printfn "%A" nowyStanFloty_3

//curring
let dodajLiczby x y z = x+y+z
let wynik1 = dodajLiczby 1 2 3
printfn "dodaj liczby = %d" wynik1

let wynik2 = dodajLiczby 1 2
let wynik3 = wynik2 5
printfn "Dodaj liczby curring = %d" wynik3

//Potok

let lista = [ ("Mazda",2);("VW",7);("Audi",3)]
let stanFloty1 = lista |> Map.ofList
printfn "firma posiada %d sztuk pojazdów marki mazda" stanFloty1.["Mazda"]
printfn "%A" stanFloty1

let add x y = x+y
let mul x y = x*y

let wynik4 = add 5 1
let wynik5 = mul wynik4 2
printfn "Wynik zwykły = %d" wynik5

let wynik6 = 5 |> add 1 |> mul 2
printfn "Wynik potokowy = %d" wynik6
