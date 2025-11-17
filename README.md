# Górski Hotel — README

## Opis problemu

W alpejskiej miejscowości działa niewielki hotel posiadający **dwa apartamenty**. Przyjmuje on liczne rezerwacje na pobyt w określonych przedziałach czasowych. Każdy klient deklaruje:

- dzień rozpoczęcia pobytu `p`,
- dzień zakończenia pobytu `k`,
- oferowaną zapłatę `z`.

Hotel sam decyduje, które rezerwacje przyjąć, aby **zmaksymalizować zysk**.

Ograniczenia:

- Jedna rezerwacja dotyczy zawsze jednego apartamentu.
- Dwóch rezerwacji nie można przypisać do tego samego apartamentu, jeśli ich terminy na siebie nachodzą.
- Jeśli rezerwacja kończy się danego dnia, kolejna może zaczynać się w tym samym dniu.
- Hotel ma dokładnie **dwa apartamenty**.

Celem jest wybranie takiego zestawu rezerwacji i przypisanie ich do apartamentów, aby suma zysków była jak największa.

## Wejście

1. W pierwszej linii:
n (1 <= n < 300)


2. Następnie `n` linii w formacie:
p k z

gdzie:
- `p` — dzień początku rezerwacji (1 ≤ p ≤ 300),
- `k` — dzień końca rezerwacji (p < k ≤ 300),
- `z` — zysk z rezerwacji (1 ≤ z ≤ 1000)

Na wejściu nie ma dwóch rezerwacji kończących się tego samego dnia.

## Wyjście

Wypisz jedną liczbę całkowitą — **maksymalny możliwy zysk**, który hotel może uzyskać.

## Przykład

**Wejście:**\
5\
9 11 2\
1  5 4\
1  8 7\
5  9 4\
6 10 5 

**Wyjście:**
18


## Wersja uproszczona (60%)

- dostępny jest tylko **1 apartament**
- mogą istnieć rezerwacje kończące się tego samego dnia
