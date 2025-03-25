# Aplikacja ToDo 

# Opis zadania: 
Zadanie polega na napisaniu aplikacji pt. "Todo List"
## Założenia: 

* aplikacja typu web (ASP.NET) lub desktop (WPF) napisana w języku C# 
    - [x] Todo list  zrealizowana jako aplika desktopowa z użyciem WPF
* aplikacja do składowania informacji powinna wykorzystywać bazę danych i korzystać z technik mapowania obiektowo-relacyjnego (ORM)
    - [x] Zastosowano Entity Framework Core i zapis do lokalnej bazy MsSQL
* dodawanie/usuwanie/edycję zadań dla określonego dnia
    - [x] Dodanie możliwości dodawania zadań dla danego dnia, możliwość usuwania i edycję zadań zawartych w
    bazie danych
* zmianę dnia dla którego wyświetlane są zadania
    - [x] Dodano element wyboru daty i przycisk Show Task
* powiadomienia o zbliżających się zadaniach
    - [x] Przycisk ShowTask pokazuje zadania, ma zaimplementowany mechanizm sprawdzania tasków 
    zaplanowanych na bieżący dzień

## Instrukcja aplikacji: 
* Do uruchomienia aplikacji konieczne jest .NET 8 i MsSQL Server
* Przed uruchomieniem aplikacji konieczne jest utworzenie tabeli w bazie danych za pomocą komendy Update-Database
    * Visual Studio Tools -> Nuget Package Manager -> Package Manager Console -> Update-Database
* Poniżej przedstawiono grafikę na której ponumerowane są odpowiednie elementy aplikacji:
1. DatePicker do wybierania daty zadania jaka ma zostać dodana/ wyświetlona

2. Pole Name, gdzie ustawiana jest nazwa zadania, jakie chcemy dodać lub zaktualizować

3. Przycisk Add Task dodaje zadanie do bazy danych (dokonuje sprawdzenia czy jest coś wpisane w polu Name, jeśli nie dostajemy komunikat, 
że należy uzupełnić to pole). Po dodaniu zadania, pole jest aktualizowane

4. Przycisk ShowTasks pokazuje zadania dla wybranego dnia, dodatkowo sprawdza czy są zadania dla dnia bieżącego (podaje ilość)

5. Przycisk Delete usuwa dane zadanie, i wraca do widoku dla danego dnia (wybranego w DatePicker)

6. Przycisk Update aktualizuje nazwe zadania (sprawdzana czy pole Name jest uzupełnione), i wraca do widoku dla danego dnia (wybranego w DatePicker)

7. Pole wyświetlające datę zadania

8. Pole wyświetlające nazwę zadania

9. Znacznik ukończenia zadania 

10. Przycisk Show All Tasks (Dodatkowy przycisk pomocniczy) pokazuje wszystkie zadania dostępne w bazie

11. Przycisk Clear Panel, usuwający aktualnie wyświetlane zadania w panelu

![2](https://github.com/jacekk024/ToDoWpf/assets/45696277/bd8031d4-2f82-4644-9cf2-a485d4e41681)
* Poniżej przedstawiono wyświetlanie komunikatu o aktualnym stanie nadchodzących zadań (wyświetlana jest liczba nadchodzących zadań):
![1](https://github.com/jacekk024/ToDoWpf/assets/45696277/7470233d-e1a1-470a-b4ca-2db5d7cccc05)

