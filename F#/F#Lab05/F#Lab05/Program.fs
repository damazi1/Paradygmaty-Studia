let lista1 = [1..10]

//Funkcje wyższych rzędów
let rec suma list = 
    match list with
        | head::tail -> head + suma tail
        | [] -> 0

let rec iloczyn list =
    match list with
        | head::tail -> head*iloczyn tail
        | [] -> 1

printfn "Suma = %d, Iloczyn = %d" (suma lista1) (iloczyn lista1)

let agregacja agregat wynik lista =
    let rec suma wynik lista =
        match lista with
            | head::tail -> agregat head (suma wynik tail)
            | [] -> wynik
    suma wynik lista

let add a b = a+b
let mul a b = a*b

let wynik1 = agregacja add 0 lista1
let wynik2 = agregacja mul 1 lista1
printfn "agregacja add = %d, Iloczy = %d" wynik1 wynik2

//wywołanie z funkcją anonimową
let wynik3 = agregacja (fun a b -> a+b) 0 lista1 

//ZADANIA
//Napisz funkcje naszMap, która będzie dokonywała dowolnego mapowania listy
let naszMap agregat lista = 
    let rec mapuj lista =
        match lista with
            | head::tail -> agregat head :: mapuj(tail)
            | _ -> []
    mapuj lista

let wynik4 = naszMap (fun a -> a*a) lista1
let wynik5 = naszMap (fun a -> a*5) lista1
printfn "Lista po mapowaniu: %A" wynik4
printfn "Lista po mapowaniu: %A" wynik5

//Napisz funkcję, która pozwoli na dowolną agregację elementów zapisanych w drzewie
type tree =
    | End
    | Node of int*tree*tree

let myTree = Node(1,Node(2,End,End),Node(3,Node(4,End,End),End))

let agregacjaTree agregat wynik tree =
    let rec dzialanie tree =
        match tree with
            | End -> wynik
            | Node(value,right,left) -> agregat value (agregat (dzialanie right) (dzialanie left))
    dzialanie tree

let wynik6 = agregacjaTree (fun a b-> a+b) 0 myTree
let wynik7 = agregacjaTree (fun a b-> a*b) 1 myTree
printfn "Agregacja drzewa add: %d, mul: %d" wynik6 wynik7

//Napisz funkcje, która sprawdzi czy w drzewie umieszczono wartość spełniającą warunek przekazany jako parametr
let warunekTree warunek tree =
    let rec sprawdz tree =
        match tree with
            | End -> false
            | Node(value,right,left) when warunek value -> warunek value
            | Node(value, right,left) -> sprawdz left || sprawdz right
    sprawdz tree

let wynik8 = warunekTree (fun x -> x >=5) myTree
printfn "Warunek: %b" wynik8