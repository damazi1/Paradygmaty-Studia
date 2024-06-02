//typy

type Punkt = {
    X:float
    Y:float
    Kolor:string
}
let p1 = {X=10.0; Y=20.0; Kolor="czerwony"}
printfn "wspolrzedna X: %f, Y: %f" p1.X p1.Y
printfn "kolor to %s" p1.Kolor

//unia z dyskryminatorem
type Figura =
    | Prostokat of szerokosc:float*wysokosc:float
    | Okrag of float
    | Trojkat of szerokosc:float*wysokosc:float
    | Prostopadloscian of szerokosc:float*wysokosc:float*float

let kwadrat = Prostokat(12.0,12.0)
let prostokat = Prostokat(szerokosc=12,wysokosc=12)
let okrag = Okrag(12.0)
let trojkat = Trojkat(wysokosc=12.0, szerokosc=24.0)
let prostopadloscian = Prostopadloscian(12.0,24.0,12.0)

let wypisanieWlasciwosci figura = 
    match figura with
        | Okrag promien -> printfn "okr. o prom. %f" promien
        | Prostokat (szerokosc, wysokosc) -> printfn "Prostokąt o wymiatach %fx%f" szerokosc wysokosc
        | Trojkat (szerokosc, wysokosc) -> printfn "Trojkat o wymiarach %fx%f" szerokosc wysokosc
        | Prostopadloscian (szerokosc, wysokosc, dlugosc) -> printfn "Prostopadłościan o wymiarach %fx%fx%f" szerokosc wysokosc dlugosc
        | _ -> printfn "inna figura"
wypisanieWlasciwosci kwadrat
wypisanieWlasciwosci prostokat
wypisanieWlasciwosci okrag
wypisanieWlasciwosci trojkat
wypisanieWlasciwosci prostopadloscian

let wypisanieWlasciwosci1 = function 
        | Okrag promien -> printfn "okr. o prom. %f" promien
        | Prostokat (szerokosc, wysokosc) -> printfn "Prostokąt o wymiatach %fx%f" szerokosc wysokosc
        | Trojkat (szerokosc, wysokosc) -> printfn "Trojkat o wymiarach %fx%f" szerokosc wysokosc
        | Prostopadloscian (szerokosc, wysokosc, dlugosc) -> printfn "Prostopadłościan o wymiarach %fx%fx%f" szerokosc wysokosc dlugosc
        | _ -> printfn "inna figura"
wypisanieWlasciwosci1 kwadrat
wypisanieWlasciwosci1 prostokat
wypisanieWlasciwosci1 okrag
wypisanieWlasciwosci1 trojkat
wypisanieWlasciwosci1 prostopadloscian

let obliczPole = function
    | Okrag promien -> System.Math.PI*promien*promien
    | Prostokat (szerokosc, wysokosc) -> szerokosc*wysokosc
    | Trojkat (szerokosc, wysokosc) -> 1.0/2.0*wysokosc*szerokosc
    | Prostopadloscian (szerokosc, wysokosc, dlugosc) -> 2.0*szerokosc*wysokosc+2.0*szerokosc*dlugosc+2.0*wysokosc*dlugosc
    | _ -> 0.0
printfn "pole figury kwadrat: %f" (obliczPole kwadrat)
printfn "pole figury prostokat: %f" (obliczPole prostokat)
printfn "pole figury okrag: %f" (obliczPole okrag)
printfn "pole figury trojkat: %f" (obliczPole trojkat)
printfn "pole figury prostopadloscian: %f" (obliczPole prostopadloscian)

type pojazd =
    | Zaglowka of powZagla:float*opisDzialania:string
    | Samolot of liczbaMiejsc:int*liczSilnikow:int*opisDzialania:string
    | Samochod of liczbaMiejsc:int*opisDzialania:string
let lodka = Zaglowka(100.0, "plywanie")
let samolot = Samolot(200,2,"latanie")
let samochod = Samochod(5,"jazda")

let wlasciwosciPojazdu = function
    | Zaglowka (powZagla,opisDzialania) -> printfn "Zaglowka: %f / %s" powZagla opisDzialania
    | Samolot (liczbaMiejsc, liczSilnikow, opisDzialania) -> printfn "Samolot: %i / %i / %s" liczbaMiejsc liczSilnikow opisDzialania
    | Samochod (liczbaMiejsc, opisDzialania) -> printfn "Samochod: %i / %s" liczbaMiejsc opisDzialania
    | _ -> printfn "niezidentyfikowany pojazd"
wlasciwosciPojazdu lodka
wlasciwosciPojazdu samolot
wlasciwosciPojazdu samochod

//struktura danych typu drzewo
type Tree = 
    | End
    | Node of int * Tree * Tree

let myTree = Node(0,Node(1,Node(2,End,End),Node(3,End,End)),Node(4,End,End))

let rec sumTree tree = 
    match tree with
        | End -> 0
        | Node(value, left, right) -> value + sumTree (left) + sumTree (right)

printfn "Suma wartosci to: %d" (sumTree myTree)

//czy punkt znajduje się w okregu
let czyWOkregu (mid:Punkt, r:float, p:Punkt) =
    let szukana=(p.X-mid.X)*(p.X-mid.X)+(p.Y-mid.Y)*(p.Y-mid.Y)
    if(szukana<r*r) then printfn "znajduje sie"
    else printfn "nie znajduje sie"

let p2 = {X=10.0; Y=1.0; Kolor="czerwony"}
let p3 = {X=1.0; Y=2.0; Kolor="czerwony"}

czyWOkregu(p2,11.0,p3)