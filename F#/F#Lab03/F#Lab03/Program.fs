let lista1 = [1; 3; 6; 7];;
// pusta lista
let lista2 =[];;
//generowanie listy
let lista3 = [1..10];;
let lista3B = [1..2..10];;
//generowanie listy z for
let lista4 = [for i in 1..10 -> i*i];;
//dodawanie elementu na początku listy
let lista5 = 0 :: lista4;;
//dodawanie na końcu listy
let lista6 = lista4 @ [1000];;
//łączenie list
let lista7 = lista1 @ lista3
//właściwości list
//długość listy
printfn "dlugosc listy = %d " lista7.Length;;
//pierwszy element
printfn "Pierwszy element = %d" lista7.Head;;
//Wszystkie elementy z wyjątkiem pierwszego
printfn "Wszystkie oprócz pierwszego = %A" lista7.Tail;;
//Element o określonym indeksie
printfn "o indeksie 7  zapis1 = %d, zapis2 = %d, zapis3 = %d" (lista7.Item(7)) (List.item 7 lista7) lista7.[7];;
//Mapowanie list
let lista8 =List.map (fun x -> x*x) lista7;;
printfn "lista po zmapowaniu = %A" lista8;;
//Filter list
let lista9 = List.filter (fun x -> x%2=0) lista7;;
printfn "lista po filtrowaniu = %A" lista9;;
//Printowanie listy
List.iter(fun x -> printfn "element listy to: %d" x) lista7

//Rekurencyjna suma elementów
let rec suma list =
    match list with
        | head :: tail -> head + suma tail
        | [] -> 0
printfn "suma liczb w lista7 to %d" (suma lista7)

//Generowanie list funkcją
let rec genListFib (a:int, b:int, n:int) =
    if a+b < n then
        a+b :: genListFib(b, a+b, n)
    else
        [];;
let listaFib (n:int) =
    0:: 1 :: genListFib(0,1,n);;
printfn "Lista fibbonaciego do 400 = %A" (listaFib 400)

let rec genListFib2 (a:int, b:int, n:int) =
    let current = a + b
    match current with
        | _ when current >= n -> []
        | _ -> current :: genListFib2(b,current,n);;
printfn "List fibbonaciego do 400 = %A" (0::1::genListFib2(0,1,400))

//ZADANIA
//dana jest lista 
let lista = [5..5..50];;
//wygeneruj taką samą liste za pomocą funkcji rekurencyjnej
let rec zad1 (start:int, skok:int, koniec:int) =
    if start > koniec then []
    else start :: zad1 (start + skok, skok, koniec)
printfn "Wygenerowania lista rekurencyjnie: %A" (zad1(5,5,50))

//Funkcja która zwróci n-ty element listy
let rec zad2 (list: int list, element:int) =
    match list with
        | head::tail when element > 0 -> zad2(tail, element-1)
        | head::tail when element = 0 -> head
        | _ -> int(nan)
printfn "N-ty element listy rekurencyjnie: %A" (zad2( lista7, 5))

//Funckja określająca czy element znajduje się na liście
let rec zad3 (list :int list, elementValue:int) =
    match list with
        | head::tail when head=elementValue -> true
        | head::tail -> zad3(tail, elementValue)
        | _ -> false
printfn "Czy element n na liście: %b" (zad3(lista7,5))

//szukanie indeksu elementu
let rec zad4 (list, elementValue:int, elementIndex:int) =
    match list with
        |head::tail when head = elementValue -> elementIndex
        |head::tail -> zad4(tail,elementValue,elementIndex+1)
        | _ -> -1
let zad4Help (list, elementValue:int) =
    let index = 0
    zad4(list, elementValue, index)
printfn "Indeks elementu to = %d" (zad4Help(lista7, 10))

//Usuwanie elementu
let rec zad5 (list, elementIndex:int) =
    match list with
        |head::tail when elementIndex>0 -> head::zad5(tail,elementIndex-1)
        |head::tail when elementIndex=0 -> tail
        | _ -> []
printfn "usunięcie elementu: %A" (zad5(lista7, 13))

//Indeksy wyszukiwanego elementu
let rec zad6 (list: int list, elementValue:int, elementIndex:int) =
    match list with
        | head::tail when head=elementValue -> elementIndex::zad6(tail,elementValue, elementIndex+1)
        | head::tail -> zad6(tail,elementValue,elementIndex+1)
        | _ -> []
let rec zad6Help(list:int list, elementValue:int) =
    let index = 0
    zad6(list,elementValue,index)
printfn "Dany element jest w miejscach: %A" (zad6Help(lista7,6))